using MaterialSkin.Controls;
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

namespace RatingSystem
{
    public partial class MainForm : MaterialForm
    {
        // private readonly EmployeeRepository employeeRepository;
        private Database db { get; set; }
        
        public MainForm(User user, Database database)
        {
            InitializeComponent();
            db = database;
            nameMaterialLabel.Text = user.Name;

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

            
                topFlowLayoutPanel.BorderStyle = BorderStyle.None;
                topFlowLayoutPanel.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                topFlowLayoutPanel.AutoScroll = true;


                allFlowLayoutPanel.BorderStyle = BorderStyle.None;
                allFlowLayoutPanel.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                allFlowLayoutPanel.AutoScroll = true;

                allFlowLayoutPanel.Scroll += (sender, e) =>
                {
                    Rectangle visibleArea = new Rectangle(allFlowLayoutPanel.AutoScrollPosition, allFlowLayoutPanel.ClientSize);
                    allFlowLayoutPanel.Invalidate(visibleArea);
                };

            var topRatedEmployees = db.GetTopRatedEmployees(3);
            foreach (var employee in topRatedEmployees)
            {
                EmployeeCard employeeCard = new EmployeeCard(employee, user, db);
                employeeCard.ParentForm = this; // TEST
                topFlowLayoutPanel.Controls.Add(employeeCard);
            }

            var allEmployees = db.GetAllEmployees();
            foreach (var employee in allEmployees)
            {
                EmployeeCard employeeCard = new EmployeeCard(employee, user, db);
                employeeCard.ParentForm = this; // TEST
                allFlowLayoutPanel.Controls.Add(employeeCard);
            }
        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
