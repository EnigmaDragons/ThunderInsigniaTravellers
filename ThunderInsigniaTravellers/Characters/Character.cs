using Microsoft.Xna.Framework;
using ThunderInsigniaTravellers.Engine;

namespace ThunderInsigniaTravellers.Characters
{
    public interface Character : IGameObject
    {
        void SetPosition(Vector2 position);
    }
}
