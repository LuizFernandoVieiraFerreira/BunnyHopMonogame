using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss.Carrot {

    public abstract class BossCarrotState {

        protected BossCarrot boss;
        protected BossCarrotStateMachine stateMachine;

        public virtual void Create(BossCarrot boss, BossCarrotStateMachine stateMachine) {
            this.boss = boss;
            this.stateMachine = stateMachine;
        }

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);

    }

}
