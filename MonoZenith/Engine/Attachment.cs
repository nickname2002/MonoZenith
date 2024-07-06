using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Engine;

// ReSharper disable once CheckNamespace
namespace MonoZenith;

public enum MouseButtons { Left, Middle, Right }

public partial class Game
{
    private readonly GameFacade _facade;

    public Color BackgroundColor => _facade.BackgroundColor;
    public int ScreenWidth => _facade.ScreenWidth;
    public int ScreenHeight => _facade.ScreenHeight;
    public bool ScreenResizable => _facade.ScreenResizable;
    public bool ScreenFullScreen => _facade.ScreenFullScreen;
    public string WindowTitle => _facade.WindowTitle;
    
    public bool ControllerConnected => _facade.ControllerConnected;
    public bool HasLeftStick => _facade.HasLeftStick;
    public bool HasRightStick => _facade.HasRightStick;
    public bool HasDPad => _facade.HasDPad;
    public bool HasLeftTrigger => _facade.HasLeftTrigger;
    public bool HasRightTrigger => _facade.HasRightTrigger;
    public bool HasLeftBumper => _facade.HasLeftBumper;
    public bool HasRightBumper => _facade.HasRightBumper;
    public bool HasAButton => _facade.HasAButton;
    public bool HasBButton => _facade.HasBButton;
    public bool HasXButton => _facade.HasXButton;
    public bool HasYButton => _facade.HasYButton;
    
    // PlayStation DualSense buttons
    public enum DualSenseButtons
    {
        Cross = Buttons.A,
        Circle = Buttons.B,
        Square = Buttons.X,
        Triangle = Buttons.Y,
        L1 = Buttons.LeftShoulder,
        R1 = Buttons.RightShoulder,
        L2 = Buttons.LeftTrigger,
        R2 = Buttons.RightTrigger,
        Share = Buttons.Back,
        Options = Buttons.Start,
        L3 = Buttons.LeftStick,
        R3 = Buttons.RightStick,
        Ps = Buttons.BigButton,
        Touchpad = Buttons.BigButton, // Assuming Touchpad uses the same button as PS
        Up = Buttons.DPadUp,
        Down = Buttons.DPadDown,
        Left = Buttons.DPadLeft,
        Right = Buttons.DPadRight
    }
    
    // XBOX Controller buttons
    public enum XboxButtons
    {
        A = Buttons.A,
        B = Buttons.B,
        X = Buttons.X,
        Y = Buttons.Y,
        L1 = Buttons.LeftShoulder,
        R1 = Buttons.RightShoulder,
        L2 = Buttons.LeftTrigger,
        R2 = Buttons.RightTrigger,
        Back = Buttons.Back,
        Start = Buttons.Start,
        L3 = Buttons.LeftStick,
        R3 = Buttons.RightStick,
        Xbox = Buttons.BigButton,
        Up = Buttons.DPadUp,
        Down = Buttons.DPadDown,
        Left = Buttons.DPadLeft,
        Right = Buttons.DPadRight
    }
    
    // Nintendo Switch Pro Controller buttons
    public enum SwitchProButtons
    {
        B = Buttons.A,
        A = Buttons.B,
        Y = Buttons.X,
        X = Buttons.Y,
        L = Buttons.LeftShoulder,
        R = Buttons.RightShoulder,
        ZL = Buttons.LeftTrigger,
        ZR = Buttons.RightTrigger,
        Minus = Buttons.Back,
        Plus = Buttons.Start,
        L3 = Buttons.LeftStick,
        R3 = Buttons.RightStick,
        Home = Buttons.BigButton,
        Up = Buttons.DPadUp,
        Down = Buttons.DPadDown,
        Left = Buttons.DPadLeft,
        Right = Buttons.DPadRight
    }
    
    public Game(GameFacade f)
    {
        _facade = f;
    }

    /// <summary>
    /// Log a message to the console.
    /// </summary>
    /// <param name="msg">Message</param>
    public void DebugLog(string msg)
    {
        Console.WriteLine(msg);
    }
    
    /// <summary>
    /// Set the background color.
    /// </summary>
    /// <param name="c">Color</param>
    public void SetBackgroundColor(Color c)
    {
        _facade.SetBackgroundColor(c);
    }
    
    /// <summary>
    /// Set the screen size.
    /// </summary>
    /// <param name="w">Width</param>
    /// <param name="h">Height</param>
    public void SetScreenSize(int w, int h)
    {
        _facade.SetScreenSize(w, h);
    }
    
    /// <summary>
    /// Set the screen full screen.
    /// </summary>
    /// <param name="fullScreen">Whether the screen is full screen.</param>
    public void SetScreenFullScreen(bool fullScreen)
    {
        _facade.SetScreenFullScreen(fullScreen);
    }
    
    /// <summary>
    /// Set the screen resizable.
    /// </summary>
    /// <param name="resizable">Whether the screen is resizable.</param>
    public void SetScreenResizable(bool resizable)
    {
        _facade.SetScreenResizable(resizable);
    }

    /// <summary>
    /// Set the window title.
    /// </summary>
    /// <param name="t">The window title.</param>
    public void SetWindowTitle(string t)
    {
        _facade.SetWindowTitle(t);
    }

    /// <summary>
    /// Get whether a keyboard key is pressed.
    /// </summary>
    /// <param name="key">The key that is checked.</param>
    /// <returns>Whether the provided key is pressed.</returns>
    public bool GetKeyDown(Keys key)
    {
        return _facade.GetKeyDown(key);
    }

