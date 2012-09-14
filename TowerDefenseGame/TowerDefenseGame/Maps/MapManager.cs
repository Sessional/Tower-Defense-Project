using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using TowerDefenseGame.Windows;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenseGame.Tiles;

namespace TowerDefenseGame.Maps
{
    public class MapManager
    {
        private TowerDefenseGame masterGame;

        private ContentManager content;

        private GameMap currentMap;

        private WindowManager windowManager;


        public MapManager(TowerDefenseGame masterGame, ContentManager content)
        {
            this.masterGame = masterGame;
            this.content = content;

            windowManager = new WindowManager(masterGame, content);
        }

        public void SetScreenSize()
        {
            masterGame.SetScreenSize(currentMap.getMapWidth(), currentMap.getMapHeight() + 200);
        }

        public void LoadMap(string mapName)
        {
            currentMap = new GameMap(masterGame, mapName);
        }

        public TowerDefenseGame GetRootGame()
        {
            return masterGame;
        }

        public WindowManager GetWindowManager()
        {
            return windowManager;
        }

        public void ExitGame()
        {
            currentMap = null;
            while (GetWindowManager().GetWindow() != null)
            {
                GetWindowManager().RemoveWindow();
            }
            masterGame.SetGameState(TowerDefenseGame.GameState.MainWindow);
        }

        public void HandleEscape()
        {
            GetWindowManager().HandleEscape();
        }

        public void TogglePause()
        {
            if (currentMap == null)
            {
                return;
            }
            currentMap.TogglePause();
        }

        public void OnClick(int x, int y)
        {
            if (currentMap.IsPaused())
            {
                GetWindowManager().HandleClick(Mouse.GetState().X, Mouse.GetState().Y);
            }
            else if (!currentMap.IsPaused())
            {
                
            }
        }

        public void Draw(SpriteBatch sprites)
        {
            currentMap.Draw(sprites);


            if (currentMap.IsPaused())
            {
                GetWindowManager().Draw(sprites);
            }
            else
            {
                int x = Mouse.GetState().X;
                int y = Mouse.GetState().Y;
                try
                {
                    GameTile tile = currentMap.getTile((int)x / GameTile.TILE_DIMENSIONS, (int)y / GameTile.TILE_DIMENSIONS);
                    tile.OnHover(sprites);
                }
                catch (IndexOutOfRangeException)
                {

                }
            }
        }
    }
}
