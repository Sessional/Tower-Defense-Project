using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Tiles;

namespace TowerDefenseGame.Waves.Pathing
{
    public class PathedTile
    {

        GameTile thisTile;
        public List<GameTile> inputTiles;
        public List<GameTile> outputTiles;

        public PathedTile(GameTile tile)
        {
            thisTile = tile;
        }
    }
}
