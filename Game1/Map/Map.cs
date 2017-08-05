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

               if (String.IsNullOrEmpty(tileCodeLine[tileCodeLine.Length - 1]))
               {
                  tileCodeLine = tileCodeLine.Reverse().Skip(1).Reverse().ToArray();
               }

               columns = columns < tileCodeLine.Length ? tileCodeLine.Length : columns;

               MapGrid.AddRange(tileCodeLine.ToList());
               rows++;
            }

            if (columns != rows)
            {
               // Come lancio un'eccezione?
            }
            
            MapHeight = rows;
            MapWidth = columns;
            
         }
         else
         {
            // Come lancio un'eccezione?
         }
      }
   }
}
