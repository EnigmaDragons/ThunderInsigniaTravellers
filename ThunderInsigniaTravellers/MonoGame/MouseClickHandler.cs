using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThunderInsigniaTravellers.Map;

namespace ThunderInsigniaTravellers.MonoGame
{
    public class MouseClickHandler
    {
        private MouseState prevState;
        private Action<Tile> onClick;

        public MouseClickHandler(Action<Tile> onClick)
        {
            prevState = Mouse.GetState();
            this.onClick = onClick;
        }

        public void Update(GameTime deltaTime)
        {
            var state = Mouse.GetState();

            if (state.LeftButton == ButtonState.Released && prevState.LeftButton == ButtonState.Pressed)
            {
                var p = state.Position;
                onClick(new Tile(p.X / 32, p.Y / 32));
            }

            prevState = state;
        }
    }
}