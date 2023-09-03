using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    private ParticleManager _particleManager;
    
    /* Initialize game vars and load assets. */
    public void Init()
    {
        SetScreenSize(800, 600);
        _particleManager = new ParticleManager(this);
    }

    /* Update game logic. */
    public void Update(GameTime gameTime)
    {
        _particleManager.CreateParticle(
            null, 
            new Vector2(400, 300), 
            new Vector2(0, -1), 
            Color.Gold, 
            5, 
            3);
        _particleManager.Update(gameTime);
    }

    /* Draw objects/backdrop. */
    public void Draw()
    {
        _particleManager.Draw();
    }
}