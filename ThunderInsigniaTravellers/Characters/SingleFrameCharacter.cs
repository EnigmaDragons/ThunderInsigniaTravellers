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
        private Vector2 position;
        public Vector2 target;

        public float slowingRadius = 25;
        public float maxSpeed = 250;

        protected SingleFrameCharacter(string spriteName)
        {
            _spriteName = spriteName;
            position = new Vector2(0, 0);
            target = position;
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
            var desired = target - position;
            var distance = desired.Length();

            desired.Normalize();
            if (distance < 0.00001f) desired = new Vector2(0, 0);

            if (distance < slowingRadius)
            {
                desired = desired * maxSpeed * (distance / slowingRadius);
            }
            else
            {
                desired = desired * maxSpeed;
            }
            position += desired * (float)deltaTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(_sprite, position);
        }

        public void SetPosition(Tile tile)
        {
            var rect = new ScreenPosition(tile.X, tile.Y);
            target = new Vector2(rect.Get().X, rect.Get().Y);
        }
    }
}
