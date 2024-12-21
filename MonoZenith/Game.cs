using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    /* Initialize game vars and load assets. */
    public static void Init()
    {
        
    }

    /* Update game logic. */
    public static void Update(GameTime deltaTime)
    {

    }
    
    /* Draw objects/backdrop. */
    public static void Draw()
    {
        DrawRectangle(
            Color.Red,
            new Vector2(0, 0),
            ScreenWidth / 2,
            ScreenHeight / 2);
    }
}