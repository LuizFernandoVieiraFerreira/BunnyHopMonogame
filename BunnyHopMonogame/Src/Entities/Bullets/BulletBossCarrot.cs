using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Bullets {

    public class BulletBossCarrot : Bullet {

        public Sprite sp;

        public BulletBossCarrot(int x=0, int y=0) {
            sp = new Sprite("bullet_boss_meca", 4, 0.2f);
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {
            box.Y += 1;
            sp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("Tile")) {
                isActive = false;
            }
        }

        public override bool Is(string type) {
            return type.Equals("EnemyBullet");
        }

    }

}
