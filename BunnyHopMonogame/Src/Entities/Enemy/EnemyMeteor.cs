using System;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyMeteor : Enemy {

        private EnemyMeteorSize size;

        private Sprite sp;
        private Sprite spDmg;

        public EnemyMeteor(int x, int y, EnemyMeteorSize size) {
            this.size = size;

            switch (size) {
                case EnemyMeteorSize.SM:
                    health = 3;
                    sp = new Sprite("meteor_sm");
                    spDmg = new Sprite("meteor_sm_dmg");
                    break;
                case EnemyMeteorSize.MD:
                    health = 3;
                    sp = new Sprite("meteor_md");
                    spDmg = new Sprite("meteor_md_dmg");
                    break;
                case EnemyMeteorSize.LG:
                    health = 3;
                    sp = new Sprite("meteor_lg");
                    spDmg = new Sprite("meteor_lg_dmg");
                    break;
            }

            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {
            if (health == 3) {
                sp.Update(gameTime);
            } else if (health >= 0 && health < 3) {
                spDmg.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (health == 3) {
                sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
            }
            else if (health >= 0 && health < 3) {
                spDmg.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
            }
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("Bullet")) {
                health -= 1;
                if (health <= 0) {
                    Random r = new Random();
                    if (size == EnemyMeteorSize.LG) {
                        StateLocator.State.AddObject(new EnemyMeteor(box.X + r.Next(-16, 16), box.Y, EnemyMeteorSize.MD));
                        StateLocator.State.AddObject(new EnemyMeteor(box.X + r.Next(-16, 16), box.Y + 32, EnemyMeteorSize.MD));
                    } else if (size == EnemyMeteorSize.MD) {
                        StateLocator.State.AddObject(new EnemyMeteor(box.X + r.Next(-16, 16), box.Y, EnemyMeteorSize.SM));
                        StateLocator.State.AddObject(new EnemyMeteor(box.X + r.Next(-16, 16), box.Y + 16, EnemyMeteorSize.SM));
                    }
                }
            }
        }

    }

}
