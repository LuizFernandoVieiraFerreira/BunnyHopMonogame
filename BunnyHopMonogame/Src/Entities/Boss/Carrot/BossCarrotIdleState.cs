using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Carrot {

    public class BossCarrotIdleState : BossCarrotState {

        public override void Update(GameTime gameTime) {
            if (boss.Life <= 2) {
                stateMachine.ChangeState(new BossCarrotBombState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (boss.Life > 3) {
                boss.idleSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
            } else if (boss.Life == 3) {
                boss.rotSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
            }
        }

    }

}
