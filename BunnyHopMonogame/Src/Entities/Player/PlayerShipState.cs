using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BunnyHopMonogame.Src.Entities.Player;

namespace BunnyHopMonogame.Src {

    public abstract class PlayerShipState {

        protected PlayerShip player;
        protected PlayerShipStateMachine stateMachine;

        public virtual void Create(PlayerShip player, PlayerShipStateMachine stateMachine) {
            this.player = player;
            this.stateMachine = stateMachine;
        }

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);

    }

}
