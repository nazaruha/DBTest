﻿using Bogus;
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
            GenerateUsers(10);
            GenerateUserPasswords();

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
            string[] tables = { "tblRegions.sql", "tblCities.sql", "tblRoles.sql", "tblUsers.sql", "tblUserPasswords.sql", "tblUserRoles.sql", "tblUserAdresses.sql" };
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

            List<User> users = new List<User>();
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

            MessageBox.Show("END");
        }

        private List<User> GetUsers()
        {
            cmd.CommandText = "SELECT * " +
                "FROM tblUsers ";
            List<User> users = new List<User>();
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
            List<User> users = GetUsers();
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
    }

}