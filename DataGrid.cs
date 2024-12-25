using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rushan.Kursach
{
    class DataGrid
    {
        public static void Data(DataGridView dataGrid)//Условие датагрида Командиры1
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Командиры", con);
                adapter.SelectCommand = com;
                adapter.Fill(table);
                dataGrid.DataSource = table;
            }
        }

        public static void Data1(DataGridView dataGrid1)//Условие датагрида Командиры2
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Командиры", con);
                adapter.SelectCommand = com;
                adapter.Fill(table);
                dataGrid1.DataSource = table;
            }
        }

        public static void Data2(DataGridView dataGrid2)//Условие датагрида Части
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Chasti", con);
                adapter.SelectCommand = com;
                adapter.Fill(table);
                dataGrid2.DataSource = table;
            }
        }
        public static void DataPsihiator(DataGridView dataGrid)//Условие датагрида Психолог
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Психиатр", con);
                adapter.SelectCommand = com;
                adapter.Fill(table);
                dataGrid.DataSource = table;
            }
        }
        public static void DataOFT(DataGridView dataGrid)//Условие датагрида Офтальмолог
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Офтальмолог", con);
                adapter.SelectCommand = com;
                adapter.Fill(table);
                dataGrid.DataSource = table;
            }
        }
        public static void DataHirurg(DataGridView dataGrid)//Условие датагрида Хирург
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Хирург", con);
                adapter.SelectCommand = com;
                adapter.Fill(table);
                dataGrid.DataSource = table;
            }
        }
        public static void DataZakluchenie(DataGridView dataGrid)//Условие датагрида Заклчение
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(DataBase.SQL))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM ВрачебноеЗаключение", con);
                adapter.SelectCommand = com;
                adapter.Fill(table);
                dataGrid.DataSource = table;
            }
        }
    }
}
