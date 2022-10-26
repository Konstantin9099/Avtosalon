using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AvtosalonDB
{
    public partial class Otchet : Form
    {
        public int ID = 0;
        public Otchet(int ID_log)
        {
            InitializeComponent();
            ID = ID_log;
        }

        private void Otchet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Otchet_Load(object sender, EventArgs e)
        {
            // Таблица вкладки "Автомобили".
            string query = " SELECT * FROM prodazha, avto, menedzher, pokupatel WHERE prodazha.id_avto=avto.id_avto AND prodazha.id_menedzhera=menedzher.id_menedzher AND prodazha.id_pokupatelya=pokupatel.id_pokupatel ORDER BY data_prodazhi; ";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                this.dataGridView1.Columns[0].HeaderText = "Код продажи";
                dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].Width = 70;
                this.dataGridView1.Columns[1].HeaderText = "Дата продажи";
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].HeaderText = "Код автомобиля";
                dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].HeaderText = "Код менеджера";
                dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].HeaderText = "Код покупателя";
                dataGridView1.Columns[4].Visible = false;
                this.dataGridView1.Columns[5].HeaderText = "Код автомобиля";
                dataGridView1.Columns[5].Visible = false;
                this.dataGridView1.Columns[6].Width = 100;
                this.dataGridView1.Columns[6].HeaderText = "Марка автомобиля";
                this.dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[7].Width = 80;
                this.dataGridView1.Columns[7].HeaderText = "Тип автомобиля";
                this.dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[8].Width = 90;
                this.dataGridView1.Columns[8].HeaderText = "Страна";
                this.dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[9].Width = 130;
                this.dataGridView1.Columns[9].HeaderText = "Номер кузова";
                this.dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[10].Width = 50;
                this.dataGridView1.Columns[10].HeaderText = "Год выпуска";
                this.dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[11].HeaderText = "Цвет кузова";
                this.dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[12].Width = 75;
                this.dataGridView1.Columns[12].HeaderText = "Дата поступления";
                this.dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[13].Width = 75;
                this.dataGridView1.Columns[13].HeaderText = "Цена автомобиля";
                this.dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[14].HeaderText = "Код статуса";
                dataGridView1.Columns[14].Visible = false;
                this.dataGridView1.Columns[15].HeaderText = "Код менеджера";
                dataGridView1.Columns[15].Visible = false;
                this.dataGridView1.Columns[16].Width = 210;
                this.dataGridView1.Columns[16].HeaderText = "ФИО менеджера";
                this.dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[17].Width = 110;
                this.dataGridView1.Columns[17].HeaderText = "№ телефона менеджера";
                this.dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[18].HeaderText = "Код покупателя";
                dataGridView1.Columns[18].Visible = false;
                this.dataGridView1.Columns[19].Width = 210;
                this.dataGridView1.Columns[19].HeaderText = "ФИО покупателя";
                this.dataGridView1.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[20].Width = 80;
                this.dataGridView1.Columns[20].HeaderText = "Паспорт";
                this.dataGridView1.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[21].Width = 230;
                this.dataGridView1.Columns[21].HeaderText = "Адрес";
                this.dataGridView1.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[22].Width = 110;
                this.dataGridView1.Columns[22].HeaderText = "№ телефона покупателя";
                this.dataGridView1.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value);
            }

            label1.Text = (" Общая сумма реализации составляет: ") + sum.ToString("# ##0 ##0", System.Globalization.CultureInfo.InvariantCulture) + (" руб. 00 коп.");
        }
        // Кнопка "Печать".
        private void button1_Click(object sender, EventArgs e)
        {
            int kol = dataGridView1.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp =
                        new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView1.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начало заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // Кнопка "Назад".
        private void button2_Click(object sender, EventArgs e)
        {
            Avtosalon Win = new Avtosalon(ID);
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }
    }
}
