using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo._GameOver;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Demo
{

    public partial class Game1
    {
        void MainMenuButton()
        {
            MainMenu.PlayButton.IsClicked += () =>
                {
                    SoundManager.Button.Play();
                    Play.Reset();
                    CurrentGameState = GameState.Play;
                    Food.ChangePosition(Play.Wall.ListWall);
                    MediaPlayer.Play(SoundManager.Play);
                };
            
            MainMenu.ExitButton.IsClicked += () => this.Exit();
        }
       
        void GameOverMenuButton()
        {
            GameOverMenu.MainMenuButton.IsClicked += () =>
            {
                SoundManager.Button.Play();
                CurrentGameState = GameState.MainMenu;
                GameOverMenu.Reset();
                MediaPlayer.Play(SoundManager.MainMenu);
            };
            GameOverMenu.ExitButton.IsClicked += () => this.Exit();
        }  
    }
}
