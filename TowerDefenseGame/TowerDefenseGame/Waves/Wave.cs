using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Monsters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.Tiles;

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

        private int timeUntilNextSpawn;

        private List<Monster> monstersAlive;

        public Wave(WaveManager masterManager, TowerDefenseGame masterGame, Monster typeOfMonster)
        {
            timeUntilNextSpawn = 5;
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
            if (timeUntilNextSpawn <= 0 && GetRemainingSpawns() > 0)
            {
                return true;
            }
            return false;
        }

        public void SpawnNextMonster()
        {
            Monster newMonster = new Monster(masterGame, masterGame.GetMapManager(), masterManager, masterGame.GetMapManager().GetSpawnTile().GetXCoord() + GameTile.TILE_DIMENSIONS / 3, masterGame.GetMapManager().GetSpawnTile().GetYCoord() + GameTile.TILE_DIMENSIONS / 3);

            this.monstersAlive.Add(newMonster);

            timeUntilNextSpawn = 5;
        }

        public void Draw(SpriteBatch sprites)
        {
            foreach (Monster m in monstersAlive)
            {
                m.Draw(sprites);
            }
        }

        internal void Update(GameTime gameTime)
        {
            foreach (Monster m in monstersAlive)
            {
                m.Update(gameTime);
            }

            timeUntilNextSpawn--;

            if (ShouldSpawnNextMonster())
            {
                SpawnNextMonster();
            }
        }
    }
}
