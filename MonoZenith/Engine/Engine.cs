using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Engine.Support;

namespace MonoZenith.Engine
{
    public class Engine : Microsoft.Xna.Framework.Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameFacade _gameFacade;
        private Game _game;
        private float _splashScreenTimer = 3000;

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
            
            // Load content
            DataManager.GetInstance(_game);
        }

        private void HandleControllerSupport()
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            if (!capabilities.IsConnected)
                return;

            _gameFacade.ControllerConnected = true;

            Dictionary<Func<GamePadCapabilities, bool>, Action> capabilityMappings = new Dictionary<Func<GamePadCapabilities, bool>, Action>
            {
                { cap => cap.HasLeftXThumbStick, () => _gameFacade.HasLeftStick = true },
                { cap => cap.HasRightXThumbStick, () => _gameFacade.HasRightStick = true },
                { cap => cap.HasDPadRightButton, () => _gameFacade.HasDPad = true },
                { cap => cap.HasRightTrigger, () => _gameFacade.HasRightTrigger = true },
                { cap => cap.HasLeftTrigger, () => _gameFacade.HasLeftTrigger = true },
                { cap => cap.HasLeftShoulderButton, () => _gameFacade.HasLeftBumper = true },
                { cap => cap.HasRightShoulderButton, () => _gameFacade.HasRightBumper = true },
                { cap => cap.HasAButton, () => _gameFacade.HasAButton = true },
                { cap => cap.HasBButton, () => _gameFacade.HasBButton = true },
                { cap => cap.HasXButton, () => _gameFacade.HasXButton = true },
                { cap => cap.HasYButton, () => _gameFacade.HasYButton = true },
                { cap => cap.HasStartButton, () => _gameFacade.HasStartButton = true },
                { cap => cap.HasBackButton, () => _gameFacade.HasBackButton = true }
            };

            foreach (var mapping in capabilityMappings.
                         Where(mapping => mapping.Key(capabilities)))
            {
                mapping.Value();
            }
        }
        
        private void ShowSplashScreen()
        {
            Texture2D splashScreen = DataManager.GetInstance(_game).MonoZenithLogo;
            float scale = (float)_game.ScreenWidth / splashScreen.Width * 0.6f;
            scale += (1 - _splashScreenTimer / 3000) / 10;
            
            // Fade in slowly
            float alpha = 1;
            if (_splashScreenTimer > 2000)
            {
                alpha = 1 - (_splashScreenTimer - 2000) / 1000;
            }
            
            // Draw splash screen
            _game.DrawImage(
                splashScreen, 
                new Vector2(_game.ScreenWidth / 2, _game.ScreenHeight / 2),
                scale,
                0, 
                false, 
                alpha);
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (_splashScreenTimer > 0)
            {
                _splashScreenTimer -= gameTime.ElapsedGameTime.Milliseconds;
                return;
            }
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            
            HandleControllerSupport();  
            _game.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_splashScreenTimer > 0 ? Color.White : _game.BackgroundColor);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            
            if (_splashScreenTimer > 0)
            {
                ShowSplashScreen();
                _spriteBatch.End();
                return;
            }
            
            _game.Draw();
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}