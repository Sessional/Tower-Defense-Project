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
using TowerDefenseGame.Menu;
using TowerDefenseGame.Menus;

namespace TowerDefenseGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameState currentState;
        GameMap currentMap;
        GameMenu currentMenu;

        public Texture2D menuTexture;
        public Texture2D singlePlayerButton;

        TileManager tileManager;
        MenuManager menuManager;
        MapManager mapManager;

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

        public Game1()
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

        public void setScreenSize(int width, int height)
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
            }

            int x = Mouse.GetState().X;
            int y = Mouse.GetState().Y;

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (currentState == GameState.MainWindow)
                {
                    GetMenuManager().OnClick(x, y);
                }
            }
            // TODO: Add your update logic here

            prevState = Keyboard.GetState();

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

        internal void setGameState(GameState gameState)
        {
            this.currentState = gameState;
        }
    }
}
