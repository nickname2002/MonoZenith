using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSharpEngine;

public partial class Game
{
    // Members
    private Color _backgroundColor;
    private (int, int) _screenDimensions;
    private string _windowTitle;
    private readonly SpriteBatch _spriteBatch;
    private readonly GraphicsDeviceManager _graphicsDeviceManager;

    // Properties
    public Color BackgroundColor => this._backgroundColor;
    public int ScreenWidth => this._screenDimensions.Item1;
    public int ScreenHeight => this._screenDimensions.Item2;
    public string WindowTitle => this._windowTitle;

    public Game(SpriteBatch s, GraphicsDeviceManager g)
    {
        this._backgroundColor = new Color(0, 0, 0);
        this._spriteBatch = s;
        this._graphicsDeviceManager = g;
        this._screenDimensions = (300, 300);
        this._windowTitle = "C# Engine (title not final)";
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
    
    public void DrawRectangle()
    {
        throw new NotImplementedException();
    }
}