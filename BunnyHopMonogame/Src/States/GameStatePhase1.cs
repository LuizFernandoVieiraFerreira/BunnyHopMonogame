using System;
using BunnyHopMonogame.Desktop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using Microsoft.Xna.Framework.Input;
using BunnyHopMonogame.Src.Entities.Player;

namespace BunnyHopMonogame.Src.States {

    public class GameStatePhase1 : State {

        BunnyHopGame game;

        KeyboardState oldKeyState;
        KeyboardState newKeyState;
        GamePadState oldGamePadState;
        GamePadState newGamePadState;

        Map map;

        Player player;

        public override void Create(BunnyHopGame game) {
            this.game = game;
            map = new Map();
            player = new Player();
        }

        public override void LoadContent(ContentManager content) {
            map.LoadContent(content);
        }

        public override void Update(GameTime gameTime) {
            newKeyState = Keyboard.GetState();
            newGamePadState = GamePad.GetState(PlayerIndex.One);

            // Left
            if (newKeyState.IsKeyDown(Keys.A) ||
                newKeyState.IsKeyDown(Keys.Left) ||
                newGamePadState.IsButtonDown(Buttons.DPadLeft) ||
                newGamePadState.ThumbSticks.Left.X < -0.5f) {
                player.Position = new Vector2(player.Position.X - 1, player.Position.Y);
            }

            // Right
            if (newKeyState.IsKeyDown(Keys.D) ||
                newKeyState.IsKeyDown(Keys.Right) ||
                newGamePadState.IsButtonDown(Buttons.DPadRight) ||
                newGamePadState.ThumbSticks.Left.X > 0.5f) {
                player.Position = new Vector2(player.Position.X + 1, player.Position.Y);
            }

            map.Update(gameTime);
            player.Update(gameTime);

            oldKeyState = newKeyState;
            oldGamePadState = newGamePadState;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }

        public override void Pause() {

        }

        public override void Resume() {

        }

    }

}

/*
            ballPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);

            var kstate = Keyboard.GetState();

            //if (kstate.IsKeyDown(Keys.Up))
            //    ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Down))
            //    ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Left))
            //    ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Right))
            //    ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //ballPosition.X = Math.Min(Math.Max(ballTexture.Width / 2, ballPosition.X), graphics.PreferredBackBufferWidth - ballTexture.Width / 2);
            //ballPosition.Y = Math.Min(Math.Max(ballTexture.Height / 2, ballPosition.Y), graphics.PreferredBackBufferHeight - ballTexture.Height / 2);


            // Left
            if (newKeyState.IsKeyDown(Keys.A) && oldKeyState.IsKeyUp(Keys.A) ||
                newKeyState.IsKeyDown(Keys.Left) && oldKeyState.IsKeyUp(Keys.Left) ||
                newGamePadState.IsButtonDown(Buttons.DPadLeft) && oldGamePadState.IsButtonUp(Buttons.DPadLeft) ||
                newGamePadState.ThumbSticks.Left.X < -0.5f && oldGamePadState.ThumbSticks.Left.X > -0.5) {
                player.Position = new Vector2(player.Position.X - 1, player.Position.Y);
            }

            // Right
            if (newKeyState.IsKeyDown(Keys.D) && oldKeyState.IsKeyUp(Keys.D) ||
                newKeyState.IsKeyDown(Keys.Right) && oldKeyState.IsKeyUp(Keys.Right) ||
                newGamePadState.IsButtonDown(Buttons.DPadRight) && oldGamePadState.IsButtonUp(Buttons.DPadRight) ||
                newGamePadState.ThumbSticks.Left.X > 0.5f && oldGamePadState.ThumbSticks.Left.X < 0.5) {
                player.Position = new Vector2(player.Position.X + 1, player.Position.Y);
            }   
*/
