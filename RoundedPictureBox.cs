using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatingSystem
{
    public class RoundedPictureBox : PictureBox
    {
        // Приватное поле для хранения радиуса скругления
        private int _cornerRadius = 0;

        // Свойство для задания радиуса скругления
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        // Переопределение метода OnPaint для отрисовки PictureBox с скругленными углами
        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
            this.Region = new Region(graphicsPath);
            base.OnPaint(pe);
        }
    }
}
