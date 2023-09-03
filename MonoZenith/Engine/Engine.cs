using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoZenith
{
    public class Engine : Microsoft.Xna.Framework.Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameFacade _gameFacade;
        private Game _game;

        public Engine()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameFacade = new GameFacade(_spriteBatch, _graphics, Content);
            _game = new Game(_gameFacade);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _game.Init();

            // Change window properties
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = _game.ScreenWidth;
            _graphics.PreferredBackBufferHeight = _game.ScreenHeight;
            _graphics.ApplyChanges();
            Window.Title = _game.WindowTitle;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            
            _game.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_game.BackgroundColor);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            _game.Draw();
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}