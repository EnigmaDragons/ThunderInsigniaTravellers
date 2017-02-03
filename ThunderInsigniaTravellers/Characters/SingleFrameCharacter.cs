using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.Map;
using ThunderInsigniaTravellers.MonoGame;

namespace ThunderInsigniaTravellers.Characters
{
    public abstract class SingleFrameCharacter : Character
    {
        private readonly string _spriteName;

        private Texture2D _sprite;
        private Vector2 _position;

        protected SingleFrameCharacter(string spriteName)
        {
            _spriteName = spriteName;
            _position = new Vector2(0, 0);
        }

        public void LoadContent()
        {
            _sprite = new LoadedTexture(_spriteName).Get();
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
            sprites.Draw(_sprite, _position);
        }

        public void SetPosition(Tile tile)
        {
            var rect = new ScreenPosition(tile.X, tile.Y);
            _position = new Vector2(rect.Get().X, rect.Get().Y);
        }
    }
}
