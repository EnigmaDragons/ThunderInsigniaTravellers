using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.MonoGame;
using ThunderInsigniaTravellers.Player;

namespace ThunderInsigniaTravellers.Map
{
    public class HighlightedMap : IGameView
    {
        private readonly Map _map;
        private readonly List<Tile> _tiles = new List<Tile>();
        private Texture2D _highlight;
        private MouseClickHandler _mouseHandler;
        private PlayerCommands _commands;

        public HighlightedMap(Map map)
        {
            _commands = new PlayerCommands(this);
            _mouseHandler = new MouseClickHandler(x => _commands.Select(x));
            _map = map;
        }

        public void LoadContent()
        {
            _highlight = new RectangleTexture(32, 32, Color.FromNonPremultiplied(16, 136, 192, 100)).Create();
            _map.LoadContent();
        }

        public void UnloadContent()
        {
            _highlight?.Dispose();
            _map.UnloadContent();
        }

        public void Update(GameTime deltaTime)
        {
            _mouseHandler.Update(deltaTime);
            _map.Update(deltaTime);
        }

        public void Draw(SpriteBatch sprites)
        {
            _map.Draw(sprites);
            _tiles.ForEach(x => sprites.Draw(_highlight, new ScreenPosition(x.X, x.Y).Get(), Color.White));
        }

        public void SetHighlights(List<Tile> tiles)
        {
            _tiles.Clear();
            _tiles.AddRange(tiles);
        }

        public Map GetMap()
        {
            return _map;
        }
    }
}
