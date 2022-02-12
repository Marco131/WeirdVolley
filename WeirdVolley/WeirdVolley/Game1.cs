using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WeirdVolley.Models;

namespace WeirdVolley
{
    public class Game1 : Game
    {
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Texture2D pointTexture;

        // Game Objects
        private Sprite _net;
        private Paddle _paddleLeft;
        private Paddle _paddleRight;
        private Ball _ball;

        public static int windowWidth
        {
            get { return _graphics.PreferredBackBufferWidth;}
        }
        public static int windowHeight
        {
            get { return _graphics.PreferredBackBufferHeight; }
        }

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

            pointTexture = Content.Load<Texture2D>("circle");

            #region Game Object           

            Texture2D defaultTexture = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            defaultTexture.SetData(new Color[] { Color.White });

            // net
            this._net = new Sprite(
                defaultTexture,
                new Rectangle(
                    windowWidth / 2 - 5,
                    windowHeight - windowHeight / 4,
                    10,
                    windowHeight / 2
                    )
                );

            this._paddleLeft = new Paddle(
                new Sprite(
                    defaultTexture,
                    new Rectangle(0, windowHeight - 50, 125, 10)),
                new Input
                {
                    moveLeft = Keys.A,
                    moveRight = Keys.D,
                    rotateLeft = Keys.W,
                    rotateRight = Keys.S
                },
                true
            );

            this._paddleRight = new Paddle(
                new Sprite(
                    defaultTexture,
                    new Rectangle(windowWidth, windowHeight - 50, 125, 10)),
                new Input
                {
                    moveLeft = Keys.Left,
                    moveRight = Keys.Right,
                    rotateLeft = Keys.Up,
                    rotateRight = Keys.Down
                },
                false
            );

            this._ball = new Ball(
                new Sprite(
                    defaultTexture,
                    new Rectangle(
                        windowWidth / 2 - 10,
                        25,
                        20,
                        20
                    )
                )
            );

            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this._paddleLeft.Update(gameTime, _net, windowWidth);
            this._paddleRight.Update(gameTime, _net, windowWidth);

            this._ball.Update(gameTime, this._net);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            _spriteBatch.Begin();

            this._net.Draw(_spriteBatch);
            this._paddleLeft.Draw(_spriteBatch, pointTexture);
            this._paddleRight.Draw(_spriteBatch, pointTexture);
            this._ball.sprite.Draw(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
