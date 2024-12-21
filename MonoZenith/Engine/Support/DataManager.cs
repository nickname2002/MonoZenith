using Microsoft.Xna.Framework.Graphics;
using static MonoZenith.Game;

namespace MonoZenith.Engine.Support
{
    public class DataManager
    {
        private static DataManager _instance;
        
        // Fonts
        public SpriteFont ComponentFont;
        
        // Textures
        public Texture2D MonoZenithLogo;
        
        // Audio

        private DataManager()
        {
            LoadData();
        }

        /// <summary>
        /// Get the instance of the DataManager.
        /// </summary>
        /// <returns>The DataManager instance.</returns>
        public static DataManager GetInstance()
        {
            return _instance ??= new DataManager();
        }

        private void LoadFonts()
        {
            ComponentFont = LoadFont("Fonts/pixel.ttf", 1);
        }
        
        private void LoadTextures()
        {
            MonoZenithLogo = LoadImage("Images/monozenith.png");
        }
        
        private void LoadSoundEffects()
        {
            
        }
        
        /// <summary>
        /// Load all data.
        /// </summary>
        private void LoadData()
        {
            LoadFonts();
            LoadTextures();
            LoadSoundEffects();
        }
    }
}