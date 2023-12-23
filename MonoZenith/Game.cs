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
        
        // Create text field
        _textField = new TextField(this, new Vector2(400, 300), 210, 50, 1)
        {
            BackColor = Color.DarkGray,
            ContentColor = Color.White,
            BorderColor = Color.DimGray,
            MaxLength = 20
        };
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