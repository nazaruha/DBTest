using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTest
{
    public partial class Form1 : Form
    {
        private string dirSql = "SqlTables";
        private string dbName = "UsersRolesCities";
        private SqlConnection con;
        private SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_GenerateTables_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=.;Integrated Security=True;";
            string connectionStr = $"{conStr}Initial Catalog={dbName}";

            con = new SqlConnection(conStr);
            con.Open();
            if (!IsDatabaseExist())
            {
                cmd.CommandText = $"CREATE DATABASE {dbName}";
                cmd.ExecuteNonQuery();
            }
            con = new SqlConnection(connectionStr);
            con.Open();
            cmd = con.CreateCommand();

            GenerateTables();
        }

        private bool IsDatabaseExist()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT name FROM master.sys.databases";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["name"].ToString() == dbName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void GenerateTables()
        {
            string[] tables = { "tblRegions.sql", "tblCities.sql", "tblRoles.sql", "tblUsers.sql", "tblUserRoles.sql", "tblUserAdresses.sql" };
            foreach (var table in tables)
            {
                ExecuteCommandFromFile(table);
            }
        }

        private void ExecuteCommandFromFile(string file)
        {
            string sql = ReadSqlFile(file);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        private string ReadSqlFile(string file)
        {
            string sql = File.ReadAllText($"{dirSql}\\{file}");
            return sql;
        }

        private void addCity_Click(object sender, EventArgs e)
        {
            AddCities addCities = new AddCities();
            addCities.ShowDialog();
        }
    }
}
