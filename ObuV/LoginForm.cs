using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObuV
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.Text = "Вход в систему";
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Times New Roman", 10f);

            lblTitle.Font = new System.Drawing.Font("Times New Roman", 16f, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Black;

            btnLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#00FA9A");
            btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            btnGuest.BackColor = System.Drawing.ColorTranslator.FromHtml("#7FFF00");
            btnGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            string logoPath = System.IO.Path.Combine(Application.StartupPath, "Resources", "logo.png");
            if (System.IO.File.Exists(logoPath))
            {
                picLogo.Image = System.Drawing.Image.FromFile(logoPath);
                picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {

          }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT u.UserID, u.UserSurname, u.UserName, r.RoleName
            FROM [User] u
            JOIN Role r ON u.RoleID = r.RoleID
            WHERE u.Login = @login AND u.Password = @password";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CurrentUser.UserID = reader.GetInt32(0);
                            CurrentUser.FullName = reader.GetString(1) + " " + reader.GetString(2);
                            CurrentUser.Login = login;
                            CurrentUser.RoleName = reader.GetString(3);

                            var productForm = new ProductForm();
                            productForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser.RoleName = "Гость";
            CurrentUser.FullName = "Гость";

            var productForm = new ProductForm();
            productForm.Show();
            this.Hide();
        }
    }
}
