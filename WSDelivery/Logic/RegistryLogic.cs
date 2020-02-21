using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WSDelivery.Connections;
using WSDelivery.Models;

namespace WSDelivery.Logic
{
    public class RegistryLogic
    {
        #region SecurityUserRegisterJson Definition
        public List<UserResponseGeneric> SecurityUserRegisterJson(string dato)
        {
            DataTable dtJson = (DataTable)JsonConvert.DeserializeObject(dato, typeof(DataTable));
            var datos = dtJson.Select();

            List<UserResponseGeneric> response = new List<UserResponseGeneric>();
            using (MySqlConnection con = Connection.conn())
            {
                MySqlCommand cmd = new MySqlCommand("PRC_SECURITY_USER_REGISTRY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_name", datos[0][0].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_last_name", datos[0][1].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_identification", datos[0][2].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_address", datos[0][3].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_mail", datos[0][4].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_date_of_birth", datos[0][5].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_password", datos[0][6].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_type", datos[0][7].ToString()));
                
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    response.Add(new UserResponseGeneric
                    {
                        status = rdr.GetBoolean(rdr.GetOrdinal("ESTADO")),
                        dato = rdr.GetString(rdr.GetOrdinal("DATO")),
                        message = rdr.GetString(rdr.GetOrdinal("MENSAJE"))
                    });
                }
                rdr.Close();
                con.Close();
            }
            return response;
        }
        #endregion

    }
}