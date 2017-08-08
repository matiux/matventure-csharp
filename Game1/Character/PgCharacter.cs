using System;
using Game1.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Character
{
    public class PgCharacter : IGraph
    {
        private Texture2D Texture { get; }
        private int TextureRows { get; }
        private int TextureColumns { get; }
        private int _currentFrame;
        private DateTime _future;

        public PgCharacter(Texture2D texture, int textureRows, int textureColumns)
        {
            Texture = texture;
            TextureRows = textureRows;
            TextureColumns = textureColumns;
            _currentFrame = 0;
            
            _future = DateTime.Now + TimeSpan.FromMilliseconds(200);
        }

        public void Update()
        {
            if (DateTime.Now >= _future)
            {
                _future = DateTime.Now + TimeSpan.FromMilliseconds(200);
                _currentFrame++;
                
                if (_currentFrame == 4)
                {
                    _currentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int singleFrameWidth = Texture.Width / TextureColumns;
            int singleFrameHeight = Texture.Height / TextureRows;
            
            Rectangle sourceRectangle = new Rectangle(singleFrameWidth * _currentFrame, singleFrameHeight * 0, singleFrameWidth, singleFrameHeight);
            Rectangle destinationRectangle = new Rectangle(Game1.WindowWidth /2 - Game1.TileWidth/2, Game1.WindowHeight /2 - Game1.TileHeight/2, singleFrameWidth, singleFrameHeight);
            
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}