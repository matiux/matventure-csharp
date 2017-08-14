using System;
using Game1.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Character
{
    public class PgCharacter : Character
    {
        private enum Directions : int {Down = 0, Left = 1, Right = 2, Up = 3};

        public PgCharacter(Texture2D texture, int textureRows, int textureColumns) : base(texture, textureRows, textureColumns)
        {
            Direction =  (int)Directions.Down;
            CurrentFrame = 0;
        }

        public override void Update()
        {
            //Console.WriteLine("Direction: {0}", Direction);

            if (Game1.PgPosX < CurrentPosX && Game1.PgPosY < CurrentPosY)
            {
                Direction = (int) Directions.Up;
                CurrentPosX = Game1.PgPosX;
                CurrentPosY = Game1.PgPosY;
                
                ChangeFrame();
            }
            else if(Game1.PgPosX > CurrentPosX && Game1.PgPosY > CurrentPosY)
            {
                Direction = (int) Directions.Down;
                CurrentPosX = Game1.PgPosX;
                CurrentPosY = Game1.PgPosY;
                
                ChangeFrame();
            }
            else if(Game1.PgPosX > CurrentPosX && Game1.PgPosY < CurrentPosY)
            {
                Direction = (int) Directions.Right;
                CurrentPosX = Game1.PgPosX;
                CurrentPosY = Game1.PgPosY;
                
                ChangeFrame();
            }
            else if(Game1.PgPosX < CurrentPosX && Game1.PgPosY > CurrentPosY)
            {
                Direction = (int) Directions.Left;
                CurrentPosX = Game1.PgPosX;
                CurrentPosY = Game1.PgPosY;
                
                ChangeFrame();
            }
        }
    }
}