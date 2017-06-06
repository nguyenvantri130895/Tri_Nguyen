using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo._Caterpillar
{
    class WaitPoint
    {
        public Vector2 Position;
        public Direction Direction;
        public WaitPoint(Vector2 position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
        }
    }
}
