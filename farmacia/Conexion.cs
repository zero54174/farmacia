using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmacia
{
    class Conexion
    {
        public SqlConnection Conectar()
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-3J24IC0\\SQLEX;integrated security=yes; database=bd_farmacia");
            return con;


        }
    }
}
