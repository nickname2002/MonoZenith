using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Components;
using SpriteFontPlus;

namespace MonoZenith.Engine;

public class GameFacade
{
    private Color _backgroundColor;
    private (int, int) _screenDimensions;
    private bool _screenResizable;
    private bool _screenFullScreen;
    private string _windowTitle;
    private readonly SpriteBatch _spriteBatch;
    private readonly GraphicsDeviceManager _graphicsDeviceManager;
    private readonly ContentManager _content;

    public Color BackgroundColor => this._backgroundColor;
    public int ScreenWidth => this._screenDimensions.Item1;
    public int ScreenHeight => this._screenDimensions.Item2;
    public bool ScreenResizable => this._screenResizable;
    public bool ScreenFullScreen => this._screenFullScreen;
    public string WindowTitle => this._windowTitle;
    
    public bool ControllerConnected { get; set; }
    public bool HasLeftStick { get; set; }
    public bool HasRightStick { get; set; }
    public bool HasDPad { get; set; }
    public bool HasLeftTrigger { get; set; }
    public bool HasRightTrigger { get; set; }
    public bool HasLeftBumper { get; set; }
    public bool HasRightBumper { get; set; }
    public bool HasAButton { get; set; }
    public bool HasBButton { get; set; }
    public bool HasXButton { get; set; }
    public bool HasYButton { get; set; }
    public bool HasStartButton { get; set; }
    public bool HasBackButton { get; set; }

    public GameFacade(SpriteBatch s, GraphicsDeviceManager g, ContentManager content)
    {
        this._backgroundColor = new Color(0, 0, 0);
        this._spriteBatch = s;
        this._graphicsDeviceManager = g;
        this._screenDimensions = (300, 300);
        this._screenResizable = false;
        this._screenFullScreen = false;
        this._windowTitle = "MonoZenith";
        this._content = content;
    }
    
    /// <summary>
    /// Set the background color.
    /// </summary>
    /// <param name="c">The background color.</param>
    public void SetBackgroundColor(Color c)
    {
        this._backgroundColor = c;
    }

    /// <summary>
    /// Set the screen size.
    /// </summary>
    /// <param name="w">Width of the screen.</param>
    /// <param name="h">Height of the screen.</param>
    public void SetScreenSize(int w, int h)
    {
        this._screenDimensions = (w, h);
    }
    
    /// <summary>
    /// Set whether the screen is resizable.
    /// </summary>
    /// <param name="resizable">Whether the screen is resizable.</param>
    public void SetScreenResizable(bool resizable)
    {
        this._screenResizable = resizable;
    }
    
    /// <summary>
    /// Set whether the screen is full screen.
    /// </summary>
    /// <param name="fullScreen">Whether the screen is full screen.</param>
    public void SetScreenFullScreen(bool fullScreen)
    {
        this._screenFullScreen = fullScreen;
    }
    
    /// <summary>
    /// Set the window title.
    /// </summary>
    /// <param name="t">The window title.</param>
    public void SetWindowTitle(string t)
    {
        this._windowTitle = t;
    }
    
    /// <summary>
    /// Get whether a keyboard key is pressed.
    /// </summary>
    /// <param name="key">The key that is checked.</param>
    /// <returns>Whether the provided key is pressed.</returns>
    public bool GetKeyDown(Keys key)
    {
        KeyboardState state = Keyboard.GetState();
        return state.IsKeyDown(key);
    }
    
    /// <summary>
    /// Get whether a mouse button is pressed.
    /// </summary>
    /// <param name="button">The button that is checked.</param>
    /// <returns>Whether a mouse button is pressed.</returns>
    public bool GetMouseButtonDown(MouseButtons button)
    {
        var mouseState = Mouse.GetState();
        return button switch
        {
            MouseButtons.Left => mouseState.LeftButton == ButtonState.Pressed,
            MouseButtons.Middle => mouseState.MiddleButton == ButtonState.Pressed,
            MouseButtons.Right => mouseState.RightButton == ButtonState.Pressed,
            _ => false
        };
    }
    
    /// <summary>
    /// Get the mouse position.
    /// </summary>
    /// <returns>Position of the mouse pointer.</returns>
    public Point GetMousePosition()
    {
        var mouseState = Mouse.GetState();
        return mouseState.Position;
    }
    
    /// <summary>
    /// Get the mouse wheel value.
    /// </summary>
    /// <returns>The value of the mouse wheel.</returns>
    public int GetMouseWheelValue()
    {
        var mouseSate = Mouse.GetState();
        return mouseSate.ScrollWheelValue;
    }
    
