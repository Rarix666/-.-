
namespace Rushan.Kursach
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.Vihod3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Jeton_B = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Vnos_B = new System.Windows.Forms.Button();
            this.ZP_I = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Update_B = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Vihod3
            // 
            this.Vihod3.Location = new System.Drawing.Point(12, 408);
            this.Vihod3.Name = "Vihod3";
            this.Vihod3.Size = new System.Drawing.Size(75, 23);
            this.Vihod3.TabIndex = 17;
            this.Vihod3.Text = "Выйти";
            this.Vihod3.UseVisualStyleBackColor = true;
            this.Vihod3.Click += new System.EventHandler(this.Vihod3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox2.Controls.Add(this.Jeton_B);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Vnos_B);
            this.groupBox2.Controls.Add(this.ZP_I);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Update_B);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 377);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // Jeton_B
            // 
            this.Jeton_B.FormattingEnabled = true;
            this.Jeton_B.Location = new System.Drawing.Point(95, 122);
            this.Jeton_B.Name = "Jeton_B";
            this.Jeton_B.Size = new System.Drawing.Size(99, 21);
            this.Jeton_B.TabIndex = 16;
            this.Jeton_B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Jeton_B_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(33, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Зарплата";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(7, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Номер жетона";
            // 
            // Vnos_B
            // 
            this.Vnos_B.Location = new System.Drawing.Point(58, 205);
            this.Vnos_B.Name = "Vnos_B";
            this.Vnos_B.Size = new System.Drawing.Size(75, 23);
            this.Vnos_B.TabIndex = 13;
            this.Vnos_B.Text = "Внести";
            this.Vnos_B.UseVisualStyleBackColor = true;
            this.Vnos_B.Click += new System.EventHandler(this.Vnos_B_Click);
            // 
            // ZP_I
            // 
            this.ZP_I.Location = new System.Drawing.Point(94, 171);
            this.ZP_I.MaxLength = 6;
            this.ZP_I.Name = "ZP_I";
            this.ZP_I.Size = new System.Drawing.Size(100, 20);
            this.ZP_I.TabIndex = 12;
            this.ZP_I.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZP_I_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(43, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Назначение З/П";
            // 
            // Update_B
            // 
            this.Update_B.Location = new System.Drawing.Point(151, 205);
            this.Update_B.Name = "Update_B";
            this.Update_B.Size = new System.Drawing.Size(75, 23);
            this.Update_B.TabIndex = 5;
            this.Update_B.Text = "Обновить";
            this.Update_B.UseVisualStyleBackColor = true;
            this.Update_B.Click += new System.EventHandler(this.Update_B_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(277, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 377);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(204, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Заработная плата";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(543, 312);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(877, 437);
            this.Controls.Add(this.Vihod3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Бухгалтерия";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Vihod3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Vnos_B;
        private System.Windows.Forms.TextBox ZP_I;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Update_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Jeton_B;
    }
}