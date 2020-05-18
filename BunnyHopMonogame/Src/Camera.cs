using System;
using Microsoft.Xna.Framework;

namespace BunnyHopMonogame.Src {

    public class Camera {

        public Rectangle box;

        public Camera(int x=0, int y=0) {
            box = new Rectangle(0, 0, 160, 144);
        }

    }

}
