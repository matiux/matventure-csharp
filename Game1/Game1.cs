using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Map;

namespace TextureAtlas
{
   public class Game1 : Microsoft.Xna.Framework.Game
   {
      private const int windowWidth = 1360;
      private const int windowHeight = 768;

      GraphicsDeviceManager graphics;
      SpriteBatch spriteBatch;

      private World w;

      public Game1()
      {
         graphics = new GraphicsDeviceManager(this)
         {
            PreferredBackBufferWidth = windowWidth,
            PreferredBackBufferHeight = windowHeight,
            //IsFullScreen = fullscreen
         };

         Content.RootDirectory = "Content";
      }

      protected override void Initialize()
      {
         base.Initialize();
      }

      protected override void LoadContent()
      {
         spriteBatch = new SpriteBatch(GraphicsDevice);

         Texture2D groundTexture = Content.Load<Texture2D>("ground");

         //tileSprite = new TileSprite(groundTexture, 9, 9);

         w = new World(groundTexture, 9, 9, new int[]{
41,1,41,41,41,41,41,41,41,41,81,41,41,41,41,41,41,41,41,41,41, //20
25,48,60,52,78,81,41,41,41,41,81,81,41,41,41,41,41,41,41,41,41,//41
41,41,41,19,41,41,41,41,41,41,41,81,41,41,41,41,41,41,41,41,41,//62
41,81,81,81,81,41,41,41,41,41,41,81,41,41,41,41,41,41,41,41,41,//83
41,41,81,81,81,81,41,41,41,41,41,81,41,41,41,41,41,41,41,41,41,//104
41,41,81,81,81,81,81,81,41,41,41,81,81,41,41,41,41,41,41,41,41,//125
41,41,41,81,41,21,75,81,41,41,41,41,81,41,41,41,41,41,41,41,41,
41,41,41,41,41,41,19,81,41,41,41,41,81,81,41,41,41,41,41,41,41,
41,41,41,41,41,41,41,81,41,41,41,41,81,81,41,41,41,41,41,41,41,
41,41,41,41,41,41,81,81,41,41,41,41,81,41,41,41,41,41,41,41,41,
41,41,41,41,81,81,81,41,41,41,41,41,81,81,41,41,41,41,41,41,41,
41,41,81,81,81,41,41,41,41,41,41,41,41,81,41,41,41,41,41,41,41,
81,81,81,41,41,41,41,41,41,41,41,41,41,81,41,41,41,41,41,41,41,
41,41,41,41,41,41,41,41,41,41,41,41,81,81,81,81,41,41,41,41,41,
41,41,41,41,41,41,41,41,41,41,41,41,81,81,81,81,41,41,41,41,41,
41,41,41,41,41,41,41,41,41,41,41,41,81,81,81,81,81,81,41,41,41,
41,41,41,41,41,41,41,41,41,41,41,41,41,81,81,81,41,81,81,41,41,
41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,81,81,81,
41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,81,
41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,
41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41
         }, 21, 21, windowWidth, windowHeight, 1, 1);

      }

      protected override void UnloadContent()
      {
      }

      protected override void Update(GameTime gameTime)
      {
         // Allows the game to exit
         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();


         w.Update();
         base.Update(gameTime);
      }

      protected override void Draw(GameTime gameTime)
      {
         GraphicsDevice.Clear(Color.Black);
         spriteBatch.Begin();
         w.Draw(spriteBatch);
         spriteBatch.End();
         //tileSprite.Draw(spriteBatch, new Vector2(150, 200), 2);


         base.Draw(gameTime);
      }
   }
}
