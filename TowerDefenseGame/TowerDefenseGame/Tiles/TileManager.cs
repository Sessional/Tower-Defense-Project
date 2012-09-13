using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using TowerDefenseGame.Content;

namespace TowerDefenseGame.Tiles
{
    public class TileManager
    {

        Dictionary<string, TileSet> tileSets;
        ContentManager content;

        public TileManager(ContentManager content)
        {
            tileSets = new Dictionary<string, TileSet>();
            this.content = content;
            LoadTiles();
        }

        public TileSet getTileSet(string tileSet)
        {
            return tileSets[tileSet];
        }

        public void LoadTiles()
        {
            TileSetReader tsr = new TileSetReader(this, "standard", content);
        }

        public void AddTileSet(TileSet tileset)
        {
            tileSets.Add(tileset.GetName(), tileset);
        }
    }
}
