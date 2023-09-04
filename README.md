# MonoZenith

**MonoZenith** is a lightweight MonoGame wrapper designed to streamline game development using C#. It aims to simplify the game development process by providing useful abstractions and helper methods, allowing developers to focus on creating engaging gameplay experiences.
The project is currently in development, and is not yet ready for use in production. New features and bug fixes will be added in the future.

## Table of contents
- [Files & folders](#files--folders)
- [Provided helper methods](#provided-helper-methods)
- [Setup](#setup)
- [Usage](#usage)
  - [`Init`, `Update` & `Draw`](#init--update--draw)
  - [Setting up the screen](#setting-up-the-screen)
  - [Loading assets](#loading-assets)
  - [Using assets](#using-assets)
  - [Initializing & using UI components](#initializing--using-ui-components)
  - [Colliders](#colliders)
- [Known issues](#known-issues)
- [Maintenance](#maintenance)

## Files & folders
- `bin/Debug/net6/Content` - This folder contains all the assets used in the game.
- `Components` - This folder contains all the UI components that can be used in a MonoZenith game. 
- `Content` - This folder contains the MGCB file, which is used to load assets into the game.
- `Engine` - This contains all the backend logic for the MonoZenith project.
- `Game.cs` - This file contains the remainder of the `Game` class, which is the base class for all games created using MonoZenith. All gameplay related logic needs to be implemented in this file.

````
MonoZenith
├── bin
├─────── Debug
├─────────── net6
├─────────────── Content
├── Components
├─────── Button.cs
├─────── Component.cs
├── Content
├─────── Content.mgcb
├── Engine
├─────── Attachment.cs
├─────── Engine.cs
├─────── GameFacade.cs
├─────── Program.cs
├── Game.cs
├── Icon.bmp
├── Icon.ico
├── MonoZenith.csproj
└── MonoZenith.sln
````

## Provided Helper Methods
MonoZenith offers abstractions for MonoGame using the following methods:

### Debugging
- `DebugLog(string msg) : void`

### Window
- `SetBackgroundColor(Color c) : void`
- `SetScreenSize(int w, int h) : void`
- `SetWindowTitle(string t) : void`

### Keyboard & Mouse
- `GetKeyDown(Keys key) : bool`
- `GetMouseButtonDown(MouseButtons button) : bool`
- `GetMousePosition() : Point`
- `GetMouseWheelValue() : int`

### Loading Assets
- `LoadFont(string font) : SpriteFont`
- `LoadImage(string filepath) : Texture2D`
- `LoadSound(string filepath) : SoundEffect`

### Drawing Objects
- `DrawText(string text, SpriteFont font, Vector2 position, Color color, float scale=1, float angle=0) : void`
- `DrawImage(Texture2D image, Vector2 position, float scale=1, float angle=0, bool flipped=false) : void`
- `DrawRectangle(Color color, Vector2 pos, int width, int height) : void`

## Setup
You can set up MonoZenith for your project in two ways:

1. Download the .zip folder of the project from GitHub.
2. Fork the project on GitHub and clone it to your local machine for the latest build.

## Usage
Learn how to use MonoZenith with the provided helper methods.

### Initializing, Updating & Drawing
The three core methods for your game are `Init`, `Update`, and `Draw`. Here's a basic template:

```csharp
using Microsoft.Xna.Framework;

namespace MonoZenith;

public partial class Game
{
    /* Initialize game vars and load assets. */
    public void Init()
    {
        
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        
    }
}
```

### Setting up the screen
Modify screen properties using helper methods in the `Init` method:

```csharp
/* Initialize game vars and load assets. */
public void Init()
{
   SetScreenSize(800, 600);
   SetBackgroundColor(Color.White);
   SetWindowTitle("My game");     
}
```
### Loading assets
Load assets from the `Content` folder using provided methods:

```csharp
Texture2D myImage;
SoundEffect mySound;
SpriteFont myFont;

/* Initialize game vars and load assets. */
public void Init()
{
   myImage = LoadImage("Textures/myImage.png");
   mySound = LoadSound("Audio/mySound.wav");
   myFont = LoadFont("myFont");
}
```

### Using assets
Incorporate assets into your game's logic and rendering:
    
```csharp
/* Update game logic. */
public void Update(GameTime deltaTime)
{
   if (GetKeyDown(Keys.Space))
   {
      mySound.Play();
   }
}

/* Draw objects/backdrop. */
public void Draw()
{
   DrawImage(myImage, new Vector2(100, 100));
   DrawText("Hello world!", myFont, new Vector2(100, 100), Color.Black);
}
```

### Initializing & using UI components
Initialize UI components in the `Init` method. Update and draw them in the `Update` and `Draw` methods, respectively:

```csharp
Button myButton;
    
/* Initialize game vars and load assets. */
public void Init()
{
    SetScreenSize(800, 600);
    SetBackgroundColor(Color.White);
    
    // Initialize button
    myButton = new Button(
        this,                          // Game reference
        new Vector2(400, 300),         // Position
        400, 100,                      // Width, Height
        "Click me!", 2, Color.White,   // Text, Font Size, Text Color
        Color.Black,                   // Button Color
        3, Color.Red);                 // Border Width, Border Color
    }

/* Update game logic. */
public void Update(GameTime deltaTime)
{
    myButton.Update(deltaTime);
    myButton.SetOnClickAction(() => DebugLog("UwU"));
}
    
/* Draw objects/backdrop. */
public void Draw()
{
    myButton.Draw();
}
```

### Colliders
Colliders are used to detect collisions between objects. They can be initialized in the `Init` method and updated in the `Update` method. 
Besides, they can be drawn in the `Draw` method for debugging purposes:

```csharp
/* Initialize game vars and load assets. */
public void Init()
{
    SetScreenSize(800, 600);
        
    // Create position for collider c
    pos = new Vector2(100, 0);
        
    // Setup colliders
    c = new Collider(this, pos, 50, 50);
    c2 = new Collider(this, new Vector2(100, 100), 50, 50);
}

/* Update game logic. */
public void Update(GameTime deltaTime)
{
    // Stop if c collides with c2
    if (c.CollidesWith(c2))
    {
        return;
    }
        
    // Move c down
    pos.Y += 0.5f;
    c.Update(pos);
}
    
/* Draw objects/backdrop. */
public void Draw()
{
    // Draw colliders
    c.Draw();
    c2.Draw();
}
```

### Particle system
The particle system is used to create particle effects. It makes use of the `ParticleManager` class, which is initialized 
in the `Init` method. Particles are updated in the `Update` method and drawn in the `Draw` method:

```csharp
private ParticleManager _particleManager;
    
/* Initialize game vars and load assets. */
public void Init()
{
    SetScreenSize(800, 600);
    SetBackgroundColor(Color.White);
    _particleManager = new ParticleManager(this);
}

/* Update game logic. */
public void Update(GameTime gameTime)
{
    _particleManager.CreateParticle(
        null, 
        new Vector2(400, 300), 
        new Vector2(0, -1), 
        Color.Black, 
        5, 
        3);
    _particleManager.Update(gameTime);
}

/* Draw objects/backdrop. */
public void Draw()
{
    _particleManager.Draw();
}
```
To create custom particles (recommended), create a class that inherits from `Particle`. Then, override the `Update`
method to define the particle's behavior:

```csharp
public class MyParticle : Particle
{
    public MyParticle(Game game, Texture2D texture, Vector2 position, Vector2 velocity, Color color, float scale, float lifeTime) 
        : base(game, texture, position, velocity, color, scale, lifeTime)
    {
    }

    public override void Update(GameTime gameTime)
    {
        // Define particle behavior here
    }
}
```

### Tilemap reading
Reading tilemaps is not built into MonoZenith. However, for reading tilemaps, the framework TiledSharp is recommended.
An example of reading a tilemap using TiledSharp is provided [here](https://github.com/Temeez/TiledSharp-MonoGame-Example/blob/master/TiledSharp%20MonoGame%20Example/Game1.cs).

## Known issues
- Only the "pixel.ttf" font can be used due to conversion limitations. This will be addressed in the future.
- At the moment, the assets need to be placed inside the `Content` folder within the `bin` folder. This is not the intended 
behavior, and will be addressed in the future.
- Particle transparency only works with light backdrops. This will be addressed in the future.

## Maintenance
This project is maintained by [Nick Jordan](https://www.linkedin.com/in/nick-jordan-11247bba/).
For questions, suggestions, or inquiries, [contact](mailto:nickjordan2002@gmail.com) me.

