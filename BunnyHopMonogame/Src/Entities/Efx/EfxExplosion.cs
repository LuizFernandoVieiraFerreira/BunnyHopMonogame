using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Efx {

    public class EfxExplosion : Entity {

        private Sprite sp;
        private Timer timer;
        private float timeToLive;

        public EfxExplosion(int x, int y) {
            sp = new Sprite("efx_explosion", 7, 0.3f);
            box = new Rectangle(x, y, sp.Width, sp.Height);
            timer = new Timer();
            timeToLive = 2.1f;
        }

        public override void Update(GameTime gameTime) {
            sp.Update(gameTime);
            timer.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
        }

        public override bool IsDead() {
            return timer.Get()/1000 > timeToLive;
        }

        public override void NotifyCollision(Entity go) {

        }

        public override bool Is(string type) {
            return type.Equals("Efx");
        }

    }

}
