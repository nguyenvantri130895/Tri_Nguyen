using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo._GameOver
{
    class GameOverMenuButton
    {
        Texture2D texture2D;
        Vector2 position;
        Rectangle sourceRectangle = new Rectangle(0, 0, 200, 70);
        Rectangle path;
        float scale = 0;
        public event Action IsClicked;
        public GameOverMenuButton(Texture2D texture2D, Vector2 position)
        {
            this.texture2D = texture2D;
            this.position = position;
            this.path = new Rectangle((int)this.position.X - 100, (int)this.position.Y - 35, 190, 60);
        }
        public void Reset()
        {
            this.scale = 0;          
        }
        public void Update()
        {
            if (scale >= 1)
            {
                Rectangle mouse = new Rectangle(Game1.CurrentMouseState.X, Game1.CurrentMouseState.Y,
                    1, 1);
                if (mouse.Intersects(this.path))
                {
                    this.sourceRectangle.X = 200;
                    if (Game1.CurrentMouseState.LeftButton == ButtonState.Pressed &&
                        Game1.OldMouseState.LeftButton == ButtonState.Released)
                        this.IsClicked();
                }
                else
                    this.sourceRectangle.X = 0;
            }
            else
                scale = (float)Math.Round(scale + 0.05f, 2);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (scale > 0)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(this.texture2D, this.position, this.sourceRectangle, Color.White * this.scale,
                    1f - scale, new Vector2(100, 35), this.scale, 0, 0);
                spriteBatch.End();
            }
        }
    }
}
