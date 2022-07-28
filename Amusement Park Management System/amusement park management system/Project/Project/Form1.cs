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
//using System.Data;
using System.IO;

namespace Project
{
    public partial class loginform : Form
    {
        
       // private static string userrole = "admin";
        public loginform()
        {
            InitializeComponent();
        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            //Credits to www.flaticon.com for my icons :)
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {

            AdminForm adminfrm = new AdminForm();
            Userform userfrm = new Userform();
            try
            {

                if (txtusername.Text == "" || txtpassword.Text == "")
                {
                    MessageBox.Show("Please fill up the missing fields");
                }
                else
                
                    connection.connection.DB();
                    String gen = "Select * from Users where [username] = '" + txtusername.Text + "'and [password] = '" + txtpassword.Text + "'";
                    SqlCommand command = new SqlCommand(gen, connection.connection.conn);
                    function.function.datareader = command.ExecuteReader();

                    string role;
                    if (function.function.datareader.Read())
                    {

                    role = function.function.datareader["role"].ToString();
                    
                    //txtusername.Text = (reader["username"].ToString());
                    //txtpassword.Text = (reader["password"].ToString());
                    if (role == "Admin")
                    {
                        this.Hide();
                        MessageBox.Show("You have successfully log-in as Admin", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminForm.labeladmin = txtusername.Text;
                        AdminForm.labelrole = role;

                       // AdminForm.image = image;
                        adminfrm.Show();
                    }
                    else
                    {
                        this.Hide();
                        MessageBox.Show("You have successfully log-in as User", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Userform.labeladmin = txtusername.Text;
                        Userform.labelrole = role;
                        userfrm.Show();
                    }
                }


                else
                {
                    MessageBox.Show("Your Username or Password is Incorrect");
                    txtusername.Clear();
                    txtpassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btnregister_Click(object sender, EventArgs e)
        {
            RegisterForm a = new RegisterForm();
            this.Hide();
            a.Show();
        }

        private void txtusername_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void Txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username")
                txtusername.Text = null;

            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtusername.ForeColor = Color.FromArgb(78, 184, 206);

            panel2.BackColor = Color.WhiteSmoke;
            txtpassword.ForeColor = Color.WhiteSmoke;
        }

        private void Txtusername_Leave(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                txtusername.Text = "Username";

            }
            
        }

        private void Txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            { 
                txtpassword.Text = null;
                txtpassword.PasswordChar = '*';

            }
            

            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtpassword.ForeColor = Color.FromArgb(78, 184, 206);

            panel1.BackColor = Color.WhiteSmoke;
            txtusername.ForeColor = Color.WhiteSmoke;



        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                txtpassword.PasswordChar = '*';
            }
            else
            {
                txtpassword.PasswordChar = '\0';
            }
        }

        private void Txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.PasswordChar = '\0';
                txtpassword.Text = "Password";
            }
            panel2.BackColor = Color.WhiteSmoke;
            txtpassword.ForeColor = Color.WhiteSmoke;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtusername.ForeColor = Color.FromArgb(78, 184, 206);

            panel2.BackColor = Color.WhiteSmoke;
            txtpassword.ForeColor = Color.WhiteSmoke;
        }

        private void Txtpassword_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtpassword.ForeColor = Color.FromArgb(78, 184, 206);

            panel1.BackColor = Color.WhiteSmoke;
            txtusername.ForeColor = Color.WhiteSmoke;
        }

        private void Btnlogin_DragEnter(object sender, DragEventArgs e)
        {
            panel1.BackColor = Color.WhiteSmoke;
            txtusername.ForeColor = Color.WhiteSmoke;

            panel2.BackColor = Color.WhiteSmoke;
            txtpassword.ForeColor = Color.WhiteSmoke;
        }
    }
}
