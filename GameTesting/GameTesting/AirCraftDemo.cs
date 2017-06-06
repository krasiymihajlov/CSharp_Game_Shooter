#define My_Debug     

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTesting
{
    public partial class AirCraftDemo : Form
    {

#if My_Debug
        private int _cursX = 0;
        private int _cursY = 0;
#endif

        private Asteroid _asteroid;

        public AirCraftDemo()  //AirCraft constructor
        {
            InitializeComponent();

            _asteroid = new Asteroid() {Left = 300, Top = 100};         
        }

        private void timerGameLoop_Tick(object sender, EventArgs e) // timer event
        {
            
        }

        protected override void OnPaint(PaintEventArgs e) // OnPaint event
        {
            Graphics divaceContext = e.Graphics;

#if My_Debug // Опцията My_Debug e за наше улеснение, за да виждаме кординатите по приложението.

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis; // формат на текста(дали е центриран, с отстояние и т.н)
            Font _font = new Font("Stencil", 12, FontStyle.Regular);                        // задаваме фонта
            TextRenderer.DrawText(divaceContext, "X=" + _cursX + ":" + "Y=" + _cursY, _font, 
                new Rectangle(0, 0, 120, 20), SystemColors.ControlLight, flags); // рендерираме тест с координати X и У, поставяме го в правоъгълник с координати и му задаваме цвят на текста и формат.
# endif

            _asteroid.DrawImage(divaceContext);

            base.OnPaint(e);
        }

        private void AirCraftDemo_MouseMove(object sender, MouseEventArgs e)
        {
#if My_Debug
            _cursX = e.X;   // задаваме координати на мишката по Х и У
            _cursY = e.Y;
#endif
            this.Refresh(); // рефрешваме графиката 
        }
    }
}
