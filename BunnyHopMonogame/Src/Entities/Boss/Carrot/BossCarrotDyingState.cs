using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Carrot {

    public class BossCarrotDyingState : BossCarrotState {

        Timer timer = new Timer();
        float timeToDie = 3.0f;

        public override void Update(GameTime gameTime) {
            boss.dyingSp.Update(gameTime);
            timer.Update(gameTime);

            if (timer.GetAsSeconds() > timeToDie) {
                boss.Die();
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            boss.dyingSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
        }

    }

}
