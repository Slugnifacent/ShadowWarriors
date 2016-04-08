using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DarwinsFinches
{
    class Shadow : GameObject
    {
        Rectangle levelBounds;
        bool Melee;
        bool Magic;

        DirectionAnimationPacket walk;
        DirectionAnimationPacket attack;
        DirectionAnimationPacket magic;
        DirectionAnimationPacket currentAnimation;

        int timer = 0;
        bool still;
        public Shadow()
        {
            sprite = Game1.content.Load<Texture2D>("Hero");
            kinetics = new Kinetic(new Vector2(400, 400), new Vector2(0, 0), new Rectangle());
            Kinetic.SetBoundingBoxDimensions(ref kinetics.boundingBox, sprite);
            kinetics.maxSpeed = 5;
            levelBounds = new Rectangle(124, 178, 800, 550);

            Animation Up = new Animation();
            Up.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Up\wc-up-2"));
            Up.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Up\wc-up-1"));
            Up.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Up\wc-up-2"));
            Up.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Up\wc-up-3"));
            Up.SetTime(10);
            Up.SetFrame(0);

            Animation Down = new Animation();
            Down.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Down\wc-down-2"));
            Down.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Down\wc-down-1"));
            Down.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Down\wc-down-2"));
            Down.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Down\wc-down-3"));
            Down.SetTime(10);
            Down.SetFrame(0);

            Animation Left = new Animation();
            Left.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Left\wc-left-2"));
            Left.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Left\wc-left-1"));
            Left.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Left\wc-left-2"));
            Left.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Left\wc-left-3"));
            Left.SetTime(10);
            Left.SetFrame(0);

            Animation Right = new Animation();
            Right.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Right\wc-right-2"));
            Right.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Right\wc-right-1"));
            Right.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Right\wc-right-2"));
            Right.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Right\wc-right-3"));
            Right.SetTime(10);
            Right.SetFrame(0);

            Animation Idle = new Animation();
            Idle.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Up\wc-up-2"));
            Idle.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Down\wc-down-2"));
            Idle.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Left\wc-left-2"));
            Idle.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Right\wc-right-2"));
            Idle.SetTime(10);
            Idle.SetFrame(0);


            walk = new DirectionAnimationPacket();
            walk.InitializeAnimation(Up, DirectionAnimationPacket.Animations.UP);
            walk.InitializeAnimation(Down, DirectionAnimationPacket.Animations.DOWN);
            walk.InitializeAnimation(Left, DirectionAnimationPacket.Animations.LEFT);
            walk.InitializeAnimation(Right, DirectionAnimationPacket.Animations.RIGHT);
            walk.InitializeAnimation(Idle, DirectionAnimationPacket.Animations.IDLE);
            walk.setAnimation(DirectionAnimationPacket.Animations.IDLE);

            int attackSpeed = 3;
            Animation AttackUp = new Animation();
            Texture2D temp = Game1.content.Load<Texture2D>(@"Hero\Attack\Up\attack-up-1");
            AttackUp.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Up\attack-up-1"));
            AttackUp.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Up\attack-up-2"));
            AttackUp.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Up\attack-up-3"));
            AttackUp.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Up\attack-up-4"));
            AttackUp.SetTime(attackSpeed);
            AttackUp.Offset(new Vector2(-64, -64));
            AttackUp.SetFrame(0);

            Animation AttackDown = new Animation();
            AttackDown.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Down\attack-down-1"));
            AttackDown.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Down\attack-down-2"));
            AttackDown.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Down\attack-down-3"));
            AttackDown.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Down\attack-down-4"));
            AttackDown.SetTime(attackSpeed);
            AttackDown.SetFrame(0);

            Animation AttackLeft = new Animation();
            AttackLeft.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Left\attack-left-1"));
            AttackLeft.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Left\attack-left-2"));
            AttackLeft.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Left\attack-left-3"));
            AttackLeft.SetTime(attackSpeed);
            AttackLeft.Offset(new Vector2(-64, -64));
            AttackLeft.SetFrame(0);

            Animation AttackRight = new Animation();
            AttackRight.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Right\attack-right-1"));
            AttackRight.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Right\attack-right-2"));
            AttackRight.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Right\attack-right-3"));
            AttackRight.SetTime(attackSpeed);
            AttackRight.Offset(new Vector2(-0, -64));
            AttackRight.SetFrame(0);

            attack = new DirectionAnimationPacket();
            attack.InitializeAnimation(AttackUp, DirectionAnimationPacket.Animations.UP);
            attack.InitializeAnimation(AttackDown, DirectionAnimationPacket.Animations.DOWN);
            attack.InitializeAnimation(AttackLeft, DirectionAnimationPacket.Animations.LEFT);
            attack.InitializeAnimation(AttackRight, DirectionAnimationPacket.Animations.RIGHT);

            attackSpeed = 3;
            Animation MagicUp = new Animation();
            temp = Game1.content.Load<Texture2D>(@"Hero\Attack\Up\attack-up-1");
            MagicUp.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Up\attack-up-4"));
            MagicUp.SetTime(attackSpeed);
            MagicUp.Offset(new Vector2(-64, -64));
            MagicUp.SetFrame(0);

            Animation MagicDown = new Animation();
            MagicDown.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Down\attack-down-4"));
            MagicDown.SetTime(attackSpeed);
            MagicDown.SetFrame(0);

            Animation MagicLeft = new Animation();
            MagicLeft.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Left\attack-left-3"));
            MagicLeft.SetTime(attackSpeed);
            MagicLeft.Offset(new Vector2(-64, -64));
            MagicLeft.SetFrame(0);

            Animation MagicRight = new Animation();
            MagicRight.AddFrame(Game1.content.Load<Texture2D>(@"Hero\Attack\Right\attack-right-3"));
            MagicRight.SetTime(attackSpeed);
            MagicRight.Offset(new Vector2(-0, -64));
            MagicRight.SetFrame(0);

            magic = new DirectionAnimationPacket();
            magic.InitializeAnimation(MagicUp, DirectionAnimationPacket.Animations.UP);
            magic.InitializeAnimation(MagicDown, DirectionAnimationPacket.Animations.DOWN);
            magic.InitializeAnimation(MagicLeft, DirectionAnimationPacket.Animations.LEFT);
            magic.InitializeAnimation(MagicRight, DirectionAnimationPacket.Animations.RIGHT);
            magic.setAnimation(DirectionAnimationPacket.Animations.UP);
            currentAnimation = walk;

        }

        public override bool Dead()
        {
            return false;
        }

        public override void Update()
        {
            float speed = 5;
            kinetics.velocity.X = ControllerInput.Instance().Sticks.Right.X * speed;
            kinetics.velocity.Y = -ControllerInput.Instance().Sticks.Right.Y * speed;

            if (ControllerInput.Instance().GetKey(Keys.Left).Held)
            {
                kinetics.velocity.X = -speed;
            }

            if (ControllerInput.Instance().GetKey(Keys.Right).Held)
            {
                kinetics.velocity.X = speed;
            }

            if (ControllerInput.Instance().GetKey(Keys.Down).Held)
            {
                kinetics.velocity.Y = speed;
            }

            if (ControllerInput.Instance().GetKey(Keys.Up).Held)
            {
                kinetics.velocity.Y = -speed;
            }

            Attack();

            LevelBoundingBox();

            kinetics.Update();

            if (Melee)
            {
                if (currentAnimation.Finished())
                {
                    currentAnimation = walk;
                    currentAnimation.Reset();
                    Melee = false;
                }
            }

            if (Magic)
            {
                if (currentAnimation.Finished())
                {
                    currentAnimation = walk;
                    currentAnimation.Reset();
                    Magic = false;
                }
            }

            currentAnimation.Update(kinetics);
            if (Vector2.Distance(kinetics.position, Avatar.Instance().kinetics.position) < 50) {
                Avatar.Instance().health.grow(.05f);
            }
        }

        public void LevelBoundingBox()
        {
            kinetics.position.X = MathHelper.Clamp(kinetics.position.X, levelBounds.Left, levelBounds.Right - kinetics.boundingBox.Width);
            kinetics.position.Y = MathHelper.Clamp(kinetics.position.Y, levelBounds.Top, levelBounds.Bottom - kinetics.boundingBox.Height);
        }

        public override void CollisionResolution(GameObject Item)
        {

        }

        public override void Attack()
        {
            if (ControllerInput.Instance().GetButton(Buttons.X).Pressed && !Magic ||
                ControllerInput.Instance().GetKey(Keys.X).Pressed && !Magic)
            {
                DamageBox temp = new DamageBox(kinetics.position + kinetics.orientations.GetVecOrientation() * 100, Vector2.Zero, 3, true);
                LevelManager.Instance().getCurrentLevel().InsertGameObject(temp);
                SoundManager.Instance().AddSound(new SFX("SFX\\swing"));
                Melee = true;
                currentAnimation = attack;
                currentAnimation.Reset();
            }

            if (ControllerInput.Instance().GetButton(Buttons.RightShoulder).Pressed) { 
               
                still = !still;
                
            }

            if(still){
                if (kinetics.velocity != Vector2.Zero)
                {
                    kinetics.orientations.SetOrientation(kinetics.velocity);
                    kinetics.velocity = Vector2.Zero;
                }
            }


            if (ControllerInput.Instance().GetButton(Buttons.RightTrigger).Held && !Melee ||
                ControllerInput.Instance().GetKey(Keys.Z).Pressed && !Melee)
            {
                still = true;
                if (timer > 15)
                {
                    FireBall fireBall = new FireBall(kinetics.position, kinetics.orientations.GetVecOrientation() * 30, 30, true);
                    LevelManager.Instance().getCurrentLevel().InsertGameObject(fireBall);
                    SoundManager.Instance().AddSound(new SFX("SFX\\fireball"));
                    Magic = true;
                    currentAnimation = magic;
                    currentAnimation.Reset();
                    timer = 0;
                }
                else timer++;
            }
            if (ControllerInput.Instance().GetButton(Buttons.RightTrigger).Released) {
                timer = 15;
                still = false;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            currentAnimation.Draw(batch,Color.BlueViolet);
            
        }
    }
}
