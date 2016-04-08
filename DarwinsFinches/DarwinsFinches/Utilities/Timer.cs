using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarwinsFinches
{
    class Timer
    {
        float goalTime;
        float currentTime;
        bool puase;
        DateTime timeStamp;

        public Timer(float Timer) {
            goalTime = Timer;
            timeStamp = DateTime.Now;
            currentTime = 0;
        }

        public void Update() {
            if (puase) return;
            DateTime time = DateTime.Now;
            currentTime = (float)DateTime.Now.Subtract(timeStamp).TotalSeconds;
        }

        public bool  Ready() { 
            return currentTime > goalTime;
        }

        public void Start() {
            puase = false;
        }

        public void Puase() {
            puase = true;
        }

        public void Reset() {
            currentTime = 0;
            timeStamp = DateTime.Now;
        }

        public float CurrentTime()
        {
            return currentTime;
        }
    }
}
