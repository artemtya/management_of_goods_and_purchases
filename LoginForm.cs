using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Kalimov_curs;
using MySql.Data.MySqlClient;

namespace InventoryManagementApp
{
    public partial class LoginForm : Form
    {
        private MySqlConnection connection;
        private Dictionary<Control, Rectangle> controlsData = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private Size formOriginalSize;

        public LoginForm()
        {
            InitializeComponent();
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            btnLogin.Click += btnLogin_Click;

            this.MinimumSize = new Size(300, 200);

            this.Load += LoginForm_Load;
            this.Resize += LoginForm_Resize;


            txtPassword.UseSystemPasswordChar = true;

            Database db = new Database("///",
                                       "///",
                                       "///",
                                       "///");
            connection = db.GetConnection();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

            formOriginalSize = this.Size;
            foreach (Control ctrl in this.Controls)
            {
                controlsData[ctrl] = ctrl.Bounds;
                if (ctrl.Font != null)
                    originalFontSizes[ctrl] = ctrl.Font.Size;
            }
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            float scaleX = (float)this.Width / formOriginalSize.Width;
            float scaleY = (float)this.Height / formOriginalSize.Height;
            float scaleFont = Math.Min(scaleX, scaleY);

            foreach (Control ctrl in controlsData.Keys)
            {
                Rectangle originalBounds = controlsData[ctrl];
                ctrl.SetBounds(
                    (int)(originalBounds.X * scaleX),
                    (int)(originalBounds.Y * scaleY),
                    (int)(originalBounds.Width * scaleX),
                    (int)(originalBounds.Height * scaleY)
                );
            }

            foreach (Control ctrl in originalFontSizes.Keys)
            {
                ctrl.Font = new Font(ctrl.Font.FontFamily, originalFontSizes[ctrl] * scaleFont, ctrl.Font.Style);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string query = "SELECT users_id, role_id FROM users WHERE username=@username AND password=@password";

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32("users_id");
                        int roleId = reader.GetInt32("role_id");

                        this.Hide();
                        AdminForm adminForm = new AdminForm(userId, roleId);
                        adminForm.WindowState = FormWindowState.Maximized; // Открываем на весь экран
                        adminForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}