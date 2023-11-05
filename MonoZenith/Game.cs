using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoZenith.Components;

namespace MonoZenith;

public partial class Game
{
    private Texture2D _tileMap;
    private Texture2D _tile;
    
    /* Initialize game vars and load assets. */
    public void Init()
    {
        _tileMap = ReadTileMap("Textures/tilemap.png");
        _tile = ReadTileFromMap(_tileMap, 1, 32);
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        DrawImage(_tile, new Vector2(16, 16));
    }
}