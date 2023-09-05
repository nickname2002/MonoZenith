using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    private Vector2 pos;
    private Collider c;
    private Collider c2;
    
    /* Initialize game vars and load assets. */
    public void Init()
    {
        SetScreenSize(800, 600);
        
        // Create position for collider c
        pos = new Vector2(100, 0);
        
        // Setup colliders
        c = new Collider(this, pos, 50, 50);
        c2 = new Collider(this, new Vector2(100, 100), 50, 50);
    }

/* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        // Stop if c collides with c2
        if (c.CollidesWith(c2))
        {
            return;
        }
        
        // Move c down
        pos.Y += 0.5f;
        c.Update(pos);
    }
    
/* Draw objects/backdrop. */
    public void Draw()
    {
        // Draw colliders
        c.Draw();
        c2.Draw();
    }
}