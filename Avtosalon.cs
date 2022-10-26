using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ExcelObj = Microsoft.Office.Interop.Excel;

namespace AvtosalonDB
{
    public partial class Avtosalon : Form
    {
        public int ID = 0;

        public Avtosalon(int ID_log)
        {
            InitializeComponent();
            Get_Info(ID_log);
            ID = ID_log;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        // Для завершения отладки после закрытия окна программы.
        private void Avtosalon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Получаем из БД данные для таблиц программы и выводим их в DataGridView1.
        public void Get_Info(int ID)
        {
            // Таблица вкладки "Автомобили".
            string query = "SELECT * FROM avto, status WHERE avto.id_status=status.id_status ORDER BY data_postupleniya; ";
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
                //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Red;
                this.dataGridView1.Columns[0].HeaderText = "Код автомобиля";
                dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].HeaderText = "Марка автомобиля";
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].HeaderText = "Тип автомобиля";
                this.dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].Width = 100;
                this.dataGridView1.Columns[3].HeaderText = "Страна";
                this.dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].Width = 180;
                this.dataGridView1.Columns[4].HeaderText = "Номер кузова";
                this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[5].Width = 75;
                this.dataGridView1.Columns[5].HeaderText = "Год выпуска";
                this.dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[6].Width = 75;
                this.dataGridView1.Columns[6].HeaderText = "Цвет кузова";
                this.dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[7].HeaderText = "Дата поступления";
                this.dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[8].HeaderText = "Цена";
                //dataGridView1.Columns[8].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[9].HeaderText = "Код статуса";
                dataGridView1.Columns[9].Visible = false;
                this.dataGridView1.Columns[10].HeaderText = "Код статуса";
                dataGridView1.Columns[10].Visible = false;
                // dataGridView1.Columns[10].DisplayIndex = 7;
                this.dataGridView1.Columns[11].HeaderText = "Статус";
                this.dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Таблица вкладки "Менеджеры".
            string query1 = "SELECT * FROM menedzher ORDER BY fio_menedzher; ";
            MySqlConnection conn1 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, conn1);
            DataTable dt1 = new DataTable();
            try
            {
                conn1.Open();
                dataGridView3.DataSource = dt1;
                dataGridView3.ClearSelection();
                sda1.Fill(dt1);
                dataGridView3.DataSource = dt1;
                dataGridView3.ClearSelection();
                this.dataGridView3.Columns[0].HeaderText = "Код менеджера";
                dataGridView3.Columns[0].Visible = false;
                this.dataGridView3.Columns[1].Width = 280;
                this.dataGridView3.Columns[1].HeaderText = "ФИО менеджера";
                this.dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[2].Width = 200;
                this.dataGridView3.Columns[2].HeaderText = "№ телефона";
                this.dataGridView3.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[2].Width = 180;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Таблица вкладки "Покупатели".
            string query2 = "SELECT * FROM pokupatel ORDER BY fio_pokupatel; ";
            MySqlConnection conn2 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, conn2);
            DataTable dt2 = new DataTable();
            try
            {
                conn2.Open();
                dataGridView4.DataSource = dt2;
                dataGridView4.ClearSelection();
                sda2.Fill(dt2);
                dataGridView4.DataSource = dt2;
                dataGridView4.ClearSelection();
                this.dataGridView4.Columns[0].HeaderText = "Код покупателя";
                dataGridView4.Columns[0].Visible = false;
                this.dataGridView4.Columns[1].Width = 270;
                this.dataGridView4.Columns[1].HeaderText = "ФИО покупателя";
                this.dataGridView4.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[2].Width = 130;
                this.dataGridView4.Columns[2].HeaderText = "Серия и № паспорта";
                this.dataGridView4.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[3].Width = 350;
                this.dataGridView4.Columns[3].HeaderText = "Адрес";
                this.dataGridView4.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[4].Width = 150;
                this.dataGridView4.Columns[4].HeaderText = "№ телефона";
                this.dataGridView4.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Продажи" - таблица "Автомобиль".
            string query3 = "SELECT id_avto AS 'Код автомобиля', GROUP_CONCAT(marka_avto, '  ', tip_avto, '  ', strana, '  ', nomer_kuzova, '  ', god_vypuska, '  ', cvet_kuzova) AS 'Параметры автомобилей:', cena_avto AS 'Цена', id_status AS 'Статус' FROM avto GROUP BY id_avto; ";
            MySqlConnection conn3 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, conn3);
            DataTable dt3 = new DataTable();
            try
            {
                conn3.Open(); 
                dataGridView2.DataSource = dt3;
                dataGridView2.ClearSelection();
                sda3.Fill(dt3);
                dataGridView2.DataSource = dt3;
                dataGridView2.ClearSelection();
                dataGridView2.Columns[0].Visible = false;
                this.dataGridView2.Columns[1].Width = 750;
                this.dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[2].Width = 120;
                this.dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[3].Visible = false;
                conn3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Продажи" - таблица "Покупатели".
            string query4 = "SELECT id_pokupatel AS 'Код покупателя', GROUP_CONCAT(fio_pokupatel, ' паспорт: ', pasport, '  ', adres, ' тел.: ', telefon) AS 'Данные покупателей:' FROM pokupatel GROUP BY id_pokupatel; ";
            MySqlConnection conn4 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda4 = new MySqlDataAdapter(query4, conn4);
            DataTable dt4 = new DataTable();
            try
            {
                conn4.Open();
                dataGridView6.DataSource = dt4;
                dataGridView6.ClearSelection();
                sda4.Fill(dt4);
                dataGridView6.DataSource = dt4;
                dataGridView6.ClearSelection();
                dataGridView6.Columns[0].Visible = false;
                this.dataGridView6.Columns[1].Width = 850;
                this.dataGridView6.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                conn4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Продажи" - таблица "Менеджеры".
            string query5 = "SELECT id_menedzher AS 'Код менеджера', GROUP_CONCAT(fio_menedzher, '  ', ' тел.: ', telefon) AS 'Данные менеджеров:' FROM menedzher GROUP BY id_menedzher; ";
            MySqlConnection conn5 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda5 = new MySqlDataAdapter(query5, conn5);
            DataTable dt5 = new DataTable();
            try
            {
                conn4.Open();
                dataGridView5.DataSource = dt5;
                dataGridView5.ClearSelection();
                sda5.Fill(dt5);
                dataGridView5.DataSource = dt5;
                dataGridView5.ClearSelection();
                dataGridView5.Columns[0].Visible = false;
                this.dataGridView5.Columns[1].Width = 480;
                this.dataGridView5.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                conn5.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Запрос к БД из вкладки "Профиль".
            string query6 = "SELECT * FROM avtorizacia; ";
            MySqlConnection conn6 = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query6, conn6);
            try
            {
                conn6.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                    while (rd.Read())
                    {
                        login_label.Text = rd.GetString(1);
                        password_label.Text = rd.GetString(2);
                    }
                conn6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        //Функция, позволяющая отправить команду на сервер БД для оптимизации кода.
        public void do_Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        // ******************ВКЛАДКА АВТОМОБИЛИ *********************

        // Вывод данных в текстовые поля вкладки "Автомобили".
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); // Марка автомобиля.
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); // Тип автомобиля.
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            textBox24.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); // Страна.
            this.textBox24.ForeColor = System.Drawing.Color.Blue;
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); // Номер кузова.
            this.maskedTextBox1.ForeColor = System.Drawing.Color.Blue;
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString(); // Год выпуска.
            this.maskedTextBox2.ForeColor = System.Drawing.Color.Blue;
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString(); // Цвет.
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString(); // Дата поступления.
            textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString(); // Цена.
            this.textBox4.ForeColor = System.Drawing.Color.Green;
            this.textBox25.ForeColor = System.Drawing.Color.Red;
            textBox25.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString(); // Статус.
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // Кнопка "Поиск" - вкладка "Автомобили".
        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox5.Text.ToLower()))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
            MessageBox.Show("     Не найдено!" + Environment.NewLine);
        }

        // Кнопка "Добавить" - вкладка "Автомобили".
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были введены ФИО.
            if (textBox1.Text == null || textBox1.Text == "")
                MessageBox.Show(
                    "Введите марку автомобиля.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox2.Text == null || textBox2.Text == "")
                MessageBox.Show(
                    "Введите тип автомобиля.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (maskedTextBox1.Text == null || maskedTextBox1.Text == "")
                MessageBox.Show(
                    "Введите № кузова (VIN).",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (maskedTextBox2.Text == null || maskedTextBox2.Text == "")
                MessageBox.Show(
                    "Введите год выпуска.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox3.Text == null || textBox3.Text == "")
                MessageBox.Show(
                    "Введите цвет кузова.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox4.Text == null || textBox4.Text == "")
                MessageBox.Show(
                    "Введите цену.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {

                string Date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string query = "insert into avto(marka_avto, tip_avto, strana, nomer_kuzova, god_vypuska, cvet_kuzova, data_postupleniya, cena_avto, id_status) " +
                        "" +
                        "values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox24.Text + "', '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '" + textBox3.Text + "', '" + Date1 + "', '" + textBox4.Text + "', '" + '1' + "'); ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                }
                do_Action(query);
                Get_Info(ID);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox24.Clear();
                    textBox25.Clear();
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                }
            }
        }

        // Кнопка "Изменить" - вкладка "Автомобили".
        private void button2_Click(object sender, EventArgs e)
        {
            string id_st = textBox25.Text;
            try
            {
                string ID_status = "SELECT id_status FROM status where status='" + id_st + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(ID_status, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(ID_status, conn);
                label9.Text = command.ExecuteScalar().ToString();
                conn.Close();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Проверяем, чтобы были введены ФИО.
            if (textBox1.Text == null || textBox1.Text == "")
                MessageBox.Show(
                    "Введите марку автомобиля.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox2.Text == null || textBox2.Text == "")
                MessageBox.Show(
                    "Введите тип автомобиля.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (maskedTextBox1.Text == null || maskedTextBox1.Text == "")
                MessageBox.Show(
                    "Введите № кузова (VIN).",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (maskedTextBox2.Text == null || maskedTextBox2.Text == "")
                MessageBox.Show(
                    "Введите год выпуска.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox3.Text == null || textBox3.Text == "")
                MessageBox.Show(
                    "Введите цвет кузова.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox4.Text == null || textBox4.Text == "")
                MessageBox.Show(
                    "Введите цену.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {

                    string Date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE avto SET marka_avto='" + textBox1.Text + "', tip_avto='" + textBox2.Text + "', strana='" + textBox24.Text + "', nomer_kuzova= '" + maskedTextBox1.Text + "', god_vypuska='" + maskedTextBox2.Text + "', cvet_kuzova='" + textBox3.Text + "', data_postupleniya='" + Date1 + "', cena_avto='" + textBox4.Text + "', id_status='" + label9.Text + "' WHERE id_avto=" + n + "; ";
                    MySqlConnection conn1 = DBUtils.GetDBConnection();
                    MySqlCommand cmDB1 = new MySqlCommand(query, conn1);
                    try
                    {
                        conn1.Open();
                        conn1.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox24.Clear();
                    textBox25.Clear();
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                }
            }
        }

        // Кнопка "Удалить" - вкладка "Автомобили".
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены что хотите удалить информацию?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string del = "delete from avto where id_avto = " + n + ";";
                do_Action(del);
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Удаление невозможно.");
            }
            Get_Info(ID);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox24.Clear();
            textBox25.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        // Кнопка "Печать" - вкладка "Автомобили".
        private void button6_Click(object sender, EventArgs e)
        {
            int kol = dataGridView1.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
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
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // ********************* ВКЛАДКА ПРОДАЖИ **********************

        // Вывод данных во вкладке "Продажи" в текстовое поле таблицы "Покупатель".
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox11.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
            this.textBox11.ForeColor = System.Drawing.Color.Blue;
        }

        // Вывод данных во вкладке "Продажи" в текстовое поле таблицы "Автомобиль".
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            int cena = int.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());
            textBox6.Text = cena.ToString("# ##0 ##0", System.Globalization.CultureInfo.InvariantCulture) + (" руб.");
            this.textBox6.ForeColor = System.Drawing.Color.Green;
            this.textBox9.ForeColor = System.Drawing.Color.Blue;            
            int prod = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
            if (prod == 2)
            {
                label11.Text = "Автомобиль продан!";                      
            }
            else if (prod == 1)
            {
                label11.Text = " ";
            }
        }

        // Вывод данных во вкладке "Продажи" в текстовое поле таблицы "Менеджеры".
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            this.textBox10.ForeColor = System.Drawing.Color.Blue;
        }

        // Оформление продажи.
        private void button7_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были выбраны покупатель, автомобиль и менеджер.
            if (textBox11.Text == null || textBox11.Text == "")
                MessageBox.Show(
                    "Выберете покупателя.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox9.Text == null || textBox9.Text == "")
                MessageBox.Show(
                    "Выберете автомобиль.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox10.Text == null || textBox10.Text == "")
                MessageBox.Show(
                    "Выберете менеджера.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите оформить продажу?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int id_pok = int.Parse(dataGridView6.CurrentRow.Cells[0].Value.ToString());
                    int id_avt = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    int id_men = int.Parse(dataGridView5.CurrentRow.Cells[0].Value.ToString());
                    string Date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    string query = "insert into prodazha(data_prodazhi, id_avto, id_menedzhera, id_pokupatelya) values('" + Date + "', '" + id_avt + "', '" + id_men + "', '" + id_pok + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);

                    string query1 = "UPDATE avto SET id_status = '2' WHERE id_avto = " + id_avt + "; ";
                    MySqlConnection conn1 = DBUtils.GetDBConnection();
                    _ = new MySqlCommand(query1, conn1);
                    try
                    {
                        conn1.Open();
                        conn1.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query1);
                    Get_Info(ID);
                }
            }
        }

        // Кнопка "Отчет о продажах".
        private void button4_Click(object sender, EventArgs e)
        {
            Otchet Win = new Otchet(ID);
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        // ******************* ВКЛАДКА МЕНЕДЖЕРЫ *******************

        // Кнопка "Добавить" - вкладка "Менеджер".
        private void button13_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были введены ФИО.
            if (textBox14.Text == null || textBox14.Text == "")
                MessageBox.Show(
                    "Введите ФИО менеджера.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "insert into menedzher(fio_menedzher, telefon) values('" + textBox14.Text + "', '" + maskedTextBox8.Text + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                }
            }
        }

        // Кнопка "Изменить" - вкладка "Менеджер".
        private void button12_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были введены ФИО.
            if (textBox14.Text == null || textBox14.Text == "")
                MessageBox.Show(
                    "Введите ФИО менеджера.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE menedzher SET fio_menedzher='" + textBox14.Text + "', telefon='" + maskedTextBox8.Text + "' WHERE id_menedzher=" + n + "; ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                }
            }
        }

        // Кнопка "Поиск" - вкладка "Менеджер".
        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView3.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox15.Text.ToLower()))
                        {
                            dataGridView3.Rows[i].Selected = true;
                            break;
                        }
            }
            MessageBox.Show("     Не найдено!" + Environment.NewLine);
        }

        // Кнопка "Печать" - вкладка "Менеджер".
        private void button10_Click(object sender, EventArgs e)
        {
            int kol = dataGridView3.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView3.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView3.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView3.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // Вывод данных в текстовые поля вкладки "Менеджеры" при выделении соответствующей строки в таблице нажатием курсора.
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            this.textBox14.ForeColor = System.Drawing.Color.Blue;
            maskedTextBox8.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            this.maskedTextBox8.ForeColor = System.Drawing.Color.Blue;
        }

        // *********************** ВКЛАДКА ПОКУПАТЕЛИ ***********************

        // Вывод данных в текстовые поля вкладки "Покупатели" при выделении соответствующей строки в таблице нажатием курсора.
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox17.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            this.textBox17.ForeColor = System.Drawing.Color.Blue;
            maskedTextBox10.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            this.maskedTextBox10.ForeColor = System.Drawing.Color.Blue;
            textBox16.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            this.textBox16.ForeColor = System.Drawing.Color.Blue;
            maskedTextBox9.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            this.maskedTextBox9.ForeColor = System.Drawing.Color.Blue;
        }

        // Кнопка "Добавить" - вкладка "Покупатели".
        private void button17_Click(object sender, EventArgs e)
        {
             if (textBox17.Text == null || textBox17.Text == "")
                MessageBox.Show(
                    "Введите ФИО покупателя.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox16.Text == null || textBox16.Text == "")
                MessageBox.Show(
                    "Введитеадрес покупателя.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "insert into pokupatel(fio_pokupatel, pasport,  adres, telefon) values('" + textBox17.Text + "', '" + maskedTextBox10.Text + "', '" + textBox16.Text + "', '" + maskedTextBox9.Text + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                }
            }
        }

        // Кнопка "Изменить"  - вкладка "Покупатели".
        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == null || textBox17.Text == "")
                MessageBox.Show(
                    "Введите ФИО покупателя.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox16.Text == null || textBox16.Text == "")
                MessageBox.Show(
                    "Введите адрес покупателя.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE pokupatel SET  fio_pokupatel='" + textBox17.Text + "', pasport='" + maskedTextBox10.Text + "', adres= '" + textBox16.Text + "', telefon='" + maskedTextBox9.Text + "' WHERE id_pokupatel=" + n + "; ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                }
            }

        }

        // Кнопка "Поиск"  - вкладка "Покупатели".
        private void button15_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView4.RowCount; i++)
            {
                dataGridView4.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    if (dataGridView4.Rows[i].Cells[j].Value != null)
                        if (dataGridView4.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox18.Text.ToLower()))
                        {
                            dataGridView4.Rows[i].Selected = true;
                            break;
                        }
            }
            MessageBox.Show("     Не найдено!" + Environment.NewLine);
        }

        // Кнопка "Печать"  - вкладка "Покупатели".
        private void button14_Click(object sender, EventArgs e)
        {
            int kol = dataGridView4.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView4.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView4.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView4.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // ********************** ВКЛАДКА ПРОФИЛЬ ************************

        // Копка "Изменить" - вкладка "Профиль".
        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.Text == "Изменить")
            {
                textBox19.Visible = true;
                textBox19.Text = login_label.Text;
                login_label.Visible = false;
                textBox20.Visible = true;
                textBox20.Text = password_label.Text;
                password_label.Visible = false;
                button18.Text = "Сохранить";
            }
            else if (button18.Text == "Сохранить")
            {
                string query = "update avtorizacia set login ='" + textBox19.Text + "', password ='" + textBox20.Text + "' where id_user = " + ID.ToString() + ";";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    cmDB.ExecuteReader();
                    conn.Close();
                    textBox19.Visible = false;
                    textBox20.Visible = false;
                    login_label.Visible = true;
                    password_label.Visible = true;
                    button18.Text = "Изменить";
                    Get_Info(ID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                }
            }
        }
        // запрет на ввод любых символов и букв в поле ввода "Цена".
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(".")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
    }
}
