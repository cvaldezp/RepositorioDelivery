using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WSDelivery.Connections
{
    public class Connection
    {
        public static MySqlConnection conn()
        {
            string Ambiente = "Delivery_Pro";
            string cs = ConfigurationManager.ConnectionStrings[Ambiente].ConnectionString;
            MySqlConnection con = new MySqlConnection(cs);
            return con;
        }
    }
}