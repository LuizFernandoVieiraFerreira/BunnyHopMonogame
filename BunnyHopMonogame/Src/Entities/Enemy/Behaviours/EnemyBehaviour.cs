using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;

namespace BunnyHopMonogame.Src.Entities.Enemy {

    public abstract class EnemyBehaviour {
        public abstract void Setup(Entity entity, TiledMapObject i);
        public abstract void Update(GameTime gameTime);
    }

}