    /// <summary>
    /// Get whether a mouse button is pressed.
    /// </summary>
    /// <param name="button">The button that is checked.</param>
    /// <returns>Whether a mouse button is pressed.</returns>
    public bool GetMouseButtonDown(MouseButtons button)
    {
        return _facade.GetMouseButtonDown(button);
    }

    /// <summary>
    /// Get the mouse position.
    /// </summary>
    /// <returns>Position of the mouse pointer.</returns>
    public Point GetMousePosition()
    {
        return _facade.GetMousePosition();
    }

    /// <summary>
    /// Get the mouse wheel value.
    /// </summary>
    /// <returns>The value of the mouse wheel.</returns>
    public int GetMouseWheelValue()
    {
        return _facade.GetMouseWheelValue();
    }

    /// <summary>
    /// Load a font.
    /// </summary>
    /// <param name="font">Name of the font to be loaded.</param>
    /// <param name="scale">Scale of the font.</param>
    /// <returns>The SpriteFont of the requested font.</returns>
    public SpriteFont LoadFont(string font, float scale)
    {
        return _facade.LoadFont(font, scale);
    }

    /// <summary>
    /// Draw text to the screen.
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="pos">Position</param>
    /// <param name="font">Font</param>
    /// <param name="c">Color</param>
    /// <param name="scale">Scale</param>
    /// <param name="angle">Rotational angle</param>
    public void DrawText(string content, Vector2 pos, SpriteFont font, Color c, float scale=1, float angle=0)
    {
        _facade.DrawText(content, pos, font, c, scale, angle);
    }

    /* Source: https://community.monogame.net/t/loading-png-jpg-etc-directly/7403 */
    /// <summary>
    /// Load an image.
    /// </summary>
    /// <param name="filepath">Filepath</param>
    /// <returns>Texture of the requested image.</returns>
    public Texture2D LoadImage(string filepath)
    {
        return _facade.LoadImage(filepath);
    }

    /* Source: https://www.industrian.net/tutorials/texture2d-and-drawing-sprites/ */
    /// <summary>
    /// Draw an image to the screen.
    /// </summary>
    /// <param name="texture">Image texture</param>
    /// <param name="pos">Position</param>
    /// <param name="scale">Scale</param>
    /// <param name="angle">Rotational angle</param>
    /// <param name="flipped">Horizontally flipped</param>
    /// <param name="alpha">Alpha</param>
    public void DrawImage(
        Texture2D texture, 
        Vector2 pos, 
        float scale=1, 
        float angle=0, 
        bool flipped=false, 
        float alpha=1.0f)
    {
        _facade.DrawImage(texture, pos, scale, angle, flipped, alpha);
    }
    
    /// <summary>
    /// Draw a rectangle to the screen.
    /// </summary>
    /// <param name="color">Color</param>
    /// <param name="pos">Position</param>
    /// <param name="width">Width</param>
    /// <param name="height">Height</param>
    public void DrawRectangle(Color color, Vector2 pos, int width, int height)
    {
        _facade.DrawRectangle(color, pos, width, height);
    }

    /// <summary>
    /// Load an audio file.
    /// </summary>
    /// <param name="filePath">Filepath to the audio file to be loaded.</param>
    /// <returns>SoundEffectInstance of the audio file.</returns>
    public SoundEffectInstance LoadAudio(string filePath)
    {
        return _facade.LoadAudio(filePath);
    }

    public void LogControllerSupportProperties()
    {
        DebugLog("===== Controller support properties =====");
        DebugLog($"Controller connected: {ControllerConnected}");
        DebugLog($"Has left stick: {HasLeftStick}");
        DebugLog($"Has right stick: {HasRightStick}");
        DebugLog($"Has DPad: {HasDPad}");
        DebugLog($"Has left trigger: {HasLeftTrigger}");
        DebugLog($"Has right trigger: {HasRightTrigger}");
        DebugLog($"Has left bumper: {HasLeftBumper}");
        DebugLog($"Has right bumper: {HasRightBumper}");
        DebugLog($"Has A button: {HasAButton}");
        DebugLog($"Has B button: {HasBButton}");
        DebugLog($"Has X button: {HasXButton}");
        DebugLog($"Has Y button: {HasYButton}");
        DebugLog("========================================");
    }
    
    /// <summary>
    /// Get the gamepad state.
    /// </summary>
    /// <returns>Gamepad state.</returns>
    public GamePadState GetGamePadState()
    {
        return GamePad.GetState(PlayerIndex.One);
    }

    /// <summary>
    /// Log the pressed DualSense buttons.
    /// </summary>
    private void LogPressedDualSenseButton()
    {
        foreach (DualSenseButtons button in Enum.GetValues(typeof(DualSenseButtons)))
        {
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown((Buttons)button))
            {
                Console.WriteLine("Pressed: " + button.ToString());
            }
        }
    }

    /// <summary>
    /// Vibrate the controller. 
    /// </summary>
    /// <param name="leftMotor">Left motor in controller</param>
    /// <param name="rightMotor">Right motor in controller</param>
    public void VibrateController(float leftMotor, float rightMotor)
    {
        if (!ControllerConnected)
        {
            DebugLog("Controller not connected.");
            return;
        }
        
        GamePad.SetVibration(PlayerIndex.One, leftMotor, rightMotor);
    }
}