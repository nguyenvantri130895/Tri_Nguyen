using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo._MainMenu;

namespace Demo
{
    class MainMenu:DrawableGameComponent
    {
        
        public static MainMenuButton PlayButton;
        
        public static MainMenuButton ExitButton;    
        public MainMenu(Game1 game) : base(game) { }
        protected override void LoadContent()
        {
            
            PlayButton = new MainMenuButton(Game.Content.Load<Texture2D>("MainMenu/PlayButton"), new Vector2(650, 310));
            
            ExitButton = new MainMenuButton(Game.Content.Load<Texture2D>("MainMenu/ExitButton"), new Vector2(650, 380));
        }
        public override void Update(GameTime gameTime)
        {
            if (Game1.CurrentGameState == GameState.MainMenu)
            {
                MouseState mouseState = Mouse.GetState();
                    PlayButton.Update();
                    ExitButton.Update();
                    base.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            if (Game1.CurrentGameState == GameState.MainMenu)
            {
                SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
                
                    PlayButton.Draw(spriteBatch);
                    
                    ExitButton.Draw(spriteBatch);
                
                spriteBatch.Begin();
                spriteBatch.DrawString(Game1.Font1, "Top Score:",
                    new Vector2(0, 300), Color.Black );
                spriteBatch.DrawString(Game1.Font1, Game1.HighScore.ToString(),
                    new Vector2(200, 350), Color.Black );
                spriteBatch.End();
            }            
            base.Draw(gameTime);
        }
    }
}
