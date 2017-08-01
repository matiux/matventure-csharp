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
         int espansioneDalCentro = 5;
      
         for (int tmpX = MapStartX - espansioneDalCentro; tmpX <= MapStartX + espansioneDalCentro; tmpX++)
         {
            if (tmpX < 0 || tmpX >= MapWidth)
            {
               continue;
            }

            int tileInTexture = MapGrid[MapWidth * MapStartY + tmpX] - 1; //x = 1, y = 0 -> indice 1 (texture 1)

            int textureTileRow = (int)((float)tileInTexture / (float)TextureColumns);
            int textureTileColumn = tileInTexture % TextureColumns;

            Rectangle sourceRectangle = new Rectangle(TileWidth * textureTileColumn, TileHeight * textureTileRow, TileWidth, TileHeight);

            int posX = (ScreenWidth / 2 - TileWidth / 2) + ((TileWidth / 2) * tmpX);
            int posY = (ScreenHeight / 2 - TileHeight / 2) + ((TileHeight / 2) * tmpX);

            Rectangle destinationRectangle = new Rectangle(
                              posX,
                              posY,
                              TileWidth, TileHeight
                           );

            Console.WriteLine(posX);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
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