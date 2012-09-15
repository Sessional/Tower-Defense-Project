using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using TowerDefenseGame.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Waves;
using TowerDefenseGame.Monsters;

namespace TowerDefenseGame.Buildings.Towers
{
    public class Tower : Building
    {

        private int range;
        private int rateOfFire;
        private int nextFire;

        public Tower(TowerDefenseGame masterGame, ContentManager content, GameTile parentTile, BuildingType type, Texture2D image)
            : base(masterGame, content, parentTile, type, image)
        {
            range = 2;
            rateOfFire = 30;
            nextFire = 0;
            projectiles = new List<Projectile>();
        }

        public List<Projectile> projectiles;

        public void RemoveProjectile(Projectile proj)
        {
            projectiles.Remove(proj);
        }

        public override void Update(GameTime gameTime)
        {
            int tileX = GetParentTile().getTileX();
            int tileY = GetParentTile().getTileY();

            WaveManager waveManager = GetRootGame().GetMapManager().GetWaveManager();

            for (int i = projectiles.Count; i > 0; i--)
            {
                projectiles[i-1].Update(gameTime);
            }

            List<Monster> mList = waveManager.GetCurrentWave().GetMonsters();
            if (nextFire <= 0)
            {
                foreach (Monster m in mList)
                {
                    if (GetParentTile().DistanceTo(m.GetPosition()) <= range)
                    {
                        projectiles.Add(new Projectile(GetRootGame(),this, m));
                        nextFire = rateOfFire;
                        break;
                    }
                }
            }
            else
            {
                nextFire--;
            }
        }

        public override void Draw(SpriteBatch sprites)
        {

            sprites.Begin();
            sprites.Draw(GetTexture(), new Rectangle(GetParentTile().GetXCoord() + 10, GetParentTile().GetYCoord() + 10, DIMENSION, DIMENSION), Color.White);
            sprites.End();

            foreach (Projectile p in projectiles)
            {
                p.Draw(sprites);
            }
        }
    }
}
