using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using BunnyHopMonogame.Src.Locator;
using BunnyHopMonogame.Src.Entities.Item;
using BunnyHopMonogame.Src.Entities.Enemy;
using BunnyHopMonogame.Src.Entities.Boss;
using BunnyHopMonogame.Src.Entities.Enemy.Behaviours;

namespace BunnyHopMonogame.Src {

    public class Map {
    
        private TiledMap map;
        private TiledMapRenderer mapRenderer;

        public int mapWidth;
        public int mapHeight;
        public Vector2 tileSize;

        private List<Rectangle> tileColliderBoxes;
        private Texture2D colliderTexture;

        public enum TileCollision {
            Passable = 0,
            Block = 1,
            Platform = 2,
            Stair = 3
        }

        public Map() {
            tileColliderBoxes = new List<Rectangle>();
            colliderTexture = new Texture2D(GraphicsLocator.Graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            colliderTexture.SetData(new Color[] { Color.Green });
        }

        public void LoadContent(ContentManager content) {
            map = content.Load<TiledMap>("Level2");
            mapRenderer = new TiledMapRenderer(GraphicsLocator.Graphics.GraphicsDevice);

            mapWidth = map.WidthInPixels;
            mapHeight = map.HeightInPixels;
            tileSize = new Vector2(16, 16);

            var tsx = (int)tileSize.X;
            var tsy = (int)tileSize.Y;

            var blockedLayer = map.GetLayer<TiledMapObjectLayer>("Block");
            if (blockedLayer != null)
            {
                foreach (var tile in blockedLayer.Objects)
                {
                    tileColliderBoxes.Add(new Rectangle((int)tile.Position.X * tsx, (int)tile.Position.Y * tsy, tsx, tsy));
                }
            }

            var instancesLayer = map.GetLayer<TiledMapObjectLayer>("Instances");
            if (instancesLayer != null) {
                foreach(var i in instancesLayer.Objects) {

                    EnemyBehaviour enemyBehaviour = new EnemyEmptyBehaviour();

                    switch (i.Type) {

                        // ITEM
                        case "Antidote":
                            StateLocator.State.AddObject(new Antidote((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "Coin":
                            StateLocator.State.AddObject(new Coin((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "ItemMachinegun":
                            StateLocator.State.AddObject(new ItemMachinegun((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "ItemMisslegun":
                            StateLocator.State.AddObject(new ItemMisslegun((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "ItemShotgun":
                            StateLocator.State.AddObject(new ItemShotgun((int)i.Position.X, (int)i.Position.Y));
                            break;

                        // ENEMY
                        case "EnemyBear":
                            StateLocator.State.AddObject(new EnemyBird((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemyBird":
                            StateLocator.State.AddObject(new EnemyBird((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemyBomb":
                            enemyBehaviour = GetEnemyBehaviour(i);
                            EnemyBomb enemy = new EnemyBomb((int)i.Position.X, (int)i.Position.Y, enemyBehaviour, GetEnemyRange(i), GetEnemyGoingDown(i));
                            enemyBehaviour.Setup(enemy, i);
                            StateLocator.State.AddObject(enemy);
                            break;
                        case "EnemyDripper":
                            StateLocator.State.AddObject(new EnemyDripper((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemyFox":
                            StateLocator.State.AddObject(new EnemyFox((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemyFoxShock":
                            StateLocator.State.AddObject(new EnemyFoxShock((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemyHelicopter":
                            enemyBehaviour = GetEnemyBehaviour(i);
                            EnemyHelicopter enemyHelicopter = new EnemyHelicopter((int)i.Position.X, (int)i.Position.Y, enemyBehaviour, GetEnemyRange(i), GetEnemyGoingDown(i));
                            enemyBehaviour.Setup(enemyHelicopter, i);
                            StateLocator.State.AddObject(enemyHelicopter);
                            break;
                        case "EnemyHelicopterGun":
                            enemyBehaviour = GetEnemyBehaviour(i);
                            EnemyHelicopterGun enemyHelicopterGun = new EnemyHelicopterGun((int)i.Position.X, (int)i.Position.Y, enemyBehaviour, GetEnemyRange(i), GetEnemyGoingDown(i));
                            enemyBehaviour.Setup(enemyHelicopterGun, i);
                            StateLocator.State.AddObject(enemyHelicopterGun);
                            break;
                        case "EnemyMeteor":
                            StateLocator.State.AddObject(new EnemyMeteor((int)i.Position.X, (int)i.Position.Y, GetEnemyMeteorSize(i)));
                            break;
                        case "EnemyShell":
                            StateLocator.State.AddObject(new EnemyShell((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemyShield":
                            StateLocator.State.AddObject(new EnemyShield((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemySpace":
                            StateLocator.State.AddObject(new EnemySpace((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemySpike":
                            StateLocator.State.AddObject(new EnemySpike((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "EnemyZeppelin":
                            StateLocator.State.AddObject(new EnemyZeppelin((int)i.Position.X, (int)i.Position.Y));
                            break;

                        // BOSS
                        case "BossMeca":
                            StateLocator.State.AddObject(new BossMeca((int)i.Position.X, (int)i.Position.Y));
                            break;
                        case "BossCarrot":
                            StateLocator.State.AddObject(new BossCarrot((int)i.Position.X, (int)i.Position.Y));
                            break;

                    }
                }
            }
        }

        private EnemyBehaviour GetEnemyBehaviour(TiledMapObject i) {
            if(i.Properties.ContainsKey("Behaviour")) {
                switch(i.Properties["Behaviour"]) {
                    case "UpDown":
                        return new EnemyBehaviourUpDown();
                    case "LeftRight":
                        return new EnemyBehaviourLeftRight();
                    case "Circle":
                        return new EnemyBehaviourCircle();
                    case "Shoot":
                        return new EnemyBehaviourShoot();
                    default:
                        return new EnemyEmptyBehaviour();
                }
            }

            return new EnemyEmptyBehaviour();
        }

        private int GetEnemyRange(TiledMapObject i) { 
            if(i.Properties.ContainsKey("Range")) {
                return Int32.Parse(i.Properties["Range"]);
            }
            return 0;
        }

        private bool GetEnemyGoingDown(TiledMapObject i) {
            if (i.Properties.ContainsKey("GoingDown")) {
                return string.Compare(i.Properties["GoingDown"], "true") == 0 ? true : false;
            }
            return false;
        }

        private EnemyMeteorSize GetEnemyMeteorSize(TiledMapObject i) {
            if (i.Properties.ContainsKey("Size")) {
                switch (i.Properties["Size"]) {
                    case "SM":
                        return EnemyMeteorSize.SM;
                    case "MD":
                        return EnemyMeteorSize.MD;
                    case "LG":
                        return EnemyMeteorSize.LG;
                    default:
                        return EnemyMeteorSize.SM;
                }
            }
            return EnemyMeteorSize.SM;
        }

        public void Update(GameTime gameTime) {
            mapRenderer.Update(map, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            //var viewMatrix = CameraLocator.Camera.GetViewMatrix();
            //var projectionMatrix = Matrix.CreateOrthographicOffCenter(0,
            //    ConfigLocator.Config.VirtualWidth,
            //    ConfigLocator.Config.VirtualHeight, 0, 0f, -1f);
            //mapRenderer.Draw(viewMatrix, projectionMatrix);
            mapRenderer.Draw(map);
        }

        public TiledMapObjectLayer GetBlockLayer() {
            return map.GetLayer<TiledMapObjectLayer>("Block");
        }

        public TiledMapObjectLayer GetPlatformLayer() {
            return map.GetLayer<TiledMapObjectLayer>("Platform");
        }

        public TiledMapObjectLayer GetStairLayer() {
            return map.GetLayer<TiledMapObjectLayer>("Stair");
        }

        public bool IsTileBlocked(int x, int y) {
            if (y < 0 || y > mapHeight || x < 0 || x > mapWidth) return false;
            var blockLayer = GetBlockLayer();
            if (blockLayer == null) return false;

            // TiledMapTileLayer
            // TiledMapTile
            // TiledMapObject
            // TiledMapObjectLayer
            // for ()
            // https://github.com/rafaelalmeidatk/Super-Pete-The-Pirate/blob/master/Super%20Pete%20The%20Pirate/Objects/GameMap.cs

            //if (blockLayer.GetTile(x, y) == null) return false;
            //return blockLayer.GetTile(x, y).Id != 0;
            return false;
        }

        public bool IsTilePlatform(int x, int y) {
            if (y < 0 || y > mapHeight || x < 0 || x > mapWidth) return false;
            var platformLayer = GetPlatformLayer();
            if (platformLayer == null) return false;
            //if (platformLayer.GetTile(x, y) == null) return false;
            //return platformLayer.GetTile(x, y).Id != 0;
            return false;
        }

        public TileCollision GetCollision(int x, int y) {
            if (x < 0 || x >= map.Width || IsTileBlocked(x, y)) {
                return TileCollision.Block;
            }
                
            if (IsTilePlatform(x, y)) {
                return TileCollision.Platform;
            }
                
            return TileCollision.Passable;
        }

        public Rectangle GetTileBounds(int x, int y) {
            return new Rectangle(x * (int)tileSize.X, y * (int)tileSize.Y, (int)tileSize.X, (int)tileSize.Y);
        }

        private void DrawColliders(SpriteBatch spriteBatch) {
            foreach (var collider in tileColliderBoxes) {
                spriteBatch.Draw(colliderTexture, collider, Color.White * 0.1f);
            }                
        }

    }

}
