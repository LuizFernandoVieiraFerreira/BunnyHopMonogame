using System;
using BunnyHopMonogame.Src.Entities.Boss.Meca;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss {

    public class BossMeca : Entity {

        public BossMecaStateMachine stateMachine;

        public Sprite flyingClosedBubbleSp;
        public Sprite flyingClosedSp;
        public Sprite flyingOpenedSp;
        public Sprite flyingDyingSp;

        int life;
        int moveSpeed;

        bool canShoot;
        float shootCooldown;
        Timer shootTimer;

        bool firstBulletPattern;
        bool movingUp;

        int range;
        int startY;

        bool isDead;

        public BossMeca(int x=0, int y=0) {
            stateMachine = new BossMecaStateMachine();
            stateMachine.Create(this);
            flyingClosedBubbleSp = new Sprite("boss_meca_closed_bubble");
            flyingClosedSp = new Sprite("boss_meca_closed");
            flyingOpenedSp = new Sprite("boss_meca_open");
            flyingDyingSp = new Sprite("player_flying_dying", 3, 0.5f);
            box = new Rectangle(x, y, flyingClosedBubbleSp.Width, flyingClosedBubbleSp.Height);
            life = 18;
            moveSpeed = 1;
            canShoot = true;
            shootCooldown = 1;
            shootTimer = new Timer();
            firstBulletPattern = true;
            movingUp = false;
            range = 64;
            startY = box.Y;
            isDead = false;
        }

        public override void Update(GameTime gameTime) {
            stateMachine.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            stateMachine.Draw(spriteBatch);
        }

        public override bool IsDead() {
            return isDead;
        }

        public override void NotifyCollision(Entity go) {
            if (go.Is("Bullet") || go.Is("BulletPlayerShip")) {
                life -= 1;
            }
        }

        public override bool Is(string type) {
            return type.Equals("BossMeca");
        }

        public void Die() {
            isDead = true;
        }

        public int Life {
            get {
                return life;
            }
            set {
                life = value;
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

        public bool FirstBulletPattern {
            get {
                return firstBulletPattern;
            }
            set {
                firstBulletPattern = value;
            }
        }

        public bool MovingUp {
            get {
                return movingUp;
            }
            set {
                movingUp = value;
            }
        }

        public int Range {
            get {
                return range;
            }
            set {
                range = value;
            }
        }

        public int StartY {
            get {
                return startY;
            }
            set {
                startY = value;
            }
        }

    }

}
