using System;
using BunnyHopMonogame.Src.Entities.Bullets;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Carrot {

    public class BossCarrotBombState : BossCarrotState {

        public override void Update(GameTime gameTime) {
            boss.ShootTimer.Update(gameTime);

            if (boss.ShootTimer.GetAsSeconds() > boss.ShootCooldown) {
                boss.CanShoot = true;
            }

            if (boss.CanShoot) {
                Shoot();
                boss.CanShoot = false;
                boss.ShootTimer.Restart();
            }

            if (boss.Life <= 1) {
                boss.ShootTimer.Restart();
                stateMachine.ChangeState(new BossCarrotSpikeState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            boss.bombSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
        }

        private void Shoot() {
            StateLocator.State.AddObject(new BulletBossCarrot(boss.box.X - 50, 16));
            StateLocator.State.AddObject(new BulletBossCarrot(boss.box.X - 100, 16));
            StateLocator.State.AddObject(new BulletBossCarrot(boss.box.X - 150, 16));
            StateLocator.State.AddObject(new BulletBossCarrot(boss.box.X - 200, 16));
        }

    }
}
