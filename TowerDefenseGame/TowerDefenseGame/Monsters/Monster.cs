using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.Waves;
using TowerDefenseGame.Maps;

namespace TowerDefenseGame.Monsters
{
    public class Monster
    {
        int x;
        int y;
        int width;
        int height;

        int moveRate;

        GameTile currentTile;
        GameTile destinationTile;
        Texture2D monsterTexture;

        TowerDefenseGame masterGame;
        MapManager mapManager;
        WaveManager waveManager;

        public Monster(TowerDefenseGame masterGame, MapManager mapManager, WaveManager waveManager, int x, int y)
        {
            this.mapManager = mapManager;
            this.masterGame = masterGame;
            this.waveManager = waveManager;

            width = 20;
            height = 20;
            this.x = x;
            this.y = y;

            monsterTexture = masterGame.Content.Load<Texture2D>("Monsters//GreenBall");

            //TODO: waveManager.GetPathingManager().
            moveRate = 5;
        }

        internal void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(monsterTexture, new Rectangle(x, y, width, height), Color.White);
            sprites.End();
        }
    }
}
