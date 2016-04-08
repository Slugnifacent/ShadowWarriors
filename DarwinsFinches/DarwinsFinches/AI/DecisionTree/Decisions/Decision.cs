using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DarwinsFinches
{
    public abstract class Decision
    {

        public Decision trueNode;
        public Decision falseNode;

        public static void makeDecision(Decision DecisionTree) {
            DecisionTree.Update();
        }

       abstract public void Update();

    }
}
