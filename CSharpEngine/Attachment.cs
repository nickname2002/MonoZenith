using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSharpEngine;

public partial class Game
{
    // Members
    private Color _backgroundColor;
    private (int, int) _screenDimensions;

    // Properties
    public Color BackgroundColor => this._backgroundColor;
    public int ScreenWidth => this._screenDimensions.Item1;
    public int ScreenHeight => this._screenDimensions.Item2;
    private SpriteBatch _spriteBatch;

    public Game(SpriteBatch s)
    {
        this._backgroundColor = new Color(0, 0, 0);
        this._spriteBatch = s;
    }
    
    public void SetBackgroundColor(Color c)
    {
        this._backgroundColor = c;
    }
    
    public void SetScreenSize(int w, int h)
    {
        this._screenDimensions = (w, h);
    }

    public void LoadImage()
    {
        throw new NotImplementedException();
    }
    
    public void DrawImage()
    {
        throw new NotImplementedException();
    }
    
    public void DrawRectangle()
    {
        throw new NotImplementedException();
    }
}