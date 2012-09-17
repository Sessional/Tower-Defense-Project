using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Monsters;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.Tiles;

namespace TowerDefenseGame.Buildings.Towers
{
    public class Projectile
    {

        private int damage;

        private Tower parentTower;

        private Monster target;

        private Texture2D texture;

        private float x;
        private float y;

        private float velocity;

        public Projectile(TowerDefenseGame masterGame, Tower parentTower, Monster target)
        {
            damage = 2;
            velocity = 1.5f;
            this.target = target;
            this.x = parentTower.GetParentTile().GetXCoord() + GameTile.TILE_DIMENSIONS / 3;
            this.y = parentTower.GetParentTile().GetYCoord() + GameTile.TILE_DIMENSIONS / 3;
            this.parentTower = parentTower;
            texture = masterGame.Content.Load<Texture2D>("Towers//Projectiles//Projectile");
        }

        public void Update(GameTime gameTime)
        {
            int monsterX = target.GetPosition().GetXCoord() + 20;
            int monsterY = target.GetPosition().GetYCoord() + 20;

            if (target.isDead || target.isLeak)
            {
                parentTower.RemoveProjectile(this);
            }

            if (DistanceTo(monsterX, monsterY) < 2)
            {
                parentTower.RemoveProjectile(this);
                target.Damage(damage);
            }

            if (monsterX > x)
            {
                float diffInCoordinates = Math.Abs(x - monsterX);
                x += Math.Min(velocity, diffInCoordinates);
            }
            else if (x > monsterX)
            {
                float diffInCoordinates = Math.Abs(x - monsterX);
                x -= Math.Min(velocity, diffInCoordinates);
            }

            if (monsterY > y)
            {
                float diffInCoordinates = Math.Abs(y - monsterY);
                y += Math.Min(velocity, diffInCoordinates);
            }
            else if (y > monsterY)
            {
                float diffInCoordinates = Math.Abs(y - monsterY);
                y -= Math.Min(velocity, diffInCoordinates);
            }

        }

        public double DistanceTo(int monsterX, int monsterY)
        {
            return Math.Abs(Math.Sqrt(((this.x - monsterX) * (this.x - monsterX)) + ((this.y - monsterY) * (this.y - monsterY))));
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(texture, new Rectangle((int)x, (int)y, 20, 20), Color.White);
            sprites.End();
        }

        public float GetX()
        {
            return x;
        }

        public float GetY()
        {
            return y;
        }

        public Vector2 GetPosition()
        {
            return new Vector2(GetX(), GetY());
        }

        public Monster GetTarget()
        {
            return target;
        }
    }
}
