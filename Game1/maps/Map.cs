using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Map
{
   public abstract class Map
   {
      protected int[] MapGrid { get; set; }

      protected int ScreenWidth { get; set; }
      protected int ScreenHeight { get; set; }

      private int textureColumns, textureRows;

      protected Texture2D Texture { get; private set; }

      protected int TileWidth { get; set; }
      protected int TileHeight { get; set; }

      protected int MapStartX { get; set; }
      protected int MapStartY { get; set; }
      protected int MapWidth { get; set; }

      protected int MapHeight { get; set; }

      protected int TextureColumns
      {
         get { return textureColumns; }
         private set
         {
            if (value < 0)
               value = 0;

            textureColumns = value;
         }
      }

      protected int TextureRows
      {
         get { return textureRows; }
         private set
         {
            if (value < 0)
               value = 0;

            textureRows = value;
         }
      }

      protected Map(
         Texture2D texture,
         int textureRows, int textureColumns,
         int[] mapGrid,
         int screenWidth, int screenHeight,
         int tileStartX, int tileStartY,
         int mapWidth, int mapHeight
      )
      {
         Texture = texture;
         TextureRows = textureRows;
         TextureColumns = textureColumns;
         MapGrid = mapGrid;
         ScreenWidth = screenWidth;
         ScreenHeight = screenHeight;
         MapStartX = tileStartX;
         MapStartY = tileStartY;
         MapWidth = mapWidth;
         MapHeight = mapHeight;

         TileWidth = texture.Width / TextureColumns;
         TileHeight = texture.Height / TextureRows;
      }

      public virtual void Update()
      {

      }

      public abstract void Draw(SpriteBatch spriteBatch);
   }
}
