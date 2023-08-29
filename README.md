# MonoZenith
MonoZenith is a wrapper for MonoGame, with the goal to make developing games using C# a 
faster process. Initially, MonoZenith was developed for personal use, but I decided to make 
it public to make it easier for others to develop games using MonoGame. **MonoZenith is still
in development, and is not yet ready for use in a production environment**.

## Contents
- [Files & folders](#files--folders)
- [Provided helper methods](#provided-helper-methods)
- [Setup](#setup)
- [Usage](#usage)
  - [`Init`, `Update` & `Draw`](#init--update--draw)
  - [Setting up the screen](#setting-up-the-screen)

## Files & folders
- `Program.cs` - This file is the entry point for the MonoZenith application. 
- `Engine.cs` - This file contains the `Engine` class, containing the basic logic for the MonoGame application.
- `Attachment.cs` - This file contains the most logic of the `Game` class. All the helper methods, mostly containing a call to another helper method in the `GameFacade`, can be found in this file.
- `Game.cs` - This file contains the remainder of the `Game` class, which is the base class for all games created using MonoZenith. All gameplay related logic needs to be implemented in this file.
- `GameFacade.cs` - This file contains the `GameFacade` class, which contains properties and complexity used to perform MonoGame activities.
- `Content` - This folder contains all the assets for the MonoGame application. This includes images, fonts, and audio files.
The remainder of the files and folders are used for the MonoGame application, and can be ignored for now.

````
MonoZenith
├── Attachment.cs
├── Content
├─────── Audio
├─────── Fonts
├─────── Textures
├── Engine.cs
├── Game.cs
├── GameFacade.cs
├── Icon.bmp
├── Icon.ico
├── MonoZenith.csproj
├── MonoZenith.sln
├── Program.cs
└── readme.md
````

## Provided helper methods
Currently, the wrapper provides abstractions for MonoGame using the following methods:

### Debugging
- `DebugLog(string msg) : void`

### Window
- `SetBackgroundColor(Color c) : void`
- `SetScreenSize(int w, int h) : void`
- `SetWindowTitle(string t) : void`

### Keyboard & mouse
- `GetKeyDown(Keys key) : bool`
- `GetMouseButtonDown(MouseButtons button) : bool`
- `GetMousePosition() : Point`
- `GetMouseWheelValue() : int`

### Loading assets
- `LoadFont(string font) : SpriteFont`
- `LoadImage(string filepath) : Texture2D`
- `LoadSound(string filepath) : SoundEffect`

### Drawing objects
- `DrawText(string text, SpriteFont font, Vector2 position, Color color, float scale=1, float angle=0) : void`
- `DrawImage(Texture2D image, Vector2 position, float scale=1, float angle=0, bool flipped=false) : void`
- `DrawRectangle(Color color, Vector2 pos, int width, int height) : void`

## Setup
MonoZenith can be set up for your project in two ways.
<br/>The first way is to download the .zip folder of the project on GitHub. 
<br/>The second and recommended way is to fork the project on GitHub, and clone it to your local 
machine. This way, you can build upon the latest build of MonoZenith. 

## Usage
This section contains some instructions on how to use this template as intended. 

### `Init`, `Update` & `Draw`
The three basic methods of the game are `Init`, `Update` and `Draw`.
- The `Init` method is called once, when the game is started. This method is used to initialize
the game, and should be used to load all the assets needed for the game.
- The `Update` method is called every frame, and is used to update the game logic.
- The `Draw` method is called every frame, and is used to draw the necessary objects onto the screen.

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
Initially, the screen size is set to be 300x300 pixels. Besides, the screen has a starting 
background color of black and a title of "MonoZenith". These properties can be changed
using the provided helper methods in the `Game` class.

```csharp
/* Initialize game vars and load assets. */
public void Init()
{
   SetScreenSize(800, 600);
   SetBackgroundColor(Color.White);
   SetWindowTitle("My game");     
}
```
### TODO: Adding assets

### TODO: Example game (inclusion of drawing rectangles)

## Maintenance
This project is maintained by [Nick Jordan](https://www.linkedin.com/in/nick-jordan-11247bba/).
For questions, suggestions, or other inquiries, please [contact](mailto:nickjordan2002@gmail.com) me. 

