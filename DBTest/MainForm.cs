using Bogus;
using DBTest.Models;
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
    public partial class MainForm : Form
    {
        private string dirSql = "SqlTables";
        private string dbName = "UsersRolesCities";
        private SqlConnection con;
        private SqlCommand cmd;
        private List<User> users = new List<User>();
        public MainForm()
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
            GenerateUsers(10);
            GenerateUserPasswords();
            GenerateUserRoles();
            GenerateUserAddresses();
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
            string[] tables = { "tblRegions.sql", "tblCities.sql", "tblRoles.sql", "tblUsers.sql", "tblUserPasswords.sql", "tblUserRoles.sql", "tblUserAddresses.sql" };
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

        private void GenerateUsers(int count = 1000000)
        {
            Faker<User> faker = new Faker<User>("uk")
                .RuleFor(u => u.Name, (f, u) => f.Name.FullName());

            for (int i = 0; i < count; i++)
            {
                var user = faker.Generate();
                users.Add(user);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn(nameof(User.Id)));
            dt.Columns.Add(new DataColumn(nameof(User.Name)));

            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                int r = rnd.Next(0, count);
                var user = users[r];
                DataRow row = dt.NewRow();
                row[nameof(User.Id)] = user.Id;
                row[nameof(User.Name)] = user.Name;
                dt.Rows.Add(row);
            }
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
            {
                bulkCopy.DestinationTableName = "tblUsers";
                bulkCopy.WriteToServer(dt);
            }
        }

        private List<User> GetUsers()
        {
            users.Clear();
            cmd.CommandText = "SELECT * " +
                "FROM tblUsers ";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var user = new User() { Id = Int32.Parse(reader["Id"].ToString()), Name = reader["Name"].ToString() };
                    users.Add(user);
                }
            }
            return users;
        }

        private void GenerateUserPasswords()
        {
            Faker faker = new Faker();
            for (int i = 0; i < users.Count; i++)
            {
                string password = faker.Internet.Password();
                if (users.Any(u => u.Password == password))
                    i--;
                else
                    users[i].Password = password;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn(nameof(User.Id)));
            dt.Columns.Add(new DataColumn(nameof(User.Password)));

            for (int i = 0; i < users.Count; i++)
            {
                DataRow row = dt.NewRow();
                row[nameof(User.Id)] = users[i].Id;
                row[nameof(User.Password)] = users[i].Password;
                dt.Rows.Add(row);
            }
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
            {
                bulkCopy.DestinationTableName = "tblUserPasswords";
                bulkCopy.WriteToServer(dt);
            }
        }
        private void GenerateUserRoles()
        {
            List<int> roleIds = GetRoleId();
            Random rnd = new Random();
            for (int i = 0; i < users.Count; i++)
            {
                int r = rnd.Next(0, roleIds.Count - 1);
                users[i].RoleId = roleIds[r];
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("UserId");
            dt.Columns.Add(new DataColumn(nameof(User.RoleId)));

            for (int i = 0; i < users.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["UserId"] = users[i].Id;
                row[nameof(User.RoleId)] = users[i].RoleId;
                dt.Rows.Add(row);
            }
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
            {
                bulkCopy.DestinationTableName = "tblUserRoles";
                bulkCopy.WriteToServer(dt);
            }
        }

        private List<int> GetRoleId()
        {
            cmd.CommandText = "SELECT r.Id " +
                "FROM tblRoles AS r";

            List<int> roleIds = new List<int>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    roleIds.Add(Int32.Parse(reader["Id"].ToString()));
                }
            }
            return roleIds;
        }

        private void GenerateUserAddresses()
        {
            Faker faker = new Faker();
            List<int> cityIds = GetCityId();

            Random rnd = new Random();
            for (int i = 0; i < users.Count; i++)
            {
                int r = rnd.Next(0, cityIds.Count - 1);
                users[i].CityId = cityIds[r];
                users[i].Street = faker.Address.StreetAddress();
                users[i].HouseNumber = faker.Address.BuildingNumber();
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("UserId");
            dt.Columns.Add(new DataColumn(nameof(User.CityId)));
            dt.Columns.Add("Street");
            dt.Columns.Add("HouseNumber");

            for (int i = 0; i < users.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["UserId"] = users[i].Id;
                row[nameof(User.CityId)] = users[i].CityId;
                row["Street"] = users[i].Street;
                row["HouseNumber"] = users[i].HouseNumber;
                dt.Rows.Add(row);
            }
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
            {
                bulkCopy.DestinationTableName = "tblUserAddresses";
                bulkCopy.WriteToServer(dt);
            }

        }

        private List<int> GetCityId()
        {
            cmd.CommandText = "SELECT c.Id " +
                "FROM tblCities AS c";

            List<int> cityIds = new List<int>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cityIds.Add(Int32.Parse(reader["Id"].ToString()));
                }
            }
            return cityIds;
        }

    }

}