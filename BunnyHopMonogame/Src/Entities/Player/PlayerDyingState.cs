using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class PlayerDyingState : PlayerState {

        public override void Create(Player player, PlayerStateMachine stateMachine) {
            this.player = player;
            this.stateMachine = stateMachine;
        }

        public override void Update(GameTime gameTime) {
            this.player.dyingSp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            this.player.dyingSp.Draw(spriteBatch, this.player.Position);
        }

    }

}
