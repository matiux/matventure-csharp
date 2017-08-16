using System;
using Game1.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Character
{
    public abstract class Character : IGraph
    {
        protected Texture2D Texture { get; }
        protected int TextureRows { get; }
        protected int TextureColumns { get; }
        protected int CurrentFrame;
        protected DateTime Future;
        protected int CurrentPosX, CurrentPosY;
        
        protected int Direction;

        protected Character(Texture2D texture, int textureRows, int textureColumns)
        {
            Texture = texture;
            TextureRows = textureRows;
            TextureColumns = textureColumns;
            CurrentPosX = Game1.PgPosX;
            CurrentPosY = Game1.PgPosY;
            
            Future = DateTime.Now + TimeSpan.FromMilliseconds(200);
        }

        public abstract void Update();

        protected void ChangeFrame()
        {
            if (DateTime.Now < Future)
                return;
            
            Future = DateTime.Now + TimeSpan.FromMilliseconds(200);
            CurrentFrame++;
                
            if (CurrentFrame == TextureColumns)
                CurrentFrame = 0;
        }

        protected void MoveTo(int newDirection)
        {
            Direction = newDirection;
            
            CurrentPosX = Game1.PgPosX;
            CurrentPosY = Game1.PgPosY;

            ChangeFrame();
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            int singleFrameWidth = Texture.Width / TextureColumns;
            int singleFrameHeight = Texture.Height / TextureRows;
            
            Rectangle sourceRectangle = new Rectangle(singleFrameWidth * CurrentFrame, singleFrameHeight * Direction, singleFrameWidth, singleFrameHeight);
            Rectangle destinationRectangle = new Rectangle(Game1.WindowWidth / 2 - singleFrameWidth/2, Game1.WindowHeight / 2 - singleFrameHeight + 14 , singleFrameWidth, singleFrameHeight);
            
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}