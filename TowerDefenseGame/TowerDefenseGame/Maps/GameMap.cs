using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Content;

namespace TowerDefenseGame.Maps
{
    public class GameMap
    {
        //##################################
        //######## Public Variables ########
        //##################################
        public Texture2D DEFAULT_TILE_TEXTURE;

        public TileSet tileset;
        //##################################
        //######## Constructors ############
        //##################################

        public GameMap(TowerDefenseGame masterGame, string mapName)
        {
            this.masterGame = masterGame;
            this.mapName = mapName;
            tileset = masterGame.GetTileManager().getTileSet("standard");
            isPaused = false;
            Load();
        }

        public void SetTileSet(string tilesetName)
        {
            tileset = masterGame.GetTileManager().getTileSet(tilesetName);
        }

        //##################################
        //######## Instance Variables ######
        //##################################
        TowerDefenseGame masterGame;
        GraphicsDeviceManager graphics;

        int mapWidth;
        int mapHeight;

        GameTile[][] mapTiles;

        string mapName;

        bool isPaused;
        //##################################
        //######## State Methods ###########
        //##################################

        public bool IsPaused()
        {
            return isPaused;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {
            TextMapReader mapReader = new TextMapReader(this, mapName);
            mapTiles = mapReader.getTiles();
            mapWidth = mapTiles.Length;
            mapHeight = mapTiles[0].Length;
            masterGame.SetScreenSize(GetMapWidth() * GameTile.TILE_DIMENSIONS, GetMapHeight() * GameTile.TILE_DIMENSIONS + 200);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprites"></param>
        public void Draw(SpriteBatch sprites)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    mapTiles[x][y].Draw(sprites);
                    
                }
            }

        }

        //##################################
        //######## Getters #################
        //##################################

        public TowerDefenseGame GetRootGame()
        {
            return this.masterGame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMapWidth()
        {
            return mapWidth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMapHeight()
        {
            return mapHeight;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GameTile GetTile(int x, int y)
        {
            return mapTiles[x][y];
        }

        public GameTile GetTileByCoord(int x, int y)
        {
            int tileX = (int)(x / GameTile.TILE_DIMENSIONS);
            int tileY = (int)(y / GameTile.TILE_DIMENSIONS);

            return GetTile(tileX, tileY);
        }

        public List<GameTile> GetSpawnTiles()
        {
            List<GameTile> spawnTiles = new List<GameTile>();
            for (int x = 0; x < mapTiles.Length; x++)
            {
                for (int y = 0; y < mapTiles[x].Length; y++)
                {
                    if (mapTiles[x][y].getBaseImage() == tileset.GetTexture("start"))
                    {
                        spawnTiles.Add(mapTiles[x][y]);
                    }
                }
            }
            return spawnTiles;
        }

        public List<GameTile> GetFinishTiles()
        {
            List<GameTile> finishTiles = new List<GameTile>();
            for (int x = 0; x < mapTiles.Length; x++)
            {
                for (int y = 0; y < mapTiles[x].Length; y++)
                {
                    if (mapTiles[x][y].getBaseImage() == tileset.GetTexture("finish"))
                    {
                        finishTiles.Add(mapTiles[x][y]);
                    }
                }
            }
            return finishTiles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public GameTile[] GetTiles(int x)
        {
            return mapTiles[x];
        }

        //##################################
        //######## Setters #################
        //##################################

        /// <summary>
        /// 
        /// </summary>
        public void TogglePause()
        {
            isPaused = !isPaused;
        }
    }
}
