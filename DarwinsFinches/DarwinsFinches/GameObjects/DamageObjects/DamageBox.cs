using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarwinsFinches
{
    class DamageBox : GameObject
    {
        bool dead;
        int time;
        bool friendly;
        public Animation anim;
        public DamageBox(Vector2 Position, Vector2 Velocity, int Time, bool Friendly)
        {
            sprite = Game1.content.Load<Texture2D>("Hero");
            kinetics = Kinetic.ZERO();
            kinetics.position = Position;
            kinetics.velocity = Velocity;
            Kinetic.SetBoundingBoxDimensions(ref kinetics.boundingBox, sprite);
            dead = false;
            time = Time;
            friendly = Friendly;
            anim = new Animation();
        }

        public override void Update()
        {
            if (time <= 0)
            {
                dead = true;
            }
            kinetics.Update();
            time--;
            anim.Update();
            anim.SetPosition(kinetics.position);
        }

        public override bool Dead()
        {
            return dead;
        }

        public override void CollisionResolution(GameObject Item)
        {
            if (Item.GetType() == typeof(Avatar))
            {
                if (!friendly)
                {
                    dead = true;
                }
            }

            if (Item.GetType() == typeof(Enemy))
            {
                if (friendly)
                {
                    dead = true;
                }
            }
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch batch)
        {
            if (anim.Count() > 0)
            {
                anim.Draw(batch);
            }
        }

        public Animation GetAnimation()
        {
            return anim;
        }

        public bool Friendly()
        {
            return friendly;
        }
    }
}
