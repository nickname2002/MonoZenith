using System.Data;
using Microsoft.Xna.Framework;

namespace MonoZenith;

public class Timer
{
    public readonly int OriginalMilliSeconds;
    private int _milliSeconds;
    private int _index;
    
    public Timer(int milliSeconds, int index)
    {
        OriginalMilliSeconds = milliSeconds;
        _milliSeconds = milliSeconds;
        _index = index;
    }

    public void Update(GameTime gameTime)
    {
        if (_milliSeconds <= 0)
            return;
        
        _milliSeconds -= gameTime.ElapsedGameTime.Milliseconds;
    }
    
    public bool TimerOver()
    {
        return _milliSeconds <= 0;
    }
    
    public void ResetTimer()
    {
        _milliSeconds = OriginalMilliSeconds;
    }
}