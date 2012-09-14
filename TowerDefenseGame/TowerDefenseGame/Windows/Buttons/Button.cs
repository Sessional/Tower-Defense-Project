using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.Windows.Buttons
{
    public abstract class Button
    {
        private Texture2D buttonImage;
        GameWindow parentWindow;

        private string text;

        private int xCoord;
        private int yCoord;

        private int width;
        private int height;

        public Button(GameWindow parentWindow, Texture2D image, int xCoord, int yCoord, int width, int height)
        {
            this.parentWindow = parentWindow;
            this.buttonImage = image;
            this.xCoord = xCoord + GetParentWindow().GetX();
            this.yCoord = yCoord + GetParentWindow().GetY();
            this.width = width;
            this.height = height;
        }

        public GameWindow GetParentWindow()
        {
            return parentWindow;
        }

        public abstract void OnClick();

        public abstract void OnHover(SpriteBatch sprites);

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
