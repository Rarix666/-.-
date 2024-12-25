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
using Excel = Microsoft.Office.Interop.Excel;

namespace Rushan.Kursach
{
    public partial class MedOtdelForm : Form
    {
        public MedOtdelForm()
        {
            InitializeComponent();
            DataGrid.DataPsihiator(dataGridView1);
            DataGrid.DataOFT(dataGridView2);
            DataGrid.DataHirurg(dataGridView3);
            DataGrid.DataZakluchenie(dataGridView4);
            Update();
        }

        private new void Update()
        {
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                conn.Open();
                SqlCommand IDChasti1 = conn.CreateCommand(); 
                IDChasti1.CommandText = "SELECT Jeton FROM Командиры";
                SqlDataReader Read = IDChasti1.ExecuteReader();
                while (Read.Read())
                {
                    JetonMZ_Comb.Items.Add(Read.GetInt32(0));
                }
                conn.Close();
            }
        } // Обновление данных combobox

        private void SaveMZ_button_Click(object sender, EventArgs e)
        {
            using(SqlConnection sql = new SqlConnection(DataBase.SQL))
            {
                if (CategoryMZ_Comb.Text == "Не годен")
                {
                    using (SqlConnection con = new SqlConnection(DataBase.SQL))
                    {
                        con.Open();
                        SqlCommand com = con.CreateCommand();
                        com.CommandText = $"DELETE FROM ВрачебноеЗаключение WHERE Жетон = '{JetonMZ_Comb.Text}'; DELETE FROM Командиры WHERE Jeton = '{JetonMZ_Comb.Text}'; DELETE FROM Хирург WHERE Жетон = '{JetonMZ_Comb.Text}'; DELETE FROM Психиатр WHERE Жетон = '{JetonMZ_Comb.Text}'; DELETE FROM Офтальмолог WHERE Жетон = '{JetonMZ_Comb.Text}'; UPDATE Chasti SET Имя_Командира = '', Фамилия_Командира = '', Жетон_Командира = '' WHERE Жетон_Командира = '{JetonMZ_Comb.Text}'";
                        com.ExecuteNonQuery();
                        con.Close();
                        JetonMZ_Comb.Items.Clear();
                        Update();
                        DataGrid.DataPsihiator(dataGridView1);
                        DataGrid.DataOFT(dataGridView2);
                        DataGrid.DataHirurg(dataGridView3);
                        DataGrid.DataZakluchenie(dataGridView4);
                        Application.Exit();
                        MessageBox.Show("Боец отправлен в отставку по медицинским причинам");
                    }
                }
                else
                {
                    using (SqlCommand com = new SqlCommand("Create_Psiholog", sql))
                    {
                        sql.Open();
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Jeton", JetonMZ_Comb.Text);
                        com.Parameters.AddWithValue("@Adecvat", AdecvatPS_Comb.Text);
                        com.Parameters.AddWithValue("@ObshSost", ObshPS_Comb.Text);
                        com.Parameters.AddWithValue("@Misli", MislPS_Comb.Text);
                        com.Parameters.AddWithValue("@Kogn", KognPS_Comb.Text);
                        com.Parameters.AddWithValue("@Emocii", EmocPS_Comb.Text);
                        com.ExecuteNonQuery();
                        sql.Close();
                    }

                    using (SqlCommand com = new SqlCommand("Create_Oftal", sql))
                    {
                        sql.Open();
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Jeton", JetonMZ_Comb.Text);
                        com.Parameters.AddWithValue("@Zrenie", OstOFT_Text.Text);
                        com.Parameters.AddWithValue("@Kor", KorOFT_Comb.Text);
                        com.ExecuteNonQuery();
                        sql.Close();
                    }

                    using (SqlCommand com = new SqlCommand("Create_Hirurg", sql))
                    {
                        sql.Open();
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Jeton", JetonMZ_Comb.Text);
                        com.Parameters.AddWithValue("@SostHR", SostHR_Comb.Text);
                        com.Parameters.AddWithValue("@FizSostHR", FizSostHR_Comb.Text);
                        com.Parameters.AddWithValue("@RiskHR", RiskHR_Comb.Text);
                        com.ExecuteNonQuery();
                        sql.Close();
                    }

                    using (SqlCommand com = new SqlCommand("Create_Zakl", sql))
                    {
                        sql.Open();
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Jeton", JetonMZ_Comb.Text);
                        com.Parameters.AddWithValue("@Kategory", CategoryMZ_Comb.Text);
                        com.Parameters.AddWithValue("@Rec", RecomMZ_RichText.Text);
                        com.ExecuteNonQuery();
                        sql.Close();
                        JetonMZ_Comb.Items.Clear();
                        Update();
                        DataGrid.DataPsihiator(dataGridView1);
                        DataGrid.DataOFT(dataGridView2);
                        DataGrid.DataHirurg(dataGridView3);
                        DataGrid.DataZakluchenie(dataGridView4);
                    }
                    MessageBox.Show("В мед.карту офицера внесены изменения");
                }
            }
        } // Обновление медицинских данных

