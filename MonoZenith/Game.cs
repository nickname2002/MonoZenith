using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoZenith;

public partial class Game
{
    SpriteFont _font;
    
    /* Initialize game vars and load assets. */
    public void Init()
    {
        _font = LoadFont("pixel");
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        DrawText("Hello, world!", new Vector2(10, 10), _font, Color.White);
    }
}