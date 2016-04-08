using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DarwinsFinches
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Texture2D background;
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static ContentManager content;
        public static Camera Cam;
        EnemySpawner spawner = new EnemySpawner();
        Shadow temp;
        public static bool exit;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            content = Content;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            ControllerInput.Instance();
            Avatar.Instance();
            Level level = new Level(10, 10, 60);
            level.InsertGameObject(Avatar.Instance());
            temp = new Shadow();
            level.InsertGameObject(temp);
            level.InsertGameObject(new Enemy(5,5,5,Attributes.AttackType.Melee,"Red",Attributes.Weapons.Axe,0,5));
            LevelManager.Instance().SetLevel(level);
            SoundManager.Instance();
            SoundManager.Instance().BGM(new SongTrack("BGM\\BossBattle"));
            SoundManager.Instance().BGM().Play();
            SoundManager.Instance().Volume(.1f);
            Utilities.Instance().StartWatch();
            exit = false;
            background = content.Load<Texture2D>(@"Background\background-0");
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();


            Cam = new Camera(Avatar.Instance().kinetics.position, new Rectangle(0,0,background.Width, background.Height));
     
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (ControllerInput.Instance().GetButton(Buttons.A).Released || exit)
            {
                this.Exit();
            }

            
            Random rand = new Random(Utilities.Instance().ElapsedTime().Milliseconds);
            if (Utilities.Instance().ElapsedTime().Seconds >= rand.Next(1,2))
            {
                Enemy barge = (new Enemy(5, 5, 5, Attributes.AttackType.Melee, "Red", Attributes.Weapons.Axe, 0, 5));
               
                barge.kinetics.position = new Vector2((float)rand.NextDouble() * 1024, (float)rand.NextDouble() * 768);
                LevelManager.Instance().getCurrentLevel().InsertGameObject(barge);
                SoundManager.Instance().AddSound(new SFX("SFX\\arrowhit"));
                Utilities.Instance().RestartWatch();
            }
            

            ControllerInput.Instance().Update();

            LevelManager.Instance().Update();
            LevelManager.Instance().getCurrentLevel().Collision();
            SoundManager.Instance().Update();
            Cam.Update();
            Vector2 displacement = (temp.kinetics.position - Avatar.Instance().kinetics.position) / 2.0f;
            Vector2 position = Avatar.Instance().kinetics.position + displacement;
            Cam.SetTarget(position);
            spawner.Update();            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront,null,null,null,null,null,Cam.View());
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            LevelManager.Instance().Draw(spriteBatch);
            spriteBatch.End();

            
            spriteBatch.Begin();
            Utilities.Instance().DrawTime(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
        public void Test()
        {
            /*
            GeneticAlgorithm GA = new GeneticAlgorithm();
            Enemy testEnemy = new Enemy();
            testEnemy = GA.GenerateRandomEnemy();
            Console.WriteLine("Enemy Stats :\nHP : " + testEnemy.HP +
                                           "\nRoundSpawned : " + testEnemy.RoundSpawned +
                                           "\nScore : " + testEnemy.Score +
                                           "\nSpeed : " + testEnemy.Speed +
                                           "\nWeapon : " + testEnemy.Weapon +
                                           "\nColor : " + testEnemy.EnemyColor);
            List<Enemy> testMutate = new List<Enemy>(GA.MutatedSample())*/
        }

        
    }
}
