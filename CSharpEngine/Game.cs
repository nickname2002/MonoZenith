using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace CSharpEngine;

public partial class Game
{
    /* Initialize game vars and load assets. */
    public void Init()
    {

    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {

    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        DrawRectangle(Color.Blue, new Vector2(100, 100), 100, 100);
    }
}