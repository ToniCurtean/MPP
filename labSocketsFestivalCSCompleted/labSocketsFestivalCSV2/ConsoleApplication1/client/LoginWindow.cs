using System;
using System.Windows.Forms;

namespace client
{
    public partial class LoginWindow : Form
    {
        private FestivalClientCtrl ctrl;
        public LoginWindow(FestivalClientCtrl ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }
        
        

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;
            try
            {
                ctrl.login(username, password);
                this.Close();
                //FestivalWindow fest = new FestivalWindow(ctrl, ctrl.cashier);
                //fest.Text = "Window for " + username;
                //fest.Show();
                //this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Login Error" + ex.Message);
                return;
            }
        }
    }
}