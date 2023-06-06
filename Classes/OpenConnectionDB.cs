using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Session_1.Classes
{
    public class OpenConnectionDB       //открытие соединения с БД
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=localhost\SERJASSQL;Initial Catalog=GlazkiSave;Integrated Security=True");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
