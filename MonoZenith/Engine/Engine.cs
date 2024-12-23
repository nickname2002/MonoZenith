﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Engine.Support;
using static MonoZenith.Game;

namespace MonoZenith.Engine
{
    public class Engine : Microsoft.Xna.Framework.Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameFacade _gameFacade;
        private float _splashScreenTimer = 3000;

        public Engine()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initialize the game.
        /// </summary>
        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameFacade = new GameFacade(_spriteBatch, _graphics, Content);
            Game.Initialize(_gameFacade);
            base.Initialize();
        }

        /// <summary>
        /// Load game content.
        /// </summary>
        protected override void LoadContent()
        {
            Init();
            Window.AllowUserResizing = ScreenResizable;

            // If full screen, set window size to screen size
            if (ScreenFullScreen)
            {
                SetScreenSize(
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            }
            
            // Change window properties
            _graphics.IsFullScreen = ScreenFullScreen;
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();
            Window.Title = WindowTitle;
            
            // Load content
            DataManager.GetInstance();
        }

        /// <summary>
        /// Handle controller support.
        /// </summary>
        private void HandleControllerSupport()
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            if (!capabilities.IsConnected)
                return;

            _gameFacade.ControllerConnected = true;

            Dictionary<Func<GamePadCapabilities, bool>, Action> capabilityMappings = 
                new Dictionary<Func<GamePadCapabilities, bool>, Action>
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
        
        /// <summary>
        /// Show splash screen.
        /// </summary>
        private void ShowSplashScreen()
        {
            Texture2D splashScreen = DataManager.GetInstance().MonoZenithLogo;
            float scale = (float)ScreenWidth / splashScreen.Width * 0.6f;
            scale += (1 - _splashScreenTimer / 3000) / 10;
            
            // Fade in slowly
            float alpha = 1;
            if (_splashScreenTimer > 2000)
            {
                alpha = 1 - (_splashScreenTimer - 2000) / 1000;
            }
            
            // Calculate splash screen position
            float x = ScreenWidth / 2f;
            float y = ScreenHeight / 2f;
            
            // Draw splash screen
            _spriteBatch.Draw(
                splashScreen, 
                new Vector2(x, y), 
                null, 
                new Color(Color.White, alpha), 
                0, 
                new Vector2(
                    splashScreen.Width / 2f, 
                    splashScreen.Height / 2f),
                scale,
                SpriteEffects.None,
                0);
        }
        
        /// <summary>
        /// Update the game.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            // Change window size accordingly when resizing
            if (Window.ClientBounds.Width != ScreenWidth || Window.ClientBounds.Height != ScreenHeight)
            {
                SetScreenSize(Window.ClientBounds.Width, Window.ClientBounds.Height);
            }
            
            // If splash screen is still showing, wait
            if (_splashScreenTimer > 0)
            {
                _splashScreenTimer -= gameTime.ElapsedGameTime.Milliseconds;
                return;
            }

            // Exit game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            HandleControllerSupport();
            MonoZenith.Game.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the game.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_splashScreenTimer > 0 ? Color.White : BackgroundColor);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            
            if (_splashScreenTimer > 0)
            {
                ShowSplashScreen();
                _spriteBatch.End();
                return;
            }
            
            MonoZenith.Game.Draw();
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}