using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyShield : Enemy {

        public Sprite spDef;
        public Sprite spAtk;

        public EnemyShield(int x=0, int y=0) {
            spDef = new Sprite("enemy_shield_def");
            spAtk = new Sprite("enemy_shield_atk", 3, 0.3f);
            box = new Rectangle(x, y, spDef.Width, spDef.Height);
        }

        public override void Update(GameTime gameTime) {

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

    }

}
