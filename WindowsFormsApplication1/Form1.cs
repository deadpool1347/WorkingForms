using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Point moveStart;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = new Bitmap(Path.GetDirectoryName(Application.ExecutablePath) + "/pic.png");
            this.TransparencyKey = Color.White;
            this.Height = 960;
            this.Width = 960;
            this.MouseClick += Closeprog;
            this.MouseDown += Frm1MDown;
            this.MouseMove += Frm1MMove;
        }

        /* перемещение формы 1 */
        public void Frm1MDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        public void Frm1MMove(object sender, MouseEventArgs e)
        {
            // если нажата ЛКМ
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + deltaPos.X, this.Location.Y + deltaPos.Y);
            }
        }

        public void Closeprog(object sender, MouseEventArgs e)
        {
            // колесо средней кнопки мыши 
            if (e.Button == MouseButtons.Middle)
            {
                new Form2().Show();
            }

            // ПКМ закрыть
            if (e.Button == MouseButtons.Right)
            {
                this.Close();
            }
        }
    }
}
