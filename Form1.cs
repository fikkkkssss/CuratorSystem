using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace CuratorReportSystem
{
    public partial class Form1 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";

        public Form1()
        {
            InitializeComponent();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // показываем пароль
            }
            else
            {
                txtPassword.PasswordChar = '●'; // скрываем
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = HashPassword(password);

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT u.user_id, r.role_name 
                                     FROM users u
                                     JOIN roles r ON u.role_id = r.role_id
                                     WHERE u.login = @login AND u.password_hash = @password";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Program.CurrentUserId = reader.GetInt32(0);
                                Program.CurrentUserRole = reader.GetString(1);
                                Program.CurrentUserLogin = login;

                                if (Program.CurrentUserRole == "student")
                                {
                                    GetStudentGroupId();
                                }
                                else if (Program.CurrentUserRole == "curator")
                                {
                                    GetCuratorGroupId();
                                }

                                // ВАЖНОЕ ИЗМЕНЕНИЕ: 
                                // Вместо создания Form2 напрямую, мы просто говорим,
                                // что вход успешен, и закрываем форму. 
                                // Программа сама откроет Form2 благодаря циклу в Program.cs
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetStudentGroupId()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT group_id FROM student WHERE user_id = @user_id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", Program.CurrentUserId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            Program.CurrentUserGroupId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void GetCuratorGroupId()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT group_id FROM ""group"" WHERE curator_id = @user_id LIMIT 1";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", Program.CurrentUserId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            Program.CurrentUserGroupId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}