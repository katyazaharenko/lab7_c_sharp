using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colors
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Содержит код цвета, определенного положением ползунков.
        /// </summary>
        string color;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик события тика таймера. Каждый тик таймера происходит изменение цвета panel1 в зависимости от положения ползунков.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            
        }
        /// <summary>
        /// Обработчик события изменения цвета panel1. 
        /// При изменении цвета изменяется значение color, которое заносится в буфер обмена, и становится значением для вывода в всплывающем окне.
        /// </summary>
        private void panel1_BackColorChanged(object sender, EventArgs e)
        {
            color = String.Format("#{0:X2}{1:X2}{2:X2}", panel1.BackColor.R, panel1.BackColor.G, panel1.BackColor.B);
            toolTip1.SetToolTip(panel1, color);
            Clipboard.SetText(color);
        }
        /// <summary>
        /// Обработчик события изменения размера формы. 
        /// При изменении размера формы происходит пересчет размера шрифта для label1-label9.
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            int n=12;
           
            if (Height < 300  || Width < 780)
            {
                n = 12;

            }
            if (Height >= 300 && Height <= 600 || Width >= 780 && Width <= 1000)
            {
                n = 14;

            }
            if(Height > 600 || Width > 1000)
            {
                n = 16;
            }
            label1.Font = new Font(Font.FontFamily, n);
            label2.Font = new Font(Font.FontFamily, n);
            label3.Font = new Font(Font.FontFamily, n);
            label4.Font = new Font(Font.FontFamily, n);
            label5.Font = new Font(Font.FontFamily, n);
            label6.Font = new Font(Font.FontFamily, n);
            label7.Font = new Font(Font.FontFamily, n);
            label8.Font = new Font(Font.FontFamily, n);
            label9.Font = new Font(Font.FontFamily, n);
        }
    }
}
