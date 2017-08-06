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
        private int _posX, _posY;
        private int _currentFrame, _frameWaiting;

        public PgCharacter(Texture2D texture, int textureRows, int textureColumns, int startPosX, int startPosY)
        {
            Texture = texture;
            TextureRows = textureRows;
            TextureColumns = textureColumns;
            _posX = startPosX;
            _posY = startPosY;
            _currentFrame = 0;
            _frameWaiting = 0;
        }

        public void Update()
        {
            _frameWaiting++;

            if (_frameWaiting == 10)
            {
                _frameWaiting = 0;
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
            Rectangle destinationRectangle = new Rectangle(_posX, _posY, singleFrameWidth, singleFrameHeight);
            
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}