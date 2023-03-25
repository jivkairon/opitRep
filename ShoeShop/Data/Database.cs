using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Data
{
    class Database
    {
        private static string connectionString = "Server=DESKTOP-D0447AH\\SQLSERVERWOR; Database=ShoeShop; Integrated Security=true";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
