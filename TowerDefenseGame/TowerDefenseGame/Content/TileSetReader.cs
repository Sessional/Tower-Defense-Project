using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Tiles;
using System.IO;
using TowerDefenseGame.Maps;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseGame.Content
{
    public class TileSetReader
    {
        public static string TILESET_DIRECTORY = "Content//TileSets//";

        private TileManager masterManager;

        private string path;
        private string name;

        private ContentManager content;

        public TileSetReader(TileManager masterManager, string tilesetName, ContentManager contentManager)
        {
            this.masterManager = masterManager;
            this.content = contentManager;
            name = tilesetName;
            this.path = TILESET_DIRECTORY + tilesetName + ".txt";
            ReadFile();
        }

        private void ReadFile()
        {
            StreamReader tilesetReader = new StreamReader(path);
            TileSet tempTileSet = new TileSet(name);
            while (!tilesetReader.EndOfStream)
            {
                string line = tilesetReader.ReadLine();
                string[] contents = line.Split(":".ToCharArray());
                tempTileSet.AddTile(contents[0], content.Load<Texture2D>(contents[1]));
            }
            this.masterManager.AddTileSet(tempTileSet);
        }
    }
}
