using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Maps;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseGame.GameGUI.CursorModifications;
using Microsoft.Xna.Framework;

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

        private Texture2D backgroundTexture;

        public GameGUIManager(MapManager masterManager, TowerDefenseGame masterGame, ContentManager content, int yStart, int width)
        {
            this.masterGame = masterGame;
            this.masterManager = masterManager;
            this.content = content;
            this.yStart = yStart;
            this.width = width;

            backgroundTexture = content.Load<Texture2D>("GameGUI//gameGUIBackground");
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            sprites.Draw(backgroundTexture, new Rectangle(0, yStart, width, 200), Color.White);
            sprites.End();
        }

        public void OnClick(int x, int y)
        {

        }

        public void OnRightClick(int x, int y)
        {

        }
    }
}
