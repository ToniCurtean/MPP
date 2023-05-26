using System;
using System.Configuration;
using System.Windows.Forms;
using WindowsFormsApp2.model;
using WindowsFormsApp2.repository;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {

        private Service service;

        public Service Service
        {
            get { return service;}
            set { service = value; }
        }

        public Login()
        {
            InitializeComponent();
        }
        
        private void loginLoad(object sender, EventArgs e)
        {
            labelError.Visible = false;
            textBox2.PasswordChar = '*';
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (Service.ServiceCashier.getCashierByUserPassword(textBox1.Text, textBox2.Text)==1)
            {
                this.Hide();
                MainForm main = new MainForm();
                main.Service = this.Service;
                main.Show();
            }
            else
            {
                labelError.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
        
    }
}