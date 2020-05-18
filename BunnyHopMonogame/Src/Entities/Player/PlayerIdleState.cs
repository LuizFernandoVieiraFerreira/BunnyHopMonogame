using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class PlayerIdleState : PlayerState {

        public override void Create(Player player, PlayerStateMachine stateMachine) {
            this.player = player;
            this.stateMachine = player.stateMachine;

        }

        public override void Update(GameTime gameTime) {

            this.player.idleSp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            this.player.idleSp.Draw(spriteBatch, this.player.Position);
        }

    }

}
