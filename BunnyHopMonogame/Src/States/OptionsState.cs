using System.Collections.Generic;
using BunnyHopMonogame.Desktop;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BunnyHopMonogame.Src.States
{

    public class OptionsState : State {

        BunnyHopGame game;
        SpriteFont font;
        List<Text> options;
        List<Text> optionsValues;
        int currentSelectedOption;

        KeyboardState oldKeyState;
        KeyboardState newKeyState;
        GamePadState oldGamePadState;
        GamePadState newGamePadState;

        public OptionsState() {
        }

        public override void Create(BunnyHopGame game) {
            this.game = game;
            options = new List<Text>();
            options.Add(new Text("SCALE", new Vector2(18, 42)));
            options.Add(new Text("FULLSCREEN", new Vector2(18, 52)));
            options.Add(new Text("VSYNC", new Vector2(18, 62)));
            options.Add(new Text("SOUND", new Vector2(18, 72)));
            options.Add(new Text("MUSIC", new Vector2(18, 82)));
            options.Add(new Text("BACK", new Vector2(18, 92)));
            optionsValues = new List<Text>();
            optionsValues.Add(new Text(ConfigLocator.Config.Scale.ToString(), new Vector2(118, 42)));
            optionsValues.Add(new Text(ConfigLocator.Config.Fullscreen == OnOff.ON ? "ON" : "OFF", new Vector2(118, 52)));
            optionsValues.Add(new Text(ConfigLocator.Config.Vsync == OnOff.ON ? "ON" : "OFF", new Vector2(118, 62)));
            optionsValues.Add(new Text(ConfigLocator.Config.Sound.ToString(), new Vector2(118, 72)));
            optionsValues.Add(new Text(ConfigLocator.Config.Music.ToString(), new Vector2(118, 82)));
            currentSelectedOption = 0;
            oldKeyState = Keyboard.GetState();
            newKeyState = oldKeyState;
            oldGamePadState = GamePad.GetState(PlayerIndex.One);
            newGamePadState = oldGamePadState;
        }

        public override void LoadContent(ContentManager content) {
            font = content.Load<SpriteFont>("gameboy");
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

            if (newKeyState.IsKeyDown(Keys.D) && oldKeyState.IsKeyUp(Keys.D) ||
                newKeyState.IsKeyDown(Keys.Right) && oldKeyState.IsKeyUp(Keys.Right) ||
                newGamePadState.IsButtonDown(Buttons.DPadRight) && oldGamePadState.IsButtonUp(Buttons.DPadRight) ||
                newGamePadState.ThumbSticks.Left.X > 0.5f && oldGamePadState.ThumbSticks.Left.X < 0.5) {
                switch (currentSelectedOption) {
                    case 0:
                        if (ConfigLocator.Config.Scale < 5) {
                            ConfigLocator.Config.Scale += 1;
                            GraphicsLocator.Graphics.PreferredBackBufferWidth = ConfigLocator.Config.VirtualWidth * ConfigLocator.Config.Scale;
                            GraphicsLocator.Graphics.PreferredBackBufferHeight = ConfigLocator.Config.VirtualHeight * ConfigLocator.Config.Scale;
                            GraphicsLocator.Graphics.ApplyChanges();
                            optionsValues[0].Value = ConfigLocator.Config.Scale.ToString();
                        }
                        break;
                    case 1:
                        if (ConfigLocator.Config.Fullscreen == OnOff.OFF) {
                            game.SetFullscreen(true);
                            ConfigLocator.Config.Fullscreen = OnOff.ON;
                            optionsValues[1].Value = ConfigLocator.Config.Fullscreen.ToString();
                        }
                        break;
                    case 2:
                        if (ConfigLocator.Config.Vsync == OnOff.OFF) {
                            game.SetVsync(true);
                            ConfigLocator.Config.Vsync = OnOff.ON;
                            optionsValues[2].Value = ConfigLocator.Config.Vsync.ToString();
                        }
                        break;
                    case 3:
                        if (ConfigLocator.Config.Sound < 10) {
                            ConfigLocator.Config.Sound += 1;
                            optionsValues[3].Value = ConfigLocator.Config.Sound.ToString();
                        }
                        break;
                    case 4:
                        if (ConfigLocator.Config.Music < 10) {
                            ConfigLocator.Config.Music += 1;
                            optionsValues[4].Value = ConfigLocator.Config.Music.ToString();
                        }
                        break;
                }
            }

            if (newKeyState.IsKeyDown(Keys.A) && oldKeyState.IsKeyUp(Keys.A) ||
                newKeyState.IsKeyDown(Keys.Left) && oldKeyState.IsKeyUp(Keys.Left) ||
                newGamePadState.IsButtonDown(Buttons.DPadLeft) && oldGamePadState.IsButtonUp(Buttons.DPadLeft) ||
                newGamePadState.ThumbSticks.Left.X < -0.5f && oldGamePadState.ThumbSticks.Left.X > -0.5) {
                switch (currentSelectedOption) {
                    case 0:
                        if (ConfigLocator.Config.Scale > 1) {
                            ConfigLocator.Config.Scale -= 1;
                            GraphicsLocator.Graphics.PreferredBackBufferWidth = ConfigLocator.Config.VirtualWidth * ConfigLocator.Config.Scale;
                            GraphicsLocator.Graphics.PreferredBackBufferHeight = ConfigLocator.Config.VirtualHeight * ConfigLocator.Config.Scale;
                            GraphicsLocator.Graphics.ApplyChanges();
                            optionsValues[0].Value = ConfigLocator.Config.Scale.ToString();
                        }
                        break;
                    case 1:
                        if (ConfigLocator.Config.Fullscreen == OnOff.ON) {
                            game.SetFullscreen(false);
                            ConfigLocator.Config.Fullscreen = OnOff.OFF;
                            optionsValues[1].Value = ConfigLocator.Config.Fullscreen.ToString();
                        }
                        break;
                    case 2:
                        if (ConfigLocator.Config.Vsync == OnOff.ON) {
                            game.SetVsync(false);
                            ConfigLocator.Config.Vsync = OnOff.OFF;
                            optionsValues[2].Value = ConfigLocator.Config.Vsync.ToString();
                        }
                        break;
                    case 3:
                        if (ConfigLocator.Config.Sound > 0) {
                            ConfigLocator.Config.Sound -= 1;
                            optionsValues[3].Value = ConfigLocator.Config.Sound.ToString();
                        }
                        break;
                    case 4:
                        if (ConfigLocator.Config.Music > 0) {
                            ConfigLocator.Config.Music -= 1;
                            optionsValues[4].Value = ConfigLocator.Config.Music.ToString();
                        }
                        break;
                }
            }

            if (newKeyState.IsKeyDown(Keys.Space) && oldKeyState.IsKeyUp(Keys.Space) ||
                newKeyState.IsKeyDown(Keys.Enter) && oldKeyState.IsKeyUp(Keys.Enter) ||
                newGamePadState.IsButtonDown(Buttons.A) && oldGamePadState.IsButtonUp(Buttons.A)) {
                switch (currentSelectedOption) {
                    case 5:
                        game.Pop();
                        break;
                }
            }

            oldKeyState = newKeyState;
            oldGamePadState = newGamePadState;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < options.Count; i++) {
                if (i == currentSelectedOption) {
                    spriteBatch.DrawString(font, options[i].Value, options[i].Position, Color.White);
                } else {
                    spriteBatch.DrawString(font, options[i].Value, options[i].Position, new Color(123, 114, 99));
                }
            }

            for (int i = 0; i < optionsValues.Count; i++) {
                if (i == currentSelectedOption) {
                    spriteBatch.DrawString(font, optionsValues[i].Value, optionsValues[i].Position, Color.White);
                } else {
                    spriteBatch.DrawString(font, optionsValues[i].Value, optionsValues[i].Position, new Color(123, 114, 99));
                }
            }
        }

        public override void Pause() {

        }

        public override void Resume() {

        }

    }

}
