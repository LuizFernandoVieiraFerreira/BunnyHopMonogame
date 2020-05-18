using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Meca {

    public class BossMecaStateMachine {

        BossMeca boss;
        BossMecaState state = new BossMecaIdleState();

        public void Create(BossMeca boss) {
            this.boss = boss;
            state.Create(boss, this);
        }

        public void Update(GameTime gameTime) {
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            state.Draw(spriteBatch);
        }

        public void ChangeState(BossMecaState state) {
            this.state = state;
            this.state.Create(boss, this);
        }

    }

}
