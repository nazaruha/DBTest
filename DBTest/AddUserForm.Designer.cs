namespace DBTest
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lb_Password = new System.Windows.Forms.Label();
            this.lb_Name = new System.Windows.Forms.Label();
            this.Error_pswrd = new System.Windows.Forms.Label();
            this.cb_Region = new System.Windows.Forms.ComboBox();
            this.lb_Region = new System.Windows.Forms.Label();
            this.lb_City = new System.Windows.Forms.Label();
            this.cb_City = new System.Windows.Forms.ComboBox();
            this.lb_Role = new System.Windows.Forms.Label();
            this.cb_Role = new System.Windows.Forms.ComboBox();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.TotalErrors = new System.Windows.Forms.Label();
            this.lb_Street = new System.Windows.Forms.Label();
            this.txt_Street = new System.Windows.Forms.TextBox();
            this.lb_HouseNumber = new System.Windows.Forms.Label();
            this.txt_HouseNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_Name.Location = new System.Drawing.Point(97, 20);
            this.txt_Name.Multiline = true;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(268, 41);
            this.txt_Name.TabIndex = 1;
            this.txt_Name.TextChanged += new System.EventHandler(this.txt_PswrdAndName_TextChanged);
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_Password.Location = new System.Drawing.Point(525, 20);
            this.txt_Password.Multiline = true;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(268, 41);
            this.txt_Password.TabIndex = 2;
            this.txt_Password.TextChanged += new System.EventHandler(this.txt_PswrdAndName_TextChanged);
            // 
            // lb_Password
            // 
            this.lb_Password.AutoSize = true;
            this.lb_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Password.Location = new System.Drawing.Point(395, 24);
            this.lb_Password.Name = "lb_Password";
            this.lb_Password.Size = new System.Drawing.Size(135, 29);
            this.lb_Password.TabIndex = 0;
            this.lb_Password.Text = "Password:";
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Name.Location = new System.Drawing.Point(12, 24);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(89, 29);
            this.lb_Name.TabIndex = 0;
            this.lb_Name.Text = "Name:";
            // 
            // Error_pswrd
            // 
            this.Error_pswrd.AutoSize = true;
            this.Error_pswrd.ForeColor = System.Drawing.Color.IndianRed;
            this.Error_pswrd.Location = new System.Drawing.Point(528, 68);
            this.Error_pswrd.Name = "Error_pswrd";
            this.Error_pswrd.Size = new System.Drawing.Size(95, 20);
            this.Error_pswrd.TabIndex = 2;
            this.Error_pswrd.Text = "Error_pswrd";
            this.Error_pswrd.Visible = false;
            // 
            // cb_Region
            // 
            this.cb_Region.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_Region.FormattingEnabled = true;
            this.cb_Region.Location = new System.Drawing.Point(17, 168);
            this.cb_Region.Name = "cb_Region";
            this.cb_Region.Size = new System.Drawing.Size(375, 37);
            this.cb_Region.TabIndex = 3;
            this.cb_Region.SelectedIndexChanged += new System.EventHandler(this.cb_Region_SelectedIndexChanged);
            // 
            // lb_Region
            // 
            this.lb_Region.AutoSize = true;
            this.lb_Region.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Region.Location = new System.Drawing.Point(156, 136);
            this.lb_Region.Name = "lb_Region";
            this.lb_Region.Size = new System.Drawing.Size(97, 29);
            this.lb_Region.TabIndex = 0;
            this.lb_Region.Text = "Region";
            // 
            // lb_City
            // 
            this.lb_City.AutoSize = true;
            this.lb_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_City.Location = new System.Drawing.Point(579, 136);
            this.lb_City.Name = "lb_City";
            this.lb_City.Size = new System.Drawing.Size(57, 29);
            this.lb_City.TabIndex = 0;
            this.lb_City.Text = "City";
            // 
            // cb_City
            // 
            this.cb_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_City.FormattingEnabled = true;
            this.cb_City.Location = new System.Drawing.Point(418, 168);
            this.cb_City.Name = "cb_City";
            this.cb_City.Size = new System.Drawing.Size(375, 37);
            this.cb_City.TabIndex = 4;
            // 
            // lb_Role
            // 
            this.lb_Role.AutoSize = true;
            this.lb_Role.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Role.Location = new System.Drawing.Point(371, 384);
            this.lb_Role.Name = "lb_Role";
            this.lb_Role.Size = new System.Drawing.Size(68, 29);
            this.lb_Role.TabIndex = 0;
            this.lb_Role.Text = "Role";
            // 
            // cb_Role
            // 
            this.cb_Role.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_Role.FormattingEnabled = true;
            this.cb_Role.Location = new System.Drawing.Point(312, 416);
            this.cb_Role.Name = "cb_Role";
            this.cb_Role.Size = new System.Drawing.Size(200, 37);
            this.cb_Role.TabIndex = 7;
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_AddUser.FlatAppearance.BorderSize = 10;
            this.btn_AddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddUser.Location = new System.Drawing.Point(231, 564);
            this.btn_AddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(359, 72);
            this.btn_AddUser.TabIndex = 8;
            this.btn_AddUser.Text = "Add User";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // TotalErrors
            // 
            this.TotalErrors.AutoSize = true;
            this.TotalErrors.ForeColor = System.Drawing.Color.IndianRed;
            this.TotalErrors.Location = new System.Drawing.Point(239, 654);
            this.TotalErrors.Name = "TotalErrors";
            this.TotalErrors.Size = new System.Drawing.Size(87, 20);
            this.TotalErrors.TabIndex = 2;
            this.TotalErrors.Text = "TotalErrors";
            this.TotalErrors.Visible = false;
            // 
            // lb_Street
            // 
            this.lb_Street.AutoSize = true;
            this.lb_Street.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Street.Location = new System.Drawing.Point(12, 295);
            this.lb_Street.Name = "lb_Street";
            this.lb_Street.Size = new System.Drawing.Size(90, 29);
            this.lb_Street.TabIndex = 0;
            this.lb_Street.Text = "Street:";
            // 
            // txt_Street
            // 
            this.txt_Street.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_Street.Location = new System.Drawing.Point(100, 295);
            this.txt_Street.Multiline = true;
            this.txt_Street.Name = "txt_Street";
            this.txt_Street.Size = new System.Drawing.Size(268, 41);
            this.txt_Street.TabIndex = 5;
            this.txt_Street.TextChanged += new System.EventHandler(this.txt_PswrdAndName_TextChanged);
            // 
            // lb_HouseNumber
            // 
            this.lb_HouseNumber.AutoSize = true;
            this.lb_HouseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_HouseNumber.Location = new System.Drawing.Point(374, 295);
            this.lb_HouseNumber.Name = "lb_HouseNumber";
            this.lb_HouseNumber.Size = new System.Drawing.Size(149, 29);
            this.lb_HouseNumber.TabIndex = 0;
            this.lb_HouseNumber.Text = "HouseNum:";
            // 
            // txt_HouseNum
            // 
            this.txt_HouseNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_HouseNum.Location = new System.Drawing.Point(527, 291);
            this.txt_HouseNum.Multiline = true;
            this.txt_HouseNum.Name = "txt_HouseNum";
            this.txt_HouseNum.Size = new System.Drawing.Size(268, 41);
            this.txt_HouseNum.TabIndex = 6;
            this.txt_HouseNum.TextChanged += new System.EventHandler(this.txt_PswrdAndName_TextChanged);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 852);
            this.Controls.Add(this.btn_AddUser);
            this.Controls.Add(this.cb_City);
            this.Controls.Add(this.cb_Role);
            this.Controls.Add(this.cb_Region);
            this.Controls.Add(this.TotalErrors);
            this.Controls.Add(this.Error_pswrd);
            this.Controls.Add(this.lb_HouseNumber);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.lb_Password);
            this.Controls.Add(this.lb_City);
            this.Controls.Add(this.lb_Role);
            this.Controls.Add(this.txt_HouseNum);
            this.Controls.Add(this.txt_Street);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lb_Street);
            this.Controls.Add(this.lb_Region);
            this.Controls.Add(this.lb_Name);
            this.Name = "AddUserForm";
            this.Text = "AddUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lb_Password;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Label Error_pswrd;
        private System.Windows.Forms.ComboBox cb_Region;
        private System.Windows.Forms.Label lb_Region;
        private System.Windows.Forms.Label lb_City;
        private System.Windows.Forms.ComboBox cb_City;
        private System.Windows.Forms.Label lb_Role;
        private System.Windows.Forms.ComboBox cb_Role;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Label TotalErrors;
        private System.Windows.Forms.Label lb_Street;
        private System.Windows.Forms.TextBox txt_Street;
        private System.Windows.Forms.Label lb_HouseNumber;
        private System.Windows.Forms.TextBox txt_HouseNum;
    }
}