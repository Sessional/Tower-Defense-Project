using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefenseGame.Waves
{
    public class WaveManager
    {

        private Wave currentWave;
        private Wave nextWave;

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
            return currentWave.IsWaveComplete();
        }

        public void Update()
        {

        }
    }
}
