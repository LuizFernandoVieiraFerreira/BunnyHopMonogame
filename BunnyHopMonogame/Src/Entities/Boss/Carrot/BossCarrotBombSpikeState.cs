using System;
using BunnyHopMonogame.Src.Entities.Bullets;
using BunnyHopMonogame.Src.Entities.Spikes;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Carrot {

    public class BossCarrotBombSpikeState : BossCarrotState {    

        public override void Update(GameTime gameTime) {
            boss.ShootTimer.Update(gameTime);

            if (boss.ShootTimer.GetAsSeconds() > boss.ShootCooldown) {
                boss.CanShoot = true;
            }

            if (boss.CanShoot) {
                Shoot();
                Spike();
                boss.CanShoot = false;
                boss.ShootTimer.Restart();
            }

            if (boss.Life <= 0) {
                boss.ShootTimer.Restart();
                stateMachine.ChangeState(new BossCarrotDyingState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            boss.spikeSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
        }

        private void Shoot() {
            StateLocator.State.AddObject(new BulletBossCarrot(boss.box.X - 50, 16));
            StateLocator.State.AddObject(new BulletBossCarrot(boss.box.X - 100, 16));
            StateLocator.State.AddObject(new BulletBossCarrot(boss.box.X - 150, 16));
            StateLocator.State.AddObject(new BulletBossCarrot(boss.box.X - 200, 16));
        }

        private void Spike() {
            StateLocator.State.AddObject(new SpikeBossCarrot(boss.box.X - 50, 16 * 8));
            StateLocator.State.AddObject(new SpikeBossCarrot(boss.box.X - 100, 16 * 8));
            StateLocator.State.AddObject(new SpikeBossCarrot(boss.box.X - 150, 16 * 8));
            StateLocator.State.AddObject(new SpikeBossCarrot(boss.box.X - 200, 16 * 8));
        }

    }

}
