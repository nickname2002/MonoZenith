
using Microsoft.Xna.Framework;

namespace MonoZenith.Components;

public abstract class Component
{
    protected Game Game;
    protected Vector2 Position;
    protected int Width;
    protected int Height;
    
    protected Component(MonoZenith.Game g, Vector2 pos, int width, int height)
    {
        this.Game = g;
        this.Position = pos;
        this.Width = width;
        this.Height = height;
    }
    
    public abstract void Update(GameTime deltaTime);
    public abstract void Draw();
}