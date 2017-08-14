using System;
using System.Collections.Generic;
using Game1.Character;
using Game1.Interface;
using Game1.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
   public class Game1 : Microsoft.Xna.Framework.Game
   {
      public static int WindowWidth = 1360;
      public static int WindowHeight = 768;
      public static int TileWidth = 126;
      public static int TileHeight = 64;
      
      public static int PgPosX, PgPosY;
      
      private GraphicsDeviceManager _graphics;
      private SpriteBatch _spriteBatch;
      private World _m;
      private PgCharacter _pg;
      private List<IGraph> _scena;
      private DateTime _future;

      public Game1()
      {
         Console.WriteLine("Instanzio Game1");
         
         _graphics = new GraphicsDeviceManager(this) {
            PreferredBackBufferWidth = WindowWidth,
            PreferredBackBufferHeight = WindowHeight,
         };

         Content.RootDirectory = "Content";
      }

      protected override void Initialize()
      {
         Console.WriteLine("Initialize");

         PgPosX = 15;
         PgPosY = 16;
         
         _future = DateTime.Now + TimeSpan.FromMilliseconds(200);
         _spriteBatch = new SpriteBatch(GraphicsDevice);
         _scena = new List<IGraph>();
         
         base.Initialize();
      }

      protected override void LoadContent()
      {
         Console.WriteLine("Load content");
         
         Texture2D groundTexture = Content.Load<Texture2D>("ground");
         Texture2D pgTexture = Content.Load<Texture2D>("Characters/Sephiroth/sephiroth");
         
         _m = new World(groundTexture, 9, 9, "Content/maps/world.csv");
         _pg = new PgCharacter(pgTexture, 4, 4);
         
         _scena.Add(_m);
         _scena.Add(_pg);
      }

      protected override void UnloadContent()
      {
         Console.WriteLine("Unload content");
      }

      protected override void Update(GameTime gameTime)
      {
         //Console.WriteLine("Aggiorno il gioco");
         
         // Allows the game to exit
         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();

         UpdateKeyboard();

         foreach (IGraph igr in _scena)
         {
            igr?.Update();
         }

         base.Update(gameTime);
      }

      protected override void Draw(GameTime gameTime)
      {
         //Console.WriteLine("Disegno il gioco");
         
         GraphicsDevice.Clear(Color.Black);

         _spriteBatch.Begin();

         foreach (IGraph igr in _scena)
         {
            igr?.Draw(_spriteBatch);
         }
         
         _spriteBatch.End();


         base.Draw(gameTime);
      }

      private void UpdateKeyboard()
      {
         KeyboardState keyboardState = Keyboard.GetState();

         if (keyboardState.IsKeyDown(Keys.Escape))
            Uscita();

         if (DateTime.Now < _future)
            return;

         _future = DateTime.Now + TimeSpan.FromMilliseconds(100);

         if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
         {
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
               if (PgPosY - 1 >= 0)
               {
                  PgPosY--;
               }
            }
            else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
               if (PgPosX - 1 >= 0)
               {
                  PgPosX--;
               }
            }
            else
            {
               if (PgPosX - 1 >= 0 && PgPosY - 1 >= 0)
               {
                  PgPosY--;
                  PgPosX--;
               }
            }
         }
         else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
         {
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
               if (PgPosX + 1 < 41)
               {
                  PgPosX++;
               }
            }
            else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
               if (PgPosY + 1 < 41)
               {
                  PgPosY++;
               }
            }
            else
            {
               if (PgPosX + 1 < 41 && PgPosY + 2 <= 41)
               {
                  PgPosY++;
                  PgPosX++;
               }
            }
         } else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
         {
            if (PgPosX + 1 < 41 && PgPosY - 1 >= 0)
            {
               PgPosY--;
               PgPosX++;
            }
         }
         else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
         {
            if (PgPosX - 1 >= 0 && PgPosY + 1 < 41)
            {
               PgPosY++;
               PgPosX--;               
            }
            

         }
        
      }

      public void Uscita()
      {
         Console.WriteLine("Chiusura in corso...");

         EndRun();
         Exit();
      }
   }
}
