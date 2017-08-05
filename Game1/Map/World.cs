using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Map
{
   public sealed class World : Map
   {
      public World(
         Texture2D texture,
         int textureRows, int textureColumns,
         string mapPath,
         int screenWidth, int screenHeight,
         int mapStartX, int mapStartY
      ) : base(texture, textureRows, textureColumns, mapPath, screenWidth, screenHeight, mapStartX, mapStartY)
      {
      }

      // public World(Texture2D texture) : base(texture, 1, 1)
      // {

      // }
      
      public override void Draw(SpriteBatch spriteBatch)
      {
         for (int incrementoY = -EspansioneDalCentroY; incrementoY <= EspansioneDalCentroY; incrementoY++)
         {
            if ((MapStartY+incrementoY) < 0 || (MapStartY+incrementoY) > MapHeight) { continue; }

            for (int incrementoX = -EspansioneDalCentroX; incrementoX <= EspansioneDalCentroX; incrementoX++)
            {
               if ((MapStartX+incrementoX) < 0 || (MapStartX+incrementoX) > MapWidth) { continue; }

               int tileInTexture = GetTileCode(incrementoX, incrementoY);
               int textureTileRow = (int)((float)tileInTexture / (float)TextureColumns);
               int textureTileColumn = tileInTexture % TextureColumns;

               Rectangle sourceRectangle = new Rectangle(TileWidth * textureTileColumn, TileHeight * textureTileRow, TileWidth, TileHeight);


               int posX = ScreenMezzoWidth + (incrementoX * MezzoTileWidth) - (incrementoY * MezzoTileWidth);
               int posY = ScreenMezzoHeight + (incrementoY * MezzoTileHeight) + (incrementoX * MezzoTileHeight);

               //Console.WriteLine(incrementoX + ", " + incrementoY + " | " + posX + ", " + posY);

               Rectangle destinationRectangle = new Rectangle(
                                 posX,
                                 posY,
                                 TileWidth, TileHeight
                              );

               spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
         }
      }
   }
}