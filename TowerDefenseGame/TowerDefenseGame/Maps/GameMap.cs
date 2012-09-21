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
            selectionHasChanged = false;

            this.viewTileDistance = 5;
            Load();
            this.viewTileX = this.GetMapWidth() / 2;
            this.viewTileY = this.GetMapHeight() / 2;
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

        private GameTile selectedTile;
        private bool selectionHasChanged;

        private int viewTileX;
        private int viewTileY;
        private int viewTileDistance;

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
            if (this.mapWidth <= 25 && this.mapHeight <= 25)
            {
                masterGame.SetScreenSize(GetMapWidth() * GameTile.TILE_DIMENSIONS, GetMapHeight() * GameTile.TILE_DIMENSIONS + 200);
            }
            else
            {
                int width = viewTileDistance * GameTile.TILE_DIMENSIONS;
                int height = width;
                masterGame.SetScreenSize(width, height + 200);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprites"></param>
        public void Draw(SpriteBatch sprites)
        {

            if (this.mapWidth <= 25 && this.mapHeight <= 25)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    for (int y = 0; y < mapHeight; y++)
                    {
                        mapTiles[x][y].Draw(sprites);
                    }
                }
            }
            else
            {
                for (int x = Math.Max(0, viewTileX - viewTileDistance); x < Math.Min(this.GetMapWidth(), viewTileX + viewTileDistance); x++)
                {
                    for (int y = Math.Max(0, viewTileY - viewTileDistance); y < Math.Min(this.GetMapHeight(), viewTileX + viewTileDistance); y++)
                    {
                        mapTiles[x][y].Draw(sprites);
                    }
                }
            }

            if (selectedTile != null)
            {
                sprites.Begin();
                if (selectedTile.isBuildable())
                {
                    sprites.Draw(tileset.GetTexture("selection"), new Rectangle(selectedTile.GetXCoord(), selectedTile.GetYCoord(), GameTile.TILE_DIMENSIONS, GameTile.TILE_DIMENSIONS), Color.White);
                }
                else
                {
                    sprites.Draw(tileset.GetTexture("invalidhover"), new Rectangle(selectedTile.GetXCoord(), selectedTile.GetYCoord(), GameTile.TILE_DIMENSIONS, GameTile.TILE_DIMENSIONS), Color.White);
                }
                sprites.End();
            }

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    mapTiles[x][y].DrawOccupants(sprites);
                }
            }

        }

        public void OnClick(int x, int y)
        {
            if (GetTileByCoord(x, y) != null)
            {
                selectionHasChanged = true;
                selectedTile = GetTileByCoord(x, y);
            }
        }

        public void OnRightClick(int x, int y)
        {
            selectionHasChanged = true;
            ClearSelection();
        }

        public bool HasSelectionChanged()
        {
            return selectionHasChanged;
        }

        public void Update(GameTime gameTime)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    mapTiles[x][y].Update(gameTime);
                }
            }
        }

        //##################################
        //######## Getters #################
        //##################################

        public GameTile GetSelection()
        {
            return selectedTile;
        }

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

        public int GetMapWidthPixels()
        {
            return mapWidth * GameTile.TILE_DIMENSIONS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMapHeight()
        {
            return mapHeight;
        }

        public int GetMapHeightPixels()
        {
            return mapHeight * GameTile.TILE_DIMENSIONS;
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

        public void ClearSelection()
        {
            this.selectedTile = null;
        }

        internal void HandleLeftArrow()
        {
            if (this.viewTileX - viewTileDistance > 0)
            {
                this.viewTileX--;
            }
        }
        internal void HandleRightArrow()
        {
            if (this.viewTileX + viewTileDistance < mapWidth)
            {
                this.viewTileX++;
            }
        }

        internal void HandleUpArrow()
        {
            if (this.viewTileY - viewTileDistance > 0)
            {
                this.viewTileY--;
            }
        }

        internal void HandleDownArrow()
        {
            if (this.viewTileY + viewTileDistance < mapHeight)
            {
                this.viewTileY++;
            }
        }
    }
}
