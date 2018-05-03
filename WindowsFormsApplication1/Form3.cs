using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
          
            this.FormClosed += closeF3;

            button1.Text = "Изменение шрифта на форме 2";
            button1.Click += EditFont;

            button2.Text = "Отобразжение элементов на форме 2";
            button2.Click += clickEnableF2;

            button3.Text = "Видимость элементов на форме 2";
            button3.Click += clickVisibleF2;
        }

        public void clickEnableF2(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<Form2>().Single().Enabled == true)
                {
                    Application.OpenForms.OfType<Form2>().Single().Enabled = false;
                }
                else
                {
                    Application.OpenForms.OfType<Form2>().Single().Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Формы 2 не открыта");
            }
        }

        public void clickVisibleF2(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<Form2>().Single().Visible == true)
                {
                    Application.OpenForms.OfType<Form2>().Single().Visible = false;
                }
                else
                {
                    Application.OpenForms.OfType<Form2>().Single().Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Формы 2 не открыта");
            }
        }

        public void closeF3(object sender, FormClosedEventArgs e)
        {
            var form2 = Application.OpenForms.OfType<Form2>().Single();
            form2.boolF3 = false;
        }

        public void EditFont(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<Form2>().Single().Font.Name.Equals("Microsoft Sans Serif"))
                {
                    Application.OpenForms.OfType<Form2>().Single().Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
                else
                {
                    Application.OpenForms.OfType<Form2>().Single().Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
            catch(Exception)
            {
                MessageBox.Show(this, "Формы 2 не открыта");
            }
        }
    }
}
