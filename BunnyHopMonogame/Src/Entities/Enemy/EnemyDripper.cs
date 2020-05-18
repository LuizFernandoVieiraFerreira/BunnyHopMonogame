using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyDripper : Enemy {

        public Sprite sp;

        EnemyDripperDirection direction;

        public EnemyDripper(int x=0, int y=0, EnemyDripperDirection direction=EnemyDripperDirection.UP) {
            this.direction = direction;

            switch(direction) {
                case EnemyDripperDirection.UP:
                    sp = new Sprite("enemy_dripper_up");
                    break;
                case EnemyDripperDirection.DOWN:
                    sp = new Sprite("enemy_dripper_down");
                    break;
            }

            box = new Rectangle(x, y, 0, 0);
        }

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

    }

}
