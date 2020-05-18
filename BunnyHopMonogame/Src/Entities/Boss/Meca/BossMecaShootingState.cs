using System;
using BunnyHopMonogame.Src.Entities.Bullets;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Meca {

    public class BossMecaShootingState : BossMecaState {

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

            if (boss.Life <= 10) {
                stateMachine.ChangeState(new BossMecaShootingWalkingState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            boss.flyingOpenedSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
        }

        private void Shoot() {
            if (boss.FirstBulletPattern) {
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y));
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y - 50));
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y - 100));
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y - 150));
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y - 200));
            } else {
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y - 30));
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y - 80));
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y - 130));
                StateLocator.State.AddObject(new BulletBossMeca(boss.box.X, boss.box.Y - 180));
            }
            boss.FirstBulletPattern = !boss.FirstBulletPattern;
        }

    }

}
