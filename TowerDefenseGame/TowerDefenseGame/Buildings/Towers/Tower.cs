using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using TowerDefenseGame.Tiles;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseGame.Buildings.Towers
{
    public class Tower : Building
    {
        public Tower(TowerDefenseGame masterGame, ContentManager content, GameTile parentTile, BuildingType type, Texture2D image)
            : base(masterGame, content, parentTile, type, image)
        {
        }
    }
}
