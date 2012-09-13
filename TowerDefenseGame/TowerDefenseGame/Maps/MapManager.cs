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
        private Game1 masterGame;

        private ContentManager content;

        private GameMap currentMap;

        private WindowManager windowManager;


        public MapManager(Game1 masterGame, ContentManager content)
        {
            this.masterGame = masterGame;
            this.content = content;

            windowManager = new WindowManager(masterGame, content);
        }

        public void LoadMap(string mapName)
        {
            currentMap = new GameMap(masterGame, mapName);
        }

        public Game1 GetRootGame()
        {
            return masterGame;
        }

        public WindowManager GetWindowManager()
        {
            return windowManager;
        }

        public void HandleEscape()
        {
            GetWindowManager().HandleEscape();
        }

        public void TogglePause()
        {
            currentMap.TogglePause();
        }

        public void Update()
        {

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