    /// <summary>
    /// Load a font from a file.
    /// </summary>
    /// <param name="filePath">File path to the font.</param>
    /// <param name="scale">Scale of the font.</param>
    /// <returns>The SpriteFont of the requested font.</returns>
    public SpriteFont LoadFont(string filePath, float scale)
    {
        string rootPath = Environment.CurrentDirectory;
        string correctedPath = $"{rootPath}/Content/" + filePath;
        var fontBakeResult = TtfFontBaker.Bake(File.ReadAllBytes(correctedPath),
            25 * scale,
            1024,
            1024,
            new[]
            {
                CharacterRange.BasicLatin,
                CharacterRange.Latin1Supplement,
                CharacterRange.LatinExtendedA,
                CharacterRange.Cyrillic
            }
        );

        return fontBakeResult.CreateSpriteFont(_graphicsDeviceManager.GraphicsDevice);
    }
    
    /// <summary>
    /// Draw text to the screen.
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="pos">Position</param>
    /// <param name="font">Font</param>
    /// <param name="c">Color</param>
    /// <param name="scale">Scale</param>
    /// <param name="angle">Rotational angle</param>
    public void DrawText(string content, Vector2 pos, SpriteFont font, Color c, float scale=1, float angle=0)
    {
        float rotationAngle = MathHelper.ToRadians(angle);
        _spriteBatch.DrawString(font, content, pos, c, rotationAngle, pos, scale, SpriteEffects.None, 0);
    }
    
    /* Source: https://community.monogame.net/t/loading-png-jpg-etc-directly/7403 */
    /// <summary>
    /// Load an image from a file.
    /// </summary>
    /// <param name="filepath">File path to the image.</param>
    /// <returns>The Texture2D of the requested image.</returns>
    public Texture2D LoadImage(string filepath)
    {
        string rootPath = Environment.CurrentDirectory;
        FileStream fs = new FileStream($"{rootPath}/Content/{filepath}", FileMode.Open);
        Texture2D spriteAtlas = Texture2D.FromStream(_graphicsDeviceManager.GraphicsDevice, fs);
        fs.Dispose();
        return spriteAtlas;
    }
    
    /* Source: https://www.industrian.net/tutorials/texture2d-and-drawing-sprites/ */
    /// <summary>
    /// Draw an image to the screen.
    /// </summary>
    /// <param name="texture">Image texture</param>
    /// <param name="pos">Position</param>
    /// <param name="scale">Scale</param>
    /// <param name="angle">Rotational angle</param>
    /// <param name="flipped">Horizontally flipped</param>
    /// <param name="alpha">Alpha</param>
    public void DrawImage(
        Texture2D texture, 
        Vector2 pos, 
        float scale=1, 
        float angle=0, 
        bool flipped=false, 
        float alpha=1.0f)
    {
        float rotationAngle = MathHelper.ToRadians(angle);
    
        // Flip image if needed
        var effect = SpriteEffects.None;
        if (flipped)
            effect = SpriteEffects.FlipHorizontally;
    
        _spriteBatch.Draw(
            texture, 
            pos, 
            null, 
            new Color(Color.White, alpha), 
            rotationAngle, 
            Vector2.Zero, scale, 
            effect, 0);
    }
    
    /// <summary>
    /// Draw a rectangle to the screen.
    /// </summary>
    /// <param name="color">Color</param>
    /// <param name="pos">Position</param>
    /// <param name="width">Width</param>
    /// <param name="height">Height</param>
    public void DrawRectangle(Color color, Vector2 pos, int width, int height)
    {
        Texture2D pixel = new Texture2D(_graphicsDeviceManager.GraphicsDevice, 1, 1);
        pixel.SetData(new[] { Color.White });
        Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, width, height);
        _spriteBatch.Draw(pixel, rect, color);
    }

    /// <summary>
    /// Load an audio file.
    /// </summary>
    /// <param name="filePath">Filepath to the audio file to be loaded.</param>
    /// <returns>SoundEffectInstance of the requested audio file.</returns>
    public SoundEffectInstance LoadAudio(string filePath)
    {
        // Get project root directory
        string rootPath = Environment.CurrentDirectory;
        using var stream = File.OpenRead($"{rootPath}/Content/" + filePath);
        var soundEffect = SoundEffect.FromStream(stream);
        return soundEffect.CreateInstance();
    }
}
