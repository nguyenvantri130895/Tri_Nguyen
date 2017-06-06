using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo._GameOver;

namespace Demo
{
    class GameOver : DrawableGameComponent
    {
        static Texture2D texture2D;
        static Vector2 position=new Vector2(400,150);
        public GameOver(Game1 game) : base(game) { }
        protected override void LoadContent()
        {
            texture2D = Game.Content.Load<Texture2D>("GameOver/GameOver");
            GameOverMenu.LoadContent(Game.Content);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            GameOverMenu.Update();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (Game1.CurrentGameState == GameState.GameOver)
            {
                SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
                spriteBatch.Begin();
                spriteBatch.Draw(texture2D, position, texture2D.Bounds, Color.White,
                    0, new Vector2(texture2D.Bounds.Width /2, texture2D.Bounds.Height / 2),
                    1, 0, 0);
                spriteBatch.End();
                GameOverMenu.Draw(spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
