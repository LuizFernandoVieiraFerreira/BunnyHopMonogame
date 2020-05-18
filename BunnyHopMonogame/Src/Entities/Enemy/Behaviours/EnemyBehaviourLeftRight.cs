using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public class EnemyBehaviourLeftRight : EnemyBehaviour {

        Entity entity;

        int start;
        int range;
        bool goingLeft;

        public override void Setup(Entity entity, TiledMapObject i) {
            this.entity = entity;
            start = entity.box.X;

            if (i.Properties.ContainsKey("Range")) {
                this.range = Int32.Parse(i.Properties["Range"]);
            }

            if (i.Properties.ContainsKey("GoingLeft")) {
                this.goingLeft = string.Compare(i.Properties["GoingLeft"], "true") == 0 ? true : false;
            }
        }

        public override void Update(GameTime gameTime) {
            if (entity.box.X < start - range) {
                goingLeft = false;
            }
            if (entity.box.X > start + range) {
                goingLeft = true;
            }

            if (goingLeft) {
                entity.box.X = entity.box.X - 1; 
            } else {
                entity.box.X = entity.box.X + 1;
            }
        }

    }

}
