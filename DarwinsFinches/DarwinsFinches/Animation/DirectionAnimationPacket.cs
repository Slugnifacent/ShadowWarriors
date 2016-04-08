using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarwinsFinches
{
    class DirectionAnimationPacket
    {
        Animation up;
        Animation down;
        Animation left;
        Animation right;
        Animation idle;
        Animation current;
        int idleFrame;
        public enum Animations { UP, DOWN, LEFT, RIGHT, IDLE }

        public DirectionAnimationPacket()
        {
            current = idle;
        }

        public void Update(Kinetic kinetic)
        {
            float orientation = kinetic.orientations.GetRadOrientation();

            if (orientation <= MathHelper.PiOver4 || orientation > 7 * MathHelper.PiOver4)
            {
                idleFrame = (int)Animations.RIGHT;
                current = right;
            }

            if (orientation <= 3 * MathHelper.PiOver4 && orientation > MathHelper.PiOver4)
            {
                idleFrame = (int)Animations.UP;
                current = up;
            }

            if (orientation <= 5 * MathHelper.PiOver4 && orientation > 3 * MathHelper.PiOver4)
            {
                idleFrame = (int)Animations.LEFT;
                current = left;
            }

            if (orientation <= 7 * MathHelper.PiOver4 && orientation > 5 * MathHelper.PiOver4)
            {
                idleFrame = (int)Animations.DOWN;
                current = down;
            }

            if (kinetic.velocity.LengthSquared() == 0 && idle != null)
            {
                current = idle;
            }

            current.Update();
            current.SetPosition(kinetic.position);
        }

        public void Draw(SpriteBatch batch)
        {
            if (current.Equals(idle))
            {
                current.SetFrame(idleFrame);
            }
            current.Draw(batch);
        }

        public void Draw(SpriteBatch batch, Color tint)
        {
            if (current.Equals(idle))
            {
                current.SetFrame(idleFrame);
            }
            current.Draw(batch,tint);
        }


        public void setAnimation(Animations animEnum)
        {
            switch (animEnum)
            {
                case Animations.UP:
                    current = up;
                    break;
                case Animations.DOWN:
                    current = down;
                    break;
                case Animations.LEFT:
                    current = left;
                    break;
                case Animations.RIGHT:
                    current = right;
                    break;
                case Animations.IDLE:
                    current = idle;
                    break;
            }
        }

        public void InitializeAnimation(Animation Anim, Animations animEnum)
        {
            switch (animEnum)
            {
                case Animations.UP:
                    up = Anim;
                    break;
                case Animations.DOWN:
                    down = Anim;
                    break;
                case Animations.LEFT:
                    left = Anim;
                    break;
                case Animations.RIGHT:
                    right = Anim;
                    break;
                case Animations.IDLE:
                    idle = Anim;
                    break;
            }
        }

        public bool Finished()
        {
            if (current != null)
            {
                return current.Finished();
            }
            return false;
        }

        public void Reset()
        {
            if (current != null)
            {
                current.Reset();
            }
        }
    }
}
