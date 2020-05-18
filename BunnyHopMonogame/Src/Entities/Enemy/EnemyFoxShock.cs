using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyFoxShock : Enemy {

        public Sprite sp;

        public EnemyFoxShock(int x=0, int y=0) {
            sp = new Sprite("enemy_fox_shock", 4, 0.3f);
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

    }

}
