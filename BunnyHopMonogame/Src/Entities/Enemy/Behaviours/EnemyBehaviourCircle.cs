using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;

namespace BunnyHopMonogame.Src.Entities.Enemy.Behaviours {

    public class EnemyBehaviourCircle : EnemyBehaviour {

        Entity entity;

        int startX;
        int startY;

        int radius;
        float arc;

        double angularSpeed;

        public override void Setup(Entity entity, TiledMapObject i) {
            this.entity = entity;
            startX = entity.box.X;
            startY = entity.box.Y;
            radius = 32;
            arc = 0;
            angularSpeed = Math.PI / 2.0;
            entity.box.X = (int)(startX + radius * Math.Cos(arc) - entity.box.Width / 2);
            entity.box.Y = (int)(startY + radius * Math.Sin(arc) - entity.box.Height / 2);
        }

        public override void Update(GameTime gameTime) {
            arc += (float) (angularSpeed * gameTime.ElapsedGameTime.Milliseconds);
            entity.box.X = (int) (startX + radius * Math.Cos(arc) - entity.box.Width / 2);
            entity.box.Y = (int) (startY + radius * Math.Sin(arc) - entity.box.Height / 2);
        }

    }

}
