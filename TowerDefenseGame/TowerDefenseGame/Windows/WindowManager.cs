using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace TowerDefenseGame.Windows
{
    public class WindowManager
    {
        private Game1 masterGame;
        private ContentManager content;

        private List<GameWindow> windows;

        public WindowManager(Game1 masterGame, ContentManager content)
        {
            this.masterGame = masterGame;
            this.content = content;

            windows = new List<GameWindow>();
        }

        public GameWindow GetWindow()
        {
            if (windows.Count == 0)
            {
                return null;
            }
            return windows[windows.Count - 1];
        }

        public void ApplyGameWindow()
        {
            GameWindow removedWindow = GetWindow();
            windows.RemoveAt(windows.Count - 1);
            removedWindow.Apply();
        }

        public void HandleEscape()
        {
            //masterGame.GetMapManager().T
        }
    }
}
