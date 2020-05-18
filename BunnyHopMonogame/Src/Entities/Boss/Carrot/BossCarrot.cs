using System;
using BunnyHopMonogame.Src.Entities.Boss.Carrot;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Boss {

    public class BossCarrot : Entity {

        public BossCarrotStateMachine stateMachine;

        public Sprite idleSp;
        public Sprite rotSp;
        public Sprite bombSp;
        public Sprite spikeSp;
        public Sprite dyingSp;

        int life;

        bool canShoot;
        float shootCooldown;
        Timer shootTimer;

        bool canSpike;
        float spikeCooldown;
        Timer spikeTimer;

        bool isDead;

        public BossCarrot(int x=0, int y=0) {
            stateMachine = new BossCarrotStateMachine();
            stateMachine.Create(this);
            idleSp = new Sprite("boss_meca_closed_bubble");
            rotSp = new Sprite("boss_meca_closed");
            bombSp = new Sprite("boss_meca_open");
            spikeSp = new Sprite("player_flying_dying", 3, 0.5f);
            dyingSp = new Sprite("player_flying_dying", 3, 0.5f);
            box = new Rectangle(x, y, idleSp.Width, idleSp.Height);
            life = 3;
            canShoot = true;
            shootCooldown = 1;
            shootTimer = new Timer();
            canSpike = true;
            spikeCooldown = 1;
            spikeTimer = new Timer();
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
            return type.Equals("BossCarrot");
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

        public bool CanSpike {
            get {
                return canSpike;
            }
            set {
                canSpike = value;
            }
        }

        public float SpikeCooldown {
            get {
                return spikeCooldown;
            }
            set {
                spikeCooldown = value;
            }
        }

        public Timer SpikeTimer {
            get {
                return spikeTimer;
            }
            set {
                spikeTimer = value;
            }
        }

    }

}
