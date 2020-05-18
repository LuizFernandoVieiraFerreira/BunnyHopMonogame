using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Carrot {

    public class BossCarrotStateMachine {

        BossCarrot boss;
        BossCarrotState state = new BossCarrotIdleState();

        public void Create(BossCarrot boss) {
            this.boss = boss;
            state.Create(boss, this);
        }

        public void Update(GameTime gameTime) {
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            state.Draw(spriteBatch);
        }

        public void ChangeState(BossCarrotState state) {
            this.state = state;
            this.state.Create(boss, this);
        }

    }

}
