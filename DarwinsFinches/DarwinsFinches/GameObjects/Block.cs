using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarwinsFinches
{
    class Block : GameObject
    {
        bool dead;
        public Block(Vector2 Position)
        {
            sprite = Game1.content.Load<Texture2D>("Hero");
            kinetics = Kinetic.ZERO();
            kinetics.position = Position;
            Kinetic.SetBoundingBoxDimensions(ref kinetics.boundingBox, sprite);
            dead = false;
        }

        public override void Update()
        {
            kinetics.Update();
        }

        public override bool Dead()
        {
            return dead;
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void CollisionResolution(GameObject Item)
        {
            if (Item.GetType() == typeof(Avatar))
            {
                dead = true;
            }
            if (Item.GetType() == typeof(DamageBox))
            {
                dead = true;
            }
        }
    }
}
