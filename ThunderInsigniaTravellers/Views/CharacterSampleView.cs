using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.Characters;
using ThunderInsigniaTravellers.Engine;

namespace ThunderInsigniaTravellers.Views
{
    public sealed class CharacterSampleView : IGameView
    {
        private readonly Game _game;
        private readonly IGameObject _character;

        public CharacterSampleView(Game game)
        {
            _game = game;
            _character = new Gaius(game);
        }

        public void LoadContent()
        {
            _character.LoadContent();
        }

        public void UnloadContent()
        {
            _character.UnloadContent();
        }

        public void Update(GameTime deltaTime)
        {
            _character.Update(deltaTime);
        }

        public void Draw(SpriteBatch sprites)
        {
            _game.GraphicsDevice.Clear(Color.Black);
            _character.Draw(sprites);
        }
    }
}
