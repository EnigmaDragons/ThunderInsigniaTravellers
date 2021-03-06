﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public GraphicsDevice Graphics => gameInstance.GraphicsDevice;
    }
}
