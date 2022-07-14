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
    public partial class AddUserForm : Form
    {
        SqlCommand cmd;
        public AddUserForm(SqlCommand cmd)
        {
            this.cmd = cmd;
            InitializeComponent();
            cb_Region.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_City.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Role.DropDownStyle = ComboBoxStyle.DropDownList;
            GetRegions();
            GetRoles();
        }

        private void txt_PswrdAndName_TextChanged(object sender, EventArgs e)
        {
            if (txt_Password.Text.Length > 20)
            {
                Error_pswrd.Text = "Too many symbols";
                Error_pswrd.Visible = true;
            }
            else if (!String.IsNullOrWhiteSpace(txt_Name.Text) && !String.IsNullOrWhiteSpace(txt_Password.Text))
            {
                cmd.CommandText = "SELECT u.[Name], up.[Password] " +
                "FROM tblUserPasswords AS up " +
                "LEFT JOIN tblUsers AS u " +
                "ON up.UserId = u.Id " +
                @"WHERE u.[Name] = @NameField AND up.[Password] = @PasswordField";
                cmd.Parameters.AddWithValue("@NameField", txt_Name.Text);
                cmd.Parameters.AddWithValue("@PasswordField", txt_Password.Text);
                SqlDataReader reader = null;
                try
                {
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader["Name"] != null && reader["Password"] != null)
                    {
                        Error_pswrd.Text = "Password is occupied";
                        Error_pswrd.Visible = true;
                    }
                }
                catch
                {
                    Error_pswrd.Visible = false;
                }
                if (reader != null)
                    reader.Close();
                cmd.Parameters.Clear();
            }
            else
            {
                Error_pswrd.Visible = false;
            }
        }

        private void GetRegions()
        {
            cmd.CommandText = "SELECT Name " +
                "FROM tblRegions";

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cb_Region.Items.Add(reader["Name"].ToString());
                }
            }
        }

        private int GetRegionId(string region)
        {
            int id = 0;
            cmd.CommandText = "SELECT Id " +
                "FROM tblRegions " +
                @"WHERE Name = @RegionName";
            cmd.Parameters.AddWithValue("@RegionName", region);
            var reader = cmd.ExecuteReader();
            reader.Read();
            id = Int32.Parse(reader["Id"].ToString());
            reader.Close();
            cmd.Parameters.Clear();
            return id;
        }

        private void GetCities()
        {
            if (cb_Region.SelectedIndex == -1) return;
            int regionId = GetRegionId(cb_Region.SelectedItem.ToString());
            cmd.CommandText = "SELECT Name " +
                "FROM tblCities " +
                @"WHERE RegionId = @Id";
            cmd.Parameters.AddWithValue("@Id", regionId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cb_City.Items.Add(reader["Name"].ToString());
                }
            }
            cmd.Parameters.Clear();
        }
        
        private void GetRoles()
        {
            cmd.CommandText = "SELECT Name " +
                "FROM tblRoles";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cb_Role.Items.Add(reader["Name"].ToString());
                }
            }
        }

        private void cb_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_City.Items.Clear();
            cb_City.Text = "";
            GetCities();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            if (!CheckInputedData())
                return;

            AddName();

            int lastUserId = GetUserId_InLastRow();
            AddPassword(lastUserId);

            int roleId = GetRoleId();
            AddRole(lastUserId, roleId);

            int cityId = GetCityId();
            AddAddress(lastUserId, cityId);

            ClearForm();
            MessageBox.Show("User is added!", "SUCCESS", MessageBoxButtons.OK);
        }

        private bool CheckInputedData()
        {
            TotalErrors.Text = "";
            if (String.IsNullOrWhiteSpace(txt_Name.Text))
                TotalErrors.Text += "* Input name\n";

            if (String.IsNullOrWhiteSpace(txt_Password.Text))
                TotalErrors.Text += "* Input password\n";
            else if (Error_pswrd.Visible == true)
                TotalErrors.Text += "* Change password\n";

            if (cb_Region.SelectedIndex == -1)
                TotalErrors.Text += "* Choose region and city\n";
            else if (cb_City.SelectedIndex == -1)
                TotalErrors.Text += "* Choose city\n";

            if (String.IsNullOrWhiteSpace(txt_Street.Text))
                TotalErrors.Text += "* Input street\n";
            if (String.IsNullOrWhiteSpace(txt_HouseNum.Text))
                TotalErrors.Text += "* Input house number\n";

            if (cb_Role.SelectedIndex == -1)
                TotalErrors.Text += "* Choose role\n";

            if (TotalErrors.Text == "")
            {
                TotalErrors.Visible = false;
                return true;
            }
            TotalErrors.Visible = true;
            return false;
        }

        private int GetUserId_InLastRow()
        {
            cmd.CommandText = "SELECT TOP 1 Id " +
                "FROM tblUsers " +
                "ORDER BY Id DESC"; // get user's id in the last row

            int lastUserId;
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                lastUserId = Int32.Parse(reader["Id"].ToString());
            }

            return lastUserId;
        }

        private int GetRoleId()
        {
            cmd.CommandText = "SELECT Id " +
                "FROM tblRoles " +
                @"WHERE Name = @RoleName";
            cmd.Parameters.AddWithValue("@RoleName", cb_Role.SelectedItem.ToString());

            int roleId;
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                roleId = Int32.Parse(reader["Id"].ToString());
            }
            cmd.Parameters.Clear();
            return roleId;
        }

        private int GetCityId()
        {
            cmd.CommandText = "SELECT Id " +
                "FROM tblCities " +
                "WHERE Name = @NameById";
            cmd.Parameters.AddWithValue("@NameById", cb_City.SelectedItem.ToString());

            int cityId;
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                cityId = Int32.Parse(reader["Id"].ToString());
            }
            cmd.Parameters.Clear();
            return cityId;
        }

        private void AddName()
        {
            cmd.CommandText = "INSERT INTO tblUsers([Name]) " +
                @"VALUES (@Name) ";
            cmd.Parameters.AddWithValue("@Name", txt_Name.Text);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        private void AddPassword(int lastUserId)
        {
            cmd.CommandText = "INSERT INTO tblUserPasswords(UserId, Password) " +
                @"VALUES (@UserId, @Password)";
            cmd.Parameters.AddWithValue("@UserId", lastUserId);
            cmd.Parameters.AddWithValue("@Password", txt_Password.Text);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }

        private void AddRole(int lastUserId, int roleId)
        {
            cmd.CommandText = "INSERT INTO tblUserRoles(UserId, RoleId) " +
                @"VALUES (@UserId, @RoleId)";
            cmd.Parameters.AddWithValue("@UserId", lastUserId);
            cmd.Parameters.AddWithValue("@RoleId", roleId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        private void AddAddress(int lastUserId, int cityId)
        {
            cmd.CommandText = "INSERT INTO tblUserAddresses(UserId, CityId, Street, HouseNumber) " +
                @"VALUES (@UserId, @CityId, @Street, @HouseNumber)";
            cmd.Parameters.AddWithValue("@UserId", lastUserId);
            cmd.Parameters.AddWithValue("@CityId", cityId);
            cmd.Parameters.AddWithValue("@Street", txt_Street.Text);
            cmd.Parameters.AddWithValue("@HouseNumber", txt_HouseNum.Text);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        private void ClearForm()
        {
            txt_Name.Clear();
            txt_Password.Clear();
            txt_Street.Clear();
            txt_HouseNum.Clear();
            cb_Region.SelectedIndex = -1;
            cb_City.SelectedIndex = -1;
            cb_Role.SelectedIndex = -1;
        }

    }
}
