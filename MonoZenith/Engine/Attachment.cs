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
    private static GameFacade _facade;
    public static Game Instance { get; private set; }

    public static Color BackgroundColor => _facade.BackgroundColor;
    public static int ScreenWidth => _facade.ScreenWidth;
    public static int ScreenHeight => _facade.ScreenHeight;
    public static bool ScreenResizable => _facade.ScreenResizable;
    public static bool ScreenFullScreen => _facade.ScreenFullScreen;
    public static string WindowTitle => _facade.WindowTitle;
    
    public static bool ControllerConnected => _facade.ControllerConnected;
    public static bool HasLeftStick => _facade.HasLeftStick;
    public static bool HasRightStick => _facade.HasRightStick;
    public static bool HasDPad => _facade.HasDPad;
    public static bool HasLeftTrigger => _facade.HasLeftTrigger;
    public static bool HasRightTrigger => _facade.HasRightTrigger;
    public static bool HasLeftBumper => _facade.HasLeftBumper;
    public static bool HasRightBumper => _facade.HasRightBumper;
    public static bool HasAButton => _facade.HasAButton;
    public static bool HasBButton => _facade.HasBButton;
    public static bool HasXButton => _facade.HasXButton;
    public static bool HasYButton => _facade.HasYButton;

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
    
    public static void Initialize(GameFacade f)
    {
        _facade = f ?? throw new ArgumentNullException(nameof(f), "GameFacade cannot be null.");
        Instance = new Game();
    }

    /// <summary>
    /// Log a message to the console.
    /// </summary>
    /// <param name="msg">The message to log.</param>
    public static void DebugLog(string msg)
    {
        Console.WriteLine(msg);
    }

    /// <summary>
    /// Set the background color of the game.
    /// </summary>
    /// <param name="c">The color to set.</param>
    public static void SetBackgroundColor(Color c)
    {
        _facade.SetBackgroundColor(c);
    }

    /// <summary>
    /// Set the size of the screen.
    /// </summary>
    /// <param name="w">Width of the screen.</param>
    /// <param name="h">Height of the screen.</param>
    public static void SetScreenSize(int w, int h)
    {
        _facade.SetScreenSize(w, h);
    }

    /// <summary>
    /// Set the screen to full screen or not.
    /// </summary>
    /// <param name="fullScreen">Whether the screen is full screen.</param>
    public static void SetScreenFullScreen(bool fullScreen)
    {
        _facade.SetScreenFullScreen(fullScreen);
    }

    /// <summary>
    /// Set whether the screen is resizable.
    /// </summary>
    /// <param name="resizable">Whether the screen is resizable.</param>
    public static void SetScreenResizable(bool resizable)
    {
        _facade.SetScreenResizable(resizable);
    }

    /// <summary>
    /// Set the window title.
    /// </summary>
    /// <param name="t">The window title.</param>
    public static void SetWindowTitle(string t)
    {
        _facade.SetWindowTitle(t);
    }

    /// <summary>
    /// Check if a key is pressed.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>Whether the key is pressed.</returns>
    public static bool GetKeyDown(Keys key)
    {
        return _facade.GetKeyDown(key);
    }

    /// <summary>
    /// Check if a mouse button is pressed.
    /// </summary>
    /// <param name="button">The mouse button to check.</param>
    /// <returns>Whether the mouse button is pressed.</returns>
    public static bool GetMouseButtonDown(MouseButtons button)
    {
        return _facade.GetMouseButtonDown(button);
    }

    /// <summary>
    /// Get the mouse position.
    /// </summary>
    /// <returns>The mouse position.</returns>
    public static Point GetMousePosition()
    {
        return _facade.GetMousePosition();
    }

    /// <summary>
    /// Get the value of the mouse wheel.
    /// </summary>
    /// <returns>The value of the mouse wheel.</returns>
    public static int GetMouseWheelValue()
    {
        return _facade.GetMouseWheelValue();
    }

    /// <summary>
    /// Load a font.
    /// </summary>
    /// <param name="font">The font to load.</param>
    /// <param name="scale">The scale of the font.</param>
    /// <returns>The loaded font.</returns>
    public static SpriteFont LoadFont(string font, float scale)
    {
        return _facade.LoadFont(font, scale);
    }

    /// <summary>
    /// Draw text to the screen.
    /// </summary>
    /// <param name="content">The content of the text.</param>
    /// <param name="pos">The position of the text.</param>
    /// <param name="font">The font of the text.</param>
    /// <param name="c">The color of the text.</param>
    /// <param name="scale">The scale of the text.</param>
    /// <param name="angle">The angle of the text.</param>
    public static void DrawText(string content, Vector2 pos, SpriteFont font, Color c, float scale = 1, float angle = 0)
    {
        _facade.DrawText(content, pos, font, c, scale, angle);
    }

    /// <summary>
    /// Load an image.
    /// </summary>
    /// <param name="filepath">The file path of the image.</param>
    /// <returns>The loaded image.</returns>
    public static Texture2D LoadImage(string filepath)
    {
        return _facade.LoadImage(filepath);
    }

    /// <summary>
    /// Draw an image to the screen.
    /// </summary>
    /// <param name="texture">The texture to draw.</param>
    /// <param name="pos">The position of the image.</param>
    /// <param name="scale">The scale of the image.</param>
    /// <param name="angle">The angle of the image.</param>
    /// <param name="flipped">Whether the image is flipped.</param>
    /// <param name="alpha">The alpha of the image.</param>
    public static void DrawImage(Texture2D texture, Vector2 pos, float scale = 1, float angle = 0, bool flipped = false, float alpha = 1.0f)
    {
        _facade.DrawImage(texture, pos, scale, angle, flipped, alpha);
    }

    /// <summary>
    /// Draw a rectangle to the screen.
    /// </summary>
    /// <param name="color">The color of the rectangle.</param>
    /// <param name="pos">The position of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <param name="height">The height of the rectangle.</param>
    public static void DrawRectangle(Color color, Vector2 pos, int width, int height)
    {
        _facade.DrawRectangle(color, pos, width, height);
    }

    /// <summary>
    /// Load audio from a file.
    /// </summary>
    /// <param name="filePath">The file path of the audio.</param>
    /// <returns>The loaded audio.</returns>
    public static SoundEffectInstance LoadAudio(string filePath)
    {
        return _facade.LoadAudio(filePath);
    }

    /// <summary>
    /// Play audio.
    /// </summary>
    public static void LogControllerSupportProperties()
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
    /// Get the game pad state.   
    /// </summary>
    /// <returns>The game pad state.</returns>
    public static GamePadState GetGamePadState()
    {
        return GamePad.GetState(PlayerIndex.One);
    }

    /// <summary>
    /// Log the pressed DualSense button.
    /// </summary>
    public static void LogPressedDualSenseButton()
    {
        foreach (var  button in Enum.GetValues(typeof(DualSenseButtons)))
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
    /// <param name="leftMotor">The left motor.</param>
    /// <param name="rightMotor">The right motor.</param>
    public static void VibrateController(float leftMotor, float rightMotor)
    {
        if (!ControllerConnected)
        {
            DebugLog("Controller not connected.");
            return;
        }

        GamePad.SetVibration(PlayerIndex.One, leftMotor, rightMotor);
    }
}