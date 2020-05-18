using System;
using Microsoft.Xna.Framework;

namespace BunnyHopMonogame.Src {

    public static class Collision {

        public static bool IsColliding(Rectangle a, Rectangle b) {
            return a.X < b.X + b.Width && a.X + a.Width > b.X && a.Y < b.Y + b.Height && a.Y + a.Height > b.Y;
        }

    }

}
