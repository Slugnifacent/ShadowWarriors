using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DarwinsFinches
{
    public class LevelManager
    {
        static LevelManager manager;
        Level current;

        LevelManager()
        {
        }

        public static LevelManager Instance()
        {
            if (manager == null)
            {
                manager = new LevelManager();
            }
            return manager;
        }

        public void Update()
        {
            current.Update();
        }

        public void Draw(SpriteBatch batch)
        {
            current.Draw(batch);
        }

        public Level getCurrentLevel()
        {
            return current;
        }

        public void SetLevel(Level lvl)
        {
            current = lvl;
        }

    }
}
