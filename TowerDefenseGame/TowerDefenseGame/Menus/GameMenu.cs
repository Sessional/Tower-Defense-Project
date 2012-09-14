using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Menus.Buttons;

namespace TowerDefenseGame.Menus
{
    public class GameMenu
    {
        private List<Button> buttons;
        private Texture2D backgroundImage;
        private TowerDefenseGame masterGame;
        private MenuManager.Menus menuState;

        int width;
        int height;

        public GameMenu(TowerDefenseGame masterGame, Texture2D bgImage)
        {
            backgroundImage = bgImage;
            this.masterGame = masterGame;
            buttons = new List<Button>();
            width = 700;
            height = 400;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public List<Button> getButtons()
        {
            return buttons;
        }

        public MenuManager.Menus GetMenuType()
        {
            return menuState;
        }

        public void AddButton(Button button)
        {
            buttons.Add(button);
        }

        public TowerDefenseGame getRootGame()
        {
            return masterGame;
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(backgroundImage, new Rectangle(0, 0, 700, 400), Color.White);
            sprites.End();
            foreach (Button b in buttons)
            {
                b.Draw(sprites);
            }
        }
    }
}
