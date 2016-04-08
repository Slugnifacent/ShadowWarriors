using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DarwinsFinches
{
    class Movement
    {
        public static float Approach(float Location, float Destination, float Movement)
        {
            return (Destination - Location) * Movement;
        }

        public static Vector2 Approach(Vector2 Location, Vector2 Destination, float Movement)
        {
            return (Destination - Location) * Movement;
        }

        public static Vector3 Approach(Vector3 Location, Vector3 Destination, float Movement)
        {
            return (Destination - Location) * Movement;
        }

        public static Vector4 Approach(Vector4 Location, Vector4 Destination, float Movement)
        {
            return (Destination - Location) * Movement;
        }

        
        public static float Seek(float Location, float Destination)
        {
            return (Destination - Location);
        }

        public static Vector2 Seek(Vector2 Location, Vector2 Destination)
        {
            return (Destination - Location);
        }

        public static Vector3 Seek(Vector3 Location, Vector3 Destination)
        {
            return (Destination - Location);
        }

        public static Vector4 Seek(Vector4 Location, Vector4 Destination)
        {
            return (Destination - Location);
        }

        public static Vector2 Persue(Kinetic Location, Kinetic Target, float MaxSpeed) {
            float distance = Vector2.Distance(Location.position, Target.position);
            float prediction = distance / MaxSpeed;
            Vector2 displacement = Target.velocity * MaxSpeed;
            Vector2 targetNetDisplacement = displacement + Target.position;
            return Seek(Location.position, targetNetDisplacement);
        }

        public static Vector2 Orientate(Kinetic Orientation, Kinetic Target, float MaxAngularVelocity)
        {
            Orientation.orientations.SetOrientation(Target.position - Orientation.position);
            return Orientation.orientations.GetVecOrientation();
        }
    }
}
