using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarwinsFinches
{
    public abstract class GameObject
    {
        protected Texture2D sprite;
        public Kinetic kinetics;
        abstract public bool Dead();
        abstract public void Update();
        abstract public void Attack();
        public Decision thought;
        abstract public void CollisionResolution(GameObject Item);

        virtual public void Draw(SpriteBatch batch)
        {
            batch.Draw(sprite, kinetics.position, Color.White);
        }
    }
}
