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

        private Texture2D backgroundTexture;
        private List<Button> guiButtons;

        public GameGUIManager(MapManager masterManager, TowerDefenseGame masterGame, ContentManager content, int yStart, int width)
        {
            this.masterGame = masterGame;
            this.masterManager = masterManager;
            this.content = content;
            this.yStart = yStart;
            this.width = width;

            guiButtons = new List<Button>();
            guiButtons.Add(new MenuButton(masterGame, content.Load<Texture2D>("Menus//Buttons//buttonOptions"), GetRelativeLocationX(width - 100), GetRelativeLocationY(10), 85, 40));

            this.gold = 75;

            backgroundTexture = content.Load<Texture2D>("GameGUI//gameGUIBackground");
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

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(backgroundTexture, new Rectangle(0, yStart, width, 200), Color.White);
            sprites.DrawString(masterGame.GetGUIFont(), "Gold: " + gold, GetRelativeLocation(10, 5), Color.Gold);
            if (masterGame.GetMapManager().GetWaveManager().GetCurrentWave() == null || masterGame.GetMapManager().GetWaveManager().IsWaveComplete())
            {
                sprites.DrawString(masterGame.GetGUIFont(), "Time until next wave: " + masterGame.GetMapManager().GetWaveManager().GetTimeUntilNextWave(), GetRelativeLocation(10, 25), Color.Red);
            }
            else if (masterGame.GetMapManager().GetWaveManager().GetCurrentWave() != null)
            {
                sprites.DrawString(masterGame.GetGUIFont(), "Monsters remaining: " + masterGame.GetMapManager().GetWaveManager().GetCurrentWave().GetTotalMonsters(), GetRelativeLocation(10, 25), Color.Red);
            }
            sprites.End();

            foreach (Button b in guiButtons)
            {
                b.Draw(sprites);
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
        }

        public void OnRightClick(int x, int y)
        {

        }
    }
}
