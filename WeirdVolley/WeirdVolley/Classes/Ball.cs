using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WeirdVolley.Models;

namespace WeirdVolley
{
    class Ball
    {
        // Attributs
        public Sprite sprite;
        
        public Vector2 direction;
        public float forceGravity = 7.5f;


        // Ctor
        public Ball(Sprite sprite)
        {
            this.sprite = sprite;
        }


        // Methods
        /// <summary>
        /// Updates the paddle
        /// </summary>
        /// <param name="gametime"></param>
        public void Update(GameTime gametime)
        {
            /*this.direction.X = this.forceGravity;

            // move the sprite
            this.sprite.rectangle.X += (int)this.direction.X;
            this.sprite.rectangle.Y += (int)this.direction.Y;*/

            this.Outside();
        }

        public void Outside()
        {
            // down
            if (this.sprite.rectangle.Top > 600)
            {
                System.Diagnostics.Debug.WriteLine("");
            }

            // left
            if (this.sprite.rectangle.Right < 0)
            {
                System.Diagnostics.Debug.WriteLine("");
            }

            // right
            if (this.sprite.rectangle.Left > 1000)
            {
                System.Diagnostics.Debug.WriteLine("");
            }
        }
    }
}