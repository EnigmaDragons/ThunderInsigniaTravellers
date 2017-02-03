using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.Characters;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.Tiles;
using System.Linq;
using ThunderInsigniaTravellers.MonoGame;
using ThunderInsigniaTravellers.Player;

namespace ThunderInsigniaTravellers.Map
{
    public class Map : IGameView
    {
        private readonly List<IGameObject>[,] internalMap = new List<IGameObject>[16, 16];

        public Map()
        {
            for (int row = 0; row < 15; row++)
                for (int column = 0; column < 15; column++) 
                    internalMap[row, column] = new List<IGameObject> { new Grass(row, column) };
        }

        public void Move(IGameObject obj, Tile currentLoc, Tile newLoc)
        {
            Remove(obj, currentLoc);
            Put(obj, newLoc);
        }

        public void Put(IGameObject obj, Tile loc)
        {
            if (obj is Character)
                ((Character)obj).SetPosition(loc);
            internalMap[loc.X, loc.Y].Add(obj);
        }

        public void Remove(IGameObject obj, Tile loc)
        {
            internalMap[loc.X, loc.Y].Remove(obj);
        }

        public void LoadContent()
        {
            ForEach(x => x.LoadContent());
        }

        public void UnloadContent()
        {
            ForEach(x => x.UnloadContent());
        }

        public void Update(GameTime deltaTime)
        {
            ForEach(x => x.Update(deltaTime));
        }

        public void Draw(SpriteBatch sprites)
        {
            ForEach(x => x.Draw(sprites));
        }

        private void ForEach(Action<IGameObject> action)
        {
            for (int row = 0; row < 15; row++)
                for (int column = 0; column < 15; column++)
                    internalMap[row, column].ForEach(action);
        }

        public Character GetOptionalCharacter(Tile location)
        {
            try
            {
                if (location.X > 0 && location.X < 16 && location.Y > 0 && location.Y < 16)
                    return internalMap[location.X, location.Y].OfType<Character>().FirstOrDefault();
            }
            finally { }
            return null;
        }

        public static Map Create()
        {
            var map = new Map();
            map.Put(new Gaius(), new Tile(7, 12));
            map.Put(new Gregor(), new Tile(8, 13));
            map.Put(new PegasusEnemy(), new Tile(6, 13));
            map.Put(new ArcherEnemy(), new Tile(7, 14));
            return map;
        }
    }
}
