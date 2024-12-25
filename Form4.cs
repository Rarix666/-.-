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

namespace Rushan.Kursach
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            UpdateCombo();
            Data();
        }

        private void Vnos_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jeton_B.Text != "" && ZP_I.Text != "")
                {
                    using (SqlConnection connection = new SqlConnection(DataBase.SQL))
                    {
                        connection.Open();
                        SqlCommand com = new SqlCommand("Зарплата", connection);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Jeton1", Jeton_B.Text);
                        com.Parameters.AddWithValue("@Зарплата", ZP_I.Text);
                        com.ExecuteNonQuery();
                        Jeton_B.Items.Clear();
                        Data();
                        UpdateCombo();
                        MessageBox.Show("Зарплата офицера внесена в базу данных");
                        Jeton_B.Text = "";
                        ZP_I.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            catch
            {
                MessageBox.Show("Проверьте все поля!");
            }
        } // Добавление З/П в БД

        private void UpdateCombo()
        {
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand IDChasti1 = new SqlCommand("", conn);
                conn.Open();
                IDChasti1.CommandText = "SELECT Jeton FROM Командиры";
                SqlDataReader Read = IDChasti1.ExecuteReader();
                while (Read.Read())
                {
                    Jeton_B.Items.Add(Read.GetInt32(0));
                }
                conn.Close();
            }
        } // Условие combobox

        private void Data()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM Бухгалтерия", conn);
                adapter.SelectCommand = comm;
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        } // Условия DATAGRID З/П

        private void Update_B_Click(object sender, EventArgs e)
        {
            try
            {

                if (Jeton_B.Text != "" && ZP_I.Text != "")
                {
                    using (SqlConnection con = new SqlConnection(DataBase.SQL))
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand("Изменить_ЗП", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Jeton", Convert.ToInt32(Jeton_B.Text));
                        com.Parameters.AddWithValue("@Зарплата", Convert.ToInt32(ZP_I.Text));
                        com.ExecuteNonQuery();
                        Data();
                        MessageBox.Show("Зарплата офицера была изменена");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            catch
            {
                MessageBox.Show("Возникла проблема! Проверьте правильное заполнение полей! Зарплата и Жетон- только числа");
            }
        } // Обновление З/П в БД

        private void Vihod3_Click(object sender, EventArgs e)
        {
            Form1 newform = new Form1();
            newform.Show();
            this.Hide();
        } // Выход с формы

        private void Jeton_B_KeyPress(object sender, KeyPressEventArgs e)
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
        } // Маска запрета ввода

        private void ZP_I_KeyPress(object sender, KeyPressEventArgs e)
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
        } // Маска числового ввода

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Вывод данных по нажатию DataGrid
        {
            Jeton_B.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ZP_I.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
