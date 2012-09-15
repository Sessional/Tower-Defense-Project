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
        float x;
        float y;
        int width;
        int height;

        float moveRate;

        public bool isDead = false;

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

            currentTile = mapManager.GetCurrentMap().GetTileByCoord(x, y);

            moveRate = .3f;
        }

        internal void Update(GameTime gameTime)
        {
            x += moveRate;

            if (masterGame.GetMapManager().GetCurrentMap().GetTileByCoord((int)x, (int)y).getBaseImage() == masterGame.GetMapManager().GetCurrentMap().tileset.GetTexture("finish"))
            {
                this.isDead = true;
            }
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(monsterTexture, new Rectangle((int)x, (int)y, width, height), Color.White);
            sprites.End();
        }
    }
}
