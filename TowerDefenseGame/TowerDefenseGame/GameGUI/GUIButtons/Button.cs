using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.GameGUI.GUIButtons
{
    public abstract class Button
    {
        TowerDefenseGame masterGame;

        private int xCoord;
        private int yCoord;
        private int width;
        private int height;

        private Texture2D texture;

        public Button(TowerDefenseGame masterGame, Texture2D texture, int x, int y, int width, int height)
        {
            this.masterGame = masterGame;
            this.texture = texture;
            this.xCoord = x;
            this.yCoord = y;
            this.width = width;
            this.height = height;
        }

        public TowerDefenseGame GetMasterGame()
        {
            return masterGame;
        }

        public int GetX()
        {
            return xCoord;
        }

        public int GetY()
        {
            return yCoord;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(texture, new Rectangle(GetX(), GetY(), GetWidth(), GetHeight()), Color.White);
            sprites.End();
        }

        public abstract void OnHover(SpriteBatch sprites);

        public abstract void OnClick();

        public abstract void OnRightClick();

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
