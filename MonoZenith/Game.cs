using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    private TextField _textField;
    
    /* Initialize game vars and load assets. */
    public void Init()
    {
        SetScreenSize(800, 600);
        SetBackgroundColor(Color.White);
        _textField = new TextField(this, new Vector2(400, 300), 200, 100, 15);
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        _textField.Update(deltaTime);
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        _textField.Draw();
    }
}