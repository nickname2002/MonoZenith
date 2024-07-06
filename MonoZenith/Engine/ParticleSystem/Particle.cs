using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoZenith;

public class Particle
{
    private Random _random;
    private readonly Game _game;
    private readonly Texture2D _texture;
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public Color Color { get; set; }
    public int Size { get; set; }
    public float Lifespan { get; set; }
    private float _startingLifespan;

    public Particle(
        Random r, 
        MonoZenith.Game g, 
        Texture2D texture, 
        Vector2 position, 
        Vector2 velocity, 
        Color color, 
        int size, 
        float lifespan)
    {
        _game = g;
        _texture = texture;
        _random = r;
        Position = position;
        Velocity = velocity;
        Color = color;
        Size = size;
        Lifespan = lifespan;
        _startingLifespan = lifespan;
    }
    
    /// <summary>
    /// Update the particle.
    /// </summary>
    /// <param name="gameTime"></param>
    public virtual void Update(GameTime gameTime)
    {
        Vector2 velocity = Velocity;
        velocity.X += (float)(_random.NextDouble() - 0.5) * 5f;
        Position += velocity;
        Lifespan -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        UpdateTransparencyOverLifeTime();
    }

    /// <summary>
    /// Update the transparency of the particle over its lifetime.
    /// </summary>
    protected void UpdateTransparencyOverLifeTime()
    {
        Color = new Color(
            Color.R,
            Color.G,
            Color.B,
            Lifespan / _startingLifespan);    
    }
    
    /// <summary>
    /// Draw the particle.
    /// </summary>
    public void Draw()
    {
        if (_texture == null)
        {
            _game.DrawRectangle(
                Color, 
                Position, 
                Size, 
                Size);
            return;
        }
        
        _game.DrawImage(_texture, Position);
    }
}