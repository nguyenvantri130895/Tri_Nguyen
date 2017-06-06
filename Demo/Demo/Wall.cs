
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    class Wall
    {
        static Random random = new Random();
        static Texture2D wallTexture2D;
        List<int> catusType = new List<int>();
        public List<Rectangle> ListWall{get;private set;}
        public Wall(ContentManager content)
        {
            wallTexture2D = content.Load<Texture2D>("Wall/Wall");
            this.ListWall = new List<Rectangle>();
            this.ListWall.Add(new Rectangle(0, 0, 800, 60));
            this.ListWall.Add(new Rectangle(0, 565, 800, 35));
            this.ListWall.Add(new Rectangle(0, 70, 35, 505));
            this.ListWall.Add(new Rectangle(765, 70, 35, 505));
        }
        private void Reset()
        {
            while (ListWall.Count > 4)
                ListWall.RemoveAt(ListWall.Count - 1);
            while (catusType.Count > 0)
                catusType.RemoveAt(0);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(wallTexture2D, wallTexture2D.Bounds, Color.White);
            spriteBatch.End();
        }
    }
}
