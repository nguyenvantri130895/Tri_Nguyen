using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    class Play : DrawableGameComponent
    {
        public static Wall Wall;
        static float elapsed = 0;
        static int scored = 0;
        public static int Score;
        public Play(Game1 game) : base(game) { }
        protected override void LoadContent()
        {
            Wall = new Wall(Game.Content);
            Score = 0;
            base.LoadContent();
        }
        public static void Reset()
        {
            elapsed = 0;
            scored = 0;
            Caterpillar.Reset(new Vector2(400, 300));
        }
        private static void IncreaseScore(int score)
        {
            SoundManager.Scored.Play();
            while (score > 0)
            {
                scored++;
                if (scored < 51)     
                {
                    if (scored % 5 == 0)
                        Caterpillar.IncreaseSpeed();                   
                }
                else
                {
                    Caterpillar.MaxSpeed();
                }
                score--;
            }
            Caterpillar.AddTail();
        }
        public override void Update(GameTime gameTime)
        {
            if (Game1.CurrentGameState == GameState.Play)
            {
                KeyboardState keyboardState = Keyboard.GetState();       
                    Food.Update(gameTime);
                    Caterpillar.Update(gameTime, keyboardState);
                    
                    if (Caterpillar.Head.Path.Intersects(Food.Path))
                    {
                        IncreaseScore(1);
                        Food.ChangePosition(Wall.ListWall);                        
                    }
                    
                    if (Caterpillar.IsHurted(Wall.ListWall) )
                    {
                        Game1.CurrentGameState = GameState.GameOver;
                        Score = scored;
                        SoundManager.SoundEffectPause();
                        MediaPlayer.Play(SoundManager.GameOver);
                        if(scored>Game1.HighScore)
                            Game1.HighScore = scored; 
                    } 
            }
            if (scored > Score)
            {
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed > 10)
                {
                    Score++;
                    elapsed = 0;
                }
            }
            else if (scored < Score)
                Score = 0;
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (Game1.CurrentGameState == GameState.Play)
            {
                SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
                Wall.Draw(spriteBatch);
                Food.Draw(spriteBatch);
                Caterpillar.Draw(spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
