using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace TowerDefenseGame.Tiles
{
    class TileManager
    {

        Dictionary<string, TileSet> tileSets;

        public TileManager()
        {

        }

        public enum TileSets
        {
            Standard
        }

        public TileSet getTileSet(TileSets tileSet)
        {
            switch (tileSet)
            {
                default:
                    return tileSets["standard"];
            } 
        }

        public void LoadTiles(ContentManager content)
        {

        }
    }
}
