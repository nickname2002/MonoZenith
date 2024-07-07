using System.Data;
using Microsoft.Xna.Framework;

namespace MonoZenith;

public class Timer
{
    public readonly int OriginalMilliSeconds;
    private int _milliSeconds;
    
    public Timer(int milliSeconds)
    {
        OriginalMilliSeconds = milliSeconds;
        _milliSeconds = milliSeconds;
    }

    /// <summary>
    /// Update the timer.
    /// </summary>
    /// <param name="deltaTime">The game time.</param>
    public void Update(GameTime deltaTime)
    {
        if (_milliSeconds <= 0)
            return;
        
        _milliSeconds -= deltaTime.ElapsedGameTime.Milliseconds;
    }
    
    /// <summary>
    /// Check if the timer has run out.
    /// </summary>
    /// <returns>Whether the timer has run out.</returns>
    public bool TimerOver()
    {
        return _milliSeconds <= 0;
    }
    
    /// <summary>
    /// Reset the timer.
    /// </summary>
    public void ResetTimer()
    {
        _milliSeconds = OriginalMilliSeconds;
    }
}