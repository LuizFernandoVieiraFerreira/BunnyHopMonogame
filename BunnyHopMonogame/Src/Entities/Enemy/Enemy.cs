using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class Enemy : Entity {

        protected int health = 1;

        public Enemy() {
        }

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

        public override void NotifyCollision(Entity go) {

        }

        public override bool IsDead() {
            return health <= 0;
        }

        public override bool Is(string type) {
            return type.Equals("Enemy");
        }

    }

}
