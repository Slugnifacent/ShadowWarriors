using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DarwinsFinches.Attributes;

namespace DarwinsFinches
{
    public class Enemy : GameObject
    {
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public AttackType AttackType { get; set; }
        public string EnemyColor { get; set; }

        public Weapons Weapon { get; set; }

        public int RoundSpawned { get; set; }
        public int Score { get; set; }
        public Vector2 Position { get; set; }

        DirectionAnimationPacket attack;
        DirectionAnimationPacket walk;

        Timer attackTimer;

        public Enemy()
        {
            this.HP = 3;
            this.Speed = 5;
            this.Damage = 30;
            this.AttackType = AttackType.Melee;
            this.EnemyColor = "red";
            this.Weapon = Weapons.Sword;
            this.RoundSpawned = 1;
            this.Score = 5;
            InitializeAnimation();
            attackTimer = new Timer(2);
        }

        public Enemy(int hp, int speed, int damage, AttackType attackType, string enemyColor, Weapons weapon, int roundSpawned, int score)
        {
            this.HP = 3;
            this.Speed = speed;
            this.Damage = damage;
            this.AttackType = attackType;
            this.EnemyColor = enemyColor;
            this.Weapon = weapon;
            this.RoundSpawned = roundSpawned;
            this.Score = score;
            InitializeAnimation();
            attackTimer = new Timer(2);
        }

        void InitializeAnimation()
        {
            kinetics = Kinetic.ZERO();
            kinetics.position = new Vector2(100, 100);
            Kinetic.SetBoundingBoxDimensions(ref kinetics.boundingBox, Game1.content.Load<Texture2D>(@"Enemy\Up\enemy-up-2"));

            Animation Up = new Animation();
            Up.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Up\enemy-up-2"));
            Up.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Up\enemy-up-1"));
            Up.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Up\enemy-up-2"));
            Up.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Up\enemy-up-3"));
            Up.SetTime(10);
            Up.SetFrame(0);

            Animation Down = new Animation();
            Down.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Down\enemy-wc-down-2"));
            Down.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Down\enemy-wc-down-1"));
            Down.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Down\enemy-wc-down-2"));
            Down.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Down\enemy-wc-down-3"));
            Down.SetTime(10);
            Down.SetFrame(0);

            Animation Left = new Animation();
            Left.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Left\wc-left-2"));
            Left.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Left\wc-left-1"));
            Left.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Left\wc-left-2"));
            Left.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Left\wc-left-3"));
            Left.SetTime(10);
            Left.SetFrame(0);

            Animation Right = new Animation();
            Right.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Right\wc-right-2"));
            Right.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Right\wc-right-1"));
            Right.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Right\wc-right-2"));
            Right.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Right\wc-right-3"));
            Right.SetTime(10);
            Right.SetFrame(0);

            Animation Idle = new Animation();
            Idle.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Up\enemy-up-2"));
            Idle.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Down\enemy-wc-down-2"));
            Idle.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Left\wc-left-3"));
            Idle.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\Right\wc-right-3"));
            Idle.SetTime(10);
            Idle.SetFrame(0);


            walk = new DirectionAnimationPacket();
            walk.InitializeAnimation(Up, DirectionAnimationPacket.Animations.UP);
            walk.InitializeAnimation(Down, DirectionAnimationPacket.Animations.DOWN);
            walk.InitializeAnimation(Left, DirectionAnimationPacket.Animations.LEFT);
            walk.InitializeAnimation(Right, DirectionAnimationPacket.Animations.RIGHT);
            walk.InitializeAnimation(Idle, DirectionAnimationPacket.Animations.IDLE);
            walk.setAnimation(DirectionAnimationPacket.Animations.IDLE);

            Animation AttackUp = new Animation();
            int attackSpeed = 3;
            Texture2D temp = Game1.content.Load<Texture2D>(@"Enemy\AttackUp\enemy-attack-up-1");
            AttackUp.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackUp\enemy-attack-up-1"));
            AttackUp.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackUp\enemy-attack-up-2"));
            AttackUp.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackUp\enemy-attack-up-3"));
            AttackUp.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackUp\enemy-attack-up-4"));
            AttackUp.SetTime(attackSpeed);
            AttackUp.Offset(new Vector2(-64, -64));
            AttackUp.SetFrame(0);

            Animation AttackDown = new Animation();
            AttackDown.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackDown\enemy-attack-down-1"));
            AttackDown.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackDown\enemy-attack-down-2"));
            AttackDown.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackDown\enemy-attack-down-3"));
            AttackDown.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackDown\enemy-attack-down-4"));
            AttackDown.SetTime(attackSpeed);
            AttackDown.SetFrame(0);

            Animation AttackLeft = new Animation();
            AttackLeft.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackLeft\enemy-attack-left-1"));
            AttackLeft.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackLeft\enemy-attack-left-2"));
            AttackLeft.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackLeft\enemy-attack-left-3"));
            AttackLeft.SetTime(attackSpeed);
            AttackLeft.Offset(new Vector2(-64, -64));
            AttackLeft.SetFrame(0);

            Animation AttackRight = new Animation();
            AttackRight.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackRight\enemy-attack-right-1"));
            AttackRight.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackRight\enemy-attack-right-2"));
            AttackRight.AddFrame(Game1.content.Load<Texture2D>(@"Enemy\AttackRight\enemy-attack-right-3"));
            AttackRight.SetTime(attackSpeed);
            AttackRight.Offset(new Vector2(-0, -64));
            AttackRight.SetFrame(0);

            attack = new DirectionAnimationPacket();
            attack.InitializeAnimation(AttackUp, DirectionAnimationPacket.Animations.UP);
            attack.InitializeAnimation(AttackDown, DirectionAnimationPacket.Animations.DOWN);
            attack.InitializeAnimation(AttackLeft, DirectionAnimationPacket.Animations.LEFT);
            attack.InitializeAnimation(AttackRight, DirectionAnimationPacket.Animations.RIGHT);
            attack.setAnimation(DirectionAnimationPacket.Animations.RIGHT);

            thought = new SearchAndDestroy(this,Avatar.Instance());

        }

