using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Spikes {

    public class SpikeBossCarrot : Entity {

        private Sprite sp;

        private Timer timer;
        private float timeToDie;

        public SpikeBossCarrot(int x=0, int y=0) {
            sp = new Sprite("player_flying");
            box = new Rectangle(x, y, sp.Width, sp.Height);
            timer = new Timer();
            timeToDie = 2;
        }

        public override void Update(GameTime gameTime) {
            timer.Update(gameTime);
        }

        public override void NotifyCollision(Entity go) {

        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X, box.Y));
        }

        public override bool IsDead() {
            return timer.GetAsSeconds() > timeToDie;
        }

        public override bool Is(string type) {
            return type.Equals("Bullet");
        }

    }

}
