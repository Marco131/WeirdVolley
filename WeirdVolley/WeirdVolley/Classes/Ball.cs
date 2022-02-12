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
        private Random rnd = new Random();

        // Moving
        private float yForce = 0.0125f;
        private float xForce = 9f;
        public Vector2 acc;
        public Vector2 vel;



        // -- CTOR --
        public Ball(Sprite sprite)
        {
            this.sprite = sprite;

            // random side initial acceleration
            this.acc = new Vector2(
                rnd.Next(0,2) > 0? this.xForce : -this.xForce,
                0
                );
        }



        // -- METHODS --
        /// <summary>
        /// Updates the ball
        /// </summary>
        /// <param name="gametime"></param>
        public void Update(GameTime gametime, Sprite net)
        {
            // apply forces
            this.applyForce(new Vector2(0, this.yForce * (float)gametime.ElapsedGameTime.TotalMilliseconds)); // gravity          

            this.vel += this.acc;
            this.sprite.rectangle.X += (int)this.vel.X;
            this.sprite.rectangle.Y += (int)this.vel.Y;

            this.acc = Vector2.Zero;

            this.Collision(net);
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
        /// wall and net collisions
        /// </summary>
        public void Collision(Sprite net)
        {
            // Wall
            // down
            if (this.sprite.rectangle.Bottom > Game1.windowHeight)
            {
                this.sprite.rectangle.Y = Game1.windowHeight - this.sprite.rectangle.Height / 2;
                this.vel.Y *= -1;
            }

            // left
            if (this.sprite.rectangle.Left < 0)
            {
                this.sprite.rectangle.X = this.sprite.rectangle.Width / 2;
                this.vel.X *= -1;
            }

            // right
            if (this.sprite.rectangle.Center.X > Game1.windowWidth)
            {
                this.sprite.rectangle.X = Game1.windowWidth - this.sprite.rectangle.Width/2;
                this.vel.X *= -1;
            }

            // Net
            // left
            if (this.sprite.rectangle.Right > net.rectangle.X &&
                this.sprite.rectangle.Right < net.rectangle.X + 5 &&
                this.sprite.rectangle.Y + this.sprite.rectangle.Height / 2 > Game1.windowHeight / 2 &&
                this.vel.X > 0)
            {
                this.sprite.rectangle.X = net.rectangle.X - this.sprite.rectangle.Width / 2;
                this.vel.X *= -1;
            }

            // right
            if(this.sprite.rectangle.Left < net.rectangle.X + 10 &&
                this.sprite.rectangle.Left > net.rectangle.X - 5 &&
                this.sprite.rectangle.Y + this.sprite.rectangle.Height / 2 > Game1.windowHeight / 2 &&
                this.vel.X < 0)
            {
                this.sprite.rectangle.X = net.rectangle.X + this.sprite.rectangle.Width / 2;
                this.vel.X *= -1;
            }
        }
    }
}