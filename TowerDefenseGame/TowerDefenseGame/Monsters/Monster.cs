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

        int currentDirection = -1;

        float moveRate;

        public int health = 20;

        public bool isDead = false;
        public bool isLeak = false;

        Texture2D monsterTexture;

        TowerDefenseGame masterGame;
        MapManager mapManager;
        WaveManager waveManager;

        public Monster(TowerDefenseGame masterGame, MapManager mapManager, WaveManager waveManager, int x, int y)
        {
            this.mapManager = mapManager;
            this.masterGame = masterGame;
            this.waveManager = waveManager;

            width = 10;
            height = 10;
            this.x = x;
            this.y = y;

            monsterTexture = masterGame.Content.Load<Texture2D>("Monsters//GreenBall");

            GetNextDirection();

            moveRate = 0.7f;
        }

        public void GetNextDirection()
        {
            GameTile curTile = mapManager.GetCurrentMap().GetTileByCoord((int)x, (int)y);
            int tileX = curTile.getTileX();
            int tileY = curTile.getTileY();

            if (currentDirection == GameTile.EAST)
            {
                if (!mapManager.GetCurrentMap().GetTileByCoord((int)x + 30, (int)y).IsPath())
                {
                    if (mapManager.GetCurrentMap().GetTile(tileX, tileY + 1).IsPath())
                    {
                        currentDirection = GameTile.SOUTH;
                    }
                    else if (mapManager.GetCurrentMap().GetTile(tileX, tileY - 1).IsPath())
                    {
                        currentDirection = GameTile.NORTH;
                    }
                }
            }
            else if (currentDirection == GameTile.NORTH)
            {
                if (!mapManager.GetCurrentMap().GetTileByCoord((int)x, (int)y - 17).IsPath())
                {
                    if (mapManager.GetCurrentMap().GetTile(tileX + 1, tileY).IsPath())
                    {
                        currentDirection = GameTile.EAST;
                    }
                    else if (mapManager.GetCurrentMap().GetTile(tileX - 1, tileY).IsPath())
                    {
                        currentDirection = GameTile.WEST;
                    }
                }
            }
            else if (currentDirection == GameTile.WEST)
            {
                if (!mapManager.GetCurrentMap().GetTileByCoord((int)x - 30, (int)y).IsPath())
                {
                    if (mapManager.GetCurrentMap().GetTile(tileX, tileY + 1).IsPath())
                    {
                        currentDirection = GameTile.SOUTH;
                    }
                    else if (mapManager.GetCurrentMap().GetTile(tileX, tileY - 1).IsPath())
                    {
                        currentDirection = GameTile.NORTH;
                    }
                }
            }
            else if (currentDirection == GameTile.SOUTH)
            {
                if (!mapManager.GetCurrentMap().GetTileByCoord((int)x, (int)y + 30).IsPath())
                {
                    if (mapManager.GetCurrentMap().GetTile(tileX + 1, tileY).IsPath())
                    {
                        currentDirection = GameTile.EAST;
                    }
                    else if (mapManager.GetCurrentMap().GetTile(tileX - 1, tileY).IsPath())
                    {
                        currentDirection = GameTile.WEST;
                    }
                }
            }
            else
            {
                if (!mapManager.GetCurrentMap().GetTile(tileX, tileY + 1).IsPath())
                {
                    currentDirection = GameTile.SOUTH;
                } else if (!mapManager.GetCurrentMap().GetTile(tileX, tileY - 1).IsPath())
                {
                    currentDirection = GameTile.NORTH;
                } else if (!mapManager.GetCurrentMap().GetTile(tileX + 1, tileY).IsPath())
                {
                    currentDirection = GameTile.EAST;
                } else if (!mapManager.GetCurrentMap().GetTile(tileX - 1, tileY).IsPath())
                {
                    currentDirection = GameTile.WEST;
                }
            }
        }

        internal void Update(GameTime gameTime)
        {

            if (masterGame.GetMapManager().GetCurrentMap().GetTileByCoord((int)x, (int)y).getBaseImage() == masterGame.GetMapManager().GetCurrentMap().tileset.GetTexture("finish"))
            {
                this.isLeak = true;
            }
            else if (this.health <= 0)
            {
                this.isDead = true;
            }
            else if (currentDirection == GameTile.NORTH)
            {
                y -= moveRate;
                GetNextDirection();
            }
            else if (currentDirection == GameTile.SOUTH)
            {
                y += moveRate;
                GetNextDirection();
            }
            else if (currentDirection == GameTile.WEST)
            {
                x -= moveRate;
                GetNextDirection();
            }
            else if (currentDirection == GameTile.EAST)
            {
                x += moveRate;
                GetNextDirection();
            }
        }

        public void Damage(int damage)
        {
            this.health -= damage;
        }

        public GameTile GetPosition()
        {
            return mapManager.GetCurrentMap().GetTileByCoord((int)x, (int)y);
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(monsterTexture, new Rectangle((int)x, (int)y, width, height), Color.White);
            DrawHealthBar(sprites);
            sprites.End();
        }

        public void DrawHealthBar(SpriteBatch sprites)
        {

        }
    }
}
