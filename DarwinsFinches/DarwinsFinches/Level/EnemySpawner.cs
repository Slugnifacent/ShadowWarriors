using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DarwinsFinches
{
    public class EnemySpawner
    {
        List<Enemy> enemiesList = new List<Enemy>();
        int round = 1;
        RoundGenerator roundGenerator;
        public EnemySpawner()
        {
            roundGenerator = new RoundGenerator();
        }
        public void Update()
        {
            List<Enemy> enemies = new List<Enemy>();
            
                
            if (Utilities.Instance().ElapsedTime().Seconds == 60)
            {
                enemies.AddRange(roundGenerator.GenerationGenerator(round));
                round++;
            }
            foreach (Enemy enemy in enemies)
            {
                LevelManager.Instance().getCurrentLevel().InsertGameObject(enemy);
            }
            
            //Enemy e = new Enemy
        }
    }
}
