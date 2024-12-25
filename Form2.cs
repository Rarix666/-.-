using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Rushan.Kursach
{
    public partial class Forma : Form
    {
        DataTable DT = new DataTable();
        public Forma()
        {
            InitializeComponent();
            DataGrid.Data(dataGridView1);
            DataGrid.Data1(dataGridView2);
            DataGrid.Data2(dataGridView3);
            LoadLD();
        }

        private new void Update()//Условия для comboBox-ов УНИВЕРСАЛЬНЫЙ
        {
            Nomer.Items.Clear();
            Rang.Items.Clear();
            Rasformit_CH.Items.Clear();
            IDChasti.Items.Clear();
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand IDChasti1 = new SqlCommand("", conn);
                conn.Open();
                IDChasti1.CommandText = "SELECT Номер_Части FROM Chasti";
                SqlDataReader Read = IDChasti1.ExecuteReader();
                while (Read.Read())
                {
                    Nomer.Items.Add(Read.GetInt32(0));
                }
                conn.Close();
            }

            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand IDChasti1 = new SqlCommand("", conn);
                conn.Open();
                IDChasti1.CommandText = "SELECT Звания FROM Rang";
                SqlDataReader Read = IDChasti1.ExecuteReader();
                while (Read.Read())
                {
                    Rang.Items.Add(Read.GetString(0));
                }
                conn.Close();
            }

            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand IDChasti1 = new SqlCommand("", conn);
                conn.Open();
                IDChasti1.CommandText = "SELECT Номер_Части FROM Chasti";
                SqlDataReader Read = IDChasti1.ExecuteReader();
                while (Read.Read())
                {
                    IDChasti.Items.Add(Read.GetInt32(0));
                    Rasformit_CH.Items.Add(Read.GetInt32(0));
                }
                conn.Close();
            }

            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                SqlCommand IDChasti1 = new SqlCommand("", conn);
                conn.Open();
                IDChasti1.CommandText = "SELECT Jeton FROM Командиры";
                SqlDataReader Read = IDChasti1.ExecuteReader();
                while (Read.Read())
                {
                    COM_CH.Items.Add(Read.GetInt32(0));
                    Jeton_D_O.Items.Add(Read.GetInt32(0));
                }
                conn.Close();
            }
        }

        private void Update2()//Жетоны создания части 
        {
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                conn.Open();
                SqlCommand IDChasti1 = new SqlCommand("", conn);
                conn.Open();
                IDChasti1.CommandText = "SELECT Jeton FROM Командиры";
                SqlDataReader Read = IDChasti1.ExecuteReader();
                while (Read.Read())
                {
                    COM_CH.Items.Add(Read.GetInt32(0));
                }
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(DataBase.SQL))
            {
                conn.Open();
                SqlCommand IDChasti1 = new SqlCommand("", conn);
                conn.Open();
                IDChasti1.CommandText = "SELECT IDChasti FROM Командиры";
                SqlDataReader Read = IDChasti1.ExecuteReader();
                while (Read.Read())
                {
                    Nomer.Items.Add(Read.GetInt32(0));
                }
                conn.Close();
            }
        }

        private void Vnesti_D_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jeton.Text != "" && Surname.Text != "" && Name.Text != "" && Age.Text != "" && Rang.Text != "" && IDChasti.Text != "" && Dostup.Text != "")
                {
                    int a = int.Parse(Age.Text);
                    if (a > 20 && a < 70)
                    {
                        using (SqlConnection connection = new SqlConnection(DataBase.SQL))
                        {
                            connection.Open();
                            SqlCommand com = new SqlCommand("Create_Commander", connection);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@Jeton", Jeton.Text);
                            com.Parameters.AddWithValue("@Surname", Surname.Text);
                            com.Parameters.AddWithValue("@Name", Name.Text);
                            com.Parameters.AddWithValue("@Age", Age.Text);
                            com.Parameters.AddWithValue("@Rang", Rang.Text);
                            com.Parameters.AddWithValue("@IDChasti", IDChasti.Text);
                            com.Parameters.AddWithValue("@Dostup", Dostup.Text);
                            SqlDataReader reader = com.ExecuteReader();
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
                                MessageBox.Show("Личное дело офицера, было внесено в Базу Данных Штаба");
                                com.ExecuteNonQuery();
                            }
                            reader.Close();
                            Jeton_D_O.Items.Clear();
                            COM_CH.Items.Clear();
                            DataGrid.Data(dataGridView1);
                            DataGrid.Data1(dataGridView2);
                            Surname.Clear();
                            Name.Clear();
                            Age.Clear();
                            Rang.SelectedIndex = -1;
                            IDChasti.Items.Clear();
                            Dostup.SelectedIndex = -1;
                            Update();
                            LoadLD();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введёный возраст недопустим");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, проверьте поля");
            }
        } // Внос личного дела в БД

        private void Forma_Load(object sender, EventArgs e)
        {
            Update();
        } // Загрузчик формы

        private void Delete_D_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jeton_D_O.Text != "")
                {
                    using (SqlConnection connection = new SqlConnection(DataBase.SQL))
                    {
                        connection.Open();
                        SqlCommand com = new SqlCommand("Delete_Commander", connection);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Jeton", Jeton_D_O.Text);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Офицер был отправлен в отставку");
                        Jeton_D_O.Items.Clear();
                        COM_CH.Items.Clear();
                        DataGrid.Data(dataGridView1);
                        DataGrid.Data1(dataGridView2);
                        DataGrid.Data2(dataGridView3);
                        Update();
                        Surname.Clear();
                        Name.Clear();
                        Age.Clear();
                        Rang.SelectedIndex = -1;
                        IDChasti.Items.Clear();
                        Dostup.SelectedIndex = -1;
                        Jeton_D_O.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле!");
                }
            }
            catch
            {
                MessageBox.Show("В жетон пишите только цифры!");
            }
        } // Удаление личного дела из БД

        private void Vihod_1_Click(object sender, EventArgs e)
        {
            Form1 newform = new Form1();
            newform.Show();
            this.Hide();
        } // Выход с формы 2

        private void Photo()//Условия для ввода фото
        {
            OpenFileDialog файл = new OpenFileDialog();
            файл.Filter = "Изображение |*.jpg;*.jpeg;*.png;*.gif";
            if (файл.ShowDialog() == DialogResult.OK)
            {
                byte[] для_запроса;
                using (FileStream чтение_открытия_картинки = new FileStream(файл.FileName, FileMode.Open, FileAccess.Read))
                {
                    для_запроса = new byte[чтение_открытия_картинки.Length];
                    чтение_открытия_картинки.Read(для_запроса, 0, для_запроса.Length);
                }
                using (SqlConnection conn = new SqlConnection(DataBase.SQL))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand("Photo1", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Jeton", Jeton.Text);
                    comm.Parameters.AddWithValue("@Photo", для_запроса);
                    comm.Parameters.AddWithValue("@NamePhoto", InsFoto.Text);
                    comm.ExecuteNonQuery();
                }
            }
        }

        private void Insert_F_D_Click(object sender, EventArgs e)
        {
            Photo();
            DataGrid.Data(dataGridView1);
        } // Добавить фото

        private void Vnesti_CH_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nomer.Text != "" && Name_CH.Text != "" && Podrazd_CH.Text != "" && COM_CH.Text != "" && Sostav_CH.Text != "" && Sclad_CH.Text != "" && Gotovnost_CH.Text != "")
                {
                    using (SqlConnection con = new SqlConnection(DataBase.SQL))
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand("Create_Chasti", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Nomer", Nomer.Text);
                        com.Parameters.AddWithValue("@Names", Name_CH.Text);
                        com.Parameters.AddWithValue("@Podr", Podrazd_CH.Text);
                        com.Parameters.AddWithValue("@Jeton", COM_CH.Text);
                        com.Parameters.AddWithValue("Sostav", Sostav_CH.Text);
                        com.Parameters.AddWithValue("@Guns", Sclad_CH.Text);
                        com.Parameters.AddWithValue("@Goto", Gotovnost_CH.Text);
                        SqlDataReader reader = com.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                MessageBox.Show("Такая часть уже существует");
                            }
                        }
                        else
                        {
                            reader.Close();
                            MessageBox.Show("Часть внесена в базу данных");
                            com.ExecuteNonQuery();
                        }
                        reader.Close();
                        Nomer.Items.Clear();
                        Name_CH.Clear();
                        Sostav_CH.Clear();
                        Sclad_CH.Clear();
                        Nomer.SelectedIndex = -1;
                        Podrazd_CH.SelectedIndex = -1;
                        Gotovnost_CH.SelectedIndex = -1;
                        Jeton_D_O.Items.Clear();
                        COM_CH.Items.Clear();
                        DataGrid.Data(dataGridView1);
                        DataGrid.Data1(dataGridView2);
                        DataGrid.Data2(dataGridView3);
                        Update();
                        Update2();
                    }
                }
                else
                {
                    MessageBox.Show("Заполни все поля!");
                }
            }
            catch
            {

            }
        } // Внос части в БД

        private void Rasform_CH_Click(object sender, EventArgs e)
        {
            if (Rasformit_CH.Text != "")
            {
                using (SqlConnection con = new SqlConnection(DataBase.SQL))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("Delete_Chasti", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Number", Rasformit_CH.Text);
                    com.ExecuteNonQuery();
                    Jeton_D_O.Items.Clear();
                    COM_CH.Items.Clear();
                    MessageBox.Show("Часть расформирована! Назначте новые части офицерам расформированной части");
                    Nomer.Text = "";
                    Rasformit_CH.SelectedIndex = -1;
                    DataGrid.Data(dataGridView1);
                    DataGrid.Data1(dataGridView2);
                    DataGrid.Data2(dataGridView3);
                    Update();
                }
            }
            else
            {
                MessageBox.Show("Заполните поле!");
            }
        } // Удаление части в БД

        private void chek_Click(object sender, EventArgs e)
        {
            Excel.Application Эксель = new Excel.Application();
            if (Эксель == null)
            {
                MessageBox.Show("Файл Эксель не обнаружен");
                return;
            }
            Эксель.Visible = true;
            string Файл = "D:/Уч.Практика/Rushan.Kursach/Отчет.xlsx";
            Excel.Workbook ОпенФаил = Эксель.Workbooks.Open(Файл);
            Excel.Worksheet Лист_1 = ОпенФаил.Sheets[1];
            try
            {
                DataTable короб = new DataTable();

                using (SqlConnection con = new SqlConnection(DataBase.SQL))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("Отчёт", con);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(короб);

                    for (int a = 0; a < короб.Rows.Count; a++)
                    {
                        Лист_1.Cells[a + 3, 1] = короб.Rows[a][0].ToString();
                        Лист_1.Cells[a + 3, 2] = короб.Rows[a][1].ToString();
                        Лист_1.Cells[a + 3, 3] = короб.Rows[a][2].ToString();
                        Лист_1.Cells[a + 3, 4] = короб.Rows[a][3].ToString();
                        Лист_1.Cells[a + 3, 5] = короб.Rows[a][4].ToString();
                        Лист_1.Cells[a + 3, 6] = короб.Rows[a][5].ToString();
                        Лист_1.Cells[a + 3, 7] = короб.Rows[a][6].ToString();
                        Лист_1.Cells[a + 3, 8] = короб.Rows[a][7].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        } // Создание отчёта

        private void Update_Delo_Click(object sender, EventArgs e)
        {
            if (Jeton.Text != "")
            {
                int a = int.Parse(Age.Text);
                if (a > 20 && a < 70)
                {
                    using (SqlConnection con = new SqlConnection(DataBase.SQL))
                    {
                        con.Open();
                        SqlCommand com = new SqlCommand("Update_Delo", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@jeton", Jeton.Text);
                        com.Parameters.AddWithValue("@Surname", Surname.Text);
                        com.Parameters.AddWithValue("@Name", Name.Text);
                        com.Parameters.AddWithValue("@Age", Age.Text);
                        com.Parameters.AddWithValue("@Rang", Rang.Text);
                        com.Parameters.AddWithValue("@IdChast", IDChasti.Text);
                        com.Parameters.AddWithValue("@Dostup", Dostup.Text);
                        com.ExecuteNonQuery();
                        Jeton_D_O.Items.Clear();
                        COM_CH.Items.Clear();
                        DataGrid.Data(dataGridView1);
                        DataGrid.Data1(dataGridView2);
                        DataGrid.Data2(dataGridView3);
                        Update();
                        MessageBox.Show("В личное дело офицера были внесены изменения!");
                    }
                }
                else
                {
                    MessageBox.Show("Введённый возраст недопустим!");
                }
            }
            else
            {
                MessageBox.Show("Заполните поле жетон!");
            }
        } // Обновить личное дело

        private void Update_Cha_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Update_Cha", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@NCH", Nomer.Text);
                com.Parameters.AddWithValue("@NameCH", Name_CH.Text);
                com.Parameters.AddWithValue("@Podr", Podrazd_CH.Text);
                com.Parameters.AddWithValue("@Sostav", Sostav_CH.Text);
                com.Parameters.AddWithValue("@Sclad", Sclad_CH.Text);
                com.Parameters.AddWithValue("@Gotov", Gotovnost_CH.Text);
                com.Parameters.AddWithValue("@JetCom", COM_CH.Text);
                com.ExecuteNonQuery();
                Jeton_D_O.Items.Clear();
                COM_CH.Items.Clear();
                Nomer.Items.Clear();
                DataGrid.Data(dataGridView1);
                DataGrid.Data1(dataGridView2);
                DataGrid.Data2(dataGridView3);
                Update();
                MessageBox.Show("Данные о части были изменены!");
            }
        } // Обновить данные войсковой части

        private void Jeton_KeyPress(object sender, KeyPressEventArgs e)
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
        } // Маска числового ввода (Для всех)

        private void COM_CH_KeyPress(object sender, KeyPressEventArgs e)
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
        } // Маска запрета ввода (Для всех)

        private void Nomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection sql = new SqlConnection(DataBase.SQL))
            {
                sql.Open();
                SqlCommand com = new SqlCommand("Select_CS", sql);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ICH", Nomer.Text);
                SqlDataReader reader = com.ExecuteReader(0);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        COM_CH.Text = reader[0].ToString();
                    }
                }
            }
        } // Ввод жетона бойца, если есть номер части (Части)

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Jeton.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Surname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Name.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Age.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Rang.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            IDChasti.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            Dostup.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            InsFoto.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            try
            {
                pictureBox_FOTO.Image = Image.FromStream(new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[9].Value));
            }
            catch (Exception)
            {
                pictureBox_FOTO.LoadAsync(@"D:/Уч.Практика/Rushan.Kursach/NOPHOTO.png");
            }
        } // Вывод данных по нажатию в DataGrid

        private void Forma_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        } // Закрыть программу

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != null)
            {
                MedKartaForm newfrm = new MedKartaForm();
                newfrm.Show();
                int Jeton = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                using (SqlConnection conn = new SqlConnection(DataBase.SQL))
                {
                    SqlCommand com = new SqlCommand("", conn);
                    conn.Open();
                    com.CommandText = $"SELECT * FROM ВрачебноеЗаключение where Жетон = '{Jeton}'";
                    SqlDataReader Read = com.ExecuteReader();
                    while (Read.Read())
                    {
                        newfrm.label1.Text = Read[0].ToString();
                        newfrm.label2.Text = Read[1].ToString();
                        newfrm.label3.Text = Read[2].ToString();
                        newfrm.label4.Text = Read[3].ToString();
                        newfrm.richTextBox1.Text = Read[4].ToString();
                        if (newfrm.label2.Text != "")
                        {
                            newfrm.label2.Text = Read[1].ToString();
                        }
                        else
                        {
                            newfrm.label2.Text = "Пусто";
                        }

                        if (newfrm.label3.Text != "")
                        {
                            newfrm.label3.Text = Read[2].ToString();
                        }
                        else
                        {
                            newfrm.label3.Text = "Пусто";
                        }

                        if (newfrm.label4.Text != "")
                        {
                            newfrm.label4.Text = Read[3].ToString();
                        }
                        else
                        {
                            newfrm.label4.Text = "Пусто";
                        }

                        if (newfrm.richTextBox1.Text != "")
                        {
                            newfrm.richTextBox1.Text = Read[4].ToString();
                        }
                        else
                        {
                            newfrm.richTextBox1.Text = "Пусто";
                        }
                    }
                    conn.Close();
                }
            }
        } // Контекстное меню
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        DataBase Base = new DataBase();
        private void LoadLD()
        {
            DataTable dataTable = ExecuteQuery("SelectJetonComEcsp");
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                Panel Zpanel = CreateZPanel(row);
                flowLayoutPanel1.Controls.Add(Zpanel);
            }
        } // Загрузчик панелей

        public Panel CreateZPanel(DataRow row)
        {

            Panel panel = new Panel
            {
                Size = new Size(320, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = row["Jeton"]
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            if (row["Photo"] != DBNull.Value)
            {
                byte[] imageData = (byte[])row["Photo"];
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }

            Button viewButton = new Button
            {
                Text = "Обновить",
                Location = new Point(200, 60),
                Size = new Size(100, 30)
            };

            Button viewButton1 = new Button
            {
                Text = "Мед.Карта",
                Location = new Point(200, 30),
                Size = new Size(100, 30)
            };

            Button viewButton2 = new Button
            {
                Text = "Личное дело",
                Location = new Point(100, 30),
                Size = new Size(100, 30),
            };

            Label JetonLabel = new Label
            {
                Text = row["Jeton"].ToString(),
                Location = new Point(230, 10),
                Size = new Size(200, 50),
                Font = new Font("Arial", 10, FontStyle.Regular),
                AutoEllipsis = true,
                ForeColor = Color.White
            };
            

            Label JetonLabel1 = new Label
            {
                Text = "Жетон:",
                Location = new Point(170, 10),
                Size = new Size(200, 50),
                Font = new Font("Arial", 10, FontStyle.Regular),
                AutoEllipsis = true,
                ForeColor = Color.White
            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(viewButton);
            panel.Controls.Add(viewButton1);
            panel.Controls.Add(viewButton2);
            panel.Controls.Add(JetonLabel);
            panel.Controls.Add(JetonLabel1);


            viewButton.Click += (s, ee) => Base.KlickUpdate(JetonLabel.Text);
            viewButton1.Click += (s, ee) => Base.KlickKarta(JetonLabel.Text);
            viewButton2.Click += (s, ee) => Base.KlickLD(JetonLabel.Text);

            return panel;
        } // Создание панелей

        public static DataTable ExecuteQuery(string storedProcedureName, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBase.SQL))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable;
        }

        private void SearchP_button_Click(object sender, EventArgs e)
        {
            DataTable TB = new DataTable();
            SqlDataAdapter Tab = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("POISKPOISK", con);
                {
                    com.CommandType = CommandType.StoredProcedure;
                };
                com.Parameters.AddWithValue("@Name", NamePoisk_Text.Text);
                com.Parameters.AddWithValue("@Surname", SurNamePoisk_Text.Text);
                com.Parameters.AddWithValue("@Role", DostupPoisk_Comb.Text);
                com.Parameters.AddWithValue("@Rang", RangPoisk_Comb.Text);
                Tab.SelectCommand = com;
                Tab.Fill(TB);
                flowLayoutPanel1.Controls.Clear();
                foreach(DataRow row in TB.Rows)
                {
                    Panel Zpanel = CreateZPanel(row);
                    flowLayoutPanel1.Controls.Add(Zpanel);
                }
            }
        }
    }
}
