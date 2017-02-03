using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.Map;

namespace ThunderInsigniaTravellers.Characters
{
    public interface Character : IGameObject
    {
        void SetPosition(Tile position);
    }
}
