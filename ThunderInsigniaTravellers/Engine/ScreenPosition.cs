using Microsoft.Xna.Framework;
using ThunderInsigniaTravellers.Map;

namespace ThunderInsigniaTravellers.Engine
{
    public class ScreenPosition
    {
        private int x;
        private int y;

        public ScreenPosition(Tile tile) 
            : this(tile.X, tile.Y) { }

        public ScreenPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Rectangle Get()
        {
            return new Rectangle(x * 32, y * 32, 32, 32);
        }
    }
}
