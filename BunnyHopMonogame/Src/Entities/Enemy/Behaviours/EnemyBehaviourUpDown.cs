using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyBehaviourUpDown : EnemyBehaviour {

        Entity entity;

        int start;
        int range;
        bool goingDown;

        public override void Setup(Entity entity, TiledMapObject i) {
            this.entity = entity;
            start = entity.box.Y;

            if (i.Properties.ContainsKey("Range")) {
                this.range = Int32.Parse(i.Properties["Range"]);
            }

            if (i.Properties.ContainsKey("GoingDown")) {
                this.goingDown = string.Compare(i.Properties["GoingDown"], "true") == 0 ? true : false;
            }
        }

        public override void Update(GameTime gameTime) {
            if (entity.box.Y > start+range) {
                goingDown = false;
            }
            if (entity.box.Y < start-range) {
                goingDown = true;
            }

            if (goingDown) {
                entity.box.Y = entity.box.Y + 1;
            } else {
                entity.box.Y = entity.box.Y - 1;
            }
        }

    }

}
