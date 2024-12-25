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
    public partial class Form3 : Form
    {
        string Dostup;
        int Login;
        string Pas;
        public Form3()
        {
            InitializeComponent();
            Data();
        }

        private void Create_Pols_Click(object sender, EventArgs e)
        {
                if (Jeton_C.Text != "" && Password_C.Text != "" && Dostup_I.Text != "")
                {
                    Dostup = Dostup_I.Text;
                    Login = Convert.ToInt32(Jeton_C.Text);
                    Pas = Password_C.Text;
                    using (SqlConnection connection = new SqlConnection(DataBase.SQL))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("Create_adm", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Dostup", Dostup);
                        command.Parameters.AddWithValue("@Login", Login);
                        command.Parameters.AddWithValue("@Password", Pas);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                MessageBox.Show("Пользователь уже существует");
                            }
                        }
                        else
                        {
                            reader.Close();
                            MessageBox.Show("Пользователь создан");
                            command.ExecuteNonQuery();
                        }
                        reader.Close();
                        Data();
                        Jeton_C.Clear();
                        Password_C.Clear();
                        Dostup_I.SelectedIndex = -1;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
        } // Добавление пользователя в БД

        private void Data()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM Vhod", conn);
                adapter.SelectCommand = comm;
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }

        } // Условие DATAGRID

        private void Delete_Pols_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jeton_C.Text != "")
                {
                    using (SqlConnection con = new SqlConnection(DataBase.SQL))
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand("Delete_Vhod", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Jeton", Jeton_C.Text);
                        com.ExecuteNonQuery();
                        Data();
                        MessageBox.Show("Пользователь удалён");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователя не существует");
                }
            }
            catch
            {
                MessageBox.Show("В Жетон пиши цифры!");
            }
        } // Удаление пользователя из БД

        private void Vihod2_Click(object sender, EventArgs e)
        {
            Form1 newform = new Form1();
            newform.Show();
            this.Hide();
        } // Кнопка выхода

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
