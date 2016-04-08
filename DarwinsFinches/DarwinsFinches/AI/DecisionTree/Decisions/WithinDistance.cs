using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DarwinsFinches
{
    class WithinDistance : Decision
    {
        GameObject agent;
        GameObject target;
        float distance;

        public WithinDistance(GameObject Agent, GameObject Target, float Distance, Decision True, Decision False) {
            agent = Agent;
            target = Target;
            distance = Distance;
            trueNode = True;
            falseNode = False;
        }

        public override void Update() {
            if (Vector2.Distance(agent.kinetics.position, target.kinetics.position) < distance)
            {
                if(trueNode != null) trueNode.Update();
            }
            else
            {
                if (falseNode != null) falseNode.Update();
            }
        }
    }
}
