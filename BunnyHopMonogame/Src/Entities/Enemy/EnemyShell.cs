using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyShell : Enemy {

        public Sprite sp;

        public EnemyShell(int x=0, int y=0) {
            sp = new Sprite("enemy_shell", 14, 0.3f);
            box = new Rectangle(x, y, sp.Width, sp.Height);
        }

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

    }

}
