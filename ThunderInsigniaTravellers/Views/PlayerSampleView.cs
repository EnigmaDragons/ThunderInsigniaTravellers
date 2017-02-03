using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.MonoGame;

namespace ThunderInsigniaTravellers.Views
{
    public class PlayerSampleView : IGameView
    {
        private Texture2D _spriteSheet;
        private Rectangle _spriteLoc = new Rectangle(87, 10, 112 - 87, 30);
        private MouseState _prevState = Mouse.GetState();
        private PlayerController _player = new PlayerController(new Vector2());

        public void LoadContent()
        {
            _spriteSheet = new LoadedTexture("Link").Get();
        }

        public void UnloadContent()
        {
            _spriteSheet.Dispose();
        }

        public void Update(GameTime deltaTime)
        {
            var state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Released && _prevState.LeftButton == ButtonState.Pressed)
                _player.MoveTo(new Vector2(state.Position.X, state.Position.Y));
            _player.Update(deltaTime);
            _prevState = state;
        }

        public void Draw(SpriteBatch sprites)
        {
            new ViewBackgroundColor(Color.CornflowerBlue).Draw();
            sprites.Draw(_spriteSheet, _player.Position, _spriteLoc, Color.White);
        }
    }
}
