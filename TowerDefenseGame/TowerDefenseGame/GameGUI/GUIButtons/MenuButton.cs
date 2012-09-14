using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseGame.GameGUI.GUIButtons
{
    public class MenuButton : Button
    {

        public MenuButton(TowerDefenseGame masterGame, Texture2D texture, int x, int y, int width, int height)
            : base(masterGame, texture, x, y, width, height)
        {

        }

        public override void OnRightClick()
        {
            throw new NotImplementedException();
        }

        public override void OnClick()
        {
            GetMasterGame().GetMapManager().GetWindowManager().HandleEscape();
        }

        public override void OnHover(SpriteBatch sprites)
        {
            throw new NotImplementedException();
        }
    }
}
