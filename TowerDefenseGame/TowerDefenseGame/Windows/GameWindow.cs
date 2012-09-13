using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace TowerDefenseGame.Windows
{
    public class GameWindow
    {

        WindowManager.GameWindows windowType;

        Texture2D menuBackgrounds;

        ContentManager content;

        public GameWindow(ContentManager content, WindowManager.GameWindows gameWindowType)
        {
            windowType = gameWindowType;
            this.content = content;

            menuBackgrounds = content.Load<Texture2D>("Menus//menuBackground");
        }

        public void Apply()
        {

        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Begin();
            switch (windowType)
            {
                case WindowManager.GameWindows.PauseMenu:
                    sprites.Draw(menuBackgrounds, new Rectangle(150, 150, 450, 200), Color.White);
                    break;
            }
            sprites.End();
        }
    }
}
