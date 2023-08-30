using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoZenith;

public enum MouseButtons { Left, Middle, Right }

public partial class Game
{
    readonly GameFacade _facade;

    // Properties
    public Color BackgroundColor => _facade.BackgroundColor;
    public int ScreenWidth => _facade.ScreenWidth;
    public int ScreenHeight => _facade.ScreenHeight;
    public string WindowTitle => _facade.WindowTitle;

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
    /// <returns>The SpriteFont of the requested font.</returns>
    public SpriteFont LoadFont(string font)
    {
        return _facade.LoadFont(font);
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
    public void DrawImage(Texture2D texture, Vector2 pos, float scale=1, float angle=0, bool flipped=false)
    {
        _facade.DrawImage(texture, pos, scale, angle, flipped);
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
}