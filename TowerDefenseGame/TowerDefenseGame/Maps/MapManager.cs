using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using TowerDefenseGame.Windows;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenseGame.Tiles;
using TowerDefenseGame.GameGUI;
using TowerDefenseGame.Waves;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.Maps
{
    public class MapManager
    {
        private TowerDefenseGame masterGame;

        private ContentManager content;

        private GameMap currentMap;

        private WindowManager windowManager;

        private GameGUIManager gameGUI;

        private WaveManager waveManager;


        public MapManager(TowerDefenseGame masterGame, ContentManager content)
        {
            this.masterGame = masterGame;
            this.content = content;

            windowManager = new WindowManager(masterGame, content);

        }

        public void SetScreenSize()
        {
            masterGame.SetScreenSize(currentMap.GetMapWidth() * GameTile.TILE_DIMENSIONS, currentMap.GetMapHeight() * GameTile.TILE_DIMENSIONS + 200);
        }

        public void LoadMap(string mapName)
        {
            currentMap = new GameMap(masterGame, mapName);
            if (currentMap.IsPaused())
            {
                currentMap.TogglePause();
            }
            gameGUI = new GameGUIManager(this, masterGame, content, currentMap.GetMapHeight() * GameTile.TILE_DIMENSIONS, currentMap.GetMapWidth() * GameTile.TILE_DIMENSIONS);
            waveManager = new WaveManager(this, masterGame, content);
        }

        public void Update(GameTime gameTime)
        {
            if (currentMap.IsPaused())
            {

            }
            else if (!currentMap.IsPaused())
            {
                waveManager.Update(gameTime);
                currentMap.Update(gameTime);
                gameGUI.Update(gameTime);
            }
        }

        public List<GameTile> GetSpawnTiles()
        {
            return currentMap.GetSpawnTiles();
        }

        public List<GameTile> GetFinishTiles()
        {
            return currentMap.GetFinishTiles();
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
                if (x < currentMap.GetMapWidthPixels() && x > 0)
                {
                    if (y < currentMap.GetMapHeightPixels() && y > 0)
                    {
                        currentMap.OnClick(x, y);
                    }
                }
                if (x < currentMap.GetMapWidthPixels() && x > 0)
                {
                    if (y < currentMap.GetMapHeightPixels() + 200 && y > currentMap.GetMapHeightPixels())
                    {
                        gameGUI.OnClick(x, y);
                    }
                }
            }
        }

        public void Draw(SpriteBatch sprites)
        {
            currentMap.Draw(sprites);

            waveManager.Draw(sprites);

            if (currentMap.IsPaused())
            {
                GetWindowManager().Draw(sprites);
            }
            else
            {
                int x = Mouse.GetState().X;
                int y = Mouse.GetState().Y;

                if (x < currentMap.GetMapWidthPixels() && x > 0)
                {
                    if (y < currentMap.GetMapHeightPixels() && y > 0)
                    {
                        GameTile tile = currentMap.GetTile((int)x / GameTile.TILE_DIMENSIONS, (int)y / GameTile.TILE_DIMENSIONS);
                        if (tile != null)
                        {
                            tile.OnHover(sprites);
                        }
                    }
                }
            }

            gameGUI.Draw(sprites);
        }

        internal void OnRightClick(int x, int y)
        {
            if (currentMap.IsPaused())
            {
            }
            else if (!currentMap.IsPaused())
            {
                currentMap.OnRightClick(x, y);
                gameGUI.OnRightClick(x, y);
            }
        }

        internal GameMap GetCurrentMap()
        {
            return currentMap;
        }

        public WaveManager GetWaveManager()
        {
            return waveManager;
        }

        public GameGUIManager GetGameGUI()
        {
            return gameGUI;
        }

        internal void HandleLeftArrow()
        {
            currentMap.HandleLeftArrow();
        }

        internal void HandleRightArrow()
        {
            currentMap.HandleRightArrow();
        }

        internal void HandleUpArrow()
        {
            currentMap.HandleUpArrow();
        }

        internal void HandleDownArrow()
        {
            currentMap.HandleDownArrow();
        }
    }
}
