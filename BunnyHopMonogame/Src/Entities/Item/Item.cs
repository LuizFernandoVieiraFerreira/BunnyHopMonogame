using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Item {

    public class Item : Entity {

        protected bool collected = false;

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

        public override void NotifyCollision(Entity go) {

        }

        public override bool IsDead() {
            return collected;
        }

        public override bool Is(string type) {
            return type.Equals("Item");
        }

    }

}
