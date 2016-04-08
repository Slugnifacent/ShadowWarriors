using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarwinsFinches
{
    class Attack : Decision
    {
        GameObject gameObject;

        public Attack(GameObject _GameObject)
        {
            gameObject = _GameObject;
        }

        public override void Update()
        {
            gameObject.thought = this;
            gameObject.Attack();
        }
    }
}
