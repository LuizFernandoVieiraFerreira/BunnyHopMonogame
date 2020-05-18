using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities {

    public abstract class Entity {

        public Rectangle box = new Rectangle(0, 0, 0, 0);
        public float rotation = 0;

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void NotifyCollision(Entity go);
        abstract public bool IsDead();
        abstract public bool Is(string type);

    }

}
