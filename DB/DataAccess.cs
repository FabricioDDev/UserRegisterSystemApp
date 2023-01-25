using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB
{
    public class DataAccess
    {
        public DataAccess()
        {
            connection = new SqlConnection("server=BRENDA-PC; database=UserRegister; integrity security=true");
            command = new SqlCommand();
        }
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader readerProp
        {
            get { return reader; }
        }
    }
}
