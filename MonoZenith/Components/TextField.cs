using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoZenith.Components;

public class TextField : Component
{
    private float _currentTypeCooldown;
    private float _typeCooldown;
    private string _content;
    private bool _selected;
    private int _fontSize;
    public bool Selected => _selected;
    public string Content => _content;
    public int MaxLength { get; set; }
    
    public TextField(Game g, Vector2 pos, int width, int height, int fontSize) : 
        base(g, pos, width, height)
    {
        _content = "";
        _selected = false;
        _typeCooldown = 8;
        _currentTypeCooldown = 0;
        MaxLength = 20;
    }

    private bool IsHovered()
    {
        Point mousePos = Game.GetMousePosition();

        // In X range
        if (mousePos.X > Position.X - Width / 2 && mousePos.X < Position.X + Width / 2)
        {
            // In Y range
            if (mousePos.Y > Position.Y - Height / 2 && mousePos.Y < Position.Y + Height / 2)
            {
                return true;
            }
        }

        return false;
    }
    
    private bool IsClicked()
    {
        return IsHovered() && Game.GetMouseButtonDown(MouseButtons.Left);
    }

    private void ToggleSelected()
    {
        if (IsClicked() && !_selected)
        {
            _selected = true;
        }
        else if (Game.GetMouseButtonDown(MouseButtons.Left) && !IsClicked() && _selected)
        {
            _selected = false;
        }
    }

    private void ManageContent()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        
        // TODO: From key name to character
        // TODO: Refactoring work for aesthetics and readability
        
        if (keyboardState.GetPressedKeys().Length > 0 && 
            keyboardState.GetPressedKeys()[0].ToString().Length == 1 &&
            _content.Length < MaxLength)
        {
            _content += keyboardState.GetPressedKeys()[0].ToString();
            _currentTypeCooldown = _typeCooldown;
        }
        else if (Game.GetKeyDown(Keys.Space) && _content.Length < MaxLength)
        {
            _content += " ";
            _currentTypeCooldown = _typeCooldown;
        }
        else if (Game.GetKeyDown(Keys.Back))
        {
            if (_content.Length <= 0) 
                return;
            
            _content = _content.Remove(_content.Length - 1);
            _currentTypeCooldown = _typeCooldown;
        }
    }
    
    public override void Update(GameTime deltaTime)
    {
        ToggleSelected();
        
        if (_selected && _currentTypeCooldown <= 0)
        {
            ManageContent();
        }
        else if (_currentTypeCooldown > 0)
        {
            _currentTypeCooldown -= 1;
        }
        
        Console.WriteLine(_content);
    }

    public override void Draw()
    {
        if (_selected)
        {
            Game.DrawRectangle(Color.DarkGray, Position, Width, Height);
        }
        else
        {
            Game.DrawRectangle(Color.Gray, Position, Width, Height);
        }
        
        Game.DrawText(_content, Position, Game.LoadFont("pixel"), Color.Black, 1);
    }
}