using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    class ScorePanel : DrawableGameComponent
    {
        static Texture2D texture2D;
        static Vector2 position = new Vector2(790, 0);
        public ScorePanel(Game1 game) : base(game) { }
        protected override void LoadContent()
        {
            texture2D = Game.Content.Load<Texture2D>("ScorePanel");
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {            
            if (Game1.CurrentGameState == GameState.Play )
            {
                SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
                spriteBatch.Begin();
                spriteBatch.Draw(texture2D, position, texture2D.Bounds, Color.White,
                            0, new Vector2(texture2D.Bounds.Width, 0), 1, 0, 0);
                        spriteBatch.DrawString(Game1.Font1, Play.Score.ToString(),
                            position - new Vector2(Game1.Font1.MeasureString(Play.Score.ToString()).X + 15, 5),Color.White);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
