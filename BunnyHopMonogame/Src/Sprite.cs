using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BunnyHopMonogame.Src.Locator;

namespace BunnyHopMonogame.Src {

    public class Sprite {

        Texture2D texture;
        Rectangle rect;
        readonly int frameCount;
        readonly float frameTime;
        int currentFrame;
        float timeElapsed;

        int width;
        int height;

        public Sprite(string texture, int frameCount = 1, float frameTime = 1) {
            this.texture = ContentLocator.Content.Load<Texture2D>(texture);
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.currentFrame = 0;
            this.timeElapsed = 0;
            this.width = this.texture.Width / frameCount;
            this.height = this.texture.Height;
            this.rect = new Rectangle(0, 0, width, height);
        }

        public void Update(GameTime gameTime) { 
            timeElapsed += gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            if (timeElapsed > frameTime) {
                timeElapsed -= frameTime;
                ++currentFrame;

                if (currentFrame == frameCount) {
                    currentFrame = 0;
                }

                SetClip((texture.Width / frameCount) * currentFrame, 0, texture.Width / frameCount, texture.Height);
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float angle = 0){
            spriteBatch.Draw(texture,
                             position,
                             new Rectangle((texture.Width / frameCount) * currentFrame, 0, texture.Width / frameCount, texture.Height),
                             Color.White,
                             0f,
                             new Vector2((texture.Width/frameCount) / 2, texture.Height / 2),
                             Vector2.One,
                             SpriteEffects.None,
                             0f);
        }

        private void SetClip(int x, int y, int w, int h) {
            this.rect = new Rectangle(x, y, w, h);
        }

        public int Width {
            get {
                return width;
            }
            set {
                width = value;
            }
        }

        public int Height {
            get {
                return height;
            }
            set {
                height = value;
            }
        }

    }

}
