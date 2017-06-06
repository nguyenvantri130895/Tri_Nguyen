using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo._Caterpillar
{
    class CaterpillarPiece
    {
        public enum Type
        {
            Head = 0,
            Body = 1,
            Tail = 2
        }
        static Texture2D texture2D;
        public Vector2 Position; 
        Rectangle sourceRectangle;
        public Rectangle Path;
        public Direction Direction;
        public List<WaitPoint> ListWaitPoint = new List<WaitPoint>();
        Type type;
        float deplay = 300;
        public static void LoadContent(ContentManager content)
        {
            texture2D = content.Load<Texture2D>("Caterpillar/CaterpillarPeice");
        }
        public CaterpillarPiece(Vector2 postion,Direction direction,CaterpillarPiece.Type type)
        {
            this.Position = postion;
            this.Direction = direction;
            this.type = type;
            this.sourceRectangle = new Rectangle(24,  24, 24, 24);
        }
       
        public void SetTypeIsBody()
        {
            this.type = Type.Body;
            this.sourceRectangle.Y = 24;
        }
        private bool ChangeDirection()
        {
            if (this.ListWaitPoint.Count > 0 && this.Position == this.ListWaitPoint[0].Position)
            {
                this.Direction = this.ListWaitPoint[0].Direction;
                return true;
            }
            else
                return false;
        }
        public void Move(int speed, CaterpillarPiece behindPiece)
        {           
            while (speed > 0)
            {
                if (this.ChangeDirection())
                {
                    if (behindPiece != null)
                        behindPiece.ListWaitPoint.Add(this.ListWaitPoint[0]);
                    this.ListWaitPoint.RemoveAt(0);
                }
                switch (this.Direction)
                {
                    case Direction.Up:
                        this.Position -= new Vector2(0, 1);
                        break;
                    case Direction.Down:
                        this.Position += new Vector2(0, 1);
                        break;
                    case Direction.Left:
                        this.Position -= new Vector2(1, 0);
                        break;
                    case Direction.Right:
                        this.Position += new Vector2(1, 0);
                        break;
                }
                speed--;
            }
            this.Path = this.Path = new Rectangle((int)this.Position.X - 6, (int)this.Position.Y - 6, 12, 12);
        }
        public void Update(GameTime gameTime)
        {
            if (this.deplay < 0)
            {
                if (this.sourceRectangle.X < 48)
                    this.sourceRectangle.X += 24;
                else
                    this.sourceRectangle.X = 0;
                this.deplay = 300;
            }
            else
                this.deplay -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(CaterpillarPiece.texture2D, this.Position, this.sourceRectangle, Color.White,
                MathHelper.ToRadians((float)this.Direction), new Vector2(12, 12), 1, 0, 0);
            spriteBatch.End();
        }
    }
}
