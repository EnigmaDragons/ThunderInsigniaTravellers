using Microsoft.Xna.Framework;

namespace ThunderInsigniaTravellers.Engine
{
    public class ScreenPosition
    {
        private int x;
        private int y;

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
