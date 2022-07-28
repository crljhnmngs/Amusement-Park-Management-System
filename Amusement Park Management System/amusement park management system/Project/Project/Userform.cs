using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class Userform : Form
    {
        public static string labeladmin;
        public static string labelrole;
       public static string id;
        public static string total;
        public static string Income;
        public static int ID;
        public static int TOTAL;
        public static double INCOME;
        public static int wew;
        public Userform()
        {
            InitializeComponent();
        }

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Userform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userDBDataSet19.transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter2.Fill(this.userDBDataSet19.transactions);
            // TODO: This line of code loads data into the 'userDBDataSet18.cart' table. You can move, or remove it, as needed.
            this.cartTableAdapter3.Fill(this.userDBDataSet18.cart);
            // TODO: This line of code loads data into the 'userDBDataSet17.cart' table. You can move, or remove it, as needed.
            this.cartTableAdapter2.Fill(this.userDBDataSet17.cart);
            // TODO: This line of code loads data into the 'userDBDataSet16.cart' table. You can move, or remove it, as needed.
            this.cartTableAdapter1.Fill(this.userDBDataSet16.cart);
            // TODO: This line of code loads data into the 'userDBDataSet14.cart' table. You can move, or remove it, as needed.
            this.cartTableAdapter.Fill(this.userDBDataSet14.cart);
            // TODO: This line of code loads data into the 'userDBDataSet13.transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter1.Fill(this.userDBDataSet13.transactions);
            // TODO: This line of code loads data into the 'userDBDataSet12.transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.userDBDataSet12.transactions);
            // TODO: This line of code loads data into the 'userDBDataSet9.rideDB' table. You can move, or remove it, as needed.
            this.rideDBTableAdapter1.Fill(this.userDBDataSet9.rideDB);
            // TODO: This line of code loads data into the 'userDBDataSet8.rideDB' table. You can move, or remove it, as needed.
            this.rideDBTableAdapter.Fill(this.userDBDataSet8.rideDB);
            lbladmin.Text = labeladmin;
            lblrole.Text = labelrole;
            string a = "";
            a = "Select * from rideDB";
            function.function.datagridfill(a, dataGridView1);
            dataGridView1.RowTemplate.Height = 340;
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img = (DataGridViewImageColumn)dataGridView1.Columns[5];
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            buyid();
            totalticket();
            income();
            string b = "";
            string c = "";
            b = "Select * from transactions";
            function.function.datagridfill(b, viewtransaction);
            c = "Select * from cart";
            function.function.datagridfill(c, cartdgv);

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btnhome_Click(object sender, EventArgs e)
        {
            label4.Text = "Welcome!";
            lbladmin.Visible = true;
            cart.SelectTab(0);
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblprice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString()+".00";
            lblcapacity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdes.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); 
            byte[] img = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

            cart.SelectTab(2);

        }

        private void Btnuserinfo_Click(object sender, EventArgs e)
        {
            label4.Text = "View Rides";
            lbladmin.Visible = false;
            cart.SelectTab(1);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            cart.SelectTab(1);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void buyid()
        {
            
            connection.connection.DB();
            String gen = "SELECT buyid from buyticket order by buyid";
            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
            function.function.datareader = command.ExecuteReader();
            while (function.function.datareader.Read())
            {
                id = function.function.datareader["buyid"].ToString();
            }
            int i = int.Parse(id);
            i = i + 1;
            ID = i;
            connection.connection.conn.Close();
            function.function.datareader.Close();
        }
        public void totalticket()
        {

            connection.connection.DB();
            String gen = "SELECT totalticketbuy from buyticket order by totalticketbuy";
            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
            function.function.datareader = command.ExecuteReader();
            while (function.function.datareader.Read())
            {
                total = function.function.datareader["totalticketbuy"].ToString();
            }
            int b = int.Parse(total);
            int  x = Convert.ToInt32(totaltickets.Text);
            b = x + b;
            TOTAL = b;
            connection.connection.conn.Close();
            function.function.datareader.Close();
        }
        public void income()
        {

            connection.connection.DB();
            String gen = "SELECT income from buyticket order by income";
            SqlCommand command = new SqlCommand(gen, connection.connection.conn);
            function.function.datareader = command.ExecuteReader();
            while (function.function.datareader.Read())
            {
                Income = function.function.datareader["income"].ToString();
            }
            double c = Double.Parse(Income);
            double v = Convert.ToDouble(totalpayments.Text);
            c = v + c;
            INCOME = c;
            connection.connection.conn.Close();
            function.function.datareader.Close();
        }
        public void Lol()
        {
            buyid();
            totalticket();
            income();
            int sa = Convert.ToInt32(lblprice.Text);
            int sd = Convert.ToInt32(cbb.SelectedItem);

            int sad = sa * sd;
            wew = sad;
        }
        private void Btnbuy_Click(object sender, EventArgs e)
        {
            if (cbb.Text == "Quantity Of Ticket")
            {
                MessageBox.Show("Please Select Quantity of Ticket!");
            }
            else
            {
                try
                {
                    double p = Convert.ToDouble(lblprice.Text);
                    double t = Convert.ToDouble(cbb.Text);
                    double tot = Convert.ToDouble(totaltickets.Text);

                    double result = tot + t;
                    double cartpayment;
                    cartpayment = p * t;
                    totaltickets.Text = result.ToString();

                    double pay = Convert.ToDouble(totalpayments.Text);

                    double payment = (p * t) + pay;
                    connection.connection.DB();
                    String a = "Insert into cart(cartridename,cartquantity,cartpayment)values('" + lblname.Text + "'," + cbb.Text +"," + cartpayment + ")";
                    
                    SqlCommand cmd = new SqlCommand(a, connection.connection.conn);
                    cmd.ExecuteNonQuery();
                    connection.connection.conn.Close();
                    Userform_Load(sender, e);
                    totalpayments.Text = payment.ToString() + ".00";
                    MessageBox.Show("Successfully Added!");
                    cbb.Text = "Quantity Of Ticket";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Txtdes_TextChanged(object sender, EventArgs e)
        {

        }

        private void Info_Click(object sender, EventArgs e)
        {

        }

        private void Txtquan_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            cart.SelectTab(1);
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            connection.connection.DB();
            String a = "Delete from cart";
            SqlCommand command = new SqlCommand(a, connection.connection.conn);
            command.ExecuteNonQuery();
            Userform_Load(sender, e);
            connection.connection.conn.Close();
            Application.Exit(); 

        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            loginform f = new loginform();
            this.Hide();
            f.Show();
            connection.connection.DB();
            String a = "Delete from cart";
            SqlCommand command = new SqlCommand(a, connection.connection.conn);
            command.ExecuteNonQuery();
            Userform_Load(sender, e);
            connection.connection.conn.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cartdgv.Columns[3].Visible = false;
            //dateTimePicker1.Vi = false;
            label4.Text = "View Cart";
            lbladmin.Visible = false;
            cart.SelectTab(4);
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss tt");

            cartdgv.BorderStyle = BorderStyle.None;
            cartdgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            cartdgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            cartdgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            cartdgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            cartdgv.BackgroundColor = Color.White;
            cartdgv.EnableHeadersVisualStyles = false;
            cartdgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            cartdgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            cartdgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Totaltickets_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Lol();
            buyid();
            totalticket();
            income();
            try
            {
                if (totaltickets.Text == "0")
                {
                    MessageBox.Show("Please Select Rides");
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Do You really want to buy " + totaltickets.Text + " Ticket/s for " + totalpayments.Text + " Pesos", "Buy Ticket", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        connection.connection.DB();
                        String gen = "Insert into buyticket(buyid,totalticketbuy,income)values(" + ID + "," + TOTAL + "," + INCOME + ")";
                        String a = "Insert into transactions(transacid,transacuser,date,time,tickets,payments)values(" + ID + ",'" + lbladmin.Text + "','" + dateTimePicker1.Text + "','" + lbltime.Text + "'," + totaltickets.Text + "," + totalpayments.Text + ")";
                        String b = "Delete from cart";
                        SqlCommand cmd1 = new SqlCommand(b, connection.connection.conn);
                        SqlCommand command = new SqlCommand(gen, connection.connection.conn);
                        SqlCommand cmd = new SqlCommand(a, connection.connection.conn);
                        cmd1.ExecuteNonQuery();
                        command.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You have Successfully buy a ticket!");
                        connection.connection.conn.Close();
                        Userform_Load(sender, e);
                        cart.SelectTab(3);
                        totaltickets.Text = "0";
                        totalpayments.Text = "0";

                    }
                    else if (dialog == DialogResult.No)
                    {
                        MessageBox.Show("OK", "Buy Ticket", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (totaltickets.Text == "0")
            {
                MessageBox.Show("Your Cart is Empty");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Do You really want to to Cancel?", "Buy Ticket", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    totaltickets.Text = "0";
                    totalpayments.Text = "0.00";
                    connection.connection.DB();
                    String a = "Delete from cart";
                    SqlCommand command = new SqlCommand(a, connection.connection.conn);
                    command.ExecuteNonQuery();
                    Userform_Load(sender, e);
                    connection.connection.conn.Close();
                }
                else if (dialog == DialogResult.No)
                {
                    MessageBox.Show("OK", "Buy Ticket", MessageBoxButtons.OK);
                }
            }
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                string gen = "Select * from transactions where transacuser LIKE" + "'" + lbladmin.Text + "%'";
                function.function.datagridfill(gen, viewtransaction);
                connection.connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            viewtransaction.Columns[0].Visible = false;
            viewtransaction.Sort(viewtransaction.Columns[0], ListSortDirection.Descending);
            label4.Text = "Your Transaction History";
            lbladmin.Visible = false;
            cart.SelectTab(5);

            viewtransaction.BorderStyle = BorderStyle.None;
            viewtransaction.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            viewtransaction.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            viewtransaction.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            viewtransaction.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            viewtransaction.BackgroundColor = Color.White;
            viewtransaction.EnableHeadersVisualStyles = false;
            viewtransaction.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            viewtransaction.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            viewtransaction.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Lbladmin_Click(object sender, EventArgs e)
        {

        }

        private void Lbladmin_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Lbltime_Click(object sender, EventArgs e)
        {

        }

        private void Blb_Click(object sender, EventArgs e)
        {

        }

        private void Txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                string q = "Select * from rideDB where ridename LIKE" + "'" + txtsearch.Text + "%'";
                function.function.datagridfill(q, dataGridView1);
                connection.connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Cartdgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            lblusercart.Text = cartdgv[0, e.RowIndex].Value.ToString();
            lblticket.Text = cartdgv[1, e.RowIndex].Value.ToString();
            lblpayment.Text = cartdgv[2, e.RowIndex].Value.ToString();
            lblcartid.Text = cartdgv[3, e.RowIndex].Value.ToString();


        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Lblprice_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            if(totaltickets.Text == "0" || lblticket.Text == "0")
            {
                MessageBox.Show("Please Select Ride to Remove");
            }
            else
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Do You really want to remove this ride ?", "Delete Record", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        double tic = Convert.ToDouble(lblticket.Text);
                        double pay = Convert.ToDouble(lblpayment.Text);
                        double carttic = Convert.ToDouble(totaltickets.Text);
                        double ticket;
                        double payments1;

                        ticket = carttic - tic;

                        totaltickets.Text = ticket.ToString();

                        double payments = Convert.ToDouble(totalpayments.Text);

                        payments1 = payments - pay;

                        totalpayments.Text = payments1.ToString() + ".00";

                        connection.connection.DB();
                        String a = "Delete cart where cartid = " + lblcartid.Text + "";
                        SqlCommand command = new SqlCommand(a, connection.connection.conn);
                        command.ExecuteNonQuery();
                        lblticket.Text = "0";
                        MessageBox.Show("Successfully Removed!");
                        Userform_Load(sender, e);
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
        }

        private void Cartdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
