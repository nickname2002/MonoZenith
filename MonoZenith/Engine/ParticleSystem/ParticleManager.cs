using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoZenith;

public class ParticleManager
{
    private Game _game;
    private List<Particle> particles;
    private Random r;

    public ParticleManager(Game g)
    {
        _game = g;
        particles = new List<Particle>();
        r = new Random();
    }

    public void CreateParticle(Texture2D texture, Vector2 position, Vector2 velocity, Color color, int size, float lifespan)
    {
        var particle = new Particle(
            r,
            _game,
            texture,
            position,
            velocity,
            color,
            size,
            lifespan
        );
        
        particles.Add(particle);
    }

    public void Update(GameTime gameTime)
    {
        for (var i = particles.Count - 1; i >= 0; i--)
        {
            // Get particle
            var particle = particles[i];
            particle.Update(gameTime);
            
            // Remove particles that have reached the end of their lifespan
            if (particle.Lifespan <= 0)
            {
                particles.RemoveAt(i);
            }
        }
    }

    public void Draw()
    {
        foreach (var particle in particles)
        {
            particle.Draw();
        }
    }
}