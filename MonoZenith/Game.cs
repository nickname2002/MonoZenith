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
        if (ControllerConnected)
        {
            GamePadState state = this.GetGamePadState();
            VibrateController(0.5f, 0.5f);
            
            if (state.IsButtonDown((Buttons)DualSenseButtons.Cross))
            {
                DebugLog("Jump!");
            }

            if (HasDPad && HasLeftStick)
            {
                if (state.IsButtonDown((Buttons)DualSenseButtons.Right) ||
                    state.ThumbSticks.Left.X > 0.5f)
                {
                    DebugLog("Move right!");
                }
            }
        }
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        
    }
}