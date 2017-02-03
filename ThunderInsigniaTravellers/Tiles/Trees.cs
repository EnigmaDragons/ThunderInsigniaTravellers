﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.MonoGame;

namespace ThunderInsigniaTravellers.Tiles
{
    public class Trees : IGameObject
    {
        private Texture2D texture;
        private readonly int x;
        private readonly int y;

        public Trees(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void LoadContent()
        {
            texture = new LoadedTexture("Trees").Get();
        }

        public void UnloadContent()
        {
            texture.Dispose();
        }

        public void Update(GameTime deltaTime)
        {
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(texture, new ScreenPosition(x, y).Get(), Color.White);
        }
    }
}
