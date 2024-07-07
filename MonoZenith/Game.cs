using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    private Timer _testTimer;
    
    /* Initialize game vars and load assets. */
    public void Init()
    {
        _testTimer = new Timer(1000, 0);
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        _testTimer.Update(deltaTime);
        
        if (_testTimer.TimerOver())
        {
            Console.WriteLine("Timer over!");
            _testTimer.ResetTimer();
        }
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
    
    }
}