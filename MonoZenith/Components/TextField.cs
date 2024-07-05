using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Engine.Support;

namespace MonoZenith.Components;

public class TextField : Component
{
    private Game _game;
    private float _currentTypeCooldown;
    private readonly float _typeCooldown;
    private readonly int _fontScale;
    
    public bool Selected { get; private set; }
    public string Content { get; private set; }
    public int MaxLength { get; set; }
    public Color ContentColor { get; set;  }
    public Color BackColor { get; set; }
    public int BorderWidth { get; set; }
    public Color BorderColor { get; set; }
    
    public TextField(Game g, Vector2 pos, int width, int height, int fontScale) : 
        base(g, pos, width, height)
    {
        _game = g;
        Content = "";
        Selected = false;
        _typeCooldown = 6;
        _currentTypeCooldown = 0;
        _fontScale = fontScale;
        MaxLength = 20;
        BorderWidth = 3;
        BorderColor = Color.DimGray;
        ContentColor = Color.White;
        BackColor = Color.DarkGray;
    }

    [SuppressMessage("ReSharper", "PossibleLossOfFraction")]
    private bool IsHovered()
    {
        var mousePos = Game.GetMousePosition();

        // In X range
        if (!(mousePos.X > Position.X - Width / 2 - BorderWidth) ||
            !(mousePos.X < Position.X + Width / 2 + BorderWidth))
        {
            return false;
        }

        // In Y range
        return mousePos.Y > Position.Y - Height / 2 - BorderWidth && 
               mousePos.Y < Position.Y + Height / 2 + BorderWidth;
    }
    
    private bool IsClicked()
    {
        return IsHovered() && Game.GetMouseButtonDown(MouseButtons.Left);
    }

    /// <summary>
    /// Toggles the selected state of the text field.
    /// </summary>
    private void ToggleSelected()
    {
        if (IsClicked() && !Selected)
        {
            Selected = true;
        }
        else if (Game.GetMouseButtonDown(MouseButtons.Left) && !IsClicked() && Selected)
        {
            Selected = false;
        }
    }

    /// <summary>
    /// Gets the content to add to the text field.
    /// </summary>
    /// <param name="key">The key that is pressed.</param>
    /// <returns>The content to add to the text field.</returns>
    private static char ContentToAdd(Keys key)
    {
        switch (key.ToString().Length)
        {
            // Handle letters
            case 1:
                return char.Parse(key.ToString());
            
            // Handle numbers
            case 2 when key.ToString()[0] == 'D':
                return key.ToString()[1];
        }

        // Handle keys that are not letters or numbers
        if (key is Keys.LeftShift or Keys.RightShift or Keys.LeftControl or Keys.RightControl)
        {
            return ' ';
        }
        
        // Handle special characters
        return key switch
        {
            Keys.Add => '+',
            Keys.Subtract => '-',
            Keys.Multiply => '*',
            Keys.Divide => '/',
            Keys.OemBackslash => '\\',
            Keys.OemComma => ',',
            Keys.OemPeriod => '.',
            Keys.OemQuestion => '?',
            Keys.OemQuotes => '\'',
            Keys.OemSemicolon => ';',
            Keys.OemTilde => '~',
            Keys.OemOpenBrackets => '(',
            Keys.OemCloseBrackets => ')',
            Keys.OemPipe => '|',
            Keys.OemEnlW => '!',
            _ => ' '
        };
    }
    
    /// <summary>
    /// Adds/removed content from the text field.
    /// </summary>
    private void ManageContent()
    {
        var keyboardState = Keyboard.GetState();

        if (IsValidKeyInput(keyboardState))
        {
            Content += ContentToAdd(keyboardState.GetPressedKeys()[0]);
            _currentTypeCooldown = _typeCooldown;
        }
        else if (IsValidSpaceInput())
        {
            Content += " ";
            _currentTypeCooldown = _typeCooldown;
        }
        else if (IsValidBackspaceInput())
        {
            HandleBackspace();
        }
    }
    
    private bool IsValidKeyInput(KeyboardState keyboardState)
    {
        return keyboardState.GetPressedKeys().Length > 0 &&
               !Game.GetKeyDown(Keys.Space) &&
               !Game.GetKeyDown(Keys.Back) &&
               Content.Length < MaxLength;
    }

    private bool IsValidSpaceInput()
    {
        return Game.GetKeyDown(Keys.Space) && Content.Length < MaxLength;
    }

    private bool IsValidBackspaceInput()
    {
        return Game.GetKeyDown(Keys.Back);
    }

    private void HandleBackspace()
    {
        if (Content.Length <= 0)
        {
            return;
        }

        Content = Content.Remove(Content.Length - 1);
        _currentTypeCooldown = _typeCooldown;
    }
    
    public override void Update(GameTime deltaTime)
    {
        ToggleSelected();
        
        // Add content to text field
        if (Selected && _currentTypeCooldown <= 0)
        {
            ManageContent();
        }
        // Update cooldown timer
        else if (_currentTypeCooldown > 0)
        {
            _currentTypeCooldown -= 1;
        }
    }

    public override void Draw()
    {
        // Draw border
        Game.DrawRectangle(BorderColor, Position, Width + BorderWidth * 2, Height + BorderWidth * 2);

        // Draw background
        if (Selected)
        {
            var selectedColor = new Color(BackColor.R + 20, BackColor.G + 20, BackColor.B + 20);
            Game.DrawRectangle(selectedColor, Position, Width, Height);
        }
        else if (IsHovered())
        {
            var hoverColor = new Color(BackColor.R + 20, BackColor.G + 20, BackColor.B + 20);
            Game.DrawRectangle(hoverColor, Position, Width, Height);
        }
        else
        {
            Game.DrawRectangle(BackColor, Position, Width, Height);
        }
        
        // Draw content
        if (Selected)
        {
            Game.DrawText(
                Content + "|",
                Position,
                DataManager.GetInstance(_game).ComponentFont,
                ContentColor, 
                _fontScale);
        }
        else
        {
            Game.DrawText(
                Content, 
                Position,
                DataManager.GetInstance(_game).ComponentFont, 
                ContentColor, 
                _fontScale);
        }
    }
}