        private void JetonMZ_Comb_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand com = new SqlCommand("", conn);
                conn.Open();
                com.CommandText = $"SELECT * FROM Психиатр where Жетон = '{JetonMZ_Comb.Text}'";
                SqlDataReader Read = com.ExecuteReader();
                while (Read.Read())
                {
                    NamePS_Text.Text = Read[1].ToString();
                    SurNamePS_Text.Text = Read[2].ToString();
                    AdecvatPS_Comb.Text = Read[3].ToString();
                    ObshPS_Comb.Text = Read[4].ToString();
                    MislPS_Comb.Text = Read[5].ToString();
                    KognPS_Comb.Text = Read[6].ToString();
                    EmocPS_Comb.Text = Read[7].ToString();
                }
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand com = new SqlCommand("", conn);
                conn.Open();
                com.CommandText = $"SELECT * FROM Офтальмолог where Жетон = '{JetonMZ_Comb.Text}'";
                SqlDataReader Read = com.ExecuteReader();
                while (Read.Read())
                {
                    NameOFT_Text.Text = Read[1].ToString();
                    SurNameOFT_Text.Text = Read[2].ToString();
                    OstOFT_Text.Text = Read[3].ToString();
                    KorOFT_Comb.Text = Read[4].ToString();
                }
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand com = new SqlCommand("", conn);
                conn.Open();
                com.CommandText = $"SELECT * FROM Хирург where Жетон = '{JetonMZ_Comb.Text}'";
                SqlDataReader Read = com.ExecuteReader();
                while (Read.Read())
                {
                    NameHR_Text.Text = Read[1].ToString();
                    SurNameHR_Text.Text = Read[2].ToString();
                    SostHR_Comb.Text = Read[3].ToString();
                    FizSostHR_Comb.Text = Read[4].ToString();
                    RiskHR_Comb.Text = Read[5].ToString();
                }
                conn.Close();
            }
        } // Выбор жетона 

        private void MedOtdelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        } // Закрытие программы 

        private void ExitMedOtdel_button_Click(object sender, EventArgs e)
        {
            Form1 newform = new Form1();
            newform.Show();
            this.Hide();
        } // Выход из мед отдела в форму авторизации

        private void CategoryMZ_Comb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                return;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else
                e.Handled = true;
        } // Условия ввода категории здоровья

        private void JetonMZ_Comb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        } // Условия ввода жетона 

        private void CreateExcel_button_Click(object sender, EventArgs e)
        {
            Excel.Application Эксель = new Excel.Application();
            if (Эксель == null)
            {
                MessageBox.Show("Файл Эксель не обнаружен");
                return;
            }
            Эксель.Visible = true;
            string Файл = "D:/Курсовые/Курсовая 06.12.2024/Rushan.Kursach/МедОтчет.xlsx";
            Excel.Workbook ОпенФаил = Эксель.Workbooks.Open(Файл);
            Excel.Worksheet Лист_1 = ОпенФаил.Sheets[1];
            try
            {
                DataTable короб = new DataTable();

                using (SqlConnection con = new SqlConnection(DataBase.SQL))
                {
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = "SELECT * FROM ВрачебноеЗаключение";
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(короб);

                    for (int a = 0; a < короб.Rows.Count; a++)
                    {
                        Лист_1.Cells[a + 3, 1] = короб.Rows[a][0].ToString();
                        Лист_1.Cells[a + 3, 2] = короб.Rows[a][1].ToString();
                        Лист_1.Cells[a + 3, 3] = короб.Rows[a][2].ToString();
                        Лист_1.Cells[a + 3, 4] = короб.Rows[a][3].ToString();
                        Лист_1.Cells[a + 3, 5] = короб.Rows[a][4].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        } // Создание мед.отчета

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            JetonMZ_Comb.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            NameMZ_Text.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            SurNameMZ_Text.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            CategoryMZ_Comb.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            RecomMZ_RichText.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
        } // Условие вывода datagrid4

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            JetonMZ_Comb.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            NameMZ_Text.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            SurNameMZ_Text.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        } // Условие вывода datagrid3

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            JetonMZ_Comb.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            NameMZ_Text.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            SurNameMZ_Text.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        } // Условие вывода datagrid2

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            JetonMZ_Comb.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            NameMZ_Text.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            SurNameMZ_Text.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        } // Условие вывода datagrid1

        private void MedOtdelForm_Load(object sender, EventArgs e)
        {
            if (Form1.Dostup == "Психиатр")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
            }
            if (Form1.Dostup == "Офтальмолог")
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage3);
            }
            if (Form1.Dostup == "Хирург")
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
            }
        }
    }
}