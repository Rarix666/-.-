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
using System.Windows.Media.Imaging;

namespace Rushan.Kursach
{
    public partial class Form1 : Form
    {
        int Login;
        string Pas;
        public static string Dostup, Jeton;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Pass.PasswordChar == '*') 
            {
                Pass.PasswordChar = '\0';
                button_Glaz.BackgroundImage = Image.FromFile(@"D:\Уч.Практика\Rushan.Kursach\glaz_Open.png");
            }
            else
            {
                Pass.PasswordChar = '*';
                button_Glaz.BackgroundImage = Image.FromFile(@"D:\Уч.Практика\Rushan.Kursach\glaz_Close.png");
            }
        } // Глазик

        private void Jetonchik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                return;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else
                e.Handled = true;
        } //Условие ввода Жетона авторизации

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        } //Закрытие программы

        private void Vhod_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jetonchik.Text != "" && Pass.Text != "")
                {
                    Login = Convert.ToInt32(Jetonchik.Text);
                    Pas = Pass.Text;
                    using (SqlConnection conn = new SqlConnection(DataBase.SQL))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand("SelectComm", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Jeton", Login);
                        command.Parameters.AddWithValue("@Passwordd", Pas);
                        command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Jeton = reader[0].ToString();
                                Dostup = reader[1].ToString();
                            }                      
                            if (Dostup == "admin")
                            {
                                    MessageBox.Show("Ключ доступа: Администратор. Приветствуем вас, вы успешно авторизованы!");
                                    Form3 newfrm1 = new Form3();
                                    newfrm1.Show();
                                    this.Hide();
                            }
                            if (Dostup == "Бухгалтер")
                            {
                                    MessageBox.Show("Ключ доступа: Бухгалтер. Приветствуем вас, вы успешно авторизованы!");
                                    Form4 newfrm1 = new Form4();
                                    newfrm1.Show();
                                    this.Hide();
                            }
                            if (Dostup == "Командующий")
                            {
                                    MessageBox.Show("Ключ доступа: Командующий. Приветствуем вас, вы успешно авторизованы!");
                                    Forma newfrm = new Forma();
                                    newfrm.Show();
                                    this.Hide();
                            }
                            if (Dostup == "Хирург")
                            {
                                    MessageBox.Show("Ключ доступа: Врач Хирург. Приветствуем вас, вы успешно авторизованы!");
                                    MedOtdelForm newfrm2 = new MedOtdelForm();
                                    newfrm2.Show();
                                    this.Hide();
                                    newfrm2.AdecvatPS_Comb.Enabled = false;
                                    newfrm2.ObshPS_Comb.Enabled = false;
                                    newfrm2.MislPS_Comb.Enabled = false;
                                    newfrm2.KognPS_Comb.Enabled = false;
                                    newfrm2.EmocPS_Comb.Enabled = false;
                                    newfrm2.OstOFT_Text.Enabled = false;
                                    newfrm2.KorOFT_Comb.Enabled = false;
                                    newfrm2.CategoryMZ_Comb.Enabled = false;
                                    newfrm2.dataGridView4.Enabled = false;
                                    newfrm2.dataGridView1.Enabled = false;
                                    newfrm2.dataGridView2.Enabled = false;
                                    newfrm2.RecomMZ_RichText.Enabled = false;
                                    newfrm2.CreateExcel_button.Enabled = false;
                            }
                            if (Dostup == "Психиатр")
                            {
                                MessageBox.Show("Ключ доступа: Врач Психиатр. Приветствуем вас, вы успешно авторизованы!");
                                MedOtdelForm newfrm2 = new MedOtdelForm();
                                newfrm2.Show();
                                this.Hide();
                                newfrm2.SostHR_Comb.Enabled = false;
                                newfrm2.FizSostHR_Comb.Enabled = false;
                                newfrm2.RiskHR_Comb.Enabled = false;
                                newfrm2.OstOFT_Text.Enabled = false;
                                newfrm2.KorOFT_Comb.Enabled = false;
                                newfrm2.CategoryMZ_Comb.Enabled = false;
                                newfrm2.dataGridView2.Enabled = false;
                                newfrm2.dataGridView3.Enabled = false;
                                newfrm2.dataGridView4.Enabled = false;
                                newfrm2.RecomMZ_RichText.Enabled = false;
                                newfrm2.CreateExcel_button.Enabled = false;
                            }
                            if (Dostup == "Офтальмолог")
                            {
                                MessageBox.Show("Ключ доступа: Врач Офтальмолог. Приветствуем вас, вы успешно авторизованы!");
                                MedOtdelForm newfrm2 = new MedOtdelForm();
                                newfrm2.Show();
                                this.Hide();
                                newfrm2.AdecvatPS_Comb.Enabled = false;
                                newfrm2.ObshPS_Comb.Enabled = false;
                                newfrm2.MislPS_Comb.Enabled = false;
                                newfrm2.KognPS_Comb.Enabled = false;
                                newfrm2.EmocPS_Comb.Enabled = false;
                                newfrm2.SostHR_Comb.Enabled = false;
                                newfrm2.FizSostHR_Comb.Enabled = false;
                                newfrm2.RiskHR_Comb.Enabled = false;
                                newfrm2.CategoryMZ_Comb.Enabled = false;
                                newfrm2.dataGridView1.Enabled = false;
                                newfrm2.dataGridView3.Enabled = false;
                                newfrm2.dataGridView4.Enabled = false;
                                newfrm2.RecomMZ_RichText.Enabled = false;
                                newfrm2.CreateExcel_button.Enabled = false;
                            }
                            if (Dostup == "Глав.Врач")
                            {
                                MessageBox.Show("Ключ доступа: Главный врач. Приветствуем вас, вы успешно авторизованы!");
                                MedOtdelForm newfrm2 = new MedOtdelForm();
                                newfrm2.Show();
                                this.Hide();
                                newfrm2.AdecvatPS_Comb.Enabled = false;
                                newfrm2.ObshPS_Comb.Enabled = false;
                                newfrm2.MislPS_Comb.Enabled = false;
                                newfrm2.KognPS_Comb.Enabled = false;
                                newfrm2.EmocPS_Comb.Enabled = false;
                                newfrm2.OstOFT_Text.Enabled = false;
                                newfrm2.KorOFT_Comb.Enabled = false;
                                newfrm2.SostHR_Comb.Enabled = false;
                                newfrm2.FizSostHR_Comb.Enabled = false;
                                newfrm2.RiskHR_Comb.Enabled = false;
                                newfrm2.dataGridView1.Enabled = false;
                                newfrm2.dataGridView2.Enabled = false;
                                newfrm2.dataGridView3.Enabled = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Данного пользователя не существует");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch
            {
                MessageBox.Show("Данного пользователя не существует");
            }
        } // Кнопка входа
    }
}
