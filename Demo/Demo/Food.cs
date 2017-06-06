using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    static class Food
    {
        static Random random = new Random();
        static Texture2D texture2D;
        static Vector2 position = Vector2.Zero;
        static Rectangle sourceRectangle = new Rectangle(0, 0, 40, 40);
        public static Rectangle Path;
        static float elapsed;
        static float delay;
        static int type;
        static int frame;
        public static void LoadContent(ContentManager content)
        {
            texture2D = content.Load<Texture2D>("Food");
        }
        private static bool CheckWall(List<Rectangle> wall)
        {
            foreach (Rectangle _path in wall)
                if (_path.Intersects(Path))
                    return true;
            return false;
        }
        public static void ChangePosition(List<Rectangle> wall)
        {
            do
            {
                position = new Vector2(random.Next(680 + 1) + 60, random.Next(445 + 1) + 95);
                Path = new Rectangle((int)position.X - 21, (int)position.Y - 21, 42, 42);
            } while ( CheckWall(wall));
            type = new Random().Next(5);
            sourceRectangle.X = 0;
            sourceRectangle.Y = type * 40;
            frame = 0;
            elapsed = 0;
            delay = 2000;
        }
        private static void Amination(GameTime gameTime)
        {
            if (delay < 0)
            {
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed > 80)
                {
                    if (frame == 0)
                        SoundManager.Food.Play();
                    frame++;                  
                    if (frame > 9)
                    {
                        frame = 0;
                        delay = 3000;
                    }
                    sourceRectangle.X = frame * 40;
                    elapsed = 0;
                }
            }
            else
                delay -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
        public static void Update(GameTime gameTime)
        {
            Amination(gameTime);
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture2D, position, sourceRectangle, Color.White,
                0, new Vector2(20, 20), 1, 0, 0);
            spriteBatch.End();
        }
    }
}