        public override bool Dead()
        {
            return (HP <= 0);
        }

        public override void Update()
        {
            float max = 5;
            Decision.makeDecision(thought);
            kinetics.velocity.X = MathHelper.Clamp(kinetics.velocity.X, -max, max);
            kinetics.velocity.Y = MathHelper.Clamp(kinetics.velocity.Y, -max, max);
            kinetics.Update();
            attackTimer.Update();
            walk.Update(kinetics);
        }

        public override void Draw(SpriteBatch batch)
        {
            walk.Draw(batch);
            
        }

        public override void Attack()
        {
            kinetics.velocity = Vector2.Zero;
            kinetics.orientations.SetOrientation(Movement.Orientate(kinetics, Avatar.Instance().kinetics, 60));
            if (attackTimer.Ready())
            {
                FireBall fireBall = new FireBall(kinetics.position, kinetics.orientations.GetVecOrientation() * 10, 30, false);
                LevelManager.Instance().getCurrentLevel().InsertGameObject(fireBall);
                SoundManager.Instance().AddSound(new SFX("SFX\\fireball"));
                attackTimer.Reset();

                thought = new SearchAndDestroy(this,Avatar.Instance());
            }
        }

        public override void CollisionResolution(GameObject Item)
        {
            if (Item.GetType().Equals(typeof(Avatar)))
            {

            }
            if (Item.GetType().Equals(typeof(FireBall)))
            {
                FireBall temp = Item as FireBall;
                if (temp.Friendly())
                {
                    SoundManager.Instance().AddSound(new SFX("SFX\\explosion"));
                    float test = Vector2.Dot(kinetics.orientations.GetVecOrientation(), temp.kinetics.orientations.GetVecOrientation());
                    if (test < 0)
                    {
                        HP -= 1;
                    }
                    else
                    {
                        HP = 0;
                    }
                }
            }
        }
    }
}
