using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TowerDefenseGame.Maps;
using TowerDefenseGame.Tiles;
using TowerDefenseGame.Menus;

namespace TowerDefenseGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TowerDefenseGame : Microsoft.Xna.Framework.Game
    {

        SpriteFont guiFont;
        SpriteFont healthFont;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameState currentState;

        public Texture2D menuTexture;
        public Texture2D singlePlayerButton;

        TileManager tileManager;
        MenuManager menuManager;
        MapManager mapManager;

        /// <summary>
        /// The SpriteFont used to write health text on the screen.
        /// </summary>
        /// <returns></returns>
        public SpriteFont GetHealthFont()
        {
            return healthFont;
        }

        public SpriteFont GetGUIFont()
        {
            return guiFont;
        }

        public TileManager GetTileManager()
        {
            return tileManager;
        }

        public MenuManager GetMenuManager()
        {
            return menuManager;
        }

        public MapManager GetMapManager()
        {
            return mapManager;
        }

        public enum GameState
        {
            MainWindow,
            GameWindow
        }

        public TowerDefenseGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currentState = GameState.MainWindow;
            this.IsMouseVisible = true;

            base.Initialize();
        }

        public void SetScreenSize(int width, int height)
        {
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            guiFont = Content.Load<SpriteFont>("GameGUI//GUIText");
            healthFont = Content.Load<SpriteFont>("Monsters//HealthText");

            tileManager = new TileManager(this, Content);
            menuManager = new MenuManager(this, Content);
            mapManager = new MapManager(this, Content);


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        KeyboardState prevState;
        MouseState prevMouseState;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();



            if (currentState == GameState.GameWindow)
            {
                GetMapManager().Update(gameTime);
            }
            else if (currentState == GameState.MainWindow)
            {
                //GetMenuManager().Update(gameTime);
            }

            if (currentState == GameState.MainWindow)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    GetMenuManager().RemoveMenu();
                }
            }
            else if (currentState == GameState.GameWindow)
            {
                if (Keyboard.GetState().GetPressedKeys().Contains(Keys.Escape) && prevState != null && !prevState.IsKeyDown(Keys.Escape))
                {
                    GetMapManager().HandleEscape();
                }

                if (Keyboard.GetState().GetPressedKeys().Contains(Keys.Left))
                {
                    GetMapManager().HandleLeftArrow();
                }
                if (Keyboard.GetState().GetPressedKeys().Contains(Keys.Up))
                {
                    GetMapManager().HandleUpArrow();
                }
                if (Keyboard.GetState().GetPressedKeys().Contains(Keys.Right))
                {
                    GetMapManager().HandleRightArrow();
                }
                if (Keyboard.GetState().GetPressedKeys().Contains(Keys.Down))
                {
                    GetMapManager().HandleDownArrow();
                }
            }

            int x = Mouse.GetState().X;
            int y = Mouse.GetState().Y;

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && prevMouseState != null && prevMouseState.LeftButton != ButtonState.Pressed)
            {
                if (currentState == GameState.MainWindow)
                {
                    GetMenuManager().OnClick(x, y);
                }
                else if (currentState == GameState.GameWindow)
                {
                    GetMapManager().OnClick(x, y);
                }
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed && prevMouseState != null && prevMouseState.LeftButton != ButtonState.Pressed)
            {
                if (currentState == GameState.MainWindow)
                {
                    GetMenuManager().OnRightClick(x, y);
                }
                else if (currentState == GameState.GameWindow)
                {
                    GetMapManager().OnRightClick(x, y);
                }
            }
            // TODO: Add your update logic here

            prevState = Keyboard.GetState();
            prevMouseState = Mouse.GetState();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            if (currentState == GameState.GameWindow)
            {
                GetMapManager().Draw(spriteBatch);
            }
            else if (currentState == GameState.MainWindow)
            {
                GetMenuManager().Draw(spriteBatch);
            }

            base.Draw(gameTime);
        }

        internal void SetGameState(GameState gameState)
        {
            this.currentState = gameState;
            if (gameState == GameState.MainWindow)
            {
                GetMenuManager().SetScreenSize();
            }
            else if (gameState == GameState.GameWindow)
            {
                //GetMapManager().SetScreenSize();
            }
        }
    }
}
