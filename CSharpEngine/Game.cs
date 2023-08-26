using System;
using Microsoft.Xna.Framework;
namespace CSharpEngine;

public class Game
{
    private Color _backgroundColor;
    public Color BackgroundColor => this._backgroundColor;

    public Game()
    {
        this._backgroundColor = new Color(0, 0, 0);
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
    
    public void Init()
    {
        Console.WriteLine("Initializing");
    }
    
    public void Update(GameTime deltaTime)
    {
        Console.WriteLine("Updating");
    }
    
    public void Draw()
    {
        Console.WriteLine("Drawing");
    }
}