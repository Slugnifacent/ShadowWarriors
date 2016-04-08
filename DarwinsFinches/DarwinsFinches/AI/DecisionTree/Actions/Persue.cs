using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarwinsFinches
{
    class Persue : Decision
    {
        Kinetic agent;
        Kinetic target;

        public Persue(Kinetic Agent, Kinetic Target)
        {
            agent = Agent;
            target = Target;
        }

        public override void Update() {
            agent.velocity = Movement.Persue(agent, target, agent.maxSpeed);
        }
    }
}
