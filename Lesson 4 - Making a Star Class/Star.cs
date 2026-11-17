using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4___Making_a_Star_Class
{



    public class Star
    {
        private Rectangle _location;
        private Vector2 _speed;
        private Texture2D _texture;

        public Star(Texture2D texture, Rectangle location, Vector2 speed)
        {
            _location = location;
            _texture = texture;
            _speed = speed;
        }

        public void Update(Rectangle window) 
        {
            _location.Offset(_speed);

            if (_location.Right < 0)
                _location.X = window.Width;
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

    }






}
