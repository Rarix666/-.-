
namespace Rushan.Kursach
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label4 = new System.Windows.Forms.Label();
            this.Vhod = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.TextBox();
            this.Jetonchik = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Glaz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(93, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Пароль:";
            // 
            // Vhod
            // 
            this.Vhod.BackColor = System.Drawing.Color.Transparent;
            this.Vhod.Location = new System.Drawing.Point(209, 178);
            this.Vhod.Name = "Vhod";
            this.Vhod.Size = new System.Drawing.Size(112, 23);
            this.Vhod.TabIndex = 21;
            this.Vhod.Text = "Войти";
            this.Vhod.UseVisualStyleBackColor = false;
            this.Vhod.Click += new System.EventHandler(this.Vhod_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(35, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Номер жетона:";
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(177, 136);
            this.Pass.Name = "Pass";
            this.Pass.PasswordChar = '*';
            this.Pass.Size = new System.Drawing.Size(178, 20);
            this.Pass.TabIndex = 18;
            // 
            // Jetonchik
            // 
            this.Jetonchik.Location = new System.Drawing.Point(177, 103);
            this.Jetonchik.MaxLength = 5;
            this.Jetonchik.Name = "Jetonchik";
            this.Jetonchik.Size = new System.Drawing.Size(178, 20);
            this.Jetonchik.TabIndex = 17;
            this.Jetonchik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Jetonchik_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(193, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Авторизация";
            // 
            // button_Glaz
            // 
            this.button_Glaz.BackColor = System.Drawing.Color.Transparent;
            this.button_Glaz.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Glaz.BackgroundImage")));
            this.button_Glaz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Glaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Glaz.Location = new System.Drawing.Point(361, 134);
            this.button_Glaz.Name = "button_Glaz";
            this.button_Glaz.Size = new System.Drawing.Size(28, 23);
            this.button_Glaz.TabIndex = 23;
            this.button_Glaz.UseVisualStyleBackColor = false;
            this.button_Glaz.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(504, 353);
            this.Controls.Add(this.button_Glaz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Vhod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.Jetonchik);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Vhod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.TextBox Jetonchik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Glaz;
    }
}

