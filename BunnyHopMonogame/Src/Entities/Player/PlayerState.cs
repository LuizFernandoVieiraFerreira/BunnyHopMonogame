using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public abstract class PlayerState {

        protected Player player;
        protected PlayerStateMachine stateMachine;

        public virtual void Create(Player player, PlayerStateMachine stateMachine) {
            this.player = player;
            this.stateMachine = stateMachine;
        }

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);

    }

}
