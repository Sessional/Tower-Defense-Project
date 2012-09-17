using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Maps;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.GameGUI.CursorModifications;
using Microsoft.Xna.Framework;
using TowerDefenseGame.GameGUI.GUIButtons;
using TowerDefenseGame.Tiles;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseGame.GameGUI
{
    public class GameGUIManager
    {

        private MapManager masterManager;
        private TowerDefenseGame masterGame;
        private ContentManager content;

        private CursorModification currentCursorModification;

        private int yStart;
        private int width;

        private int gold;
        private int exp;
        private int lives;

        private Texture2D backgroundTexture;
        private List<Button> guiButtons;
        private List<Button> contextButtons;

        public GameGUIManager(MapManager masterManager, TowerDefenseGame masterGame, ContentManager content, int yStart, int width)
        {
            this.masterGame = masterGame;
            this.masterManager = masterManager;
            this.content = content;
            this.yStart = yStart;
            this.width = width;

            guiButtons = new List<Button>();
            guiButtons.Add(new MenuButton(masterGame, content.Load<Texture2D>("Menus//Buttons//buttonOptions"), GetRelativeLocationX(width - 100), GetRelativeLocationY(10), 115, 40));

            contextButtons = new List<Button>();

            this.gold = 75;
            this.lives = 50;

            backgroundTexture = content.Load<Texture2D>("GameGUI//gameGUIBackground");
        }

        public int GetGold()
        {
            return gold;
        }

        public void AddGold(int g)
        {
            this.gold += g;
        }

        public void SpendGold(int g)
        {
            this.gold -= g;
        }

        public int GetRelativeLocationX(int offset)
        {
            return 0 + offset;
        }

        public int GetRelativeLocationY(int offset)
        {
            return yStart + offset;
        }

        public Vector2 GetRelativeLocation(int x, int y)
        {
            return new Vector2((float)GetRelativeLocationX(x), (float)GetRelativeLocationY(y));
        }

        public void LoseLife()
        {
            lives--;
        }

        public void Update(GameTime time)
        {
            
            if (masterGame.GetMapManager().GetCurrentMap().HasSelectionChanged())
            {
                while (contextButtons.Count > 0)
                {
                    contextButtons.RemoveAt(0);
                }

                if (masterGame.GetMapManager().GetCurrentMap().GetSelection() == null)
                {

                }
                else
                {
                    GameTile selectedTile = masterGame.GetMapManager().GetCurrentMap().GetSelection();

                    if (selectedTile.getOccupant() == null && selectedTile.isBuildable())
                    {
                        contextButtons.Add(new BuildBlueTowerButton(masterGame, content.Load<Texture2D>("Towers//TowerBlue"), GetRelativeLocationX(250), GetRelativeLocationY(5), 40, 40));
                    }
                    else if (selectedTile.getOccupant() != null)
                    {
                        contextButtons = selectedTile.getOccupant().GetContextButtons();
                    }
                }
            }
            
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(backgroundTexture, new Rectangle(0, yStart, width, 200), Color.White);
            sprites.DrawString(masterGame.GetGUIFont(), "Gold: " + gold, GetRelativeLocation(10, 5), Color.Gold);
            sprites.DrawString(masterGame.GetGUIFont(), "Lives: " + lives, GetRelativeLocation(10, 25), Color.White);
            if (masterGame.GetMapManager().GetWaveManager().GetCurrentWave() == null || masterGame.GetMapManager().GetWaveManager().IsWaveComplete())
            {
                sprites.DrawString(masterGame.GetGUIFont(), "Time until next wave: " + masterGame.GetMapManager().GetWaveManager().GetTimeUntilNextWave(), GetRelativeLocation(10, 45), Color.Red);
            }
            else if (masterGame.GetMapManager().GetWaveManager().GetCurrentWave() != null)
            {
                sprites.DrawString(masterGame.GetGUIFont(), "Monsters remaining: " + masterGame.GetMapManager().GetWaveManager().GetCurrentWave().GetRemainingMonsters(), GetRelativeLocation(10, 45), Color.Red);
            }
            sprites.DrawString(masterGame.GetGUIFont(), "Current Wave: " + masterGame.GetMapManager().GetWaveManager().GetWaveNumber(), GetRelativeLocation(10, 65), Color.Red);
            sprites.End();

            foreach (Button b in guiButtons)
            {
                b.Draw(sprites);
            }
            foreach (Button b in contextButtons)
            {
                b.Draw(sprites);
            }

            int x = Mouse.GetState().X;
            int y = Mouse.GetState().Y;

            foreach (Button b in guiButtons)
            {
                if (b.InBounds(x, y))
                {
                    b.OnHover(sprites);
                }

            }
            foreach (Button b in contextButtons)
            {
                if (b.InBounds(x, y))
                {
                    b.OnHover(sprites);
                }
            }
        }

        public void OnClick(int x, int y)
        {
            foreach (Button b in guiButtons)
            {
                if (b.InBounds(x, y))
                {
                    b.OnClick();
                }
            }
            foreach (Button b in contextButtons)
            {
                if (b.InBounds(x, y))
                {
                    b.OnClick();
                }
            }
        }

        public void OnRightClick(int x, int y)
        {

        }
    }
}
