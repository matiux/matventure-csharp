using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Game1.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Map
{
   public class World : IGraph
   {
      protected string MapPath { get; set; }
      protected List<string> MapGrid;
      
      private int _textureColumns, _textureRows;

      protected Texture2D Texture { get; private set; }

      private readonly int  _tileWidth, _tileHeight;

      protected int MapStartX { get; set; }
      protected int MapStartY { get; set; }
      protected int MapWidth { get; set; }
      protected int MapHeight { get; set; }

      protected int ScreenMezzoWidth, ScreenMezzoHeight,
                    MezzoTileWidth, MezzoTileHeight,
                    EspansioneDalCentroX, EspansioneDalCentroY;

      protected int TextureColumns
      {
         get => _textureColumns;
         private set
         {
            if (value < 0)
               value = 0;

            _textureColumns = value;
         }
      }

      protected int TextureRows
      {
         get => _textureRows;
         private set
         {
            if (value < 0)
               value = 0;

            _textureRows = value;
         }
      }

      public World(Texture2D texture,int textureRows, int textureColumns, string mapPath)
      {
         Texture = texture;
         TextureRows = textureRows;
         TextureColumns = textureColumns;
         MapPath = mapPath;
         MapStartX = Game1.PgPosX;
         MapStartY = Game1.PgPosY;

         //_tileWidth = texture.Width / TextureColumns;
         //_tileHeight = texture.Height / TextureRows;
         _tileWidth = Game1.TileWidth;
         _tileHeight = Game1.TileHeight;

         // Calcoliamo quanto è lungo mezzo tile per il movimento e dove si trova il centro dello schermo sull'asse X
         MezzoTileWidth = _tileWidth / 2;
         ScreenMezzoWidth = Game1.WindowWidth / 2 - MezzoTileWidth;

         // Calcoliamo quanto è alto mezzo tile per il movimento e dove si trova il centro dello schermo sull'asse Y
         MezzoTileHeight = _tileHeight / 2;
         ScreenMezzoHeight = Game1.WindowHeight / 2 - MezzoTileHeight;

         // Per ora li settiamo fissi poi li calcoleremo meglio
         EspansioneDalCentroX = 12;
         EspansioneDalCentroY = 12;
         
         LoadMap();
      }

      public void Update()
      {
         if (MapStartX != Game1.PgPosX)
         {
            MapStartX = Game1.PgPosX;
         }
         
         if (MapStartY != Game1.PgPosY)
         {
            MapStartY = Game1.PgPosY;
         }
      }

      public void Draw(SpriteBatch spriteBatch)
      {       
         for (int incrementoY = -EspansioneDalCentroY; incrementoY <= EspansioneDalCentroY; incrementoY++)
         {
            if ((MapStartY+incrementoY) < 0 || (MapStartY+incrementoY) >= MapHeight) continue;

            for (int incrementoX = -EspansioneDalCentroX; incrementoX <= EspansioneDalCentroX; incrementoX++)
            {
               if ((MapStartX + incrementoX) < 0 || (MapStartX + incrementoX) >= MapWidth) continue;

               int tileInTexture = GetTileCode(incrementoX, incrementoY);
               int textureTileRow = (int)((float)tileInTexture / (float)TextureColumns);
               int textureTileColumn = tileInTexture % TextureColumns;

               int posX = ScreenMezzoWidth + (incrementoX * MezzoTileWidth) - (incrementoY * MezzoTileWidth);
               int posY = ScreenMezzoHeight + (incrementoY * MezzoTileHeight) + (incrementoX * MezzoTileHeight);
               
               //Console.WriteLine(incrementoX + ", " + incrementoY + " | " + posX + ", " + posY);
               
               Rectangle sourceRectangle = new Rectangle(_tileWidth * textureTileColumn, _tileHeight * textureTileRow, _tileWidth, _tileHeight);
               Rectangle destinationRectangle = new Rectangle(posX, posY, _tileWidth, _tileHeight);

               spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
         }
         
         //Console.WriteLine("--------------------------------");
      }

      protected int GetTileCode(int incrementoX, int incrementoY)
      {
         int tileInTexture;
         //Console.WriteLine("{0}, {1} - Index: {2} | MapStartX: {3}, MapStartY: {4}", incrementoX, incrementoY, MapWidth * (MapStartY + incrementoY) + (MapStartX + incrementoX), MapStartX, MapStartY);
         
         string tileInTextureString = MapGrid[MapWidth * (MapStartY + incrementoY) + (MapStartX + incrementoX)];

         if (Int32.TryParse(tileInTextureString, out tileInTexture))
            return --tileInTexture;
         
         throw new System.ArgumentException("Int32.TryParse could not parse '{0}' to an int.\n",
            tileInTextureString);
      }
      
      /**
       * In questo metodo potrebbe essere comodo un refactoring:
       * Invece di fare il cast delle stringhe orese dal csv in int, all'interno del metodo Draw si potrebbe aggiungere un ciclo qui
       * e castare TUTTA la mappa subito invece delle maop necessarie a riempire lo schermo nel metodo Draw. Questo perchè il metodo draw 
       * disegna 60 volte al secondo quindi per ogni frame fa il cast di X tile. Se invece si casta tutta la mappa qui, magari casta tante stringhe
       * subito, ma lo fa solo una volta 
       */
      protected void LoadMap()
      {
         Console.WriteLine("Carico la mappa");
         
         if (File.Exists(MapPath))
         {
            var reader = new StreamReader(MapPath);

            MapGrid = new List<string>();

            int rows = 0;
            int columns = 0;
            
            while (!reader.EndOfStream)
            {
               var line = reader.ReadLine();
               var tileCodeLine = line?.Trim().Split(',');

               var temp = tileCodeLine.ToList();
      
               if (String.IsNullOrEmpty(temp?[temp.Count - 1]))
               {                
                  temp.RemoveAt(temp.Count - 1);
               }

               columns = columns < temp.Count ? temp.Count : columns;

               MapGrid.AddRange(temp);
               rows++;
            }

            if (columns != rows)
               throw new System.ArgumentException("La mappa deve essere quadrata", $"Columns: {columns} - Rows: {rows}");
            
            MapHeight = rows;
            MapWidth = columns;
         }
         else
            throw new System.ArgumentException("Il file non esiste", MapPath);
      }
   }
}
