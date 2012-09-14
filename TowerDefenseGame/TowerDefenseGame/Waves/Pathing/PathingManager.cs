using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Maps;
using TowerDefenseGame.Tiles;

namespace TowerDefenseGame.Waves.Pathing
{
    public class PathingManager
    {
        private GameMap masterMap;

        private List<GameTile> path;

        public PathingManager(GameMap masterMap)
        {
            this.masterMap = masterMap;
            path = new List<GameTile>();
        }



    }
}
