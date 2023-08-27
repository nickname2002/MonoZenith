using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MonoZenith;

public partial class Game
{
    SpriteFont pixel;

    /* Initialize game vars and load assets. */
    public void Init()
    {
        pixel = LoadFont("pixel");
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {

    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        DrawText("Hello, there!", new Vector2(100, 50), pixel, new Color(255, 255, 255));
    }
}