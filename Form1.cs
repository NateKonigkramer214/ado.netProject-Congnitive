using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Audio_Box_2._0
{
    public partial class Register : Form
    {
        //Registration Class
        Registration_Class reg = new Registration_Class();

        public Register()
        {
            InitializeComponent();
            //Calling class
            Captcha_lb.Text = reg.GenCaptcha();
            //Register button disabled until you check privacy policy
            Register_btn.Enabled = false;
        }

        private void Register_btn_Click(object sender, EventArgs e)
        {
            bool captch_validate = reg.ValCaptcha(Captcha_Tb.Text);
            if (captch_validate)
            {
                string message = reg.Registration(Username_tb.Text, Email_tb.Text, Password_tb.Text);
                if(message == "User registered Successfully continue to login")
                {
                    MessageBox.Show(message);
                    this.Hide();
                    var Login = new Login();
                    Login.Closed += (s, args) => this.Close();
                    Login.Show();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            else
            {
                MessageBox.Show("Looks like you are a robot.....Please try again");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Privacy policy check SR
            if (Privacy_cb.Checked == true)
            {
                //Enables register when privacy policy is checked
                Register_btn.Enabled = true;
            }
        }
        private void login_btn_rg_Click(object sender, EventArgs e)
        {
            //Opens login form closes register form.
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();
        }
        private void Register_Load(object sender, EventArgs e)
        {
            //Clears fields on loadup. 
            Email_tb.Clear();
            Password_tb.Clear();
            Email_tb.Clear();
            DOB_TB.Clear();
        }
    }
}
