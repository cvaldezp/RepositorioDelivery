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
    public class ResetPasswordLogic
    {
        #region SecurityUserResetPasswordJson Definition
        public List<UserResponseGeneric> SecurityUserResetPasswordJson(string dato)
        {
            DataTable dtJson = (DataTable)JsonConvert.DeserializeObject(dato, typeof(DataTable));
            var datos = dtJson.Select();

            List<UserResponseGeneric> response = new List<UserResponseGeneric>();
            using (MySqlConnection con = Connection.conn())
            {
                MySqlCommand cmd = new MySqlCommand("PRC_SECURITY_USER_RESET_PASSWORD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_reset_password_code", datos[0][0].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_password", datos[0][1].ToString()));

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