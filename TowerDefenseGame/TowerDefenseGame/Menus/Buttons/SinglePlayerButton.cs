using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Menu;

namespace TowerDefenseGame.Menus
{
    public class SinglePlayerButton : Button
    {

        public SinglePlayerButton(GameMenu parentMenu, Texture2D image, int xCoord, int yCoord, int width, int height) : base(parentMenu, image, xCoord, yCoord, width, height)
        {
            
        }

        public override void OnClick()
        {
            getParentMenu().getRootGame().setGameState(Game1.GameState.GameWindow);
        }

        public override void OnHover(SpriteBatch sprites)
        {

        }
    }
}
