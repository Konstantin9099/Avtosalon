using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AvtosalonDB
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "avto_salon_db";
            string user = "root";
            string password = "root";
            return DBMySQLUtils.GetDBConnection(host, port, database, user, password);
        }

    }
}
