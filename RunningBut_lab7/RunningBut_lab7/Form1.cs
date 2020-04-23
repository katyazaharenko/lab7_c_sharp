using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningBut_lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Предыдущее положение мыши.
        /// </summary>
        Point lastMousePosition;
        /// <summary>
        /// Предыдущий размер окна.
        /// </summary>
        Size lastClientSize;
        /// <summary>
        /// Разница между новой и старой шириной окна.
        /// </summary>
        int diffX =0;
        /// <summary>
        /// Разница между новой и старой высотой окна.
        /// </summary>
        int diffY =0;
        /// <summary>
        /// Координаты мыши.
        /// </summary>
        Point point1;
        /// <summary>
        /// Смещение кнопки от края формы.
        /// </summary>
        int h = 20;
        
        /// <summary>
        /// Обработчик события нажатия на кнопку. Вызываем Message Box.
        /// </summary>
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Поздравляем! Вы смогли нажать на кнопку!", "Убегающая кнопка");
            button1.Top = (ClientSize.Height - button1.Height) / 2;
            button1.Left = (ClientSize.Width - button1.Width) / 2;
        }
        /// <summary>
        /// Обработчик события загрузки формы.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            lastClientSize = ClientSize;
            button1.Top = (ClientSize.Height - button1.Height) / 2;
            button1.Left = (ClientSize.Width-button1.Width)/2;
        }
        /// <summary>
        /// Обработчик события движения мыши. Перемещаем кнопку согласно направлению мыши.
        /// </summary>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            point1 = new Point(e.X, e.Y);
            if (lastMousePosition == point1)
            {
                return;
            }
            int x = point1.X - button1.Location.X;
            int y = point1.Y - button1.Location.Y;
            // Двигаться никуда не нужно
            if (x == 0 && y == 0) return;
            // Длина вектора
            double k = Math.Sqrt(x * x + y * y);
            int x2 = lastMousePosition.X - button1.Location.X;
            int y2 = lastMousePosition.Y - button1.Location.Y;
            double k2 = Math.Sqrt(x2 * x2 + y2 * y2);
            // Если мышка отдаляется от кнопки, но пропускаем движение   
            if (k2 < k)
            {
                return;
            }
            double r = SystemInformation.MouseSpeed/ 4;
            int dx = (int)(r * x / k);
            int dy = (int)(r * y / k);
            int newx = button1.Location.X - dx;
            int newy = button1.Location.Y - dy;
            int n;
            // Если движение мыши приводит к достижению кнопкой границ формы, отталкиваем кнопку на значение h от края
            if (button1.Location.X - dx < 0 || button1.Location.X - dx > ClientSize.Width - button1.Width)
            {
                n = dx < 0 ? -h : +h;
                newx = button1.Location.X + dx + n;
            }
            if (button1.Location.Y - dy < 0 || button1.Location.Y - dy > ClientSize.Height - button1.Height)
            {
                n = dy < 0 ? -h : +h;
                newy = button1.Location.Y + dy + n;
            }
            button1.Location = new Point(newx, newy);
            lastMousePosition = point1;
          
        }
        /// <summary>
        /// Обработчик события изменения размера формы. Корректируем положение кнопки.
        /// </summary>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            diffX = lastClientSize.Width - ClientSize.Width;
            diffY = lastClientSize.Height - ClientSize.Height;
            lastClientSize = ClientSize;
            if (diffX > 0 ||diffY> 0)
            {
                if (button1.Right > ClientSize.Width)
                {
                    button1.Left = ClientSize.Width - button1.Width-h;
                }

                if (button1.Left < 0)
                {
                    button1.Left = h;
                }
                if (button1.Top < 0)
                {
                    button1.Top = h;
                }

                if (button1.Bottom > ClientSize.Height)
                {
                    button1.Top = ClientSize.Height - button1.Height-h ;
                }
            }
            
        }
    }
}
