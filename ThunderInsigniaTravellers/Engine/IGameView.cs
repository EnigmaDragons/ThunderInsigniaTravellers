using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThunderInsigniaTravellers.Engine
{
    public interface IGameView
    {
        void LoadContent();
        void UnloadContent();
        void Update(GameTime deltaTime);
        void Draw(SpriteBatch sprites);
    }
}
