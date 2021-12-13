using System;
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

        public Texture2D pointTexture;

        // Game Objects
        private Sprite _net;
        private Paddle _paddle1;
        private Ball _ball;

        public int windowWidth
        {
            get { return _graphics.PreferredBackBufferWidth;}
        }
        private int windowHeight
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

            this._paddle1 = new Paddle(
                new Sprite(
                    defaultTexture,
                    new Rectangle(windowWidth/4, windowHeight - 50, 125, 10)),
                new Input
                {
                    moveLeft = Keys.A,
                    moveRight = Keys.D,
                    rotateLeft = Keys.W,
                    rotateRight = Keys.S
                }
            );

            this._ball = new Ball(
                new Sprite(
                    defaultTexture,
                    new Rectangle(
                        windowWidth / 2 - 50,
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

            this._paddle1.Update(gameTime);
            this._ball.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            _spriteBatch.Begin();

            this._net.Draw(_spriteBatch);
            this._paddle1.Draw(_spriteBatch, pointTexture);
            this._ball.sprite.Draw(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }

        private static Texture2D _texture;
        private static Texture2D GetTexture(SpriteBatch spriteBatch)
        {
            if (_texture == null)
            {
                _texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                _texture.SetData(new[] { Color.White });
            }

            return _texture;
        }

        public static void DrawLine(SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            DrawLine(spriteBatch, point1, distance, angle, color, thickness);
        }

        public static void DrawLine(SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1f)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length, thickness);
            spriteBatch.Draw(GetTexture(spriteBatch), point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        }
    }
}
