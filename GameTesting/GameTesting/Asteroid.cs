using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTesting.Properties;

namespace GameTesting
{
    class Asteroid : CImageBase
    {
        private Rectangle _asteroidHotSpot = new Rectangle();

        public Asteroid() : base (Resources.Asteroid3)   // задаваме пътя на картинката от папката Resources и името и.
        {
            _asteroidHotSpot.X = Left + 20;
            _asteroidHotSpot.Y = Top - 1;
            _asteroidHotSpot.Width = 30;
            _asteroidHotSpot.Height = 40;
        }

        public void Update(int X, int Y)               // Ще се използва при генериране на рандом мишена
        {
            Left = X;
            Top = Y;
            _asteroidHotSpot.X = Left + 20;
            _asteroidHotSpot.Y = Top - 1;
        }

        public bool Hit(int X, int Y)                  // Проверява дали курсора е попаднал във мишената 
        {
            Rectangle c = new Rectangle(X, Y, 1, 1); // Create a cursor rectangle - quick way to check for hit 

            if (_asteroidHotSpot.Contains(c))
            {
                return true;
            }

            return false;  
        }
    }
}
