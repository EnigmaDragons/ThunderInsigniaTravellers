using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.Characters;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.Tiles;
using System.Linq;

namespace ThunderInsigniaTravellers.Map
{
    public class Map : IGameView
    {
        private readonly List<IGameObject>[,] internalMap = new List<IGameObject>[16, 16];

        public Map()
        {
            for (int row = 0; row < 16; row++)
                for (int column = 0; column < 16; column++) 
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
            for (int row = 0; row < 16; row++)
                for (int column = 0; column < 16; column++)
                    internalMap[row, column].ForEach(action);
        }

        public Character GetOptionalCharacter(Tile location)
        {
            return internalMap[location.X, location.Y].OfType<Character>().FirstOrDefault();
        }
    }
}
