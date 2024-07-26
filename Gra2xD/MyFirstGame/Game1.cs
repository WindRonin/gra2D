using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyFirstGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _squareTexture;
        private Vector2 _squarePosition;
        private int _squareSpeed = 100;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize the position of the square
            _squarePosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create a 50x50 white texture for the square
            _squareTexture = new Texture2D(GraphicsDevice, 50, 50);
            Color[] data = new Color[50 * 50];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            _squareTexture.SetData(data);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.Left))
                _squarePosition.X -= _squareSpeed * deltaTime;
            if (keyboardState.IsKeyDown(Keys.Right))
                _squarePosition.X += _squareSpeed * deltaTime;
            if (keyboardState.IsKeyDown(Keys.Up))
                _squarePosition.Y -= _squareSpeed * deltaTime;
            if (keyboardState.IsKeyDown(Keys.Down))
                _squarePosition.Y += _squareSpeed * deltaTime;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_squareTexture, _squarePosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
