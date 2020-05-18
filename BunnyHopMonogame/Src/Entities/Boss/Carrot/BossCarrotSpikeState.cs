using System;
using BunnyHopMonogame.Src.Entities.Spikes;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Carrot {

    public class BossCarrotSpikeState : BossCarrotState {

        public override void Update(GameTime gameTime) {
            boss.SpikeTimer.Update(gameTime);

            if (boss.SpikeTimer.GetAsSeconds() > boss.SpikeCooldown) {
                boss.CanSpike = true;
            }

            if (boss.CanSpike) {
                Spike();
                boss.CanSpike = false;
                boss.SpikeTimer.Restart();
            }

            if (boss.Life <= 1) {
                boss.SpikeTimer.Restart();
                stateMachine.ChangeState(new BossCarrotBombSpikeState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            boss.spikeSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
        }

        private void Spike() {
            StateLocator.State.AddObject(new SpikeBossCarrot(boss.box.X - 50, 16*8));
            StateLocator.State.AddObject(new SpikeBossCarrot(boss.box.X - 100, 16*8));
            StateLocator.State.AddObject(new SpikeBossCarrot(boss.box.X - 150, 16*8));
            StateLocator.State.AddObject(new SpikeBossCarrot(boss.box.X - 200, 16*8));
        }

    }
}
