using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Monsters;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.Waves
{
    public class Wave
    {
        private WaveManager masterManager;
        private TowerDefenseGame masterGame;

        private int liveMonsters;
        private int monstersToSpawn;
        private int monstersSpawned;

        private Monster monsterType;

        private TimeSpan timeUntilNextSpawn;

        private List<Monster> monstersAlive;

        public Wave(WaveManager masterManager, TowerDefenseGame masterGame, Monster typeOfMonster)
        {
            timeUntilNextSpawn = new TimeSpan(0, 0, 1);
            this.masterManager = masterManager;
            this.masterGame = masterGame;
            this.monsterType = typeOfMonster;
            liveMonsters = 0;
            monstersToSpawn = 10;
            monstersAlive = new List<Monster>();
        }

        public int getLiveMonsters()
        {
            return liveMonsters;
        }

        public int GetRemainingSpawns()
        {
            return monstersToSpawn;
        }

        public int GetNumberSpawned()
        {
            return monstersSpawned;
        }

        public int GetTotalMonsters()
        {
            return GetRemainingSpawns() + GetNumberSpawned();
        }

        public bool IsWaveComplete()
        {
            if (getLiveMonsters() == 0 && GetRemainingSpawns() == 0)
            {
                return true;
            }
            return false;
        }

        public bool ShouldSpawnNextMonster()
        {
            if (timeUntilNextSpawn.Seconds <= 0 && GetRemainingSpawns() > 0)
            {
                return true;
            }
            return false;
        }

        public void SpawnNextMonster()
        {
            this.masterGame.GetMapManager().GetSpawnTile();
            
        }

        internal void Update(GameTime gameTime)
        {
            foreach (Monster m in monstersAlive)
            {
                m.Update(gameTime);
            }

            timeUntilNextSpawn.Subtract(gameTime.ElapsedGameTime);

            if (ShouldSpawnNextMonster())
            {
                SpawnNextMonster();
            }
        }
    }
}
