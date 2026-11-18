using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Random _generator;
        private Color _color;
        

        public Star(Texture2D texture, Rectangle window, Color color)
        {
            _generator = new Random();
            double sizeProbability = _generator.NextDouble();
            int size;
            _texture = texture;

            if (sizeProbability < 0.2)
                size = 4;
            else if (sizeProbability < 0.5)
                size = 3;
            else
                size = 2;

            _location = new Rectangle(_generator.Next(window.Width), _generator.Next(window.Height), size, size);
            _speed = new Vector2(-size, 0);
          
            _color = color;
        }

        public void Update(Rectangle window, KeyboardState keyboardState) 
        {



            if (_location.Right < 0) 
            {
                _location.X = window.Width;
                _location.Y = _generator.Next(window.Height);
            }
              

            if (keyboardState.IsKeyDown(Keys.K))
            {
                _location.Offset(_speed * 5);
            }

            else 
            {
                _location.Offset(_speed);
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(_texture, _location, _color);
        }

    }






}
