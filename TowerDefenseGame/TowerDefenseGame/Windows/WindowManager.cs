using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseGame.Windows
{
    public class WindowManager
    {
        private TowerDefenseGame masterGame;
        private ContentManager content;

        private List<GameWindow> windows;

        public enum GameWindows
        {
            PauseMenu,
            DefeatWindow
        }

        public WindowManager(TowerDefenseGame masterGame, ContentManager content)
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

        public void RemoveWindow()
        {
            if (windows.Count == 0)
            {
                return;
            }
            windows.RemoveAt(windows.Count - 1);
            if (windows.Count == 0)
            {
                masterGame.GetMapManager().TogglePause();
            }
        }

        public void ApplyGameWindow()
        {
            GameWindow removedWindow = GetWindow();
            windows.RemoveAt(windows.Count - 1);
            removedWindow.Apply();

        }

        public void AddGameWindow(GameWindow gw)
        {
            if (!masterGame.GetMapManager().GetCurrentMap().IsPaused())
            {
                masterGame.GetMapManager().TogglePause();
            }
            windows.Add(gw);
        }

        public void Draw(SpriteBatch sprites)
        {
            GetWindow().Draw(sprites);
        }

        public void HandleEscape()
        {
            if (GetWindow() == null)
            {
                masterGame.GetMapManager().TogglePause();
                AddGameWindow(new GameWindow(masterGame, content, GameWindows.PauseMenu));
            }
            else
            {
                if (GetWindow().GetWindowType() == GameWindows.DefeatWindow)
                {

                }
                else
                {
                    RemoveWindow();
                }
            }
        }

        public void HandleClick(int x, int y)
        {
            GetWindow().HandleClick(x, y);
        }
    }
}
