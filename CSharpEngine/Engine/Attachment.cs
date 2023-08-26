using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSharpEngine;

public partial class Game
{
    private Color _backgroundColor;
    public Color BackgroundColor => this._backgroundColor;
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