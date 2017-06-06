using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo._MainMenu
{
    class MainMenuButton
    {
        Texture2D textture2D;
        Vector2 Position;
        Rectangle sourceRectangle;
        Rectangle path;
        public event Action IsClicked;

        public MainMenuButton(Texture2D texture, Vector2 position)
        {
            this.textture2D = texture;
            this.Position = position;
            this.sourceRectangle = new Rectangle(0, 0, 200, 50);
            this.path = new Rectangle((int)this.Position.X , (int)this.Position.Y, 120, 40);
        }
        public bool IsMouseOver()
        {
            Rectangle mouse = new Rectangle(Game1.CurrentMouseState.X, Game1.CurrentMouseState.Y,
                1, 1);
            if (mouse.Intersects(this.path))
                return true;
            else
                return false;
        }
        public void Update()
        {
            if (this.IsMouseOver())
            {
                this.sourceRectangle.X = 200;
                if (Game1.CurrentMouseState.LeftButton == ButtonState.Pressed &&
                    Game1.OldMouseState.LeftButton == ButtonState.Released)
                    this.IsClicked();
            }
            else
                this.sourceRectangle.X = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this.textture2D, this.Position, this.sourceRectangle, Color.White,
                0, new Vector2(100, 0), 1, 0, 0);
            spriteBatch.End();
        }
    }
}
