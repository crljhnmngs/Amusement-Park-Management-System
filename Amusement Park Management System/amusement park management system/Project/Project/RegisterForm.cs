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
using System.Text.RegularExpressions;

namespace Project
{
    public partial class RegisterForm : Form
    {
        private string str1;
       // private string ss;
        private string role = "User";
        
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            id();
        }
        public void id()
        {
            connection.connection.DB();
            String gen = "SELECT userid from Users order by userid";
            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
            function.function.datareader = command.ExecuteReader();
            while(function.function.datareader.Read())
            {
                txtuserid.Text = function.function.datareader["userid"].ToString();
            }
            int i = int.Parse(txtuserid.Text);
            i = i + 1;
            txtuserid.Text = i.ToString();
            connection.connection.conn.Close();
            function.function.datareader.Close();


        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Textusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btnregister_Click(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(txtage.Text, out value);
            
            connection.connection.DB();
            if (textusername.Text == "" || textpassword.Text == "" || txtfname.Text == "" || txtlname.Text == "" || txtage.Text == "" || txtaddress.Text == "" || cbbstatus.Text == "" || txtemailadd.Text == "")
            {
                MessageBox.Show("Please fill up the missing fields");
            }
            else if (!rdbmale.Checked && !rdbfemale.Checked)
            {
                MessageBox.Show("Please fill up the missing fields");
            }

            else if (value <= 10 || value >= 60)
            {
                

                    MessageBox.Show("Invalid Age");
                    txtage.Text = "";
       
            }
            else
            {

                SqlDataAdapter da = new SqlDataAdapter("Select username from Users where username = '" + textusername.Text + "'", connection.connection.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Username is already TAKEN!");
                    usernameclear();
                }
                else
                {

                    try
                    {

                        connection.connection.DB();

                        if (str1 == rdbmale.Text)
                        {
                            rdbmale.Checked = true;
                            rdbfemale.Checked = false;
                            str1 = "Male";
                        }
                        else
                        {
                            rdbfemale.Checked = true;
                            rdbmale.Checked = false;
                            str1 = "Female";
                        }
                        MemoryStream ms = new MemoryStream();
                        pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                        byte[] img = ms.ToArray();
                        String gen = "Insert into Users(userid,username,password,fname,lname,gender,age,address,civilstatus,emailadd,role,picture)values(" + txtuserid.Text + ",'" + textusername.Text + "','" + textpassword.Text + "','" + txtfname.Text + "','" + txtlname.Text + "','" + str1 + "'," + txtage.Text + ",'" + txtaddress.Text + "','" + cbbstatus.Text + "','" + txtemailadd.Text + "', '" + role + "',@img)";
                        SqlCommand command = new SqlCommand(gen, connection.connection.conn);
                        command.Parameters.AddWithValue("@img", img);
                        //command.Parameters.AddWithValue("civilstatus", cbbstatus.Text.ToString());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Registered!");
                        connection.connection.conn.Close();
                        Clear();
                        id();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            str1 = rdbmale.Text;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            str1 = rdbfemale.Text;
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            loginform a = new loginform();

            this.Hide();
            a.Show();

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textpassword.UseSystemPasswordChar = false;
            }
            else
                textpassword.UseSystemPasswordChar = true;
        }
        public void usernameclear()
        {
            textusername.Clear();
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

        private void Textusername_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void Textusername_Enter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            textusername.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Textpassword_Enter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            textpassword.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Txtfname_Enter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(78, 184, 206);
            txtfname.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Txtlname_Enter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(78, 184, 206);
            txtlname.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Rdbmale_Enter(object sender, EventArgs e)
        {
            rdbmale.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Rdbfemale_Enter(object sender, EventArgs e)
        {
            rdbfemale.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Txtage_Enter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(78, 184, 206);
            txtage.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Txtaddress_Enter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(78, 184, 206);
            txtaddress.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Cbbstatus_Enter(object sender, EventArgs e)
        {
          
        }

        private void Txtemailadd_Enter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(78, 184, 206);
            txtemailadd.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void Textusername_Leave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.WhiteSmoke;
            textusername.ForeColor = Color.WhiteSmoke;

            
        }

        private void Textpassword_Leave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.WhiteSmoke;
            textpassword.ForeColor = Color.WhiteSmoke;
        }

        private void Txtfname_Leave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.WhiteSmoke;
            txtfname.ForeColor = Color.WhiteSmoke;
        }

        private void Txtlname_Leave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.WhiteSmoke;
            txtlname.ForeColor = Color.WhiteSmoke;
        }

        private void Rdbmale_Leave(object sender, EventArgs e)
        {
            rdbmale.ForeColor = Color.WhiteSmoke;
        }

        private void Rdbfemale_Leave(object sender, EventArgs e)
        {
            
            rdbfemale.ForeColor = Color.WhiteSmoke;
        }

        private void Txtage_Leave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.WhiteSmoke;
            txtfname.ForeColor = Color.WhiteSmoke;
        }

        private void Txtaddress_Leave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.WhiteSmoke;
            txtaddress.ForeColor = Color.WhiteSmoke;
        }

        private void Cbbstatus_Leave(object sender, EventArgs e)
        {
    
        }

        private void Txtemailadd_Leave(object sender, EventArgs e)
        {
            
            panel7.BackColor = Color.WhiteSmoke;
            txtemailadd.ForeColor = Color.WhiteSmoke;
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

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Txtage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void Textusername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textusername.Text))
            {
                errorProvider1.SetError(textusername,"Username is required!");
            }
            else
            {
                errorProvider1.SetError(textusername, null);
            }
        }

        private void Textpassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textpassword.Text))
            {
                errorProvider1.SetError(textpassword, "Password is required!");
            }
            else
            {
                errorProvider1.SetError(textpassword, null);
            }
        }

        private void Txtfname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtfname.Text))
            {
                errorProvider1.SetError(txtfname, "Firstname is required!");
            }
            else
            {
                errorProvider1.SetError(txtfname, null);
            }
        }

        private void Txtlname_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtlname.Text))
            {
                errorProvider1.SetError(txtlname, "Lastname is required!");
            }
            else
            {
                errorProvider1.SetError(txtlname, null);
            }
        }

        private void Txtage_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtage.Text))
            {
                errorProvider1.SetError(txtage, "Age is required!");
            }
        
            else
            {
                errorProvider1.SetError(txtage, null);
            }
        }

        private void Txtaddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtaddress.Text))
            {
                errorProvider1.SetError(txtaddress, "Address is required!");
            }
            else
            {
                errorProvider1.SetError(txtaddress, null);
            }
        }

        private void Cbbstatus_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbbstatus.Text))
            {
                errorProvider1.SetError(cbbstatus, "Civil Status is required!");
            }
            else
            {
                errorProvider1.SetError(cbbstatus, null);
            }
        }

        private void Txtemailadd_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            
            
            
            if (string.IsNullOrEmpty(txtemailadd.Text))
            {
                errorProvider1.SetError(txtemailadd, "Email Add is required!");
            }
            else if(Regex.IsMatch(txtemailadd.Text, pattern))
            {
                errorProvider1.SetError(txtemailadd, null);
            }
            else
            {
                errorProvider1.SetError(txtemailadd, "Please Enter a valid Email!");
            }
        }

        private void PictureBox2_Validating(object sender, CancelEventArgs e)
        {

        }

        private void Txtfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Txtlname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Txtage_Validated(object sender, EventArgs e)
        {

        }
    }

}
