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
        public Sprite _sprite;
        private Input _input;
        private int moveSpeed = 1;
        private int rotateSpeed = 1;

        // Ctor
        public Paddle(Sprite sprite, Input controls)
        {
            this._sprite = sprite;
            this._input = controls;
        }

        // Methods
        /// <summary>
        /// Updates the paddle
        /// </summary>
        /// <param name="gametime"></param>
        public void Update(GameTime gametime)
        {
            Controls();
        }

        /// <summary>
        /// Controls the input, the mouvement and the rotation
        /// </summary>
        private void Controls() {
            KeyboardState kbdState = Keyboard.GetState();

            if (kbdState.IsKeyDown(this._input.moveLeft))
            {
                _sprite.rectangle.X -= moveSpeed;
            }

            if (kbdState.IsKeyDown(this._input.moveRight))
            {
                _sprite.rectangle.X += moveSpeed;
            }

            if (kbdState.IsKeyDown(this._input.rotateLeft))
            {
                _sprite.rotation -= rotateSpeed;
            }

            if (kbdState.IsKeyDown(this._input.rotateRight))
            {
                _sprite.rotation += rotateSpeed;
            }
        }
    }
}
