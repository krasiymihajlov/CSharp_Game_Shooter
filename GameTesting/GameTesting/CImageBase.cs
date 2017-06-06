using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTesting
{
    class CImageBase : IDisposable // интерфейс помагащ да почистим обектите които създаваме в приложението (Dispose)
    {
        bool disposed = false;

        Bitmap _bitmap;
        private int X;                 // top and left coordinates on _bitmap
        private int Y;

        public int Left { get { return X; } set { X = value; } }
        public int Top { get { return Y; } set { Y = value; } }

        public CImageBase(Bitmap _resource)                 // конструктор на класа
        {
            _bitmap = new Bitmap(_resource);               // заделя памет за картинката, която ще убиваме
        }

        public void DrawImage(Graphics graphics)            // метода изважда картинката в приложението.
        {
            graphics.DrawImage(_bitmap, X, Y);
        }

        public void Dispose()    // public метод, който извиква метода под него.
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                _bitmap.Dispose();
            }

            disposed = true;
        }
    }
}
