using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MonoZenith;

public enum MouseButtons { Left, Middle, Right }

public partial class Game
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

    public Game(SpriteBatch s, GraphicsDeviceManager g, ContentManager content)
    {
        this._backgroundColor = new Color(0, 0, 0);
        this._spriteBatch = s;
        this._graphicsDeviceManager = g;
        this._screenDimensions = (300, 300);
        this._windowTitle = "MonoZenith";
        this._content = content;
    }

    public void DebugLog(string msg)
    {
        Console.WriteLine(msg);
    }
    
    public void SetBackgroundColor(Color c)
    {
        this._backgroundColor = c;
    }
    
    public void SetScreenSize(int w, int h)
    {
        this._screenDimensions = (w, h);
    }

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
        switch (button)
        {
            case MouseButtons.Left:
                return mouseState.LeftButton == ButtonState.Pressed;

            case MouseButtons.Middle:
                return mouseState.MiddleButton == ButtonState.Pressed;

            case MouseButtons.Right:
                return mouseState.RightButton == ButtonState.Pressed;
        }

        return false;
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

    public SpriteFont LoadFont(string font)
    {
        return _content.Load<SpriteFont>($"Fonts/{font}");
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
        FileStream fs = new FileStream($"Content/{filepath}", FileMode.Open);
        Texture2D spriteAtlas = Texture2D.FromStream(_graphicsDeviceManager.GraphicsDevice, fs);
        fs.Dispose();
        return spriteAtlas;
    }

    /* Source: https://www.industrian.net/tutorials/texture2d-and-drawing-sprites/ */
    public void DrawImage(Texture2D texture, Vector2 pos, float scale=1, float angle=0, bool flipped=false)
    {
        float rotationAngle = MathHelper.ToRadians(angle);

        // ReSharper disable PossibleLossOfFraction
        Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);

        // Flip image if needed
        var effect = SpriteEffects.None;
        if (flipped)
            effect = SpriteEffects.FlipHorizontally;

        _spriteBatch.Draw(texture, pos, null, Color.White, rotationAngle, origin, scale, effect, 0);
    }
    
    public void DrawRectangle(Color color, Vector2 pos, int width, int height)
    {
        Texture2D pixel = new Texture2D(_graphicsDeviceManager.GraphicsDevice, 1, 1);
        pixel.SetData<Color>(new Color[] { Color.White });
        Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, width, height);
        _spriteBatch.Draw(pixel, rect, color);
    }

    // TODO: This method still needs to be tested.
    public SoundEffectInstance LoadAudio(string filePath)
    {
        DebugLog(Directory.GetCurrentDirectory());
        if (File.Exists(filePath))
        {
            return SoundEffect.FromStream(TitleContainer.OpenStream(filePath)).CreateInstance();
        } 
        
        DebugLog($"Audio File {filePath} does not exist.");
        return null;

    }
}