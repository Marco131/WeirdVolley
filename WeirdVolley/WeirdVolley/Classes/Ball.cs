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
        // -- ATTRIBUTS --
        public Sprite sprite;

        // Moving
        private float yForce = 0.0125f;
        private float xForce = 0.0125f;
        public Vector2 acc;
        public Vector2 vel;


        // -- CTOR --
        public Ball(Sprite sprite)
        {
            this.sprite = sprite;
        }


        // -- METHODS --
        /// <summary>
        /// Updates the ball
        /// </summary>
        /// <param name="gametime"></param>
        public void Update(GameTime gametime)
        {
            // apply forces
            this.applyForce(new Vector2(0, this.yForce * (float)gametime.ElapsedGameTime.TotalMilliseconds)); // gravity
            this.applyForce(new Vector2(this.xForce * (float)gametime.ElapsedGameTime.TotalMilliseconds, 0)); // side force

            this.vel += this.acc;
            this.sprite.rectangle.X += (int)this.vel.X;
            this.sprite.rectangle.Y += (int)this.vel.Y;

            this.acc = Vector2.Zero;

            this.Outside();
        }

        /// <summary>
        /// adds force to the object acceleration
        /// </summary>
        /// <param name="force"></param>
        private void applyForce(Vector2 force)
        {
            this.acc += force;
        }

        /// <summary>
        /// outside the screen collisions
        /// </summary>
        public void Outside()
        {
            // down
            if (this.sprite.rectangle.Bottom > Game1.windowHeight)
            {
                this.sprite.rectangle.Y = Game1.windowHeight - this.sprite.rectangle.Height / 2;
                this.vel.Y *= -1;
            }

            // left
            if (this.sprite.rectangle.Right < 0)
            {
                // executes twice when toching wall !!!
                this.sprite.rectangle.X = this.sprite.rectangle.Width / 2;
                this.xForce *= -1;
            }

            // right
            if (this.sprite.rectangle.Left > Game1.windowWidth)
            {
                // executes twice when toching wall !!!
                this.sprite.rectangle.X = Game1.windowWidth - this.sprite.rectangle.Width/2;
                this.xForce *= -1;
            }
        }
    }
}