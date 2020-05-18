using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class PlayerShipDyingState : PlayerShipState {

        Timer timer;
        float timeToRevive;

        public override void Create(PlayerShip player, PlayerShipStateMachine stateMachine) {
            this.player = player;
            this.stateMachine = player.stateMachine;
            timer = new Timer();
            timeToRevive = 3;
        }

        public override void Update(GameTime gameTime) {
            player.box = new Rectangle(player.box.X, player.box.Y+1, player.box.Width, player.box.Height);
            player.dyingSp.Update(gameTime);
            timer.Update(gameTime);

            if ((timer.GetAsSeconds()) > timeToRevive) {
                player.Revive();
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            player.dyingSp.Draw(spriteBatch, new Vector2(player.box.X, player.box.Y));
        }

    }

}
