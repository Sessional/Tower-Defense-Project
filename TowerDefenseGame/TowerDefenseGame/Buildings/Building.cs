using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.Buildings
{
    public class Building
    {
        private TowerDefenseGame masterGame;
        private ContentManager content;

        GameTile tile;

        public static int DIMENSION = GameTile.TILE_DIMENSIONS - 20;

        private Texture2D buildingTexture;

        private BuildingType type;

        public enum BuildingType
        {
            Neutral,
            Tower
        }

        public Building(TowerDefenseGame masterGame, ContentManager content, GameTile parentTile, BuildingType type, Texture2D image)
        {
            this.masterGame = masterGame;
            this.content = content;
            this.tile = parentTile;
            this.type = type;
            this.buildingTexture = image;
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(buildingTexture, new Rectangle(tile.GetXCoord() + 10, tile.GetYCoord() + 10, DIMENSION, DIMENSION), Color.White);
            sprites.End();
        }

        public void OnClick()
        {

        }

        public void OnRightClick()
        {

        }
    }
}
