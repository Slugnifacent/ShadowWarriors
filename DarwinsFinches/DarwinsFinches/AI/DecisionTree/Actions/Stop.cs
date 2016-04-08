using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DarwinsFinches
{
    class Stop : Decision
    {
        Kinetic agent;

        public Stop(Kinetic Agent)
        {
            agent = Agent;
        }

        public override void Update()
        {
            agent.velocity = Vector2.Zero;
        }
    }
}
