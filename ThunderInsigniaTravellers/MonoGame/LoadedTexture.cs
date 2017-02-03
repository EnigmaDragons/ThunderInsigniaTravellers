using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThunderInsigniaTravellers.MonoGame
{
    public class LoadedTexture
    {
        private readonly Game game;
        private readonly string textureName;
        private const string ImageFolder = "Images\\";

        public LoadedTexture(Game game, string textureName)
        {
            this.game = game;
            this.textureName = textureName;
        }

        public Texture2D Get()
        {
            return game.Content.Load<Texture2D>(ImageFolder + textureName);
        }
    }
}
