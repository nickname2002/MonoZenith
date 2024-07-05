using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoZenith.Engine.Support;

namespace MonoZenith.Components;

public class Slider : Component
{
    // Slider
    public float Min { get; set; }
    public float Max { get; set; }
    public float Value { get; set; }
    
    // Color
    public Color SliderColor { get; set; }
    public Color BarColor { get; set; }
    
    // Value
    public int DecimalPlaces { get; set; }
    public float TextScale { get; set; }
    public Color TextColor { get; set; }
    
    private bool _sliding;
    private SpriteFont _font;
    
    public Slider(Game g, Vector2 pos, int width, int height, int min, int max) 
        : base(g, pos, width, height)
    {
        Min = min;
        Max = max;
        Value = (max + min) / 2.0f;
     
        SliderColor = Color.Black;
        BarColor = Color.DarkGray;
        DecimalPlaces = 1;
        
        TextScale = 2;
        TextColor = Color.Black;
        
        _sliding = false;
        _font = DataManager.GetInstance(g).ComponentFont;
    }

    /* Check if mouse is hovering over slider. */
    private bool IsHovering()
    {
        return Game.GetMousePosition().X > Position.X - Width / 2
            && Game.GetMousePosition().X < Position.X + Width / 2
            && Game.GetMousePosition().Y > Position.Y - Height / 2
            && Game.GetMousePosition().Y < Position.Y + Height / 2;
    }
    
    /* Cap value between min and max. */
    private void CapValue()
    {
        if (Value < Min)
            Value = Min;
        else if (Value > Max)
            Value = Max;
    }
    
    public override void Update(GameTime deltaTime)
    {
        if (_sliding && !Game.GetMouseButtonDown(MouseButtons.Left))
            _sliding = false;
        
        if (!IsHovering() && !_sliding) 
            return;

        if (!Game.GetMouseButtonDown(MouseButtons.Left)) 
            return;
        
        _sliding = true;
        Value = (Game.GetMousePosition().X - Position.X + Width / 2) * (Max - Min) / Width + Min;
        CapValue();
    }

    /* Draw slider bar. */
    private void DrawBar()
    {
        Game.DrawRectangle(BarColor, Position, Width, Height);
    }
    
    /* Draw slider. */
    private void DrawSlider()
    {
        int sliderWidth = 15;
        int sliderHeight = (int)(Height * 2.5f);
        int sliderX = (int)(Position.X - Width / 2 + Width * (Value - Min) / (Max - Min));
        Game.DrawRectangle(
            SliderColor, 
            new Vector2(sliderX, Position.Y), 
            sliderWidth, 
            sliderHeight);
    }

    private void DrawProperties()
    {
        int sliderX = (int)(Position.X - Width / 2 + Width * (Value - Min) / (Max - Min));
        Game.DrawText(
            Math.Round(Value, DecimalPlaces).ToString(), 
            new Vector2(sliderX, Position.Y - Height / 2 - 40), 
            _font, 
            TextColor, 
            TextScale);
    }
    
    public override void Draw()
    {
        DrawBar();
        DrawSlider();
        DrawProperties();
    }
}