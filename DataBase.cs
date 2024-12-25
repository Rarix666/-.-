using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rushan.Kursach
{
    class DataBase
    {
        public static string SQL = "Data Source=510-012;Initial Catalog=Rushan;Integrated Security=True";
        Forma f = new Forma();
        public void KlickUpdate(string jeton)
        {
            using (SqlConnection conn = new SqlConnection(SQL))
            {
                SqlCommand com = new SqlCommand("", conn);
                conn.Open();
                com.CommandText = $"SELECT * FROM Командиры where Jeton = '{jeton}'";
                SqlDataReader Read = com.ExecuteReader();
                while (Read.Read())
                {
                    f.Jeton.Text = Read[1].ToString();
                    f.Surname.Text = Read[2].ToString();
                    f.Name.Text = Read[3].ToString();
                    f.Age.Text = Read[4].ToString();
                    f.Rang.Text = Read[5].ToString();
                    f.IDChasti.Text = Read[6].ToString();
                    f.Dostup.Text = Read[7].ToString();
                    try
                    {
                        f.pictureBox_FOTO.Image = Image.FromStream(new MemoryStream((byte[])Read[9]));
                    }
                    catch (Exception)
                    {
                        f.pictureBox_FOTO.Image = null;
                    }
                }
                conn.Close();
                f.tabControl1.SelectTab(f.tabPage1);
            }
        } // Метод обновления
        public void KlickKarta(string jeton)
        {
            MedKartaForm otdel = new MedKartaForm();
            otdel.Show();
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand com = new SqlCommand("", conn);
                conn.Open();
                com.CommandText = $"SELECT * FROM ВрачебноеЗаключение where Жетон = '{jeton}'";
                SqlDataReader Read = com.ExecuteReader();
                while (Read.Read())
                {
                    otdel.label1.Text = Read[0].ToString();
                    otdel.label2.Text = Read[1].ToString();
                    otdel.label3.Text = Read[2].ToString();
                    otdel.label4.Text = Read[3].ToString();
                    otdel.richTextBox1.Text = Read[4].ToString();
                    if (otdel.label2.Text != "")
                    {
                        otdel.label2.Text = Read[1].ToString();
                    }
                    else
                    {
                        otdel.label2.Text = "Пусто";
                    }

                    if (otdel.label3.Text != "")
                    {
                        otdel.label3.Text = Read[2].ToString();
                    }
                    else
                    {
                        otdel.label3.Text = "Пусто";
                    }

                    if (otdel.label4.Text != "")
                    {
                        otdel.label4.Text = Read[3].ToString();
                    }
                    else
                    {
                        otdel.label4.Text = "Пусто";
                    }

                    if (otdel.richTextBox1.Text != "")
                    {
                        otdel.richTextBox1.Text = Read[4].ToString();
                    }
                    else
                    {
                        otdel.richTextBox1.Text = "Пусто";
                    }
                }
                conn.Close();
            }

        } // Метод Мед.Карты
        public void KlickLD(string jeton)
        {
            LichDela LD = new LichDela();
            LD.Show();
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand com = new SqlCommand("", conn);
                conn.Open();
                com.CommandText = $"SELECT * FROM Командиры where Jeton = '{jeton}'";
                SqlDataReader Read = com.ExecuteReader();
                while (Read.Read())
                {
                    LD.label1.Text = Read[1].ToString();
                    LD.label2.Text = Read[2].ToString();
                    LD.label3.Text = Read[3].ToString();
                    LD.label4.Text = Read[4].ToString();
                    LD.label5.Text = Read[5].ToString();
                    LD.label6.Text = Read[6].ToString();
                    LD.label7.Text = Read[7].ToString();
                    try
                    {
                        LD.pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])Read[9]));
                    }
                    catch (Exception)
                    {
                        LD.pictureBox1.LoadAsync(@"D:/Уч.Практика/Rushan.Kursach/NOPHOTO.png");
                    }
                }
                conn.Close();
            }
        } // Метод личного дела
    }
}
