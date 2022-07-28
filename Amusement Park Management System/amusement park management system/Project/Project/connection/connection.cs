using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project.connection
{
    class connection
    {
        public static SqlConnection conn;
        private static string dbconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\old codes\\amusement park management system\\Project\\Project\\UserDB.mdf;Integrated Security=True";

        public static void DB()
        {
            try
            {
                conn = new SqlConnection(dbconnect);
                conn.Open();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
