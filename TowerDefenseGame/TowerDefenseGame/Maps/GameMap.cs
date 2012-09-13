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
    class GameMap
    {
        //##################################
        //######## Public Variables ########
        //##################################
        public Texture2D DEFAULT_TILE_TEXTURE;

        //##################################
        //######## Constructors ############
        //##################################

        public GameMap(Game1 masterGame, string mapName, Texture2D defaultTexture)
        {
            this.masterGame = masterGame;
            this.mapName = mapName;
            this.DEFAULT_TILE_TEXTURE = defaultTexture;

            Load();
        }

        //##################################
        //######## Instance Variables ######
        //##################################
        Game1 masterGame;
        GraphicsDeviceManager graphics;

        int mapWidth;
        int mapHeight;

        GameTile[][] mapTiles;

        string mapName;
        //##################################
        //######## State Methods ###########
        //##################################

        public void Load()
        {
            TextMapReader mapReader = new TextMapReader(this, mapName);
            mapTiles = mapReader.getTiles();
            mapWidth = mapTiles.Length;
            mapHeight = mapTiles[0].Length;
            masterGame.setScreenSize(getMapWidth() * GameTile.TILE_DIMENSIONS, getMapHeight() * GameTile.TILE_DIMENSIONS + 200);
            
        }

        /// <summary>
        /// 
        /// </summary>
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

        public Game1 getRootGame()
        {
            return this.masterGame;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getMapWidth()
        {
            return mapWidth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getMapHeight()
        {
            return mapHeight;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GameTile getTile(int x, int y)
        {
            return mapTiles[x][y];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public GameTile[] getTiles(int x)
        {
            return mapTiles[x];
        }

        //##################################
        //######## Setters #################
        //##################################
    }
}
