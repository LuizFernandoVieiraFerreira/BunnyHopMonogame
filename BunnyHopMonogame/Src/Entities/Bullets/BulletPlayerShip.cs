using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Bullets {

    public class BulletPlayerShip : Bullet {

        public Sprite sp;

        public BulletPlayerShip(int x=0, int y=0) {
            sp = new Sprite("player_ship_bullet");
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {
            box.X += 2;
            sp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("CameraBoundry") || go.Is("Enemy") || go.Is("BossMeca")) {
                isActive = false;
            }
        }

    }

}
