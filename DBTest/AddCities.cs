using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTest
{
    public partial class AddCities : Form
    {
        SqlCommand sqlCommand;
        SqlConnection sqlConnection;
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");
            //Window1 win = new Window1();
            //MessageBox.Show("Enter a name of the DB you want to connect with");

            //win.ShowDialog();
            //string dbname = win.Name;
            sqlConnection = new SqlConnection($"server=DESKTOP-GBJ31QG;Trusted_Connection=Yes;DataBase=UsersRolesCities;");
            sqlConnection.Open();
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        List<string> regions_list = new List<string>();
        public AddCities()
        {
            InitializeComponent();
            DataTable dt_regions = Select($"SELECT * FROM [dbo].[tblRegions]");
            for (int i = 0; i < dt_regions.Rows.Count; i++)
            {
                string r = Convert.ToString(dt_regions.Rows[i][1]);
                regions_list.Add(r);
            }
            regions.DataSource = regions_list;
        }

        private void add_Click(object sender, EventArgs e)
        {

        }
    }
}
