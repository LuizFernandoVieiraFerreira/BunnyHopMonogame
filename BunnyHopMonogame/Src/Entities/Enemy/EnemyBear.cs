using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyBear : Enemy {

        public Sprite sp;

        public EnemyBear(int x = 0, int y =0) {
            sp = new Sprite("enemy_bear", 4, 0.3f);
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

    }

}
