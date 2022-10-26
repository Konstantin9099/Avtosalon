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

namespace AvtosalonDB
{
    public partial class Avtorizacia : Form
    {
        public Avtorizacia()
        {
            InitializeComponent();
        }

        // Кнопка "Вход".
        private void button1_Click(object sender, EventArgs e)
        {
            // Запрос к таблице Authorization.
            string query = "SELECT id_user FROM Avtorizacia WHERE login ='" + textBox1.Text + "' and password = '" + textBox2.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            // Объект для выполнения SQL-запроса.
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                // Устанавливаем соединение с БД.
                conn.Open();
                int result = 0;
                result = Convert.ToInt32(cmDB.ExecuteScalar());
                if (result > 1)
                {
                    Avtosalon Win = new Avtosalon(result); // Обращение к форме "Автосалон", на которую будет совершаться переход.
                    Win.Owner = this;
                    this.Hide();
                    Win.Show(); // Запуск окна "Автосалон".
                    textBox1.Clear(); // Очистка поля - логин.
                    textBox2.Clear(); // Очистка поля - пароль.
                }
                else
                    MessageBox.Show("Возникла ошибка авторизации!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        // Кнопка "Выход".
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
