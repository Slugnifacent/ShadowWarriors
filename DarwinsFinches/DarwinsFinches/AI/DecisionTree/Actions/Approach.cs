using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarwinsFinches
{
    class Approach : Decision
    {
        Kinetic agent;
        Kinetic target;

        public Approach(Kinetic Agent, Kinetic Target)
        {
            agent = Agent;
            target  = Target;
        }

        public override void Update()
        {
            agent.velocity = Movement.Approach(agent.position, target.position, .1f);
        }
    }
}
