using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoZenith;

public class ParticleManager
{
    private Game _game;
    private List<Particle> _particles;
    private Random _r;

    public ParticleManager(Game g)
    {
        _game = g;
        _particles = new List<Particle>();
        _r = new Random();
    }

    /// <summary>
    /// Create a particle.
    /// </summary>
    /// <param name="texture">Texture of the particle.</param>
    /// <param name="position">Position of the particle.</param>
    /// <param name="velocity">Velocity of the particle.</param>
    /// <param name="color">Color of the particle.</param>
    /// <param name="size">Size of the particle.</param>
    /// <param name="lifespan">Lifespan of the particle.</param>
    public void CreateParticle(
        Texture2D texture, 
        Vector2 position, 
        Vector2 velocity, 
        Color color, 
        int size, 
        float lifespan)
    {
        var particle = new Particle(
            _r,
            _game,
            texture,
            position,
            velocity,
            color,
            size,
            lifespan
        );
        
        _particles.Add(particle);
    }

    /// <summary>
    /// Update all particles.
    /// </summary>
    /// <param name="gameTime">Game time.</param>
    public void Update(GameTime gameTime)
    {
        for (var i = _particles.Count - 1; i >= 0; i--)
        {
            // Get particle
            var particle = _particles[i];
            particle.Update(gameTime);
            
            // Remove particles that have reached the end of their lifespan
            if (particle.Lifespan <= 0)
            {
                _particles.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Draw all particles.
    /// </summary>
    public void Draw()
    {
        foreach (var particle in _particles)
        {
            particle.Draw();
        }
    }
}