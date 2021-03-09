using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Infra.Helper
{
    public class DatabaseHelperClass : IDatabaseHelperClass
    {
        private readonly String connectionString;
        public SqlConnection connection { get; set; }
        public StringBuilder query { get; set; }
        public SqlCommand command { get; set; }
        public DatabaseHelperClass(String connectionString)
        {
            this.connectionString = connectionString;
            this.connection = new SqlConnection(this.connectionString);
        }


    }
}
