using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class PlayerShipStateMachine {

        PlayerShip player;
        PlayerShipState state = new PlayerShipFlyingState();

        public void Create(PlayerShip player) {
            this.player = player;
            state.Create(player, this);
        }

        public void Update(GameTime gameTime) {
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            state.Draw(spriteBatch);
        }

        public void ChangeState(PlayerShipState state) {
            this.state = state;
            this.state.Create(player, this);
        }

    }

}
