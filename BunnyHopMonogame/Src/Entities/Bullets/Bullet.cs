using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Bullets {

    public class Bullet : Entity {

        protected bool isActive = true;

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

        public override void NotifyCollision(Entity go) {

        }

        public override bool IsDead() {
            return !isActive;
        }

        public override bool Is(string type) {
            return type.Equals("Bullet");
        }

    }
}
