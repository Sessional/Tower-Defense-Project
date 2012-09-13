using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefenseGame.Tiles;
using System.IO;
using TowerDefenseGame.Maps;

namespace TowerDefenseGame.Content
{
    public class TextMapReader
    {
        public static string MAP_DIRECTORY = "Content//Maps//";

        private string mapName;
        private string mapPath;
        private GameMap masterMap;

        private List<string> lines = new List<string>();

        private int mapWidth;
        private int mapHeight;

        private GameTile[][] gameTiles;

        public TextMapReader(GameMap masterMap, string mapName)
        {
            this.masterMap = masterMap;
            this.mapName = mapName;
            this.mapPath = MAP_DIRECTORY + mapName + ".txt";
            ReadMap();
            ParseData();
        }

        public void ReadMap()
        {
            StreamReader fileReader = new StreamReader(mapPath);
            while (fileReader.EndOfStream == false)
            {
                string line = fileReader.ReadLine();
                if (line[0].ToString() == "<")
                {
                    line = line.Substring(1, line.Length - 2);
                    string[] content = line.Split("=".ToCharArray());
                    masterMap.SetTileSet(content[1]);
                }
                else
                {
                    lines.Add(line);
                }
            }
        }

        public void ParseData()
        {
            this.mapWidth = lines[0].Length;
            this.mapHeight = lines.Count;
            gameTiles = new GameTile[mapWidth][];
            for (int x = 0; x < this.mapWidth; x++)
            {
                gameTiles[x] = new GameTile[mapHeight];
            }
            for (int y = 0; y < this.mapHeight; y++)
            {
                for (int x = 0; x < this.mapWidth; x++)
                {
                    char curTile = lines[y][x];
                    if (curTile.ToString() == "#")
                    {
                        gameTiles[x][y] = new GameTile(this.masterMap, x, y, true, masterMap.getRootGame().GetTileManager().getTileSet("standard").GetTexture("grass"));
                    }
                    else if (curTile.ToString() == "=")
                    {
                        gameTiles[x][y] = new GameTile(this.masterMap, x, y, false, masterMap.getRootGame().GetTileManager().getTileSet("standard").GetTexture("path"));
                    }
                    else if (curTile.ToString() == "f")
                    {
                        gameTiles[x][y] = new GameTile(this.masterMap, x, y, false, masterMap.getRootGame().GetTileManager().getTileSet("standard").GetTexture("finish"));
                    }
                    else if (curTile.ToString() == "s")
                    {
                        gameTiles[x][y] = new GameTile(this.masterMap, x, y, false, masterMap.getRootGame().GetTileManager().getTileSet("standard").GetTexture("start"));
                    }
                }
            }
        }

        public GameTile[][] getTiles()
        {
            return gameTiles;
        }
    }
}
