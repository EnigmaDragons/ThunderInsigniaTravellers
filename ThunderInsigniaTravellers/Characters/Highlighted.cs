using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.MonoGame;

namespace ThunderInsigniaTravellers.Characters
{
    public class Highlighted : Character
    {
        private readonly Character _character;
        private readonly Color _color;

        private Texture2D _highlight;
        private Vector2 _position;

        public Highlighted(Character character, Color color)
        {
            _character = character;
            _color = color;
            _position = new Vector2(0, 0);
        }

        public void LoadContent()
        {
            _highlight = new RectangleTexture(32, 32, _color).Create();
            _character.LoadContent();
        }

        public void UnloadContent()
        {
            _highlight?.Dispose();
            _character.UnloadContent();
        }

        public void Update(GameTime deltaTime)
        {
            _character.Update(deltaTime);
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(_highlight, _position);
            _character.Draw(sprites);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
            _character.SetPosition(position);
        }
    }
}
