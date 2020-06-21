using System;
using BunnyHopMonogame.Desktop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BunnyHopMonogame.Src.States {

    public class SplashState : State {

        BunnyHopGame game;
        Texture2D bgGamb;
        Texture2D bgLove;
        int mAlphaValue = 1;
        int mFadeIncrement = 3;
        double mFadeDelay = .035;
        bool firstImage = true;

        public SplashState() {
        }

        public override void Create(BunnyHopGame game) {
            this.game = game;

        }

        public override void LoadContent(ContentManager content) {
            bgGamb = content.Load<Texture2D>("splash_gamb");
            bgLove = content.Load<Texture2D>("splash_love");
        }        

        public override void Update(GameTime gameTime) {
            mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mFadeDelay <= 0) {
                mFadeDelay = .035;
                mAlphaValue += mFadeIncrement;
                if (mAlphaValue >= 255) {
                    mFadeIncrement *= -1;
                }
                else if (mAlphaValue <= 0) {
                    if (firstImage) {
                        firstImage = false;
                        mFadeIncrement *= -1;
                    }
                    else {
                        game.Push(new MenuState());
                    }
                }
            }

            KeyboardState keyState = Keyboard.GetState();
            GamePadState gamePadSate = GamePad.GetState(PlayerIndex.One);

            if (keyState.IsKeyDown(Keys.Space) || keyState.IsKeyDown(Keys.Enter) || gamePadSate.IsButtonDown(Buttons.A)) {
                game.Push(new MenuState());
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(firstImage ? bgGamb : bgLove,
                             new Rectangle(0, 0, bgLove.Width, bgLove.Height),
                             new Color((byte)MathHelper.Clamp(mAlphaValue, 0, 255), 
                                       (byte)MathHelper.Clamp(mAlphaValue, 0, 255), 
                                       (byte)MathHelper.Clamp(mAlphaValue, 0, 255), 
                                       (byte)255));

        }

        public override void Pause() {

        }

        public override void Resume() {

        }

    }

}
