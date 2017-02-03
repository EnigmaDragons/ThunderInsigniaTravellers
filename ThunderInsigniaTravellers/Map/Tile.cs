
namespace ThunderInsigniaTravellers.Map
{
    public class Tile
    {
        public int X { get; }
        public int Y { get; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Tile Plus(int x, int y)
        {
            return new Tile(X + x, Y + y);
        }
    }
}
