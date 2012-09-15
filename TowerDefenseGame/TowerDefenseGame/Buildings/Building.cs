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
    public abstract class Building
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

        public abstract void Draw(SpriteBatch sprites);

        public abstract void Update(GameTime gameTime);

        public void OnClick()
        {

        }

        public void OnRightClick()
        {

        }

        public Texture2D GetTexture()
        {
            return buildingTexture;
        }

        public GameTile GetParentTile()
        {
            return tile;
        }

        public TowerDefenseGame GetRootGame()
        {
            return this.masterGame;
        }

        public void DrawContextMenu(SpriteBatch sprites)
        {

        }
    }
}
