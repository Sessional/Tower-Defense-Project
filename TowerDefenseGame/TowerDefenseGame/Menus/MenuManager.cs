using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using TowerDefenseGame.Menus;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.Menus.Buttons;

namespace TowerDefenseGame.Menus
{
    public class MenuManager
    {

        private List<GameMenu> gameMenus;
        private ContentManager content;
        private TowerDefenseGame masterGame;

        public enum Menus
        {
            MainMenu,
            SinglePlayerMenu,
            MultiPlayerSelectionMenu,
            MultiPlayerCreationMenu,
            MultiPlayerLobbyMenu,
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        public void AddMenu(Menus menu)
        {
            switch (menu)
            {
                case Menus.MainMenu:
                    GameMenu tempMenu = new GameMenu(masterGame, content.Load<Texture2D>("Menus//menuMain"));
                    tempMenu.AddButton(new SinglePlayerButton(tempMenu, content.Load<Texture2D>("Menus//Buttons/buttonSinglePlayer"), 350, 200, 100, 50));
                    gameMenus.Add(tempMenu);
                    break;
                case Menus.MultiPlayerCreationMenu:
                    break;
                case Menus.MultiPlayerLobbyMenu:
                    break;
                case Menus.MultiPlayerSelectionMenu:
                    break;
                case Menus.SinglePlayerMenu:
                    break;
            }
        }

        public void RemoveAllButFirstMenu()
        {
            while (gameMenus.Count > 1)
            {
                RemoveMenu();
            }
        }

        public void SetScreenSize()
        {
            masterGame.SetScreenSize(GetMenu().GetWidth(), GetMenu().GetHeight());
        }

        /// <summary>
        /// Always returns the last element of the gameMenus list.
        /// Stack-like behavior.
        /// </summary>
        public GameMenu GetMenu()
        {
            return gameMenus[gameMenus.Count - 1];
        }

        public void RemoveMenu()
        {
            gameMenus.RemoveAt(gameMenus.Count - 1);
            if (gameMenus.Count == 0)
            {
                masterGame.Exit();
            }
        }

        public MenuManager(TowerDefenseGame masterGame, ContentManager content)
        {
            gameMenus = new List<GameMenu>();
            this.content = content;
            this.masterGame = masterGame;
            AddMenu(Menus.MainMenu);
            SetScreenSize();
        }

        public void OnClick(int x, int y)
        {
            foreach (Button b in GetMenu().getButtons())
            {
                if (b.InBounds(x, y))
                {
                    b.OnClick();
                }
            }
        }

        public void Draw(SpriteBatch sprites)
        {
            GetMenu().Draw(sprites);
        }
    }
}
