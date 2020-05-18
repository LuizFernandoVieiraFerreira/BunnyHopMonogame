using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Bullets {

    public class BulletPlayerMachinegun : Bullet {

        public Sprite sp;

        public BulletPlayerMachinegun() {
            sp = new Sprite("bullet_player_machinegun");
        }

        public override void Update(GameTime gameTime) {

            sp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("CameraBoundry")) {

            }
        }

    }

}
