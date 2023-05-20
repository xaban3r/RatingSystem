using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatingSystem
{
    public partial class RegisterForm : MaterialForm
    {
        private Database db { get; set; }
        public RegisterForm(Database database)
        {
            InitializeComponent();
            db = database;
            passwordTextBox1.PasswordChar = '*';
            passwordTextBox2.PasswordChar = '*';
            this.db = db;
        }

        private void registerButton2_Click(object sender, EventArgs e)
        {
            if (passwordTextBox1.Text == passwordTextBox2.Text && !String.IsNullOrWhiteSpace(loginTextBox.Text) && !String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                string login = loginTextBox.Text;
                string password = passwordTextBox1.Text;
                string name = nameTextBox.Text;
                bool succes = db.Register(login, name, password);
                if (!succes)
                {
                    MessageBox.Show("User with this login exists ");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Textbox is empty or passwords is not match.");
            }
            
        }
    }
}
