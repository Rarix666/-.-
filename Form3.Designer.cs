
namespace Rushan.Kursach
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.Vihod2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Delete_Pols = new System.Windows.Forms.Button();
            this.Create_Pols = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Dostup_I = new System.Windows.Forms.ComboBox();
            this.Password_C = new System.Windows.Forms.TextBox();
            this.Jeton_C = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Vihod2
            // 
            this.Vihod2.Location = new System.Drawing.Point(26, 306);
            this.Vihod2.Name = "Vihod2";
            this.Vihod2.Size = new System.Drawing.Size(75, 23);
            this.Vihod2.TabIndex = 43;
            this.Vihod2.Text = "Выйти";
            this.Vihod2.UseVisualStyleBackColor = true;
            this.Vihod2.Click += new System.EventHandler(this.Vihod2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(339, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(315, 270);
            this.dataGridView1.TabIndex = 42;
            // 
            // Delete_Pols
            // 
            this.Delete_Pols.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_Pols.Location = new System.Drawing.Point(183, 205);
            this.Delete_Pols.Name = "Delete_Pols";
            this.Delete_Pols.Size = new System.Drawing.Size(75, 23);
            this.Delete_Pols.TabIndex = 40;
            this.Delete_Pols.Text = "Удалить";
            this.Delete_Pols.UseVisualStyleBackColor = false;
            this.Delete_Pols.Click += new System.EventHandler(this.Delete_Pols_Click);
            // 
            // Create_Pols
            // 
            this.Create_Pols.Location = new System.Drawing.Point(75, 205);
            this.Create_Pols.Name = "Create_Pols";
            this.Create_Pols.Size = new System.Drawing.Size(83, 23);
            this.Create_Pols.TabIndex = 38;
            this.Create_Pols.Text = "Создать";
            this.Create_Pols.UseVisualStyleBackColor = true;
            this.Create_Pols.Click += new System.EventHandler(this.Create_Pols_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(37, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Доступ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(36, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(41, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Жетон";
            // 
            // Dostup_I
            // 
            this.Dostup_I.FormattingEnabled = true;
            this.Dostup_I.Items.AddRange(new object[] {
            "Командующий",
            "Бухгалтер",
            "Хирург",
            "Психиатр",
            "Офтальмолог",
            "Глав.Врач"});
            this.Dostup_I.Location = new System.Drawing.Point(93, 157);
            this.Dostup_I.Name = "Dostup_I";
            this.Dostup_I.Size = new System.Drawing.Size(165, 21);
            this.Dostup_I.TabIndex = 33;
            // 
            // Password_C
            // 
            this.Password_C.Location = new System.Drawing.Point(93, 114);
            this.Password_C.Name = "Password_C";
            this.Password_C.Size = new System.Drawing.Size(165, 20);
            this.Password_C.TabIndex = 32;
            // 
            // Jeton_C
            // 
            this.Jeton_C.Location = new System.Drawing.Point(93, 70);
            this.Jeton_C.MaxLength = 5;
            this.Jeton_C.Name = "Jeton_C";
            this.Jeton_C.Size = new System.Drawing.Size(165, 20);
            this.Jeton_C.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(102, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Регистрация";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(426, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 24);
            this.label5.TabIndex = 44;
            this.label5.Text = "Пользователи";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(666, 345);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Vihod2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Delete_Pols);
            this.Controls.Add(this.Create_Pols);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dostup_I);
            this.Controls.Add(this.Password_C);
            this.Controls.Add(this.Jeton_C);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Администратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Vihod2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Delete_Pols;
        private System.Windows.Forms.Button Create_Pols;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Dostup_I;
        private System.Windows.Forms.TextBox Password_C;
        private System.Windows.Forms.TextBox Jeton_C;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}