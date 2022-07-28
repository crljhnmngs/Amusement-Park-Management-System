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
    public partial class AdminForm : Form
    {
        public static string labeladmin;
        public static string labelrole;
        public static string pass;
        public static string image;
        private string str1;
        SqlDataAdapter wew;
        DataTable dt;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void UserGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AdminForm_Load(object sender, EventArgs e)
        {

            string s = "";
            s = "Select * from Users";
            function.function.datagridfill(s, UsersGrid);
        }

        private void AdminForm_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userDBDataSet15.transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.userDBDataSet15.transactions);
            // TODO: This line of code loads data into the 'userDBDataSet11.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter5.Fill(this.userDBDataSet11.Users);
            // TODO: This line of code loads data into the 'userDBDataSet10.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter4.Fill(this.userDBDataSet10.Users);
            // TODO: This line of code loads data into the 'userDBDataSet7.rideDB' table. You can move, or remove it, as needed.
            this.rideDBTableAdapter.Fill(this.userDBDataSet7.rideDB);

            // TODO: This line of code loads data into the 'userDBDataSet5.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter3.Fill(this.userDBDataSet5.Users);
            // TODO: This line of code loads data into the 'userDBDataSet4.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter2.Fill(this.userDBDataSet4.Users);
            // TODO: This line of code loads data into the 'userDBDataSet3.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter1.Fill(this.userDBDataSet3.Users);
            // TODO: This line of code loads data into the 'userDBDataSet2.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.userDBDataSet2.Users);
            string s = "";
            string a = "";
            string c = "";
            string d = "";
            s = "Select * from Users";
            function.function.datagridfill(s, UsersGrid);
            a = "Select * from rideDB";
            function.function.datagridfill(a, dataGridView1);
            c = "Select * from Users";
            function.function.datagridfill(c, dataGridView2);
            d = "Select * from transactions";
            function.function.datagridfill(d, dataGridView3);
            lbladmin.Text = labeladmin;
            lblrole.Text = labelrole;
            id();
            rideid();
            totalincome();
            ticket();
            lolo();
            // pbadmin.Image = Image.FromFile(image);



        }

        private void Btnshowdata_Click(object sender, EventArgs e)
        {
            string s = "";
            s = "Select * from Users";
            function.function.datagridfill(s, UsersGrid);
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Do You really want to delete this record ?", "Delete Record", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    connection.connection.DB();
                    String a = "Delete Users where userid = " + txtuserid.Text + "";
                    String b = "Delete transactions where transacuser = '" + textusername.Text + "'";
                    SqlCommand command = new SqlCommand(a, connection.connection.conn);
                    SqlCommand cmd = new SqlCommand(b, connection.connection.conn);
                    command.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted!");
                    AdminForm_Load_1(sender, e);
                    connection.connection.conn.Close();
                }
                else if (dialog == DialogResult.No)
                {
                    MessageBox.Show("Record not deleted", "Delete Record", MessageBoxButtons.OK);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                string gen = "Select * from Users where userid LIKE" + "'" + txtsearch.Text + "%' or username LIKE '" + txtsearch.Text + "%'";
                function.function.datagridfill(gen, UsersGrid);
                connection.connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            loginform a = new loginform();

            this.Hide();
            a.Show();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label4.Text = "User Information";
            lbladmin.Visible = false;
            tabControl1.SelectTab(1);
            // panel3.Visible = false;
            //panel6.Visible = false;
            // panel4.Visible = true;
            UsersGrid.BorderStyle = BorderStyle.None;
            UsersGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            UsersGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            UsersGrid.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            UsersGrid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            UsersGrid.BackgroundColor = Color.White;
            UsersGrid.EnableHeadersVisualStyles = false;
            UsersGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            UsersGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            UsersGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btnsysteminfo_Click(object sender, EventArgs e)
        {
            label4.Text = "System Information";
            lbladmin.Visible = false;
            tabControl1.SelectTab(2);
            //  panel4.Visible = false;
            ///  panel6.Visible = false;
            //  panel3.Visible = true;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void Panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            loginform a = new loginform();

            this.Hide();
            a.Show();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            loginform a = new loginform();

            this.Hide();
            a.Show();
        }

        private void Btnhome_Click(object sender, EventArgs e)
        {
            label4.Text = "Welcome!";
            lbladmin.Visible = true;
            tabControl1.SelectTab(0);
            // panel3.Visible = true;
            // panel6.Visible = true;


        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homepanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Btnregister_Click(object sender, EventArgs e)
        {
            Addadminform addadmin = new Addadminform();
            this.Hide();
            addadmin.Show();
        }
        public void ticket()
        {
            connection.connection.DB();
            String gen = "SELECT totalticketbuy from buyticket order by totalticketbuy";
            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
            function.function.datareader = command.ExecuteReader();
            while (function.function.datareader.Read())
            {
                lbltotal.Text = function.function.datareader["totalticketbuy"].ToString();
            }
            int b = int.Parse(lbltotal.Text);
            lbltotal.Text = b.ToString();
            connection.connection.conn.Close();
            function.function.datareader.Close();
        }

        public void totalincome()
        {

            connection.connection.DB();
            String gen = "SELECT income from buyticket order by income";
            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
            function.function.datareader = command.ExecuteReader();
            while (function.function.datareader.Read())
            {
                lblincome.Text = function.function.datareader["income"].ToString();
            }
            int i = int.Parse(lblincome.Text);
            lblincome.Text = i.ToString();
            connection.connection.conn.Close();
            function.function.datareader.Close();
        }
        private void Lbladmin_Click(object sender, EventArgs e)
        {

        }

        private void Pbadmin_Click(object sender, EventArgs e)
        {

        }

        private void Txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text == "Search")
                txtsearch.Text = null;
        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            Clear();
        }

        private void UserGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            textusername.Enabled = false;
            btnadding.Text = "Update";
            //UserGrid_CellMouseClick();
            tabControl1.SelectTab(3);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
            clearride();
        }
        public void id()
        {
            connection.connection.DB();
            String gen = "SELECT userid from Users order by userid";
            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
            function.function.datareader = command.ExecuteReader();
            while (function.function.datareader.Read())
            {
                txtuserid.Text = function.function.datareader["userid"].ToString();
            }
            int i = int.Parse(txtuserid.Text);
            i = i + 1;
            txtuserid.Text = i.ToString();
            connection.connection.conn.Close();
            function.function.datareader.Close();


        }
        private void Btnadding_Click(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(txtage.Text, out value);
            if (btnadding.Text == "Add")
            {
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
                            pictureBox5.Image.Save(ms, pictureBox5.Image.RawFormat);
                            byte[] img = ms.ToArray();
                            String gen = "Insert into Users(userid,username,password,fname,lname,gender,age,address,civilstatus,emailadd,role,picture)values(" + txtuserid.Text + ",'" + textusername.Text + "','" + textpassword.Text + "','" + txtfname.Text + "','" + txtlname.Text + "','" + str1 + "'," + txtage.Text + ",'" + txtaddress.Text + "','" + cbbstatus.Text + "','" + txtemailadd.Text + "', '" + cbbrole.Text + "',@img)";
                            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
                            command.Parameters.AddWithValue("@img", img);
                            //command.Parameters.AddWithValue("civilstatus", cbbstatus.Text.ToString());
                            command.ExecuteNonQuery();
                            MessageBox.Show("Successfully Added!");
                            id();
                            AdminForm_Load_1(sender, e);
                            connection.connection.conn.Close();

                            Clear();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                }
            }
            else if (btnadding.Text == "Update")
            {
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
                        try

                        {

                            connection.connection.DB();
                            MemoryStream ms = new MemoryStream();
                            pictureBox5.Image.Save(ms, pictureBox5.Image.RawFormat);
                            byte[] img = ms.ToArray();
                            String b = "Update Users set password = '" + textpassword.Text + "',fname = '" + txtfname.Text + "',lname = '" + txtlname.Text + "',gender = '" + str1 + "',age = " + txtage.Text + ",address = '" + txtaddress.Text + "',civilstatus = '" + cbbstatus.Text + "',emailadd = '" + txtemailadd.Text + "',role = '" + cbbrole.Text + "',picture = @img where userid = " + txtuserid.Text + "";
                            SqlCommand command = new SqlCommand(b, connection.connection.conn);
                            command.Parameters.AddWithValue("@img", img);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Successfully Updated!");
                            AdminForm_Load_1(sender, e);
                            command.CommandTimeout = 0;
                            connection.connection.conn.Close();
                            Clear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
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
            // cbbstatus.Items.Clear();
            cbbstatus.ResetText();
            checkBox1.Checked = false;
            cbbrole.ResetText();
            pictureBox5.Image = null;
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

        private void Upload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.Filter = "Choose image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (pic.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image = Image.FromFile(pic.FileName);
            }
        }

        private void Txtage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
            btnaddride.Text = "Update";

        }

        private void Btnupdate2_Click(object sender, EventArgs e)
        {
            connection.connection.DB();
            if (textusername.Text == "" || textpassword.Text == "" || txtfname.Text == "" || txtlname.Text == "" || txtage.Text == "" || txtaddress.Text == "" || cbbstatus.Text == "" || txtemailadd.Text == "")
            {
                MessageBox.Show("Please fill up the missing fields");
            }
            else if (!rdbmale.Checked && !rdbfemale.Checked)
            {
                MessageBox.Show("Please fill up the missing fields");
            }
            else
                try
                {

                    connection.connection.DB();
                    MemoryStream ms = new MemoryStream();
                    pictureBox5.Image.Save(ms, pictureBox5.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    String b = "Update userBD set password = '" + textpassword.Text + "',fname = '" + txtfname.Text + "',lname = '" + txtlname.Text + "',gender = '" + str1 + "',age = " + txtage.Text + ",address = '" + txtaddress.Text + "',civilstatus = '" + cbbstatus.Text + "',emailadd = '" + txtemailadd.Text + "',role = '" + cbbrole.Text + "',picture = @img where username = '" + textusername.Text + "'";
                    SqlCommand command = new SqlCommand(b, connection.connection.conn);
                    command.Parameters.AddWithValue("@img", img);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated!");
                    AdminForm_Load_1(sender, e);
                    // command.CommandTimeout = 0;
                    connection.connection.conn.Close();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void UsersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UsersGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtuserid.Text = UsersGrid[0, e.RowIndex].Value.ToString();
            //txtsearch.Text = UsersGrid[0, e.RowIndex].Value.ToString();
            textusername.Text = UsersGrid[1, e.RowIndex].Value.ToString();
            textpassword.Text = UsersGrid[2, e.RowIndex].Value.ToString();
            txtfname.Text = UsersGrid[3, e.RowIndex].Value.ToString();
            txtlname.Text = UsersGrid[4, e.RowIndex].Value.ToString();
            if (UsersGrid[5, e.RowIndex].Value.ToString() == "Male")
            {
                rdbmale.Select();
            }
            else if (UsersGrid[5, e.RowIndex].Value.ToString() == "Female")
            {
                rdbfemale.Select();
            }
            txtage.Text = UsersGrid[6, e.RowIndex].Value.ToString();
            txtaddress.Text = UsersGrid[7, e.RowIndex].Value.ToString();
            cbbstatus.Text = UsersGrid[8, e.RowIndex].Value.ToString();
            txtemailadd.Text = UsersGrid[9, e.RowIndex].Value.ToString();
            cbbrole.Text = UsersGrid[10, e.RowIndex].Value.ToString();
            byte[] img = (byte[])UsersGrid[11, e.RowIndex].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox5.Image = Image.FromStream(ms);
            //connection.connection.conn.Close();
        }

        private void Btnaddride_Click(object sender, EventArgs e)
        {
            if (btnaddride.Text == "Add")
            {
                if (txtridename.Text == "" || txtprice.Text == "" || txtcapacity.Text == "" || txtdescription.Text == "")
                {
                    MessageBox.Show("Please fill up the missing fields");
                }
                else
                    try
                    {
                        connection.connection.DB();
                        MemoryStream ms = new MemoryStream();
                        pictureBox6.Image.Save(ms, pictureBox6.Image.RawFormat);
                        byte[] img = ms.ToArray();
                        String gen = "Insert into rideDB(rideid,ridename,ticketprice,capacity,description,picture)values(" + txtrideid.Text + ",'" + txtridename.Text + "'," + txtprice.Text + "," + txtcapacity.Text + ",'" + txtdescription.Text + "',@img)";
                        SqlCommand command = new SqlCommand(gen, connection.connection.conn);
                        command.Parameters.AddWithValue("@img", img);
                        //command.Parameters.AddWithValue("civilstatus", cbbstatus.Text.ToString());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added!");
                        rideid();
                        AdminForm_Load_1(sender, e);
                        connection.connection.conn.Close();
                        clearride();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
            if (btnaddride.Text == "Update")
            {
                if (txtridename.Text == "" || txtprice.Text == "" || txtcapacity.Text == "" || txtdescription.Text == "")
                {
                    MessageBox.Show("Please fill up the missing fields");
                }
                else
                    try
                    {

                        connection.connection.DB();
                        MemoryStream ms = new MemoryStream();
                        pictureBox6.Image.Save(ms, pictureBox6.Image.RawFormat);
                        byte[] img = ms.ToArray();
                        String b = "Update rideDB set ridename ='" + txtridename.Text + "', ticketprice = " + txtprice.Text + ",capacity = " + txtcapacity.Text + ",description = '" + txtdescription.Text + "',picture = @img where rideid = " + txtrideid.Text + "";
                        SqlCommand command = new SqlCommand(b, connection.connection.conn);
                        command.Parameters.AddWithValue("@img", img);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated!");
                        AdminForm_Load_1(sender, e);
                        command.CommandTimeout = 0;
                        connection.connection.conn.Close();
                        clearride1();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }

        private void Panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        public void rideid()
        {
            connection.connection.DB();
            String gen = "SELECT rideid from rideDB order by rideid";
            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
            function.function.datareader = command.ExecuteReader();
            while (function.function.datareader.Read())
            {
                txtrideid.Text = function.function.datareader["rideid"].ToString();
            }
            int i = int.Parse(txtrideid.Text);
            i = i + 1;
            txtrideid.Text = i.ToString();
            connection.connection.conn.Close();
            function.function.datareader.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.Filter = "Choose image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (pic.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.Image = Image.FromFile(pic.FileName);
            }
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtrideid.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            txtridename.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            txtprice.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            txtcapacity.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            txtdescription.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            byte[] img = (byte[])dataGridView1[5, e.RowIndex].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox6.Image = Image.FromStream(ms);


        }
        public void clearride()
        {
            txtridename.Clear();
            txtprice.Clear();
            txtcapacity.Clear();
            txtdescription.Clear();
            pictureBox6.Image = null;
        }
        public void clearride1()
        {
            txtridename.Clear();
            txtprice.Clear();
            txtcapacity.Clear();
            txtdescription.Clear();
            pictureBox6.Image = null;
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Do You really want to delete this record ?", "Delete Record", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    connection.connection.DB();
                    String a = "Delete rideDB where rideid = " + txtrideid.Text + "";
                    SqlCommand command = new SqlCommand(a, connection.connection.conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted!");
                    AdminForm_Load_1(sender, e);
                    connection.connection.conn.Close();
                }
                else if (dialog == DialogResult.No)
                {
                    MessageBox.Show("Record not deleted", "Delete Record", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                string q = "Select * from rideDB where rideid LIKE" + "'" + textBox1.Text + "%' or ridename LIKE '" + textBox1.Text + "%'";
                function.function.datagridfill(q, dataGridView1);
                connection.connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search")
                textBox1.Text = null;
        }

        private void Addpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Txtcapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Txtcapacity_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            loginform f = new loginform();
            this.Hide();
            f.Show();

        }

        private void PictureBox3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            label4.Text = "View Income";
            lbladmin.Visible = false;
            tabControl1.SelectTab(5);
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

        private void Txtridename_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Txtfname_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Txtlname_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Txtridename_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //char ch = e.KeyChar;

            //if (!Char.IsLetter(ch))
            //{
            //    e.Handled = true;
            //}
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            label4.Text = "View Users";
            textBox2.Visible = false;
            lbladmin.Visible = false;
            
            tabControl1.SelectTab(6);

            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void PictureBox1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                string gen = "Select * from Users where role LIKE" + "'" + txtsearch.Text + "%'";
                function.function.datagridfill(gen, dataGridView2);
                connection.connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void lolo()
        {
            try
            {
                connection.connection.DB();
                string gen = "Select * from Users where role LIKE" + "'" + textBox2.Text + "%'";
                function.function.datagridfill(gen, dataGridView2);
                connection.connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            label4.Text = "User Transaction History";
            textBox2.Visible = false;
            lbladmin.Visible = false;
            dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Descending);
            tabControl1.SelectTab(7);
            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView3.BackgroundColor = Color.White;
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                string q = "Select * from transactions where date LIKE" + "'" + dateTimePicker1.Text  + "%'";
                function.function.datagridfill(q, dataGridView3);
                connection.connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Lbladmin_Click_1(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            AdminForm_Load_1(sender, e);
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                string q = "Select * from transactions where transacid LIKE" + "'" + textBox3.Text + "%'or transacuser LIKE" + "'" + textBox3.Text + "%'";
                function.function.datagridfill(q, dataGridView3);
                connection.connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txtemailadd_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";



            if (string.IsNullOrEmpty(txtemailadd.Text))
            {
                errorProvider2.SetError(txtemailadd, "Email Add is required!");
            }
            else if (Regex.IsMatch(txtemailadd.Text, pattern))
            {
                errorProvider2.SetError(txtemailadd, null);
            }
            else
            {
                errorProvider2.SetError(txtemailadd, "Please Enter a valid Email!");
            }
        }

        private void PictureBox2_Click_2(object sender, EventArgs e)
        {
            AdminForm_Load_1(sender, e);
        }
    }
    }

