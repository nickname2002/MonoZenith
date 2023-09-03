using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    private Slider s;
    
    /* Initialize game vars and load assets. */
    public void Init()
    {
        SetScreenSize(800, 600);
        SetBackgroundColor(Color.White);
        s = new Slider(this, new Vector2(400, 300), 500, 10, 0, 1);
        s.DecimalPlaces = 1;
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        s.Update(deltaTime);
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        s.Draw();
    }
}