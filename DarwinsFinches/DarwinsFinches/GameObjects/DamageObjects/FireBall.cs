using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarwinsFinches
{
    class FireBall : DamageBox
    {
        public FireBall(Vector2 Position, Vector2 Velocity, int Time, bool Friendly)
                 : base(Position, Velocity, Time, Friendly)
        {
            anim.AddFrame(Game1.content.Load<Texture2D>(@"VisualEffects\fire-1"));
            anim.AddFrame(Game1.content.Load<Texture2D>(@"VisualEffects\fire-2"));
            anim.AddFrame(Game1.content.Load<Texture2D>(@"VisualEffects\fire-3"));
            anim.AddFrame(Game1.content.Load<Texture2D>(@"VisualEffects\fire-4"));
        }
    }
}
