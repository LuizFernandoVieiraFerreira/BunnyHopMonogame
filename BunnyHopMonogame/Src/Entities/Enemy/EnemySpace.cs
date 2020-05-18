using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemySpace : Enemy {

        public Sprite sp;

        public EnemySpace(int x, int y) {
            health = 2;
            sp = new Sprite("enemy_space", 3, 1);
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {
            sp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("Bullet")) {
                health -= 1;
            }
        }

    }

}
