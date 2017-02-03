using Microsoft.Xna.Framework.Graphics;

namespace ThunderInsigniaTravellers.Engine
{
    public class GraphicsDeviceInstance
    {
        public GraphicsDevice Get()
        {
            return new GameInstance().Graphics;
        }
    }
}
