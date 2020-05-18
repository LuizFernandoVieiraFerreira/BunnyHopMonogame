using System;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class PlayerShipFlyingState : PlayerShipState {

        public override void Create(PlayerShip player, PlayerShipStateMachine stateMachine) {
            this.player = player;
            this.stateMachine = player.stateMachine;
        }

        public override void Update(GameTime gameTime) {
            int velX = player.MoveHorizontal * player.MoveSpeed;
            int velY = player.MoveVertical * player.MoveSpeed;

            Vector2 oldPosition = new Vector2(player.box.X, player.box.Y);
            Vector2 newPosition = new Vector2(player.box.X + velX, player.box.Y + velY);

            if (newPosition.Y < ConfigLocator.Config.TopBoundry) {
                newPosition.Y = ConfigLocator.Config.TopBoundry;
            }

            if (newPosition.Y > ConfigLocator.Config.BottomBoundry) {
                newPosition.Y = ConfigLocator.Config.BottomBoundry;
            }

            if (newPosition.X < ConfigLocator.Config.LeftBoundry) {
                newPosition.X = ConfigLocator.Config.LeftBoundry;
            }

            if (newPosition.X > ConfigLocator.Config.RightBoundry) {
                newPosition.X = ConfigLocator.Config.RightBoundry;
            }

            player.box = new Rectangle((int)newPosition.X, (int)newPosition.Y, player.box.Width, player.box.Height);
            player.flyingSp.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            player.flyingSp.Draw(spriteBatch, new Vector2(player.box.X, player.box.Y));
        }

    }

}
