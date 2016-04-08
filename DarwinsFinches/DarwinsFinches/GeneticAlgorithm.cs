using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DarwinsFinches.Attributes;

namespace DarwinsFinches
{
    public class GeneticAlgorithm
    {

        public static int EnemiesRemainingInGeneration = 100;
        public AverageStats avgStats = new AverageStats();
        public void calculateAverages(List<Enemy> enemies)
        {
            int enemyCount = 0;
            string maxColor = "tmp";
            Dictionary<string, int> colors = new Dictionary<string, int>();
            int melee = 0;
            int ranged = 0;
            foreach (Enemy enemy in enemies)
            {
                avgStats.AvgHP += enemy.HP;
                avgStats.AvgSpeed += enemy.Speed;
                avgStats.AvgDamage += enemy.Damage;
                //calculate greatest color
                if(colors.ContainsKey(enemy.EnemyColor))
                {
                     colors[enemy.EnemyColor]++;
                }
                else
                {
                    colors.Add(enemy.EnemyColor, 1);
                }
                //calculate greatest attack type
                if (enemy.AttackType == AttackType.Melee)
                {
                    melee++;
                }
                else
                {
                    ranged++;
                }

                enemyCount++;
            }
            foreach (KeyValuePair<string, int> color in colors)
            {
                int maxValue = 0;
                if (maxValue < color.Value)
                {
                    maxColor = color.Key;
                }
            }

            if (melee > ranged)
            {
                avgStats.GreatestAttackType = AttackType.Melee;
            }
            else
            {
                avgStats.GreatestAttackType = AttackType.Ranged;
            }
            avgStats.GreatestColor = maxColor;

            avgStats.AvgHP /= enemyCount;
            avgStats.AvgSpeed /= enemyCount;
            avgStats.AvgDamage /= enemyCount;
        }

        public Random randAttribute = new Random(DateTime.Now.Millisecond);

        public void SetRandAvg(int round, List<Enemy> enemies)
        {
            calculateAverages(enemies);
            foreach (Enemy enemy in enemies)
            {
                Dictionary<int, int> TempDict = new Dictionary<int, int>();
                for (int i = 0; i < round; i++)
                {
                    int TempKey = randAttribute.Next(1, 5);
                    if (TempDict.ContainsKey(TempKey))
                    {
                        while (TempDict.ContainsKey(TempKey))
                        {
                            TempKey = randAttribute.Next(1, 5);
                        }
                    }
                    else
                    {
                        TempDict.Add(TempKey, 1);
                    }
                    switch (TempKey)
                    {
                        case 1:
                            enemy.HP = avgStats.AvgHP;
                            break;
                        case 2:
                            enemy.Speed = avgStats.AvgSpeed;
                            break;
                        case 3:
                            enemy.Damage = avgStats.AvgDamage;
                            break;
                        case 4:
                            enemy.EnemyColor = avgStats.GreatestColor;
                            break;
                        case 5:
                            enemy.AttackType = avgStats.GreatestAttackType;
                            break;
                    }
                    
                }

            }
        }

        public Enemy GenerateRandomEnemy( int round )
        {
            // figure out min-max for stats
            Weapons weapon;
            int hp = randAttribute.Next(100, 200);
            int speed = randAttribute.Next(5, 10);
            int damage = randAttribute.Next(45,100);
            DFColor enemyColor = (DFColor)randAttribute.Next(0, 5);
            //attackType random
            AttackType attackType;
            int randAttackType = randAttribute.Next(0, 50);
            if (randAttackType < 25)
            {
                attackType = AttackType.Melee;
            }
            else
            {
                attackType = AttackType.Ranged;
            }
            //end AttackType Random

            if (attackType == AttackType.Melee)
            {
                weapon = (Weapons)randAttribute.Next(0, 2);
            }
            else
            {
                weapon = (Weapons)randAttribute.Next(3, 5);
            }
            int score = 5 * round;
            return new Enemy(hp, speed, damage, attackType, enemyColor.ToString(), weapon, round, score);
        }
        
        public List<Enemy> MutatedSample(int round)
        {
            
            List<Enemy> mutatedEnemyList = new List<Enemy>();
            for (int e = 0; e < 10; e++)
            {
                Enemy enemies = GenerateRandomEnemy(round);
                EnemiesRemainingInGeneration--;
                mutatedEnemyList.Add(enemies);
            }
            return mutatedEnemyList;
        }
    }
}