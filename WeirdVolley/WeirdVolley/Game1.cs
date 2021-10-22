using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WeirdVolley.Models;

namespace WeirdVolley
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game Objects
        private Sprite _net;
        private Paddle _paddle1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Game Object           
            
            Texture2D defaultTexture = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            defaultTexture.SetData(new Color[] { Color.White });

            // net
            this._net = new Sprite(
                defaultTexture,
                new Rectangle(
                    _graphics.PreferredBackBufferWidth / 2 - 5,
                    _graphics.PreferredBackBufferHeight / 2,
                    10,
                    _graphics.PreferredBackBufferHeight / 2
                    )
                );

            this._paddle1 = new Paddle(
                new Sprite(
                    defaultTexture, 
                    new Rectangle(0,0, 10, 5)),
                new Input(
                     // unfinished
                    )
                );

            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            _spriteBatch.Begin();

            this._net.Draw(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
