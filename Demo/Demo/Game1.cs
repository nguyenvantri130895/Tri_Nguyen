using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Demo
{
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;
            MediaPlayer.IsRepeating = true;
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            this.Components.Add(new MainMenu(this));
            this.Components.Add(new Play(this));
            this.Components.Add(new ScorePanel(this));
            this.Components.Add(new GameOver(this));
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            Font1 = Content.Load<SpriteFont>("Font/Font1");
            Food.LoadContent(this.Content);
            Caterpillar.LoadContent(this.Content);
            SoundManager.LoadContent(this.Content);          
            this.MainMenuButton();
            this.GameOverMenuButton();
            if (SoundManager.IsEnabled)
                MediaPlayer.Play(SoundManager.MainMenu);
        }
        protected override void UnloadContent()
        {}
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            OldMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
            SoundButton.Update();
           
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(this.Content.Load<Texture2D>("Background"), GraphicsDevice.Viewport.Bounds, Color.White);
            if (Game1.CurrentGameState == GameState.Play)
                spriteBatch.Draw(this.Content.Load<Texture2D>("Game"), GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
            SoundButton.Draw(this.spriteBatch);
           
        }
    }
}
