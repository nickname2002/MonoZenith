using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace MonoZenith;

public partial class Game
{
    SoundEffectInstance wing;

    /* Initialize game vars and load assets. */
    public void Init()
    {
        // wing = LoadAudio("Content/Audio/wing.wav");
    }

    /* Update game logic. */
    public void Update(GameTime deltaTime)
    {
        if (wing != null)
        {
            // Play the audio
            wing.Play();
        }
    }
    
    /* Draw objects/backdrop. */
    public void Draw()
    {
        
    }
}