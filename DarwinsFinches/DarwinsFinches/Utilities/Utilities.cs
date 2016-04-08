using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarwinsFinches
{
    public class Utilities
    {
        static Utilities util;
        Stopwatch clock;
        SpriteFont font;
        Utilities()
        {
            clock = new Stopwatch();
            font = Game1.content.Load<SpriteFont>(@"Font\Default");
        }

        public static Utilities Instance()
        {
            if (util == null)
            {
                util = new Utilities();
            }
            return util;
        }

        public void StartWatch()
        {
            clock.Start();
        }

        public void RestartWatch()
        {
            clock.Restart();
        }

        public TimeSpan ElapsedTime()
        {
            return clock.Elapsed;
        }

        public void DrawTime(SpriteBatch batch)
        {
            TimeSpan span = clock.Elapsed;
            batch.DrawString(font, span.ToString(), new Vector2(50, 450), Color.White);

            batch.DrawString(font, Avatar.Instance().kinetics.position.ToString(), new Vector2(50, 500), Color.White);
        }


        public void DrawString(SpriteBatch batch, string item, int offset)
        {
            batch.DrawString(font, item, new Vector2(50, 400 + offset), Color.White);
        }

        public int Wrap(int Value, int Min, int Max) {
            if (Value < Min) return Max;
            if (Value > Max) return Min;
            return Value;
        }

        public float Wrap(float Value, float Min, float Max)
        {
            if (Value < Min) return Max;
            if (Value > Max) return Min;
            return Value;
        }

    }
}
