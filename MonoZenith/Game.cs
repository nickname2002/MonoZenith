using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    private SpriteFont _font;
    
    /* Initialize game vars and load assets. */
    public void Init()
    {
        _font = LoadFont("pixel");
    }

    /* Update game logic. */
    public void Update(GameTime gameTime)
    {
        
    }

    /* Draw objects/backdrop. */
    public void Draw()
    {
        DrawText("Hello, World!", new Vector2(100, 100), _font, Color.White);
    }
}