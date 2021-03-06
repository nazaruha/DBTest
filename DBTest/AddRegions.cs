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
    public partial class AddRegions : Form
    {
        SqlCommand sqlCommand;
        SqlConnection sqlConnection;
        string dbName = "UsersRolesCities";
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
        public AddRegions()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            DataTable dt_regions = Select($"SELECT * FROM [dbo].[tblRegions]");
            
            SqlConnection con = new SqlConnection($"server=DESKTOP-GBJ31QG;Trusted_Connection=Yes;DataBase={dbName};");
            SqlCommand sqlCommand2 = con.CreateCommand();
            int flag = -1;
            
            for (int i = 0; i < dt_regions.Rows.Count; i++)
            {
                if (Convert.ToString(dt_regions.Rows[i][1]) == name.Text)
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                MessageBox.Show($"Oops, {name.Text} already exists in the database [{dbName}]");
            }
            else
            {
                con.Open();
                sqlCommand2 = con.CreateCommand();
                sqlCommand2.CommandText = "INSERT INTO dbo.tblRegions " +
                                   "(Name) " +
                                   $"VALUES('{name.Text}')";
                sqlCommand2.ExecuteNonQuery();
                this.Close();
            }
        }
    }
}
