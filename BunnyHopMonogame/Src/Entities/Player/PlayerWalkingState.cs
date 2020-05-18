using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class PlayerWalkingState : PlayerState {

        public override void Create(Player player, PlayerStateMachine stateMachine) {
            this.player = player;
            this.stateMachine = stateMachine;
        }

        public override void Update(GameTime gameTime) {
            this.player.walkingSp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            this.player.walkingSp.Draw(spriteBatch, this.player.Position);
        }

    }

}
