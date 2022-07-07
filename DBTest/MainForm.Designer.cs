namespace DBTest
{
    partial class MainForm
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
            this.btn_GenerateTables = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GenerateTables
            // 
            this.btn_GenerateTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_GenerateTables.Location = new System.Drawing.Point(525, 379);
            this.btn_GenerateTables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GenerateTables.Name = "btn_GenerateTables";
            this.btn_GenerateTables.Size = new System.Drawing.Size(252, 58);
            this.btn_GenerateTables.TabIndex = 0;
            this.btn_GenerateTables.Text = "Generate Tables";
            this.btn_GenerateTables.UseVisualStyleBackColor = true;
            this.btn_GenerateTables.Click += new System.EventHandler(this.btn_GenerateTables_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 447);
            this.Controls.Add(this.btn_GenerateTables);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GenerateTables;
    }
}

