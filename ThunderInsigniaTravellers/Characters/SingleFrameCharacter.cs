using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.MonoGame;

namespace ThunderInsigniaTravellers.Characters
{
    public abstract class SingleFrameCharacter : IGameObject
    {
        private readonly Game _game;
        private readonly string _spriteName;

        private Texture2D _sprite;

        protected SingleFrameCharacter(Game game, string spriteName)
        {
            _game = game;
            _spriteName = spriteName;
        }

        public void LoadContent()
        {
            _sprite = new LoadedTexture(_game, _spriteName).Get();
        }

        public void UnloadContent()
        {
            _sprite?.Dispose();
        }

        public void Update(GameTime deltaTime)
        {
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(_sprite, new Vector2(0, 0));
        }
    }
}
