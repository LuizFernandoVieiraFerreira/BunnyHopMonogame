using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Meca {

    public abstract class BossMecaState {

        protected BossMeca boss;
        protected BossMecaStateMachine stateMachine;

        public virtual void Create(BossMeca boss, BossMecaStateMachine stateMachine) {
            this.boss = boss;
            this.stateMachine = stateMachine;
        }

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);

    }

}
