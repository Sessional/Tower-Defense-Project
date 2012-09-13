using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefenseGame.Tiles
{
    class TileSet
    {
        Dictionary<string, GameTile> tiles;
        string tileSetName;

        public TileSet(string tileSetName)
        {
            tiles = new Dictionary<string, GameTile>();
            this.tileSetName = tileSetName;
        }

        public void AddTile(string name, GameTile tile)
        {
            tiles[name] = tile;
        }

        /// <summary>
        /// Get the tile of this tileset by the given name.
        /// </summary>
        /// <param name="tileName">The tile name to get the tile of</param>
        /// <returns>Returns the GameTile object of this tileset relating to the given name.
        /// Returns 'null' if the tileset does not contain that name.</returns>
        public GameTile GetTile(string tileName)
        {
            if (tiles.ContainsKey(tileName))
            {
                return tiles[tileName];
            }
            return null;
        }
    }
}
