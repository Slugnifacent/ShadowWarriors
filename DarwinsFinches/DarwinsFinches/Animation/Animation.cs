using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarwinsFinches
{
    class Animation
    {
        Vector2 position;
        List<Texture2D> animation;
        int index;
        int timer;
        int maxTimer;
        Vector2 offset;

        bool completed;

        public Animation()
        {
            offset = Vector2.Zero;
            animation = new List<Texture2D>();
        }

        public Animation(List<Texture2D> Animation, int Time) {
            animation = Animation;
            maxTimer = timer = Time;
        }

        public void SetPosition(Vector2 Position) {
            position = Position;
        }

        public void SetTime(int Time)
        {
            maxTimer = timer = Time; 
        }

        public void AddFrame(Texture2D Item) {
            animation.Add(Item);
        }

        public void Update() {
            if (animation.Count <= 1)
            {
                completed = true;
                return;
            }
            if (timer <= 0) {
                index++;
                if (index > animation.Count - 2)
                {
                    completed = true;
                }
                index = Utilities.Instance().Wrap(index, 0, animation.Count - 1);
                timer = maxTimer;
            }
            timer--;
        }

        public void SetFrame(int Frame) {
            index = (int)MathHelper.Clamp(Frame, 0, animation.Count);
        }

        public int Count() {
            return animation.Count;
        }

        public void Offset(Vector2 Value)
        {
            offset = Value;
        }

        public void Reset()
        {
            SetFrame(0);
            completed = false;
        }

        public bool Finished() {
            return completed;
        }
        public void Draw(SpriteBatch batch) {
            batch.Draw(animation.ElementAt<Texture2D>(index), position + offset, Color.White);
        }

        public void Draw(SpriteBatch batch, Color tint)
        {
            batch.Draw(animation.ElementAt<Texture2D>(index), position + offset, tint);
        }
    }
}
