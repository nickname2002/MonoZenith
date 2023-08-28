using System;
using System.IO;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

    /// <summary>
    /// Log a message to the console.
    /// </summary>
    /// <param name="msg">Message</param>
    public void DebugLog(string msg)
    {
        Console.WriteLine(msg);
    }
    
    /// <summary>
    /// Set the background color.
    /// </summary>
    /// <param name="c">Color</param>
    public void SetBackgroundColor(Color c)
    {
        this._backgroundColor = c;
    }
    
    /// <summary>
    /// Set the screen size.
    /// </summary>
    /// <param name="w">Width</param>
    /// <param name="h">Height</param>
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
    /// Load a font.
    /// </summary>
    /// <param name="font">Name of the font to be loaded.</param>
    /// <returns>The SpriteFont of the requested font.</returns>
    public SpriteFont LoadFont(string font)
    {
        return _content.Load<SpriteFont>($"Fonts/{font}");
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
        Vector2 origin = font.MeasureString(content) / 2;
        float rotationAngle = MathHelper.ToRadians(angle);
        _spriteBatch.DrawString(font, content, pos, c, rotationAngle, origin, scale, SpriteEffects.None, 0);
    }

    /* Source: https://community.monogame.net/t/loading-png-jpg-etc-directly/7403 */
    /// <summary>
    /// Load an image.
    /// </summary>
    /// <param name="filepath">Filepath</param>
    /// <returns>Texture of the requested image.</returns>
    public Texture2D LoadImage(string filepath)
    {
        FileStream fs = new FileStream($"Content/{filepath}", FileMode.Open);
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
        pixel.SetData<Color>(new Color[] { Color.White });
        Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, width, height);
        _spriteBatch.Draw(pixel, rect, color);
    }
}