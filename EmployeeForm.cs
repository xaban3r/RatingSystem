using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatingSystem
{
    public partial class EmployeeForm : MaterialForm
    {
        private Database db {  get; set; }
        private string userId {  get; set; }
        private string employeeId { get; set; }
        User User { get; set; }
        public Form MainParentForm { get; set; } 
        public EmployeeForm(Employee employee, User user, Database database)
        {
            InitializeComponent();
            userId = user.Id;
            employeeId = employee.Id;
            User = user;
            commentsFlowLayoutPanel.AutoScroll = true;
            employeeNameMaterialLabel.Text = employee.Name;
            db = database;
            Image originalImage = Image.FromFile(employee.PhotoPath);
            int newWidth = 130;
            int newHeight = 140;
            
            // Создание новой картинки с новыми размерами
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }
            
            // Отображение картинки в PictureBox

            profileRoundedPictureBox.Image = newImage;
            int rating = db.GetRating(userId, employeeId);
            List<PictureBox> pictureBoxList = new List<PictureBox>();
            for (int i = 1; i <= 5; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Name = "pictureBox" + i;
                pictureBox.Tag = i;//StarState.Gray;
                pictureBox.Size = new Size(20, 20);
                //pictureBox.Location = new Point(170 + i * 20, 135);
                pictureBox.Location = new Point(180 + i * 20, 125);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if (i <= rating)
                {
                    pictureBox.Image = Properties.Resources.star;
                }
                else
                {
                    pictureBox.Image = Properties.Resources.grayStar;
                }
               
                pictureBoxList.Add(pictureBox);
                this.Controls.Add(pictureBox);
            }
            foreach (PictureBox pictureBox in pictureBoxList)
            {
                pictureBox.Click += (sender, e) =>
                {
                    
                    db.SaveRating(userId, employeeId, (int)pictureBox.Tag);
                    UpdatePictureBox(pictureBoxList);
                    
                };
            }

                displayComments();

            // Общий обработчик событий для всех звездочек
            EventHandler starEventHandler = new EventHandler((object obj, EventArgs args) =>
            {
               
                int index = int.Parse(((PictureBox)obj).Tag.ToString());

                // Измен. состояние звездочек
                for (int i = 1; i <= 5; i++)
                {
                    PictureBox star = (PictureBox)this.Controls["pictureBox" + i];
                    if (i <= index)
                    {
                        star.Image = Properties.Resources.star;
                    }
                    else
                    {
                        star.Image = Properties.Resources.grayStar;
                    }
                }
            });
            EventHandler starLeaveEventHandler = new EventHandler((object obj, EventArgs args) =>
            {
                
                UpdatePictureBox(pictureBoxList);

            });

            // Привязка обработчиков событий ко всем PictureBox
            for (int i = 1; i <= 5; i++)
            {
                PictureBox star = (PictureBox)this.Controls["pictureBox" + i];
                star.MouseEnter += starEventHandler;
                star.MouseLeave += starLeaveEventHandler;
                star.Click += (object obj, EventArgs args) =>
                {
                    // Определение индекса текущей звезды
                    int index = int.Parse(((PictureBox)obj).Tag.ToString());
                    // Отправ. запрос к базе данных на обновление рейтинга сотрудника
                };
            }


        }

        private void UpdatePictureBox(List <PictureBox> pictureBoxes)
        {
            int rating = db.GetRating(userId, employeeId);
            foreach (PictureBox pictureBox in pictureBoxes) 
            {
                if ((int)pictureBox.Tag <= rating)
                {
                    pictureBox.Image = Properties.Resources.star;
                }
                else
                {
                    pictureBox.Image = Properties.Resources.grayStar;
                }
            }
            
        }

        private void displayComments()
        {
            commentsFlowLayoutPanel.Controls.Clear();
            var allComments = db.GetComments(employeeId);
            foreach (var comment in allComments)
            {
                RichTextBox commentTextBox = new RichTextBox();
                string name = db.GetName(comment.Item1);
                string commentString = name + "\n" + comment.Item2;
                commentTextBox.Text = commentString;
                commentTextBox.BorderStyle = BorderStyle.None;
                commentTextBox.BackColor = SystemColors.Control;
                commentTextBox.Width = 800;
                commentTextBox.ReadOnly = true;
                int lengthOfName = name.Length;
                commentTextBox.Select(0, lengthOfName);
                commentTextBox.SelectionFont = new Font(commentTextBox.Font.FontFamily, 12, FontStyle.Bold);

                // Изменяем свойства шрифта второй строки
                commentTextBox.Select(lengthOfName + 1, commentString.Length - lengthOfName - 1);
                commentTextBox.SelectionFont = new Font(commentTextBox.Font.FontFamily, 10, FontStyle.Regular);

                commentsFlowLayoutPanel.Controls.Add(commentTextBox);
            }
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void saveCommentButton_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text.Trim();
            text = string.Join(" ", text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            if (!string.IsNullOrEmpty(text) && text.Length < 800)
            {
                db.SaveComment(userId, employeeId, text);
                displayComments();
            }
            else
            {
                // nothing
            }
            richTextBox1.Clear();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                db.SetAverageRating(employeeId);
            }
            catch { }
            MainForm mainForm = new MainForm(User, db);
            mainForm.StartPosition = FormStartPosition.CenterParent;
            this.Hide();
            mainForm.ShowDialog(this);
        }
    }
}
