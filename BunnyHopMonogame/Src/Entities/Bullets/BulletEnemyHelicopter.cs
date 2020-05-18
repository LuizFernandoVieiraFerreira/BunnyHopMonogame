using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Bullets {

    public class BulletEnemyHelicopter : Bullet {

        public Sprite sp;

        public BulletEnemyHelicopter(int x=0, int y=0) {
            sp = new Sprite("bullet_enemy_helicopter", 4, 0.3f);
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {
            box.X -= 2;
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
