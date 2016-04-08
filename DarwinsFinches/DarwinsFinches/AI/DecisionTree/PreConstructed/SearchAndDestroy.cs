using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarwinsFinches
{
    class SearchAndDestroy : Decision
    {

        Decision searchAndDestroy;
        GameObject agent;
        GameObject target;
        // Distance Approach , Attack
        public SearchAndDestroy(GameObject Agent, GameObject Target) {
            agent = Agent;
            target = Target;

            Stop stop = new Stop(agent.kinetics);
            Persue persue = new Persue(agent.kinetics, target.kinetics);
            Approach approach = new Approach(agent.kinetics, target.kinetics);
            Attack destroy = new Attack(agent);
            WithinDistance approachable = new WithinDistance(agent, target, 300, destroy     , approach);
            WithinDistance seekDestroy = new WithinDistance(agent , target, 500, approachable, persue);
            searchAndDestroy = seekDestroy;
        }
        public override void Update() {
            searchAndDestroy.Update();
        }
    }
}
