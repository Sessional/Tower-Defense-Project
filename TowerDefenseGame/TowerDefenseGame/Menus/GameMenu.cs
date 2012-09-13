using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.Menus;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.Menu
{
    public class GameMenu
    {
        private List<Button> buttons;
        private Texture2D backgroundImage;
        private Game1 masterGame;

        public GameMenu(Game1 masterGame, Texture2D bgImage)
        {
            backgroundImage = bgImage;
            this.masterGame = masterGame;
            buttons = new List<Button>();
            masterGame.setScreenSize(700, 400);
        }

        public List<Button> getButtons()
        {
            return buttons;
        }

        public void AddButton(Button button)
        {
            buttons.Add(button);
        }

        public Game1 getRootGame()
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
