using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo._Caterpillar;
using Microsoft.Xna.Framework.Graphics;

namespace Demo
{
    static class Caterpillar
    {
        public static int Speed ;
        public static List<CaterpillarPiece> ListCaterpillarPiece;
        public static CaterpillarPiece Head { get { return ListCaterpillarPiece[0]; } }
        static public void LoadContent(ContentManager content)
        {
            CaterpillarPiece.LoadContent(content);
            ListCaterpillarPiece = new List<CaterpillarPiece>();
        }
        public static void Reset(Vector2 position)
        {
            while (ListCaterpillarPiece.Count != 0)
                ListCaterpillarPiece.RemoveAt(0);
            ListCaterpillarPiece.Add(new CaterpillarPiece(position,
                Direction.Right, CaterpillarPiece.Type.Head));
            ListCaterpillarPiece.Add(new CaterpillarPiece(position - new Vector2(24, 0),
                Direction.Right, CaterpillarPiece.Type.Body));
            ListCaterpillarPiece.Add(new CaterpillarPiece(position - new Vector2(48, 0),
                Direction.Right, CaterpillarPiece.Type.Tail));
            Speed = 2;
        }
        public static void AddTail()
        {
            ListCaterpillarPiece.Last().SetTypeIsBody();
            switch(ListCaterpillarPiece.Last().Direction)
            {
                case Direction.Up:
                    ListCaterpillarPiece.Add(new CaterpillarPiece(ListCaterpillarPiece.Last().Position + new Vector2(0, 24),
                        ListCaterpillarPiece.Last().Direction, CaterpillarPiece.Type.Tail));
                    break;
                case Direction.Down:
                    ListCaterpillarPiece.Add(new CaterpillarPiece(ListCaterpillarPiece.Last().Position - new Vector2(0, 24),
                        ListCaterpillarPiece.Last().Direction, CaterpillarPiece.Type.Tail));
                    break;
                case Direction.Left:
                    ListCaterpillarPiece.Add(new CaterpillarPiece(ListCaterpillarPiece.Last().Position + new Vector2(24, 0),
                        ListCaterpillarPiece.Last().Direction, CaterpillarPiece.Type.Tail));
                    break;
                case Direction.Right:
                    ListCaterpillarPiece.Add(new CaterpillarPiece(ListCaterpillarPiece.Last().Position - new Vector2(24, 0),
                        ListCaterpillarPiece.Last().Direction, CaterpillarPiece.Type.Tail));
                    break;
                default:
                    break;
            }
        }
        public static void IncreaseSpeed()
        {
            Speed ++;  
        }

        public static void MaxSpeed()
        {
            Speed = Speed + 0;
        }

        public static bool IsHurted(List<Rectangle> wall)
        {
            for (int i = 1; i < ListCaterpillarPiece.Count; i++)
                if (ListCaterpillarPiece[i].Path.Intersects(ListCaterpillarPiece[0].Path))
                    return true;
            foreach (Rectangle _wall in wall)
                if (_wall.Intersects(ListCaterpillarPiece[0].Path) ||
                    _wall.Intersects(ListCaterpillarPiece.Last().Path))
                    return true;
            return false;
        }
        private static void Move(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Up))
                ListCaterpillarPiece[0].ListWaitPoint.Add(new WaitPoint(ListCaterpillarPiece[0].Position,
                    Direction.Up));
            else if (keyboardState.IsKeyDown(Keys.Down))
                ListCaterpillarPiece[0].ListWaitPoint.Add(new WaitPoint(ListCaterpillarPiece[0].Position,
                    Direction.Down));
            else if (keyboardState.IsKeyDown(Keys.Left))
                ListCaterpillarPiece[0].ListWaitPoint.Add(new WaitPoint(ListCaterpillarPiece[0].Position,
                    Direction.Left));
            else if (keyboardState.IsKeyDown(Keys.Right))
                ListCaterpillarPiece[0].ListWaitPoint.Add(new WaitPoint(ListCaterpillarPiece[0].Position,
                    Direction.Right));
            for (int i = 0; i < ListCaterpillarPiece.Count - 1; i++)
                    ListCaterpillarPiece[i].Move(Speed, ListCaterpillarPiece[i + 1]);
            ListCaterpillarPiece.Last().Move(Speed, null);

        }
        public static void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            for (int i = 0; i < ListCaterpillarPiece.Count - 1; i++)
                ListCaterpillarPiece[i].Update(gameTime);
            ListCaterpillarPiece.Last().Update(gameTime);
            Move(keyboardState);
           
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = ListCaterpillarPiece.Count; i > 0; i--)
                ListCaterpillarPiece[i - 1].Draw(spriteBatch);
        }
    }
}
