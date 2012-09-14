using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.Windows.Buttons
{
    public class ResumeGameButton : Button
    {
        public ResumeGameButton(GameWindow parentWindow, Texture2D image, int xCoord, int yCoord, int width, int height)
            : base(parentWindow, image, xCoord, yCoord, width, height)
        {

        }

        public override void OnClick()
        {
            GetParentWindow().GetRootGame().GetMapManager().GetWindowManager().RemoveWindow();
            //GetParentWindow().GetRootGame().GetMapManager().TogglePause();
        }

        public override void OnHover(SpriteBatch sprites)
        {
            throw new NotImplementedException();
        }
    }
}
