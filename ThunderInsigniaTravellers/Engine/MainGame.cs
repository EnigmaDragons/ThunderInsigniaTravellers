using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThunderInsigniaTravellers.Map;
using ThunderInsigniaTravellers.MonoGame;


namespace ThunderInsigniaTravellers.Engine
{
    public class MainGame : Game, INavigator
    {
        private Texture2D background;
        private SpriteBatch _sprites;
        private IGameView _currentView;

        public MainGame()
        {
            new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            new GameInstance().SetGame(this);
            _currentView = new HighlightedMap(Map.Map.Create());
            base.Initialize();
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _sprites = new SpriteBatch(GraphicsDevice);
            background = new LoadedTexture("Background").Get();
            _currentView?.LoadContent();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
            _currentView?.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _currentView?.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _sprites.Begin();
            _sprites.Draw(background, new Rectangle(0, 0, 32 * 15, 32 * 15), Color.White);
            _currentView?.Draw(_sprites);
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
