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
using System.IO;

namespace Project
{
    
    public partial class Addadminform : Form
    {
        private string role = "Admin";
        private string str1;
        public Addadminform()
        {
            InitializeComponent();
        }

        private void Btnregister_Click(object sender, EventArgs e)
        {
            
        }

        private void Addadminform_Load(object sender, EventArgs e)
        {

        }
        public void usernameclear()
        {
            textusername.Clear();
        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Rdbmale_CheckedChanged(object sender, EventArgs e)
        {
            str1 = rdbmale.Text;
        }

        private void Rdbfemale_CheckedChanged(object sender, EventArgs e)
        {
            str1 = rdbfemale.Text;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textpassword.UseSystemPasswordChar = false;
            }
            else
                textpassword.UseSystemPasswordChar = true;
        }
        public void Clear()
        {
            textusername.Clear();
            textpassword.Clear();
            txtlname.Clear();
            txtfname.Clear();
            txtage.Clear();
            txtaddress.Clear();
            txtemailadd.Clear();
            rdbmale.Checked = false;
            rdbfemale.Checked = false;
            cbbstatus.Items.Clear();
            cbbstatus.ResetText();
            checkBox1.Checked = false;

        }

        private void Upload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.Filter = "Choose image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (pic.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(pic.FileName);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            AdminForm adminfrm = new AdminForm();
            this.Hide();
            adminfrm.Show();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
