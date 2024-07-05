using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoZenith;

public class TimerManager
{
    private static List<Timer> _timers;
    private static TimerManager _instance;

    public TimerManager()
    {
        _timers = new List<Timer>();
    }
    
    /// <summary>
    /// Get the instance of the timer manager.
    /// </summary>
    /// <returns>The timer manager instance.</returns>
    public static TimerManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new TimerManager();
        }
        
        return _instance;
    }

    /// <summary>
    /// Update all timers in the buffer.
    /// </summary>
    /// <param name="gameTime">Game time.</param>
    public static void Update(GameTime gameTime)
    {
        foreach (var t in _timers.Where(t => t != null))
        {
            t.Update(gameTime);
        }
    }
    
    /// <summary>
    /// Creates a timer at the index in the buffer.
    /// </summary>
    /// <param name="index">Index of the timer in the buffer.</param>
    /// <param name="milliSeconds">Amount of milliseconds the timer is active.</param>
    public static void CreateTimer(int index, int milliSeconds)
    {
        try
        {
            bool timerExists = _timers[index] != null;
        }
        catch (Exception e)
        {
            _timers.Insert(index, new Timer(milliSeconds, index));
        }
    }

    /// <summary>
    /// Returns whether the timer at the index in the buffer is over.
    /// </summary>
    /// <param name="index">Index of the timer in the buffer.</param>
    /// <returns>Whether timer at the index in the buffer is over.</returns>
    public static bool TimerOver(int index)
    {
        return _timers[index].TimerOver();
    }

    /// <summary>
    /// Resets the timer at the index in the buffer.
    /// </summary>
    /// <param name="index">The index of the timer in the buffer.</param>
    public static void ResetTimer(int index)
    {
        _timers[index].ResetTimer();
    }
    
    /// <summary>
    /// Remove all timers from the buffer.
    /// </summary>
    public static void ClearTimers()
    {
        _timers.Clear();
    }
}