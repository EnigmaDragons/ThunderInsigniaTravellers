using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThunderInsigniaTravellers.Engine;
using ThunderInsigniaTravellers.MonoGame;

namespace ThunderInsigniaTravellers
{
    public class MainGame : Game, INavigator
    {
        private SpriteBatch _sprites;
        private IGameView _currentView;
        private Texture2D _spriteSheet;
        private Rectangle _spriteLoc = new Rectangle(87, 10, 112 - 87, 30);
        private MouseState _prevState = Mouse.GetState();
        private PlayerController _player = new PlayerController(new Vector2());

        public MainGame()
        {
            new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _sprites = new SpriteBatch(GraphicsDevice);
            _spriteSheet = new LoadedTexture(this, "Link").Get();
            _currentView?.LoadContent();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
            _currentView?.UnloadContent();
            _spriteSheet.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Released && _prevState.LeftButton == ButtonState.Pressed)
                _player.MoveTo(new Vector2(state.Position.X, state.Position.Y));
            _player.Update(gameTime);
            _currentView?.Update(gameTime);
            _prevState = state;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _sprites.Begin();
            _currentView?.Draw(_sprites);
            _sprites.Draw(_spriteSheet, _player.Position, _spriteLoc, Color.White);
            _sprites.End();
            base.Draw(gameTime);
        }

        public void NavigateTo(string viewName)
        {
            throw new System.Exception("No known views");
        }

        private void NavigateTo(IGameView view)
        {
            view.LoadContent();
            _currentView?.UnloadContent();
            _currentView = view;
        }
    }
}
