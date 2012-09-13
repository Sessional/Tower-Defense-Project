using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseGame.Tiles
{
    public class TileSet
    {
        Dictionary<string, Texture2D> tileTextures;
        string tileSetName;

        public TileSet(string tileSetName)
        {
            tileTextures = new Dictionary<string, Texture2D>();
            this.tileSetName = tileSetName;
        }

        public void AddTile(string name, Texture2D tileTexture)
        {
            tileTextures[name] = tileTexture;
        }

        /// <summary>
        /// Get the tile of this tileset by the given name.
        /// </summary>
        /// <param name="tileName">The tile name to get the tile of</param>
        /// <returns>Returns the GameTile object of this tileset relating to the given name.
        /// Returns 'null' if the tileset does not contain that name.</returns>
        public Texture2D GetTexture(string tileName)
        {
            if (tileTextures.ContainsKey(tileName))
            {
                return tileTextures[tileName];
            }
            return null;
        }

        public string GetName()
        {
            return tileSetName;
        }
    }
}
