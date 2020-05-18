using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Bullets {

    public class BulletBossMeca : Bullet {

        public Sprite sp;

        public BulletBossMeca(int x = 0, int y = 0, int w = 0, int h = 0) {
            sp = new Sprite("bullet_boss_meca", 4, 0.2f);
            box = new Rectangle(x, y, w, h);
        }

        public override void Update(GameTime gameTime) {
            box.X -= 1;
            sp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("CameraBoundry")) {
                isActive = false;
            }
        }

        public override bool Is(string type) {
            return type.Equals("EnemyBullet");
        }

    }

}
