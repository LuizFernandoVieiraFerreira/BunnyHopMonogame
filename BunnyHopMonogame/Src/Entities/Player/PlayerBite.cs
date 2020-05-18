using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class PlayerBite : Entity {

        private Timer timer;
        private float timeToDie;
        private bool isDead;

        public PlayerBite() {
            timer = new Timer();
            timeToDie = 2;
            isDead = false;
        }

        public override void Update(GameTime gameTime) {
            timer.Update(gameTime);

            if (timer.GetAsSeconds() > timeToDie) {
                isDead = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

        public override void NotifyCollision(Entity go) {

        }

        public override bool IsDead() {
            return isDead;
        }

        public override bool Is(string type) {
            return type.Equals("Bite");
        }

    }

}
