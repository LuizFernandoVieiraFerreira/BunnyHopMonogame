using System;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class PlayerShip : Entity {

        public PlayerShipStateMachine stateMachine;

        public Sprite flyingSp;
        public Sprite dyingSp;

        int moveUp;
        int moveDown;
        int moveRight;
        int moveLeft;
        int moveHorizontal;
        int moveVertical;

        int moveSpeed;

        int life;

        WeaponType weaponType;
        bool canShoot;
        float shootCooldown;
        Timer shootTimer;

        bool canTakeDmg;
        float takeDmgCooldown;
        Timer takeDmgTimer;
        bool flicking;
        int flickCounter;

        bool render;

        public PlayerShip(int x, int y) {
            stateMachine = new PlayerShipStateMachine();
            stateMachine.Create(this);
            flyingSp = new Sprite("player_flying");
            dyingSp = new Sprite("player_flying_dying", 3, 0.5f);
            box = new Rectangle(x, y, flyingSp.Width, flyingSp.Height);
            moveUp = 0;
            moveDown = 0;
            moveRight = 0;
            moveLeft = 0;
            moveHorizontal = 0;
            moveVertical = 0;
            moveSpeed = 1;
            life = 3;
            weaponType = WeaponType.Ship;
            canShoot = true;
            shootCooldown = 3;
            shootTimer = new Timer();
            canTakeDmg = true;
            takeDmgCooldown = 2;
            takeDmgTimer = new Timer();
            flicking = false;
            flickCounter = 0;
            render = true;
        }

        public override void Update(GameTime gameTime) {
            shootTimer.Update(gameTime);
            if (shootTimer.Get() > shootCooldown) {
                canShoot = true;
            }

            if (flicking) {
                takeDmgTimer.Update(gameTime);
                flickCounter++;
                if (flickCounter > 5) {
                    render = !render;
                    flickCounter = 0;
                }
                if (takeDmgCooldown < (takeDmgTimer.Get() / 1000)) {
                    canTakeDmg = true;
                    takeDmgTimer.Restart();
                    flicking = false;
                    flickCounter = 0;
                    render = true;
                }
            }

            stateMachine.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (render) {
                stateMachine.Draw(spriteBatch);
            }
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("Coin")) {
                InMemoryDatabaseLocator.Database.AddCoin();
            } else if (go.Is("Antidote")) {
                if (life < 3) {
                    life++;
                }
            } else if (go.Is("ItemMachinegun")) {

            } else if (go.Is("ItemMisslegun")) {

            } else if (go.Is("ItemShotgun")) {

            } else if (go.Is("Enemy") || go.Is("EnemyBullet")) {
                if (canTakeDmg) {
                    life -= 1;
                    canTakeDmg = false;
                    if (life > 0) {
                        flicking = true;
                    } else {
                        stateMachine.ChangeState(new PlayerShipDyingState());
                    }
                }
            }
        }

        public override bool IsDead() {
            return life <= 0;
        }

        public override bool Is(string type) {
            return type.Equals("Player");
        }

        public void Revive() {
            box = new Rectangle(10, 80, flyingSp.Width, flyingSp.Height);
            stateMachine.ChangeState(new PlayerShipFlyingState());
        }

        public int MoveUp {
            get {
                return moveUp;
            }
            set {
                moveUp = value;
            }
        }

        public int MoveDown {
            get {
                return moveDown;
            }
            set {
                moveDown = value;
            }
        }

        public int MoveRight {
            get {
                return moveRight;
            }
            set {
                moveRight = value;
            }
        }

        public int MoveLeft {
            get {
                return moveLeft;
            }
            set {
                moveLeft = value;
            }
        }

        public int MoveHorizontal {
            get {
                return moveHorizontal;
            }
            set {
                moveHorizontal = value;
            }
        }

        public int MoveVertical {
            get {
                return moveVertical;
            }
            set {
                moveVertical = value;
            }
        }

        public int MoveSpeed {
            get {
                return moveSpeed;
            }
            set {
                moveSpeed = value;
            }
        }

        public bool CanShoot {
            get {
                return canShoot;
            }
            set {
                canShoot = value;
            }
        }

        public float ShootCooldown {
            get {
                return shootCooldown;
            }
            set {
                shootCooldown = value;
            }
        }

        public Timer ShootTimer {
            get {
                return shootTimer;
            }
            set {
                shootTimer = value;
            }
        }

        public int Life {
            get {
                return life;
            }
            set {
                life = value;
            }
        }

        public WeaponType WeaponType {
            get {
                return weaponType;
            }
            set {
                weaponType = value;
            }
        }

    }

}
