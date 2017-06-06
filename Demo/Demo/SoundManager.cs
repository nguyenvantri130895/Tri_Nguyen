using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
    static class SoundManager
    {
        static bool isEnabled = true;
        public static bool IsEnabled
        {
            get { return isEnabled; }           
            set
            {
                isEnabled = value;
                if (isEnabled)
                {
                    MediaPlayer.IsMuted = false;
                    SoundEffect.MasterVolume = 1;
                }
                else
                {
                    MediaPlayer.IsMuted = true;
                    SoundEffect.MasterVolume = 0;
                }
            }
        }
        public static Song MainMenu
        {
            get;
            private set;
        }
        public static Song Play
        {
            get;
            private set;
        }
        public static Song GameOver
        {
            get;
            private set;
        }
        public static SoundEffectInstance Food
        {
            get;
            private set;
        }
        public static SoundEffectInstance BonusFood_es
        {
            get;
            private set;
        }
        public static SoundEffectInstance BonusFood_ee
        {
            get;
            private set;
        }
        public static SoundEffectInstance Scored
        {
            get;
            private set;
        }
        public static SoundEffectInstance SpeedUp
        {
            get;
            private set;
        }
        public static SoundEffectInstance NextMap
        {
            get;
            private set;
        }
        public static SoundEffectInstance Button
        {
            get;
            private set;
        }
        public static void LoadContent(ContentManager content)
        {
            SoundManager.IsEnabled = true;
            SoundManager.MainMenu = content.Load<Song>("Sound/MainMenu");
            SoundManager.Play = content.Load<Song>("Sound/Play");
            SoundManager.GameOver = content.Load<Song>("Sound/GameOver");
            SoundManager.Food = content.Load<SoundEffect>("Sound/Food").CreateInstance();
            SoundManager.Scored = content.Load<SoundEffect>("Sound/Scored").CreateInstance();
            SoundManager.SpeedUp = content.Load<SoundEffect>("Sound/SpeedUp").CreateInstance();
            SoundManager.NextMap = content.Load<SoundEffect>("Sound/NextMap").CreateInstance();
            SoundManager.Button = content.Load<SoundEffect>("Sound/Button").CreateInstance();
            SoundManager.SpeedUp.IsLooped = true;
            SoundButton.LoadContent(content);
        }
        public static void SoundEffectPause()
        {
            SoundManager.Food.Pause();
            SoundManager.Scored.Pause();
            SoundManager.SpeedUp.Pause();
            SoundManager.NextMap.Pause();
            SoundManager.Button.Pause();
        }
        public static void SoundEffectResume()
        {
            SoundManager.SpeedUp.Resume();
        }
    }
    static class SoundButton
    {
        static Texture2D texture2D;
        static Vector2 position=new Vector2(0,560);
        static Rectangle path = new Rectangle(0, 560, 40, 35);
        public static event Action IsClicked;
        public static void LoadContent(ContentManager content)
        {
            texture2D = content.Load<Texture2D>("Sound/SoundButton");
        }
        public static void Update()
        {
            Rectangle mouse = new Rectangle(Game1.CurrentMouseState.X, Game1.CurrentMouseState.Y, 1, 1);
            if (mouse.Intersects(path))
                if (Game1.CurrentMouseState.LeftButton == ButtonState.Pressed
                    && Game1.OldMouseState.LeftButton == ButtonState.Released)
                    SoundManager.IsEnabled = !SoundManager.IsEnabled;
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (SoundManager.IsEnabled)
                spriteBatch.Draw(texture2D, position, new Rectangle(0, 0, 44, 40), Color.White);
            else
                spriteBatch.Draw(texture2D, position, new Rectangle(44, 0, 44, 40), Color.White);
            spriteBatch.End();
        }
    }
}
