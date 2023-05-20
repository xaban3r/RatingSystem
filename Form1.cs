using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace RatingSystem
{
    public partial class Form1 : MaterialForm
    {
        private Database db;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RatingSystemData.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            db = new Database(connectionString);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Accent.LightBlue100
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey50, Primary.Grey50, Primary.Grey50, Accent.LightBlue100, TextShade.BLACK);
 
            usernameTextBox.BackColor = Color.DarkGray;
            passwordTextBox.BackColor = Color.DarkGray;

            passwordTextBox.PasswordChar = '*';
            // Загрузка картинки из ресурсов
            Image originalImage = Properties.Resources.Logo;

            // Вычисление коэффициента масштабирования
            double scaleFactor = 1.0;
            if (originalImage.Width > roundedPictureBox1.Width || originalImage.Height > roundedPictureBox1.Height)
            {
                double widthRatio = (double)roundedPictureBox1.Width / (double)originalImage.Width;
                double heightRatio = (double)roundedPictureBox1.Height / (double)originalImage.Height;
                scaleFactor = Math.Min(widthRatio, heightRatio);
            }

            // Вычисление новых размеров картинки
            int newWidth = (int)(originalImage.Width * scaleFactor);
            int newHeight = (int)(originalImage.Height * scaleFactor);

            // Создание новой картинки с новыми размерами
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            // Отображение картинки в PictureBox
            roundedPictureBox1.Image = newImage;
            



        }

        
        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            //string confirmPassword = confirmPasswordTextBox.Text;
            string confirmPassword = password;


            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            { 
                db.RegisterUser(username, password);
                MessageBox.Show("User registered successfully.");
            }
            catch
            {
                MessageBox.Show("Failed to register user.");
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            Tuple<bool, User> tuple = db.AuthenticateUser(username, password);
            bool success = tuple.Item1;
            User user = tuple.Item2;
            if (success)
            {
                MessageBox.Show("Login successful!");
                MainForm mainForm = new MainForm(user, db);
                mainForm.StartPosition = FormStartPosition.CenterParent;
                this.Hide();
                mainForm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Invalid login credentials. Please try again.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void registerButton_Click_1(object sender, EventArgs e)
        {
            RegisterForm reisterForm = new RegisterForm(db);
            reisterForm.ShowDialog(this);
        }
    }
}
