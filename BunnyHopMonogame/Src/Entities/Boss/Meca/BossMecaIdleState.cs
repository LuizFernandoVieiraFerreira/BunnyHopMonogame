using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Meca {

    public class BossMecaIdleState : BossMecaState {

        public override void Update(GameTime gameTime) {
            if (boss.Life <= 16) {
                stateMachine.ChangeState(new BossMecaShootingState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (boss.Life > 17) {
                boss.flyingClosedBubbleSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
            } else {
                boss.flyingClosedSp.Draw(spriteBatch, new Vector2(boss.box.X, boss.box.Y));
            }
        }

    }

}
