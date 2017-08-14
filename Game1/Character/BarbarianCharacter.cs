using System;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Character
{
    public class BarbarianCharacter : Character
    {
        private enum Directions : int
        {
            Down = 4,
            Left = 1,
            Right = 6,
            Up = 3,
            DownSx = 0,
            DownDx = 5,
            UpSx = 2,
            UpDx = 7
        };

        public BarbarianCharacter(Texture2D texture, int textureRows, int textureColumns) : base(texture, textureRows,
            textureColumns)
        {
            Direction = (int) Directions.Down;
            CurrentFrame = 0;
        }

        public override void Update()
        {
            //Console.WriteLine("Direction: {0}", Direction);

            if (Game1.PgPosX < CurrentPosX)
            {
                if (Game1.PgPosY < CurrentPosY)
                    MoveTo((int) Directions.Up);
                else if (Game1.PgPosY == CurrentPosY)
                    MoveTo((int) Directions.UpSx);
                else if (Game1.PgPosY > CurrentPosY)
                    MoveTo((int) Directions.Left);
            }
            else if (Game1.PgPosX > CurrentPosX)
            {
                if (Game1.PgPosY > CurrentPosY)
                    MoveTo((int) Directions.Down);
                else if (Game1.PgPosY == CurrentPosY)
                    MoveTo((int) Directions.DownDx);
                else if (Game1.PgPosY < CurrentPosY)
                    MoveTo((int) Directions.Right);
            }
            else if (Game1.PgPosX == CurrentPosX)
            {
                if (Game1.PgPosY < CurrentPosY)
                    MoveTo((int) Directions.UpDx);
                else if (Game1.PgPosY > CurrentPosY)
                    MoveTo((int) Directions.DownSx);
            }
        }
    }
}