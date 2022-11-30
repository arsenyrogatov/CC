using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (!CurrentWorker.Login(login_maskedTextBox.Text, pwd_maskedTextBox.Text))
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
            else
            {
                WorkerForm workerForm = new WorkerForm();
                workerForm.FormClosed += (object se, FormClosedEventArgs ee) => { Visible = true; };
                Visible = false;
                login_maskedTextBox.Clear();
                pwd_maskedTextBox.Clear();
                workerForm.ShowDialog();
            }
        }
    }
}
