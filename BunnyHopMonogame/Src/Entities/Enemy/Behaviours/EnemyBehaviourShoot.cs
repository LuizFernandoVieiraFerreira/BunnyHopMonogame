using System;
using BunnyHopMonogame.Src.Entities.Bullets;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;

namespace BunnyHopMonogame.Src.Entities.Enemy.Behaviours {

    public class EnemyBehaviourShoot : EnemyBehaviour {

        Entity entity;

        bool canShoot;
        float shootCooldown;
        Timer shootTimer;

        public override void Setup(Entity entity, TiledMapObject i) {
            this.entity = entity;
            canShoot = true;
            shootCooldown = 2;
            shootTimer = new Timer();
        }

        public override void Update(GameTime gameTime) {
            shootTimer.Update(gameTime);

            if (shootTimer.GetAsSeconds() > shootCooldown) {
                canShoot = true;
            }

            if (canShoot) {
                Shoot();
                canShoot = false;
                shootTimer.Restart();
            }
        }

        private void Shoot() {
            StateLocator.State.AddObject(new BulletEnemyHelicopter(entity.box.X, entity.box.Y));
        }

    }

}
