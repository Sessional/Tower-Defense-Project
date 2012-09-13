using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Menu;

namespace TowerDefenseGame.Menus
{
    abstract class Button
    {
        private Texture2D buttonImage;
        private GameMenu parentMenu;

        private string text;

        private int xCoord;
        private int yCoord;

        private int width;
        private int height;

        public Button(GameMenu parentMenu, Texture2D image, int xCoord, int yCoord, int width, int height)
        {
            this.parentMenu = parentMenu;
            this.buttonImage = image;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.width = width;
            this.height = height;
        }

        public abstract void OnClick()
        {
            parentMenu.getRootGame().setGameState(Game1.GameState.GameWindow);
        }

        public void OnHover(SpriteBatch sprites)
        {

        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(buttonImage, new Rectangle(xCoord, yCoord, width, height), Color.White);
            sprites.End();
        }

        public bool InBounds(int x, int y)
        {
            if (x > xCoord && x < xCoord + width)
            {
                if (y > yCoord && y < yCoord + height)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
