using System;
using BunnyHopMonogame.Desktop;
using BunnyHopMonogame.Src.Entities.Bullets;
using BunnyHopMonogame.Src.Entities.Enemy;
using BunnyHopMonogame.Src.Entities.Item;
using BunnyHopMonogame.Src.Entities.Player;
using BunnyHopMonogame.Src.HUD;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BunnyHopMonogame.Src.States {

    public class GameStatePhase2 : State {

        const int STAGE = 2;

        BunnyHopGame game;

        KeyboardState oldKeyState;
        KeyboardState newKeyState;
        GamePadState oldGamePadState;
        GamePadState newGamePadState;

        Map map;

        PlayerShip player;

        Hud hud;

        Timer cameraTimer;
        float cameraTimeToMove;

        public override void Create(BunnyHopGame game) {
            this.game = game;
            map = new Map();
            player = new PlayerShip(20, 80);
            hud = new Hud(player, STAGE);
            cameraTimer = new Timer();
            cameraTimeToMove = 0.02f;
        }

        public override void LoadContent(ContentManager content) {
            map.LoadContent(content);
            SoundLocator.Sounds.Add(content.Load<SoundEffect>("sound_coin"));
            SoundLocator.Sounds.Add(content.Load<SoundEffect>("sound_antidote"));
        }

        public override void Update(GameTime gameTime) {
            newKeyState = Keyboard.GetState();
            newGamePadState = GamePad.GetState(PlayerIndex.One);

            cameraTimer.Update(gameTime);
            if (cameraTimer.GetAsSeconds() > cameraTimeToMove) {
                cameraTimer.Restart();
                CameraLocator.Camera.Position = new Vector2(CameraLocator.Camera.Position.X + 1f, CameraLocator.Camera.Position.Y);
                ConfigLocator.Config.LeftBoundry = (int)Math.Ceiling(CameraLocator.Camera.Position.X);
                ConfigLocator.Config.RightBoundry = (int)ConfigLocator.Config.LeftBoundry + ConfigLocator.Config.VirtualWidth;
                player.box.X += 1;
            }

            player.MoveLeft = 0;
            player.MoveRight = 0;
            player.MoveUp = 0;
            player.MoveDown = 0;

            // Left
            if (newKeyState.IsKeyDown(Keys.A) ||
                newKeyState.IsKeyDown(Keys.Left) ||
                newGamePadState.IsButtonDown(Buttons.DPadLeft) ||
                newGamePadState.ThumbSticks.Left.X < -0.5f) {
                player.MoveLeft = 1;
            }

            // Right
            if (newKeyState.IsKeyDown(Keys.D) ||
                newKeyState.IsKeyDown(Keys.Right) ||
                newGamePadState.IsButtonDown(Buttons.DPadRight) ||
                newGamePadState.ThumbSticks.Left.X > 0.5f) {
                player.MoveRight = 1;
            }

            // Up
            if (newKeyState.IsKeyDown(Keys.W) ||
                newKeyState.IsKeyDown(Keys.Up) ||
                newGamePadState.IsButtonDown(Buttons.DPadUp) ||
                newGamePadState.ThumbSticks.Left.Y > 0.5f) {
                player.MoveUp = 1;
            }

            // Down
            if (newKeyState.IsKeyDown(Keys.S) ||
                newKeyState.IsKeyDown(Keys.Down) ||
                newGamePadState.IsButtonDown(Buttons.DPadDown) ||
                newGamePadState.ThumbSticks.Left.Y < -0.5f) {
                player.MoveDown = 1;
            }

            player.MoveHorizontal = player.MoveRight - player.MoveLeft;
            player.MoveVertical = player.MoveDown - player.MoveUp;

            // Shoot
            if (newKeyState.IsKeyDown(Keys.Space) && oldKeyState.IsKeyUp(Keys.Space) ||
                newKeyState.IsKeyDown(Keys.Enter) && oldKeyState.IsKeyUp(Keys.Enter) ||
                newGamePadState.IsButtonDown(Buttons.X) && oldGamePadState.IsButtonUp(Buttons.X)) {
                if (player.CanShoot) {
                    AddObject(new BulletPlayerShip(player.box.X, player.box.Y));
                    player.CanShoot = false;
                    player.ShootTimer.Restart();
                }
            }

            map.Update(gameTime);
            UpdateObjects(gameTime);
            player.Update(gameTime);
            hud.Update(gameTime);

            CheckCollision();

            oldKeyState = newKeyState;
            oldGamePadState = newGamePadState;
        }

        private void CheckCollision() {
            for (int i = 0; i < objects.Count; ++i) {
                for (int j = i + 1; j < objects.Count; ++j) {
                    if (Collision.IsColliding(objects[i].box, objects[j].box)) {
                        objects[i].NotifyCollision(objects[j]);
                        objects[j].NotifyCollision(objects[i]);
                    }
                }
            }

            for (int i = 0; i < objects.Count; ++i) {
                if (Collision.IsColliding(objects[i].box, player.box)) {
                    objects[i].NotifyCollision(player);
                    player.NotifyCollision(objects[i]);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            map.Draw(spriteBatch);
            DrawObjects(spriteBatch);
            player.Draw(spriteBatch);
            hud.Draw(spriteBatch);
        }

        public override void Pause() {

        }

        public override void Resume() {

        }

    }

}
