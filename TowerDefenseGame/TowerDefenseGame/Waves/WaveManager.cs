using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Maps;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Waves.Pathing;

namespace TowerDefenseGame.Waves
{
    public class WaveManager
    {

        private MapManager masterManager;
        private TowerDefenseGame masterGame;
        private ContentManager content;
        private PathingManager pathingManager;

        private TimeSpan timeUntilNextWave;

        private Wave currentWave;
        private Wave nextWave;

        public WaveManager(MapManager masterManager, TowerDefenseGame masterGame, ContentManager content)
        {
            //this.currentWave = new Wave();
            this.masterManager = masterManager;
            this.masterGame = masterGame;
            this.content = content;
            timeUntilNextWave = new TimeSpan(0, 0, 30);

            pathingManager = new PathingManager(masterManager.GetCurrentMap());
        }

        public int GetTimeUntilNextWave()
        {
            return timeUntilNextWave.Seconds;
        }
        public Wave GetCurrentWave()
        {
            return currentWave;
        }

        public Wave GetNextWave()
        {
            return nextWave;
        }

        public void ProgressWaves()
        {
            currentWave = nextWave;

            GenerateNextWave();
        }

        public void GenerateNextWave()
        {

        }

        public bool IsWaveComplete()
        {
            if (currentWave == null)
            {
                return false;
            }
            return currentWave.IsWaveComplete();
        }

        public void Update(GameTime gameTime)
        {
            if (IsWaveComplete())
            {
                timeUntilNextWave.Subtract(gameTime.ElapsedGameTime);
            }
            else
            {
                //TODO:GetCurrentWave().Update(gameTime);
            }
        }
    }
}
