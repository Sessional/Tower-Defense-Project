using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.Buildings;
using TowerDefenseGame.Buildings.Towers;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.GameGUI.GUIButtons
{
    public class BuildGreenTowerButton : Button
    {

        public BuildGreenTowerButton(TowerDefenseGame masterGame, Texture2D texture, int x, int y, int width, int height)
            : base(masterGame, texture, x, y, width, height)
        {

        }

        public override void OnRightClick()
        {
            throw new NotImplementedException();
        }

        public override void OnClick()
        {
            if (GetMasterGame().GetMapManager().GetGameGUI().GetGold() >= 50)
            {
                GetMasterGame().GetMapManager().GetGameGUI().SpendGold(50);
                Tower towerToBuild = new Tower(GetMasterGame(), GetMasterGame().Content, GetMasterGame().GetMapManager().GetCurrentMap().GetSelection(), Building.BuildingType.Tower, GetMasterGame().Content.Load<Texture2D>("Towers//TowerGreen"));
                towerToBuild.SetRateOfFire(90);
                towerToBuild.SetDamage(10);
                towerToBuild.SetRange(5);
                GetMasterGame().GetMapManager().GetCurrentMap().GetSelection().setOccupant(towerToBuild);
            }
        }

        public override void OnHover(SpriteBatch sprites)
        {

            sprites.Begin();
            sprites.DrawString(GetMasterGame().GetHealthFont(), "Build green tower", new Vector2(this.GetX() + this.GetWidth(), this.GetY()), Color.Green);
            sprites.End();
        }
    }
}
