using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Maps;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Monsters;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseGame.Waves
{
    public class WaveManager
    {

        private MapManager masterManager;
        private TowerDefenseGame masterGame;
        private ContentManager content;

        private int timeUntilNextWave;

        private Wave currentWave;
        private Wave nextWave;

        public WaveManager(MapManager masterManager, TowerDefenseGame masterGame, ContentManager content)
        {
            this.masterManager = masterManager;
            this.masterGame = masterGame;
            this.content = content;
            timeUntilNextWave = 30;
            //this.currentWave = new Wave(this, masterGame,
            //    new Monster(masterGame, masterManager, this, masterManager.GetSpawnTile().GetXCoord(), masterManager.GetSpawnTile().GetYCoord()));
            
        }

        public int GetTimeUntilNextWave()
        {
            return timeUntilNextWave;
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
            timeUntilNextWave = 30;
            currentWave = nextWave;

            GenerateNextWave();
        }

        public void GenerateNextWave()
        {
            this.nextWave = new Wave(this, masterGame,
                new Monster(masterGame, masterManager, this, masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord()));
        }

        public bool IsWaveComplete()
        {
            if (currentWave == null)
            {
                return false;
            }
            return currentWave.IsWaveComplete();
        }

        public void Draw(SpriteBatch sprites)
        {
            if (GetCurrentWave() == null)
            {
                return;
            }
            GetCurrentWave().Draw(sprites);
        }

        public void Update(GameTime gameTime)
        {
            if (IsWaveComplete())
            {
                timeUntilNextWave--;

                if (timeUntilNextWave <= 0)
                {
                    ProgressWaves();
                }
            }
            else
            {
                if (GetCurrentWave() == null)
                {
                    timeUntilNextWave--;
                    if (timeUntilNextWave <= 0)
                    {
                        ProgressWaves();
                    }
                    return;
                }
                GetCurrentWave().Update(gameTime);
            }
        }
    }
}
