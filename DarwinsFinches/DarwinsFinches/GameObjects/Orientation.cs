using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DarwinsFinches
{
    public class Orientation
    {
        Vector2 vecOrient;
        float radOrient;

        public Orientation() {
            SetOrientation(0);
        }

        public Orientation(Vector2 Orient) {
            SetOrientation(Orient);
        }

        public Orientation(float Orient)
        {
            SetOrientation(Orient);
        }

        public void SetOrientation(Vector2 Orient)
        {
            Orient.Normalize();
            vecOrient = Orient;

            if (vecOrient.Y > 0)
            {
                radOrient = (float)Math.Acos(Vector2.Dot(vecOrient, new Vector2(-1, 0)));
                radOrient += MathHelper.Pi;
            }
            else
            {
                radOrient = (float)Math.Acos(Vector2.Dot(vecOrient, new Vector2(1, 0)));
            }

        }

        public void SetOrientation(float Orient)
        {
            radOrient = Orient;
            vecOrient.X = (float)Math.Cos(Orient);
            vecOrient.Y = -(float)Math.Sin(Orient);
        }

        public Vector2 GetVecOrientation() {
            return vecOrient;
        }

        public float GetRadOrientation() {
            return radOrient;
        }
    }
}
