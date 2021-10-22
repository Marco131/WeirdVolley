using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeirdVolley
{
    class Sprite
    {
        // Attributs
        public Texture2D texture;
        public Rectangle rectangle;
        public float rotation;


        // Ctor
        public Sprite(Texture2D texture, Rectangle rectangle) : this(texture, rectangle, 0f) { }

        public Sprite(Texture2D texture, Rectangle rectangle, float rotation)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.rotation = rotation;
        }


        // Methods
        /// <summary>
        /// Draws the sprite
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, null, Color.White, this.rotation, Vector2.Zero, SpriteEffects.None, 0f);
        }

    }
}
