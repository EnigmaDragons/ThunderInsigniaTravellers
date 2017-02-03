using Microsoft.Xna.Framework.Graphics;

namespace ThunderInsigniaTravellers.Engine
{
    public interface IGame
    {
        T Load<T>(string resourceName);
        GraphicsDevice Graphics { get; }
    }
}
