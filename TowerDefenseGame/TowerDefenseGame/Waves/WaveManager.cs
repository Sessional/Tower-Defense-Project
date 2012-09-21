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

        private int waveNumber;

        private Wave currentWave;
        private Wave nextWave;

        private Wave[] waveList;

        private Dictionary<string, Texture2D> monsterTextures;

        public WaveManager(MapManager masterManager, TowerDefenseGame masterGame, ContentManager content)
        {
            this.masterManager = masterManager;
            this.masterGame = masterGame;
            this.content = content;
            waveNumber = 0;
            timeUntilNextWave = 30;
            LoadTextures();
            DefineWaveList();
            this.nextWave = waveList[waveNumber + 1];
        }

        public void LoadTextures()
        {
            monsterTextures = new Dictionary<string, Texture2D>();
            monsterTextures.Add("greenball", masterGame.Content.Load<Texture2D>("Monsters//GreenBall"));
            monsterTextures.Add("blueball", masterGame.Content.Load<Texture2D>("Monsters//BlueBall"));
            monsterTextures.Add("redball", masterGame.Content.Load<Texture2D>("Monsters//RedBall"));
            monsterTextures.Add("blackball", masterGame.Content.Load<Texture2D>("Monsters//BlackBall"));

        }

        public void DefineWaveList()
        {
            waveList = new Wave[] {
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 10, monsterTextures["greenball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 15, monsterTextures["blueball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 20, monsterTextures["redball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 30, monsterTextures["blueball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 50, monsterTextures["greenball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 70, monsterTextures["redball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 100, monsterTextures["greenball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 140, monsterTextures["blueball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 190, monsterTextures["redball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 240, monsterTextures["blueball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 300, monsterTextures["greenball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord())),
                
            };
        }

        public int GetWaveNumber()
        {
            return waveNumber;
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

            waveNumber++;
            GenerateNextWave();
        }

        public void GenerateNextWave()
        {
            if (GetWaveNumber() + 1 >= waveList.Length)
            {
                this.nextWave = new Wave(this, masterGame, 10, new Monster(masterGame, masterManager, this, 70, monsterTextures["greenball"], masterManager.GetSpawnTiles()[0].GetXCoord(), masterManager.GetSpawnTiles()[0].GetYCoord()));
            }
            else
            {
                this.nextWave = waveList[GetWaveNumber() + 1];
            }
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
