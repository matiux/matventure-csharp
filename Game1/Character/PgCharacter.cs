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
        private int _currentPosX, _currentPosY;
        
        enum Directions : int {Down = 0, Left = 1, Right = 2, Up = 3};

        private int _direction;

        public PgCharacter(Texture2D texture, int textureRows, int textureColumns)
        {
            Texture = texture;
            TextureRows = textureRows;
            TextureColumns = textureColumns;
            _currentFrame = 0;
            _currentPosX = Game1.PgPosX;
            _currentPosY = Game1.PgPosY;
            _direction =  (int)Directions.Down;
            
            _future = DateTime.Now + TimeSpan.FromMilliseconds(200);
        }

        public void Update()
        {
            Console.WriteLine("Direction: {0}", _direction);

            if (Game1.PgPosX < _currentPosX && Game1.PgPosY < _currentPosY)
            {
                _direction = (int) Directions.Up;
                _currentPosX = Game1.PgPosX;
                _currentPosY = Game1.PgPosY;
                
                ChangeFrame();
            }
            else if(Game1.PgPosX > _currentPosX && Game1.PgPosY > _currentPosY)
            {
                _direction = (int) Directions.Down;
                _currentPosX = Game1.PgPosX;
                _currentPosY = Game1.PgPosY;
                
                ChangeFrame();
            }
            else if(Game1.PgPosX > _currentPosX && Game1.PgPosY < _currentPosY)
            {
                _direction = (int) Directions.Right;
                _currentPosX = Game1.PgPosX;
                _currentPosY = Game1.PgPosY;
                
                ChangeFrame();
            }
            else if(Game1.PgPosX < _currentPosX && Game1.PgPosY > _currentPosY)
            {
                _direction = (int) Directions.Left;
                _currentPosX = Game1.PgPosX;
                _currentPosY = Game1.PgPosY;
                
                ChangeFrame();
            }
        }

        private void ChangeFrame()
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
            
            Rectangle sourceRectangle = new Rectangle(singleFrameWidth * _currentFrame, singleFrameHeight * _direction, singleFrameWidth, singleFrameHeight);
            Rectangle destinationRectangle = new Rectangle(Game1.WindowWidth / 2 - singleFrameWidth/2, Game1.WindowHeight /2-singleFrameHeight , singleFrameWidth, singleFrameHeight);
            
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}