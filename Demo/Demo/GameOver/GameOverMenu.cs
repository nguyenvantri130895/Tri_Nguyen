using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo._GameOver
{
    static class GameOverMenu
    {
        public static GameOverMenuButton MainMenuButton { get; private set; }
        public static GameOverMenuButton ExitButton { get; private set; }
        public static void LoadContent(ContentManager content)
        {
            MainMenuButton = new GameOverMenuButton(content.Load<Texture2D>("GameOver/MainMenuButton"),
                new Vector2(400, 280));
            ExitButton = new GameOverMenuButton(content.Load<Texture2D>("GameOver/ExitButton"),
                new Vector2(400, 360));
        }
        public static void Reset()
        {
            MainMenuButton.Reset();
            ExitButton.Reset();
        }
        public static void Update()
        {
            MainMenuButton.Update();
            ExitButton.Update();                
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            MainMenuButton.Draw(spriteBatch);
            ExitButton.Draw(spriteBatch);
        }
    }
}
