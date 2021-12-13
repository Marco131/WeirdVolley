using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WeirdVolley.Models;

namespace WeirdVolley
{
    class Paddle
    {
        // Attributs
        public Sprite sprite;
        private Input _input;
        private int moveSpeed = 7;
        private float rotateSpeed = 0.08f;

        private List<Vector2> vertices = new List<Vector2>();


        // Ctor
        public Paddle(Sprite sprite, Input controls)
        {
            this.sprite = sprite;
            this._input = controls;
        }

        // Methods
        /// <summary>
        /// Updates the paddle (Main)
        /// </summary>
        /// <param name="gametime"></param>
        public void Update(GameTime gametime)
        {
            Controls();

            updateVertices();
        }

        /// <summary>
        /// Draws the paddle with a sprite batch (Main)
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="circle"></param>
        public void Draw(SpriteBatch spriteBatch, Texture2D circle)
        {
            sprite.Draw(spriteBatch);

            foreach (Vector2 vertice in vertices)
            {
                spriteBatch.Draw(circle, vertice, null, Color.Red, 0f, new Vector2(circle.Width/2, circle.Height/2), 1f,SpriteEffects.None, 0f);
            }

            spriteBatch.Draw(circle, sprite.rectangle.Location.ToVector2(), null, Color.Red, 0f, new Vector2(circle.Width/2, circle.Height/2), 1f,SpriteEffects.None, 0f);
        }



        /// <summary>
        /// Controls the input, the mouvement and the rotation
        /// </summary>
        private void Controls() {
            KeyboardState kbdState = Keyboard.GetState();

            if (kbdState.IsKeyDown(this._input.moveLeft))
            {
                sprite.rectangle.X -= moveSpeed;
            }

            if (kbdState.IsKeyDown(this._input.moveRight))
            {
                sprite.rectangle.X += moveSpeed;
            }

            if (kbdState.IsKeyDown(this._input.rotateLeft))
            {
                sprite.rotation -= rotateSpeed;
            }

            if (kbdState.IsKeyDown(this._input.rotateRight))
            {
                sprite.rotation += rotateSpeed;
            }
        }

        /// <summary>
        /// Finds a point in a circle 
        /// </summary>
        /// <param name="center">initial point</param>
        /// <param name="angle">angle of rotation</param>
        /// <param name="offset">center</param>
        /// <returns></returns>
        private Vector2 findPointInCircle(Vector2 center, float angle, Vector2 offset)
        {
            return new Vector2(
                (center.X - offset.X) * (float)Math.Cos(angle) - (center.Y- offset.Y) * (float)Math.Sin(angle) + offset.X,
                (center.X - offset.X) * (float)Math.Sin(angle) + (center.Y - offset.Y) * (float)Math.Cos(angle) + offset.Y
            );
        }

        /// <summary>
        /// Update the vertices position
        /// </summary>
        private void updateVertices()
        {
            Vector2 textureSize = sprite.rectangle.Size.ToVector2() / 2;

            vertices.Clear();
            vertices.Add(findPointInCircle(
                sprite.rectangle.Center.ToVector2() - sprite.rectangle.Size.ToVector2()
                , sprite.rotation, sprite.rectangle.Location.ToVector2()));

            vertices.Add(findPointInCircle(
                new Vector2(sprite.rectangle.Center.X, sprite.rectangle.Center.Y - sprite.rectangle.Size.Y)
                , sprite.rotation, sprite.rectangle.Location.ToVector2()));

            vertices.Add(findPointInCircle(
                sprite.rectangle.Center.ToVector2()
                , sprite.rotation, sprite.rectangle.Location.ToVector2()));

            vertices.Add(findPointInCircle(
                new Vector2(sprite.rectangle.Center.X - sprite.rectangle.Size.X, sprite.rectangle.Center.Y)
                , sprite.rotation, sprite.rectangle.Location.ToVector2()));
        }

    }
}
