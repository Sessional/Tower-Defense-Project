using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace TowerDefenseGame.Menu
{
    public class MenuManager
    {

        private List<GameMenu> gameMenus;
        private ContentManager content;

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

        /// <summary>
        /// Always returns the last element of the gameMenus list.
        /// Stack-like behavior.
        /// </summary>
        public GameMenu GetMenu()
        {
            return gameMenus[gameMenus.Count - 1];
        }

        public MenuManager(ContentManager content)
        {
            gameMenus = new List<GameMenu>();
            this.content = content;
        }

        public void HandleClick()
        {

        }
    }
}
