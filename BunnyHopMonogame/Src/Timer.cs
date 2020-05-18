using System;
using Microsoft.Xna.Framework;

namespace BunnyHopMonogame.Src {

    public class Timer {

        float time;

        public Timer() {
            Restart();
        }

        public void Update(GameTime gameTime) {
            time += gameTime.ElapsedGameTime.Milliseconds;
        }

        public void Restart() {
            time = 0;
        }

        public float Get() {
            return time;
        }

        public float GetAsSeconds() {
            return time / 1000;
        }

    }

}
