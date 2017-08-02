using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Map
{
   public sealed class World : Map
   {
      public World(
         Texture2D texture,
         int textureRows, int textureColumns,
         int[] mapGrid,
         int mapWidth, int mapHeight,
         int screenWidth, int screenHeight,
         int mapStartX, int mapStartY
      ) : base(texture, textureRows, textureColumns, mapGrid, screenWidth, screenHeight, mapStartX, mapStartY, mapWidth, mapHeight)
      {


         // this.screenWidth = screenWidth;
         // this.screenHeight = screenHeight;


      }

      // public World(Texture2D texture) : base(texture, 1, 1)
      // {

      // }

      public override void Draw(SpriteBatch spriteBatch)
      {
         for (int incrementoY = MapStartY - EspansioneDalCentroY; incrementoY <= MapStartY + EspansioneDalCentroY; incrementoY++)
         {
            if (incrementoY < 0 || incrementoY >= MapHeight) { continue; }

            for (int incrementoX = MapStartX - EspansioneDalCentroX; incrementoX <= MapStartX + EspansioneDalCentroY; incrementoX++)
            {
               if (incrementoX < 0 || incrementoX >= MapWidth) { continue; }

               int tileInTexture = MapGrid[MapWidth * incrementoY + incrementoX] - 1; //x = 1, y = 0 -> indice 1 (texture 1)

               int textureTileRow = (int)((float)tileInTexture / (float)TextureColumns);
               int textureTileColumn = tileInTexture % TextureColumns;

               Rectangle sourceRectangle = new Rectangle(TileWidth * textureTileColumn, TileHeight * textureTileRow, TileWidth, TileHeight);

               int posX = (ScreenMezzoWidth - MezzoTileWidth) + (incrementoX - MapStartX) * (TileWidth / 2);
               int posY = (ScreenMezzoHeight - MezzoTileHeight) + (incrementoX - MapStartY) * (TileHeight / 2);

               Console.WriteLine(posX);
               Console.WriteLine(posY);

               Rectangle destinationRectangle = new Rectangle(
                                 posX,
                                 posY,
                                 TileWidth, TileHeight
                              );

               spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
         }


         


















         // for (int y = 0; y < mapHeight; y++)
         // {
         //    for (int x = 0; x < mapWidth; x++)
         //    {
         //       int currentTile = map[x + y * mapWidth] - 1;

         //       int row = (int)((float)currentTile / (float)TextureColumns);
         //       int column = currentTile % TextureColumns;

         //       Rectangle sourceRectangle = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);
         //       Rectangle destinationRectangle = new Rectangle(
         //         // (schermoX / 2 - tileWidth / 2) + (tileWidth / 2) * i,
         //         // (schermoY / 2 - tileHeight / 2) + (tileHeight / 2) * i,
         //         -screenWidth / 2 + (tileWidth / 2) * x + tileWidth / 2 * y,
         //          screenHeight / 2 + (tileHeight / 2) * x - tileHeight / 2 * y,
         //          tileWidth, tileHeight
         //       );

         //       spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
         //    }
         // }
      }
   }
}