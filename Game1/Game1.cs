using System;
using System.Collections.Generic;
using Game1.Interface;
using Game1.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
   public class Game1 : Microsoft.Xna.Framework.Game
   {
      private const int WindowWidth = 1360;
      private const int WindowHeight = 768;
      private GraphicsDeviceManager _graphics;
      private SpriteBatch _spriteBatch;
      private World _w;
      private List<IGraph> _scena;
      private int _mapStartX, _mapStartY;
      
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

         _mapStartX = 29;
         _mapStartY = 15;
         
         _spriteBatch = new SpriteBatch(GraphicsDevice);
         _scena = new List<IGraph>();
         
         base.Initialize();
      }

      protected override void LoadContent()
      {
         Console.WriteLine("Load content");
         
         Texture2D groundTexture = Content.Load<Texture2D>("ground");
         
         _w = new World(groundTexture, 9, 9, "Content/maps/world.csv", screenWidth: WindowWidth, screenHeight: WindowHeight, mapStartX: _mapStartX, mapStartY: _mapStartY);
         _scena.Add(_w);
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

         if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
         {
            Console.WriteLine("Tasto W premuto");
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
