using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.Characters;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.MonoGame;

namespace ThunderInsigniaTravellers.Views
{
    public sealed class CharacterSampleView : IGameView
    {
        private readonly Character _character;

        public CharacterSampleView()
        {
            _character = new Highlighted(new Gaius(), new EnemyHighlightColor().Get());
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
            new ViewBackgroundColor(Color.Black).Draw();
            _character.Draw(sprites);
        }
    }
}
