using System;
using System.Collections.Generic;
using BunnyHopMonogame.Desktop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BunnyHopMonogame.Src.Entities;
using BunnyHopMonogame.Src.Locator;

namespace BunnyHopMonogame.Src.States {

    public abstract class State {

        protected List<Entity> objects = new List<Entity>();
        protected List<Entity> objectsToBeAdded = new List<Entity>();
        protected bool quit;
        protected bool pop;

        protected State() {
            StateLocator.Provide(this);
            quit = false;
            pop = false;
        }

        abstract public void Create(BunnyHopGame game);
        abstract public void LoadContent(ContentManager content);
        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void Pause();
        abstract public void Resume();

        public void AddObject(Entity entity) {
            objectsToBeAdded.Add(entity);
        }

        protected void UpdateObjects(GameTime gameTime) {
            foreach (Entity obj in objects) {
                obj.Update(gameTime);
            }
            objects.RemoveAll(o => o.IsDead());
            foreach (Entity objToBeAdded in objectsToBeAdded) {
                objects.Add(objToBeAdded);
            }
            objectsToBeAdded.Clear();
        }

        protected void DrawObjects(SpriteBatch spriteBatch) {
            foreach (Entity obj in objects) {
                obj.Draw(spriteBatch);
            }
        }

        public bool QuitRequested() {
            return quit;
        }

        public bool PopRequested() {
            return pop;
        }

    }

}
