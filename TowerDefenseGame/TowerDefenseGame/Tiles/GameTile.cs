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
    class GameTile
    {
        //##################################
        //######## Static Variables ########
        //##################################
        /// <summary>
        /// Tiles must be a square, and as such this sets the with and height of the tiles.
        /// </summary>
        public static int TILE_DIMENSIONS = 50;

        //##################################
        //######## Constructors ############
        //##################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterMap"></param>
        /// <param name="xCoord"></param>
        /// <param name="yCoord"></param>
        /// <param name="isBuildable"></param>
        public GameTile(GameMap masterMap, int xCoord, int yCoord, bool isBuildable)
        {
            this.map = masterMap;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.buildable = isBuildable;
            this.baseImage = map.DEFAULT_TILE_TEXTURE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterMap"></param>
        /// <param name="xCoord"></param>
        /// <param name="yCoord"></param>
        /// <param name="isBuildable"></param>
        /// <param name="texture"></param>
        public GameTile(GameMap masterMap, int xCoord, int yCoord, bool isBuildable, Texture2D texture)
        {
            this.map = masterMap;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
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

        private int xCoord;
        private int yCoord;

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
            sprites.Draw(baseImage, new Rectangle(xCoord * TILE_DIMENSIONS, yCoord * TILE_DIMENSIONS, TILE_DIMENSIONS, TILE_DIMENSIONS), Color.White);
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
                sprites.Draw(map.getRootGame().hoverTexture, new Rectangle(xCoord * TILE_DIMENSIONS, yCoord * TILE_DIMENSIONS, TILE_DIMENSIONS, TILE_DIMENSIONS), Color.White);
            }
            else
            {
                sprites.Draw(map.getRootGame().invalidHoverTexture, new Rectangle(xCoord * TILE_DIMENSIONS, yCoord * TILE_DIMENSIONS, TILE_DIMENSIONS, TILE_DIMENSIONS), Color.White);
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
        public int getXCoord()
        {
            return xCoord;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getYCoord()
        {
            return yCoord;
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

        //##################################
        //######## Setters #################
        //##################################

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

    }
}
