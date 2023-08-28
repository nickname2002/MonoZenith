using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MonoZenith;

public partial class Game
{
    private SpriteFont pixelFont;

    /* Initialize game vars and load assets. */
    public void Init()
    {
        pixelFont = LoadFont("pixel");
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        DrawText("Hello, World!", new Vector2(100, 100), pixelFont, Color.White);
    }
}