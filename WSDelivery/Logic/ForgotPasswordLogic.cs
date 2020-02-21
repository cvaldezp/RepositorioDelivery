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
    public class ForgotPasswordLogic
    {
        #region SecurityUserForgotPasswordJson Definition
        public List<UserResponseGeneric> SecurityUserForgotPasswordJson(string dato)
        {
            DataTable dtJson = (DataTable)JsonConvert.DeserializeObject(dato, typeof(DataTable));
            var datos = dtJson.Select();

            List<UserResponseGeneric> response = new List<UserResponseGeneric>();
            using (MySqlConnection con = Connection.conn())
            {
                MySqlCommand cmd = new MySqlCommand("PRC_SECURITY_USER_FORGOT_PASSWORD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@pi_security_user_mail", datos[0][0].ToString()));

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