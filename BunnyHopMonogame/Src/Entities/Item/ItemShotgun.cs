using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Item {

    public class ItemShotgun :Item {

        public Sprite sp;

        public ItemShotgun() {
        }

        public ItemShotgun(int x, int y) {
            sp = new Sprite("antidote");
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {
            sp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("Player")) {
                collected = true;
            }
        }

    }

}
