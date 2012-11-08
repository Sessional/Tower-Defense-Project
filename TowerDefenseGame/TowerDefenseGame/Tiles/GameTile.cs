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
            this.drawRectangle = new Rectangle(tileX * TILE_DIMENSIONS, tileY * TILE_DIMENSIONS, TILE_DIMENSIONS, TILE_DIMENSIONS);
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
            this.drawRectangle = new Rectangle(tileX * TILE_DIMENSIONS, tileY * TILE_DIMENSIONS, TILE_DIMENSIONS, TILE_DIMENSIONS);
        }

        //##################################
        //######## Instance Variables ######
        //##################################

        string specialNote;

        private GameMap map;

        private bool buildable;

        private Texture2D baseImage;
        private Building occupant;

        private Rectangle drawRectangle;

        private int tileX;
        private int tileY;

        //##################################
        //######## State Methods ###########
        //##################################

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsBuildable()
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
            if (this.GetMap().GetMapWidth() <= GameMap.VIEW_DIMENSION_X && this.GetMap().GetMapHeight() <= GameMap.VIEW_DIMENSION_Y)
            {
                sprites.Draw(baseImage,this.drawRectangle, Color.White);
            }
            else
            {
                GameTile curViewTile = GetMap().GetViewTile();
                int viewTileX = curViewTile.GetTileX();
                int viewTileY = curViewTile.GetTileY();
                int tileX = GetTileX();
                int tileY = GetTileY();

                int distFromLeft = viewTileX - GameMap.VIEW_WIDTH;
                int distFromTop = viewTileY - GameMap.VIEW_HEIGHT;

                drawRectangle.X = (tileX - distFromLeft) * GameTile.TILE_DIMENSIONS;
                drawRectangle.Y = (tileY - distFromTop) * GameTile.TILE_DIMENSIONS;

                sprites.Draw(baseImage, this.drawRectangle, Color.White);
            }
            sprites.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprites"></param>
        public void DrawOccupants(SpriteBatch sprites)
        {
            if (GetOccupant() != null)
            {
                occupant.Draw(sprites);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprites"></param>
        public void OnHover(SpriteBatch sprites)
        {
            sprites.Begin();
            if (IsBuildable())
            {
                sprites.Draw(map.tileset.GetTexture("hover"), this.drawRectangle, Color.White);
            }
            else
            {
                sprites.Draw(map.tileset.GetTexture("invalidhover"), this.drawRectangle, Color.White);
            }
            sprites.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (occupant != null)
            {
                occupant.Update(gameTime);
            }
        }

        //##################################
        //######## Getters #################
        //##################################
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTileX()
        {
            return tileX;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetXCoord()
        {
            return tileX * TILE_DIMENSIONS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTileY()
        {
            return tileY;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetYCoord()
        {
            return tileY * TILE_DIMENSIONS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Texture2D GetBaseImage()
        {
            return baseImage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Building GetOccupant()
        {
            return occupant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GameMap GetMap()
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
        public void SetXCoord(int xCoord)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yCoord"></param>
        public void SetYCoord(int yCoord)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildable"></param>
        public void SetBuildable(bool buildable)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseImage"></param>
        public void SetBaseImage(Texture2D baseImage)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="occupant"></param>
        public void SetOccupant(Building occupant)
        {
            this.occupant = occupant;
        }


        internal bool IsPath()
        {
            if (this.baseImage == this.GetMap().tileset.GetTexture("path") || this.baseImage == this.GetMap().tileset.GetTexture("start") ||
                this.baseImage == this.GetMap().tileset.GetTexture("finish"))
            {
                return true;
            }
            return false;
        }

        public double DistanceTo(GameTile tile)
        {
            return Math.Abs(Math.Sqrt((this.GetTileX() - tile.GetTileX()) * (this.GetTileX() - tile.GetTileX())
                + (this.GetTileY() - tile.GetTileY()) * (this.GetTileY() - tile.GetTileY())));
        }
    }
}
