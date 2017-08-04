using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Interface;

namespace Map
{
   public abstract class Map : IGraph
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

      protected int ScreenMezzoWidth, ScreenMezzoHeight,
                    MezzoTileWidth, MezzoTileHeight,
                    EspansioneDalCentroX, EspansioneDalCentroY;

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

         // Calcoliamo quanto è lungo mezzo tile per il movimento e dove si trova il centro dello schermo sull'asse X
         MezzoTileWidth = TileWidth / 2;
         ScreenMezzoWidth = ScreenWidth / 2 - MezzoTileWidth;

         // Calcoliamo quanto è alto mezzo tile per il movimento e dove si trova il centro dello schermo sull'asse Y
         MezzoTileHeight = TileHeight / 2;
         ScreenMezzoHeight = ScreenHeight / 2 - MezzoTileHeight;

         // Per ora li settiamo fissi a 5 poi li calcoleremo meglio
         EspansioneDalCentroX = 12;
         EspansioneDalCentroY = 12;
      }

      public virtual void Update()
      {

      }

      public abstract void Draw(SpriteBatch spriteBatch);
   }
}
