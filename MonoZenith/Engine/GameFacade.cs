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
    // Members
    private Color _backgroundColor;
    private (int, int) _screenDimensions;
    private string _windowTitle;
    private readonly SpriteBatch _spriteBatch;
    private readonly GraphicsDeviceManager _graphicsDeviceManager;
    private readonly ContentManager _content;

    // Properties
    public Color BackgroundColor => this._backgroundColor;
    public int ScreenWidth => this._screenDimensions.Item1;
    public int ScreenHeight => this._screenDimensions.Item2;
    public string WindowTitle => this._windowTitle;
    
    // Controller support
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
        this._windowTitle = "MonoZenith";
        this._content = content;
    }
    
    public void SetBackgroundColor(Color c)
    {
        this._backgroundColor = c;
    }

    public void SetScreenSize(int w, int h)
    {
        this._screenDimensions = (w, h);
    }
    
    /// <summary>
    /// Set the window title.
    /// </summary>
    /// <param name="t">The window title.</param>
    public void SetWindowTitle(string t)
    {
        this._windowTitle = t;
    }
    
    public bool GetKeyDown(Keys key)
    {
        KeyboardState state = Keyboard.GetState();
        return state.IsKeyDown(key);
    }
    
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
    
    public Point GetMousePosition()
    {
        var mouseState = Mouse.GetState();
        return mouseState.Position;
    }
    
    public int GetMouseWheelValue()
    {
        var mouseSate = Mouse.GetState();
        return mouseSate.ScrollWheelValue;
    }
    
    public SpriteFont LoadFont(string filePath, int scale)
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
    
    public void DrawText(string content, Vector2 pos, SpriteFont font, Color c, float scale=1, float angle=0)
    {
        Vector2 origin = font.MeasureString(content) / 2;
        float rotationAngle = MathHelper.ToRadians(angle);
        _spriteBatch.DrawString(font, content, pos, c, rotationAngle, origin, scale, SpriteEffects.None, 0);
    }
    
    /* Source: https://community.monogame.net/t/loading-png-jpg-etc-directly/7403 */
    public Texture2D LoadImage(string filepath)
    {
        string rootPath = Environment.CurrentDirectory;
        FileStream fs = new FileStream($"{rootPath}/Content/{filepath}", FileMode.Open);
        Texture2D spriteAtlas = Texture2D.FromStream(_graphicsDeviceManager.GraphicsDevice, fs);
        fs.Dispose();
        return spriteAtlas;
    }
    
    /* Source: https://www.industrian.net/tutorials/texture2d-and-drawing-sprites/ */
    public void DrawImage(
        Texture2D texture, 
        Vector2 pos, 
        float scale=1, 
        float angle=0, 
        bool flipped=false, 
        float alpha=1.0f)
    {
        float rotationAngle = MathHelper.ToRadians(angle);
    
        // ReSharper disable PossibleLossOfFraction
        Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
    
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
            origin, scale, 
            effect, 0);
    }
    
    public void DrawRectangle(Color color, Vector2 pos, int width, int height)
    {
        Texture2D pixel = new Texture2D(_graphicsDeviceManager.GraphicsDevice, 1, 1);
        pixel.SetData(new[] { Color.White });
        Rectangle rect = new Rectangle((int)pos.X - width / 2, (int)pos.Y - height / 2, width, height);
        _spriteBatch.Draw(pixel, rect, color);
    }

    public SoundEffectInstance LoadAudio(string filePath)
    {
        // Get project root directory
        string rootPath = Environment.CurrentDirectory;
        using var stream = File.OpenRead($"{rootPath}/Content/" + filePath);
        var soundEffect = SoundEffect.FromStream(stream);
        return soundEffect.CreateInstance();
    }
}
