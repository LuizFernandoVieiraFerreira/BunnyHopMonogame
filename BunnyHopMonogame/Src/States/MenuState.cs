using System;
using System.Collections.Generic;
using BunnyHopMonogame.Desktop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BunnyHopMonogame.Src.States {

    public class MenuState : State {

        BunnyHopGame game;
        Texture2D bg;
        SpriteFont font;
        List<Text> options;
        int currentSelectedOption;

        KeyboardState oldKeyState;
        KeyboardState newKeyState;
        GamePadState oldGamePadState;
        GamePadState newGamePadState;

        public MenuState() {
        }

        public override void Create(BunnyHopGame game) {
            this.game = game;
            options = new List<Text>();
            options.Add(new Text(Resources.Play, new Vector2(53, 88)));
            options.Add(new Text(Resources.Options, new Vector2(53, 100)));
            options.Add(new Text(Resources.Exit, new Vector2(53, 112)));
            currentSelectedOption = 0;
            oldKeyState = Keyboard.GetState();
            newKeyState = oldKeyState;
            oldGamePadState = GamePad.GetState(PlayerIndex.One);
            newGamePadState = oldGamePadState;
        }

        public override void LoadContent(ContentManager content) {
            bg = content.Load<Texture2D>("menu");
            font = content.Load<SpriteFont>("dunggeunmo");
        }

        public override void Update(GameTime gameTime) {
            newKeyState = Keyboard.GetState();
            newGamePadState = GamePad.GetState(PlayerIndex.One);

            if (newKeyState.IsKeyDown(Keys.W) && oldKeyState.IsKeyUp(Keys.W) || 
                newKeyState.IsKeyDown(Keys.Up) && oldKeyState.IsKeyUp(Keys.Up) ||
                newGamePadState.IsButtonDown(Buttons.DPadUp) && oldGamePadState.IsButtonUp(Buttons.DPadUp) ||
                newGamePadState.ThumbSticks.Left.Y > 0.5f && oldGamePadState.ThumbSticks.Left.Y < 0.5) {
                if (currentSelectedOption != 0) {
                    currentSelectedOption--;
                }
            }

            if (newKeyState.IsKeyDown(Keys.S) && oldKeyState.IsKeyUp(Keys.S) || 
                newKeyState.IsKeyDown(Keys.Down) && oldKeyState.IsKeyUp(Keys.Down) ||
                newGamePadState.IsButtonDown(Buttons.DPadDown) && oldGamePadState.IsButtonUp(Buttons.DPadDown) ||
                newGamePadState.ThumbSticks.Left.Y < -0.5f && oldGamePadState.ThumbSticks.Left.Y > -0.5) {
                if (currentSelectedOption != options.Count - 1) {
                    currentSelectedOption++;
                }
            }

            if (newKeyState.IsKeyDown(Keys.Space) && oldKeyState.IsKeyUp(Keys.Space) || 
                newKeyState.IsKeyDown(Keys.Enter) && oldKeyState.IsKeyUp(Keys.Enter) ||
                newGamePadState.IsButtonDown(Buttons.A) && oldGamePadState.IsButtonUp(Buttons.A)) {
                switch (currentSelectedOption) {
                    case 0:
                        game.Push(new GameStatePhase2()); //GameStatePhase1 GameStatePhase2
                        break;
                    case 1:
                        game.Push(new OptionsState());
                        break;
                    case 2:
                        quit = true;
                        break;
                }
            }

            oldKeyState = newKeyState;
            oldGamePadState = newGamePadState;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(bg, new Vector2(), Color.White);
            for (int i = 0; i < options.Count; i++) {
                if (i == currentSelectedOption) {
                    spriteBatch.DrawString(font, options[i].Value, options[i].Position, Color.White);
                } else {
                    spriteBatch.DrawString(font, options[i].Value, options[i].Position, new Color(123, 114, 99));
                }
            }
        }


        public override void Pause() {

        }

        public override void Resume() {

        }

    }

}
