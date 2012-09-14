using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Monsters;

namespace TowerDefenseGame.Waves
{
    public class Wave
    {

        private int liveMonsters;
        private int monstersToSpawn;
        private int monstersSpawned;

        private Monster monsterType;

        public bool IsWaveComplete()
        {
            return false;
        }
    }
}
