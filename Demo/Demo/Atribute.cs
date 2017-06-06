using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    public enum GameState
    {
        MainMenu,
        Play,
        GameOver,
    }
    public partial class Game1
    {
        public static GameState CurrentGameState = GameState.MainMenu;
        public static SpriteFont Font1;
        public static MouseState OldMouseState;
        public static MouseState CurrentMouseState;
        public static int HighScore = 0;
    }
    
}
