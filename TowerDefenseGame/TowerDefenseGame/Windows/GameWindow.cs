using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using TowerDefenseGame.Windows.Buttons;

namespace TowerDefenseGame.Windows
{
    public class GameWindow
    {

        TowerDefenseGame masterGame;

        WindowManager.GameWindows windowType;

        Texture2D menuBackgrounds;

        ContentManager content;

        List<Button> buttons;

        int x;
        int y;
        int height;
        int width;

        public GameWindow(TowerDefenseGame masterGame, ContentManager content, WindowManager.GameWindows gameWindowType)
        {
            this.masterGame = masterGame;
            windowType = gameWindowType;
            this.content = content;

            menuBackgrounds = content.Load<Texture2D>("Menus//menuBackground");

            buttons = new List<Button>();
            InitializeWindow(gameWindowType);
        }

        private void InitializeWindow(WindowManager.GameWindows gameWindowType)
        {
            switch (gameWindowType)
            {
                case WindowManager.GameWindows.PauseMenu:

                    x = 325;
                    y = 50;
                    width = 250;
                    height = 250;
                    AddButton(new ExitGameButton(this, content.Load<Texture2D>("Menus//Buttons//buttonExit"), 75, 100,  80, 60));
                    AddButton(new ResumeGameButton(this, content.Load<Texture2D>("Menus//Buttons//buttonResumeGame"), 75, 125, 80, 60));
                    break;
            }
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public TowerDefenseGame GetRootGame()
        {
            return masterGame;
        }

        public List<Button> GetButtons()
        {
            return buttons;
        }

        public void AddButton(Button button)
        {
            buttons.Add(button);
        }

        public void Apply()
        {

        }

        public void HandleClick(int x, int y)
        {
            foreach (Button b in GetButtons())
            {
                if (b.InBounds(x, y))
                {
                    b.OnClick();
                }
            }
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            switch (windowType)
            {
                case WindowManager.GameWindows.PauseMenu:
                    sprites.Draw(menuBackgrounds, new Rectangle(x, y, width, height), Color.White);
                    break;
            }
            sprites.End();

            foreach (Button b in GetButtons())
            {
                b.Draw(sprites);
            }
        }
    }
}
