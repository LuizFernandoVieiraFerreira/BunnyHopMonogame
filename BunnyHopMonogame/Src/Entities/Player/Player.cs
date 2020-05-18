using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.Entities.Player {

    public class Player : Entity {

        public PlayerStateMachine stateMachine;

        Vector2 position;

        public Sprite idleSp;
        public Sprite walkingSp;
        public Sprite dyingSp;

        int moveUp;
        int moveDown;
        int moveRight;
        int moveLeft;
        int moveHorizontal;
        int moveVertical;

        int moveSpeed;
        int gravity;

        bool facingRight;

        int life;

        bool canShoot;
        float shootCooldown;
        Timer shootTimer;
        bool takingDmg;
        bool canTakeDmg;
        float takeDmgCooldown;
        Timer takeDmgTimer;
        bool flicking;
        int flickCounter;

        public Player() {
            stateMachine = new PlayerStateMachine();
            stateMachine.Create(this);
            position = new Vector2(10, 10);
            idleSp = new Sprite("player_idle");
            walkingSp = new Sprite("player_walking", 8, 1);
            dyingSp = new Sprite("player_idle");
            moveUp = 0;
            moveDown = 0;
            moveRight = 0;
            moveLeft = 0;
            moveHorizontal = 0;
            moveVertical = 0;
            moveSpeed = 3;
            gravity = 1;
            facingRight = true;
            life = 3;
            canShoot = true;
            shootCooldown = 3;
            shootTimer = new Timer();
            takingDmg = false;
            canTakeDmg = true;
            takeDmgCooldown = 3;
            takeDmgTimer = new Timer();
            flicking = false;
            flickCounter = 0;
        }

        public override void Update(GameTime gameTime) {
            if (position.Y < 116) {
                position.Y += gravity;
            }
            stateMachine.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            stateMachine.Draw(spriteBatch);
        }

        public override void NotifyCollision(Entity go) {

        }

        public override bool IsDead() {
            return life <= 0;
        }

        public override bool Is(string type) {
            return type.Equals("Player");
        }

        public Vector2 Position {
            get {
                return position;
            }
            set {
                position = value;
            }
        }

    }

}
