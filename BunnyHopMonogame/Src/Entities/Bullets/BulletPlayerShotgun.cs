using System;
using BunnyHopMonogame.Src.Entities;
using BunnyHopMonogame.Src.Entities.Bullets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entitis.Bullets {

    public class BulletPlayerShotgun : Bullet {

        public Sprite sp;

        public BulletPlayerShotgun() {
            sp = new Sprite("bullet_player_shotgun");
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
