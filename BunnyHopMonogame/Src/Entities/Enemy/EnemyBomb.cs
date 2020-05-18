using System;
using BunnyHopMonogame.Src.Entities.Efx;
using BunnyHopMonogame.Src.Entities.Enemy.Behaviours;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyBomb : Enemy {

        public Sprite sp;
        public EnemyBehaviour enemyBehaviour;

        public EnemyBomb(int x, int y, EnemyBehaviour enemyBehaviour, int range, bool goingLeft) {
            this.enemyBehaviour = enemyBehaviour;
            health = 2;
            sp = new Sprite("bomb", 4, 0.2f);
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {
            sp.Update(gameTime);
            enemyBehaviour.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("Bullet")) {
                health -= 1;
            }
        }

        public override bool IsDead() {
            if (health <= 0) {
                StateLocator.State.AddObject(new EfxExplosion(box.X, box.Y));
                return true;
            }
            return false;
        }

    }

}
