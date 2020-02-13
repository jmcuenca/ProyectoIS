using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApiCore.ConnectionClass
{
    public class ClassConnection
    {
        SqlConnection conn;

        public int Conectar()
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["AsociacionDatabase"].ConnectionString;
                conn = new SqlConnection(connection);
                conn.Open();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public int Desconectar()
        {
            try
            {
                conn.Close();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public int loginUser(String consulta)
        {
            try
            {
                SqlCommand con = new SqlCommand(consulta, conn);
                int resp = (int)con.ExecuteScalar();
                return resp;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
    }
}