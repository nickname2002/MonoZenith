using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    /* Initialize game vars and load assets. */
    public void Init()
    {
        
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        foreach (DualSenseButtons button in Enum.GetValues(typeof(DualSenseButtons)))
        {
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown((Buttons)button))
            {
                Console.WriteLine("Pressed: " + button.ToString());
            }
        }
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        
    }
}