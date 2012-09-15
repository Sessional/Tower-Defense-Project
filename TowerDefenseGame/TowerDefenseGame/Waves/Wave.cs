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

        private int monstersToSpawn;
        private int monstersSpawned;

        private Monster monsterType;

        private int timeUntilNextSpawn;

        private List<Monster> monstersAlive;

        public Wave(WaveManager masterManager, TowerDefenseGame masterGame, Monster typeOfMonster)
        {
            timeUntilNextSpawn = 0;
            this.masterManager = masterManager;
            this.masterGame = masterGame;
            this.monsterType = typeOfMonster;
            monstersToSpawn = 10;
            
            monstersAlive = new List<Monster>();
        }

        public int GetLiveMonsters()
        {
            return monstersAlive.Count;
        }

        public int GetRemainingSpawns()
        {
            return monstersToSpawn;
        }

        public int GetNumberSpawned()
        {
            return monstersSpawned;
        }

        public int GetRemainingMonsters()
        {
            return GetRemainingSpawns() + GetLiveMonsters();
        }

        public int GetTotalMonsters()
        {
            return GetRemainingSpawns() + GetNumberSpawned();
        }

        public bool IsWaveComplete()
        {
            if (GetLiveMonsters() == 0 && GetRemainingSpawns() == 0)
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
            Monster newMonster = new Monster(masterGame, masterGame.GetMapManager(), masterManager, masterGame.GetMapManager().GetSpawnTiles()[0].GetXCoord() + GameTile.TILE_DIMENSIONS / 3, masterGame.GetMapManager().GetSpawnTiles()[0].GetYCoord() + GameTile.TILE_DIMENSIONS / 3);

            this.monstersAlive.Add(newMonster);
            monstersToSpawn--;
            monstersSpawned++;

            timeUntilNextSpawn = 100;
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
            List<Monster> mToRemove = new List<Monster>();
            foreach (Monster m in monstersAlive)
            {
                if (m.isLeak)
                {
                    masterGame.GetMapManager().GetGameGUI().LoseLife();
                }
                if (m.isDead || m.isLeak)
                {
                    mToRemove.Add(m);
                }
                else
                {
                    m.Update(gameTime);
                }
            }

            while (mToRemove.Count > 0)
            {
                monstersAlive.Remove(mToRemove[0]);
                mToRemove.RemoveAt(0);
            }

            timeUntilNextSpawn--;

            if (ShouldSpawnNextMonster())
            {
                SpawnNextMonster();
            }
        }
    }
}
