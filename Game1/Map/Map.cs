using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Game1.Interface;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Map
{
   public abstract class Map : IGraph
   {
      protected string MapPath { get; set; }
      protected List<string> MapGrid;
      
      protected int ScreenWidth { get; set; }
      protected int ScreenHeight { get; set; }

      private int _textureColumns, _textureRows;

      protected Texture2D Texture { get; private set; }

      protected int TileWidth { get; set; }
      protected int TileHeight { get; set; }

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

      protected Map(
         Texture2D texture,
         int textureRows, int textureColumns,
         string mapPath,
         int screenWidth, int screenHeight,
         int tileStartX, int tileStartY
      )
      {
         Texture = texture;
         TextureRows = textureRows;
         TextureColumns = textureColumns;
         MapPath = mapPath;
         ScreenWidth = screenWidth;
         ScreenHeight = screenHeight;
         MapStartX = tileStartX;
         MapStartY = tileStartY;

         TileWidth = texture.Width / TextureColumns;
         TileHeight = texture.Height / TextureRows;

         // Calcoliamo quanto è lungo mezzo tile per il movimento e dove si trova il centro dello schermo sull'asse X
         MezzoTileWidth = TileWidth / 2;
         ScreenMezzoWidth = ScreenWidth / 2 - MezzoTileWidth;

         // Calcoliamo quanto è alto mezzo tile per il movimento e dove si trova il centro dello schermo sull'asse Y
         MezzoTileHeight = TileHeight / 2;
         ScreenMezzoHeight = ScreenHeight / 2 - MezzoTileHeight;

         // Per ora li settiamo fissi a 5 poi li calcoleremo meglio
         EspansioneDalCentroX = 12;
         EspansioneDalCentroY = 12;
         
         LoadMap();
      }

      public virtual void Update()
      {

      }

      public abstract void Draw(SpriteBatch spriteBatch);

      protected int GetTileCode(int incrementoX, int incrementoY)
      {
         int tileInTexture;
         
         string tileInTextureString = MapGrid[MapWidth * (MapStartY + incrementoY) + (MapStartY + incrementoX)];

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
      protected virtual void LoadMap()
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
