using Microsoft.Xna.Framework;

namespace ThunderInsigniaTravellers.Engine
{
    public class PlayerController
    {
        public Vector2 position;
        public Vector2 target;

        public float slowingRadius = 25;
        public float maxSpeed = 250;

        public PlayerController(Vector2 initialPosition)
        {
            position = initialPosition;
            target = position;
        }

        public void MoveTo(Vector2 location)
        {
            target = location;
        }

        public Vector2 Position => position;

        public void Update(GameTime gameTime)
        {
            var desired = target - position;
            var distance = desired.Length();

            desired.Normalize();
            if (distance < 0.00001f) desired = new Vector2(0, 0);

            if (distance < slowingRadius)
            {
                desired = desired * maxSpeed * (distance / slowingRadius);
            }
            else
            {
                desired = desired * maxSpeed;
            }
            position += desired * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
