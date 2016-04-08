using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DarwinsFinches.Attributes;

namespace DarwinsFinches
{
    public class RoundGenerator
    {
        GeneticAlgorithm algorithm = new GeneticAlgorithm();
        public List<Enemy> GenerationGenerator(int round)
        {
            List<Enemy> mutatedEnemyList = new List<Enemy>();
            List<Enemy> enemyList = new List<Enemy>();
            switch (round)
            {
                case 1:
                    for (int i = 0; i < 5; ++i) // This will eventually be 10
                    {
                        mutatedEnemyList.Add(algorithm.GenerateRandomEnemy(round));
                    }
                    for (int i = 0; i < 15; ++i) // This will eventually be 90
                    {
                        enemyList.Add(algorithm.GenerateRandomEnemy(round));
                    }
                    
                    break;
                default:
                    
                    for (int i = 0; i < 10; ++i)
                    {
                        mutatedEnemyList.Add(algorithm.GenerateRandomEnemy(round));
                    }
                    for (int i = 0; i < 90; ++i)
                    {
                        enemyList.Add(algorithm.GenerateRandomEnemy(round));
                    }
                    algorithm.SetRandAvg(round, enemyList);

                    break;
            }
            enemyList.AddRange(mutatedEnemyList);
            foreach (Enemy enemy in enemyList)
            {
                enemy.RoundSpawned = round;
            }
            return enemyList;
        }
    }
}
