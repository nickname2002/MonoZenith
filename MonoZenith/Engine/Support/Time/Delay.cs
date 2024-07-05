namespace MonoZenith;

public class Delay
{
    public int Index { get; }
    public int DelayTime { get; }
    
    public Delay(int index, int delay)
    {
        Index = index;
        DelayTime = delay;
    }
}