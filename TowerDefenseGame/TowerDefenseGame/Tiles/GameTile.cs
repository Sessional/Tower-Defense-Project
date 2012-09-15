using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.Buildings;
using TowerDefenseGame.Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TowerDefenseGame.Tiles
{
    public class GameTile
    {
        //##################################
        //######## Static Variables ########
        //##################################
        /// <summary>
        /// Tiles must be a square, and as such this sets the with and height of the tiles.
        /// </summary>
        public static int TILE_DIMENSIONS = 50;

        public static int NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3;
        //##################################
        //######## Constructors ############
        //##################################

        string specialNote;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterMap"></param>
        /// <param name="tileX"></param>
        /// <param name="tileY"></param>
        /// <param name="isBuildable"></param>
        public GameTile(GameMap masterMap, int tileX, int tileY, bool isBuildable)
        {
            this.map = masterMap;
            this.tileX = tileX;
            this.tileY = tileY;
            this.buildable = isBuildable;
            this.baseImage = map.DEFAULT_TILE_TEXTURE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterMap"></param>
        /// <param name="tileX"></param>
        /// <param name="tileY"></param>
        /// <param name="isBuildable"></param>
        /// <param name="texture"></param>
        public GameTile(GameMap masterMap, int tileX, int tileY, bool isBuildable, Texture2D texture)
        {
            this.map = masterMap;
            this.tileX = tileX;
            this.tileY = tileY;
            this.buildable = isBuildable;
            this.baseImage = texture;
        }

        //##################################
        //######## Instance Variables ######
        //##################################

        private GameMap map;

        private bool buildable;

        private Texture2D baseImage;
        private Building occupant;

        private int tileX;
        private int tileY;

        //##################################
        //######## State Methods ###########
        //##################################

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isBuildable()
        {
            return buildable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprites"></param>
        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(baseImage, new Rectangle(tileX * TILE_DIMENSIONS, tileY * TILE_DIMENSIONS, TILE_DIMENSIONS, TILE_DIMENSIONS), Color.White);
            sprites.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprites"></param>
        public void OnHover(SpriteBatch sprites)
        {
            sprites.Begin();
            if (isBuildable())
            {
                sprites.Draw(map.tileset.GetTexture("hover"), new Rectangle(tileX * TILE_DIMENSIONS, tileY * TILE_DIMENSIONS, TILE_DIMENSIONS, TILE_DIMENSIONS), Color.White);
            }
            else
            {
                sprites.Draw(map.tileset.GetTexture("invalidhover"), new Rectangle(tileX * TILE_DIMENSIONS, tileY * TILE_DIMENSIONS, TILE_DIMENSIONS, TILE_DIMENSIONS), Color.White);
            }
            sprites.End();
        }

        //##################################
        //######## Getters #################
        //##################################
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getTileX()
        {
            return tileX;
        }

        public int GetXCoord()
        {
            return tileX * TILE_DIMENSIONS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getTileY()
        {
            return tileY;
        }

        public int GetYCoord()
        {
            return tileY * TILE_DIMENSIONS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Texture2D getBaseImage()
        {
            return baseImage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Building getOccupant()
        {
            return occupant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GameMap getMap()
        {
            return map;
        }

        public string GetSpecialNote()
        {
            return specialNote;
        }

        //##################################
        //######## Setters #################
        //##################################

        public void SetSpecialNote(string text)
        {
            specialNote = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xCoord"></param>
        public void setXCoord(int xCoord)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yCoord"></param>
        public void setYCoord(int yCoord)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildable"></param>
        public void setBuildable(bool buildable)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseImage"></param>
        public void setBaseImage(Texture2D baseImage)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="occupant"></param>
        public void setOccupant(Building occupant)
        {

        }


        internal bool IsPath()
        {
            if (this.baseImage == this.getMap().tileset.GetTexture("path") || this.baseImage == this.getMap().tileset.GetTexture("start") ||
                this.baseImage == this.getMap().tileset.GetTexture("finish"))
            {
                return true;
            }
            return false;
        }
    }
}
