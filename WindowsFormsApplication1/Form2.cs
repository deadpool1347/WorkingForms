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
    public partial class Form2 : Form
    {
        public bool boolF3, titleF2 = false;
        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            button1.Text = "Выход";
            button1.Click += closeF2;

            button2.Text = "Изменение цвета на форме 3";
            button2.Click += EditColorF3;

            button3.Text = "Наименование #3";
            button3.Click += EditTextF3;

            button4.Text = "Рамка #3";
            button4.Click += EditBorderF3;

            button5.Text = "Открыть Форму #3";
            button5.Click += OpenF3;

            button6.Text = "Прозрачность #3";
            button6.Click += OpenOpacityF3;

            button7.Text = "Убрать рамку #3";
            button7.Click += TransparencyF3;

            button8.Text = "Убрать форму #3";
            button8.Click += DisF3;

            this.FormClosing += CloseAllProg;
        }

        public void CloseAllProg(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.OpenForms.OfType<Form3>().Single().Close();
            }
            catch (Exception)
            {
                // здесь ничего не выполняем
            }
        }

        public void EditColorF3(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<Form3>().Single().BackColor.Name.Equals("Control"))
                    Application.OpenForms.OfType<Form3>().Single().BackColor = Color.Blue;
                else
                    Application.OpenForms.OfType<Form3>().Single().BackColor = Color.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Формы 3 не открыта");
            }
        }

        public void EditTextF3(object sender, EventArgs e)
        {
            try
            {
                if (!titleF2)
                {
                    Application.OpenForms.OfType<Form3>().Single().Text = "Изменили заголовок формы #3";
                    titleF2 = true;
                }
                else
                {
                    Application.OpenForms.OfType<Form3>().Single().Text = "Форма #3";
                    titleF2 = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Формы 3 не открыта");
            }
        }

        public void EditBorderF3(object sender, EventArgs e)
        {
            try
            {
                var form3 = Application.OpenForms.OfType<Form3>().Single();

                if (form3.FormBorderStyle == FormBorderStyle.Sizable)
                {
                    form3.FormBorderStyle = FormBorderStyle.None;
                }
                else
                {
                    form3.FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Формы 3 не открыта");
            }
        }

        public void OpenOpacityF3(object sender, EventArgs e)
        {
            try
            {
                var form3 = Application.OpenForms.OfType<Form3>().Single();
                
                if (form3.Opacity == 1.0)
                {
                    form3.Opacity = 0.77;
                }
                else
                {
                    form3.Opacity = 1.0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Формы 3 не открыта");
            }
        }

        public void TransparencyF3(object sender, EventArgs e)
        {
            try
            {
                var form3 = Application.OpenForms.OfType<Form3>().Single();
                if (form3 != null)
                {
                    form3.Close();
                    form3.Dispose(); // очищаем все элементы

                    if (form3.TransparencyKey.IsEmpty)
                    {
                        form3.TransparencyKey = BackColor;
                    }
                    else
                        form3.TransparencyKey = Color.Empty;

                    boolF3 = false;
                }
            }
            catch(Exception)
            {
                MessageBox.Show(this, "Формы 3 не открыта");
            }
        }

        public void DisF3(object sender, EventArgs e)
        {
            try
            {
                var form3 = Application.OpenForms.OfType<Form3>().Single();
                if (form3 != null)
                {
                    if (form3.TransparencyKey.IsEmpty)
                    {
                        form3.TransparencyKey = BackColor;
                    }
                    else
                        form3.TransparencyKey = Color.Empty;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Формы 3 не открыта");
            }
        }

        public void OpenF3(object sender, EventArgs e)
        {
            if (!boolF3)
            {
                new Form3().Show();
                boolF3 = true;
            }
        }



        public void closeF2(object sender, EventArgs e)
        {
            Application.OpenForms.OfType<Form2>().Single().Close();
        }
    }
}
