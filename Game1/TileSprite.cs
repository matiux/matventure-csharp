using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TextureAtlas
{
   public class TileSprite
   {
      public Texture2D Texture { get; set; }
      public int Rows { get; set; }
      public int Columns { get; set; }

      public TileSprite(Texture2D texture, int rows, int columns)
      {
         Texture = texture;
         Rows = rows;
         Columns = columns;
      }

      public void Update()
      {

      }

      public void Draw(SpriteBatch spriteBatch, Vector2 location, int currentFrame)
      {
         int width = Texture.Width / Columns;
         int height = Texture.Height / Rows;
         int row = (int)((float)currentFrame / (float)Columns);
         int column = currentFrame % Columns;

         Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
         Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

         
         spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
         
      }
   }
}
