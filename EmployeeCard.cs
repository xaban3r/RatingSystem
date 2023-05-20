using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatingSystem
{
    internal class EmployeeCard : MaterialCard
    {
        public string Name { get; set; }
        public Image Photo { get; set; }
        public int Rating { get; set; }
        public Employee thisEmployee { get; set; }
        public User mainUser { get; set; }
        public Form ParentForm { get; set; } //     TEST
        public Database db { get; set; }
        // private readonly Color normalColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
        private readonly Color hoverColor = Color.LightGray;
        private readonly Color normalColor = MaterialSkinManager.Instance.ColorScheme.DarkPrimaryColor;
        public EmployeeCard(Employee employee, User user, Database database)
        {
            db = database;
            mainUser = user;
            thisEmployee = employee;
            
            Cursor = Cursors.Hand;
            
            this.Size = new Size(270, 60);
            PictureBox pictureBox1 = new RoundedPictureBox();
            pictureBox1.Location = new Point(2, 0);
            pictureBox1.Size = new Size(50, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(employee.PhotoPath);

            // Создаем Label для имени пользователя
            Label label1 = new Label();
            label1.Location = new Point(60, 12);
            label1.Size = new Size(200, 15);
            label1.Text = employee.Name;

            this.Controls.Add(pictureBox1);
            this.Controls.Add(label1);

            for (int i = 0; i < employee.Rating; i++)
            {
                PictureBox pictureBox2 = new PictureBox();
                pictureBox2.Location = new Point(70 + i * 20, 35);
                pictureBox2.Size = new Size(16, 16);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = Properties.Resources.star;
                pictureBox2.Click += (sender, e) =>
                {
                    OpenNewForm(employee, user);
                };
                this.Controls.Add(pictureBox2);
            }

            pictureBox1.Click += (sender, e) =>
            {
                OpenNewForm(employee, user);
            };

            label1.Click += (sender, e) =>
            {
                OpenNewForm(employee, user);
            };


            // Добавляем обработчик события клика на карточку
            this.Click += EmployeeCard_Click;

            
        }

        private void Card_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = hoverColor;
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            BackColor = normalColor;
        }


        private void EmployeeCard_Click(object sender, EventArgs e)
        {
            OpenNewForm(thisEmployee, this.mainUser);
        }

        private void OpenNewForm(Employee employee, User user)
        {
            EmployeeForm form = new EmployeeForm(thisEmployee, user, db);
            
            form.MainParentForm = ParentForm;
            form.StartPosition = FormStartPosition.CenterParent;
            this.ParentForm.Hide();
            form.ShowDialog(ParentForm);
            
        }
    }
}
