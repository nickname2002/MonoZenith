using System;
using Microsoft.Xna.Framework;

namespace MonoZenith;

public class Collider
{
    private readonly Game _game;
    private Vector2 _position;
    public int Width { get; }
    public int Height { get; }

    public Collider(Game g, Vector2 pos, int width, int height)
    {
        _game = g;
        _position = pos;
        Width = width;
        Height = height;
    }
    
    /* Check if this collider collides with another collider */
    public bool CollidesWith(Collider other)
    {
        return Math.Abs(_position.X - other._position.X) * 2 < (Width + other.Width) &&
               Math.Abs(_position.Y - other._position.Y) * 2 < (Height + other.Height);
    }
    
    /* Update the position of the collider */
    public void Update(Vector2 pos)
    {
        _position = pos;
    }
    
    public void Draw()
    {
        _game.DrawRectangle(Color.Red, _position, Width, Height);
    }
}