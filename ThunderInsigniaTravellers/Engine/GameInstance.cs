using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ThunderInsigniaTravellers.Engine
{
    public class GameInstance : IGame
    {
        private static Game gameInstance;

        public void SetGame(Game game)
        {
            gameInstance = game;
        }

        public T Load<T>(string resourceName)
        {
            return gameInstance.Content.Load<T>(resourceName);
        }
    }
}
