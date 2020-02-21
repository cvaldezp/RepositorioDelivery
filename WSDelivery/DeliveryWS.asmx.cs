using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSDelivery.Logic;
using WSDelivery.Models;

namespace WSDelivery
{
    /// <summary>
    /// Descripción breve de DeliveryWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class DeliveryWS : System.Web.Services.WebService
    {
        #region WsSecurityUser Definition
        [WebMethod(Description = "WS que realiza operaciones para Login de Usuarios")]
        public string WsSecurityUser(string mail, string password)
        {
            LoginLogic mysqlGet = new LoginLogic();
            var datos = mysqlGet.SecurityUserUnics(mail, password);
            var response = JsonConvert.SerializeObject(datos, Formatting.Indented);
            return response;
        }
        #endregion

        #region WsSecurityLoginJson Definition
        [WebMethod(Description = "WS que realiza operaciones para Login de Usuarios")]
        public string WsSecurityLoginJson(string dato)
        {
            LoginLogic mysqlGet = new LoginLogic();
            var datos = mysqlGet.SecurityUserJson(dato);
            var response = JsonConvert.SerializeObject(datos, Formatting.Indented);
            return response;
        }
        #endregion

        #region WsRSecurityRegisterJson Definition
        [WebMethod(Description = "WS que realiza operaciones para Registro de Usuarios")]
        public string WsSecurityRegisterJson(string dato)
        {
            RegistryLogic mysqlGet = new RegistryLogic();
            var datos = mysqlGet.SecurityUserRegisterJson(dato);
            var response = JsonConvert.SerializeObject(datos, Formatting.Indented);
            return response;
        }
        #endregion

        #region WsSecurityForgotPasswordJson Definition
        [WebMethod(Description = "WS que realiza operaciones para Olvido de Contraseña de Usuarios")]
        public string WsSecurityForgotPasswordJson(string dato)
        {
            ForgotPasswordLogic mysqlGet = new ForgotPasswordLogic();
            var datos = mysqlGet.SecurityUserForgotPasswordJson(dato);
            var response = JsonConvert.SerializeObject(datos, Formatting.Indented);
            return response;
        }
        #endregion

        #region WsSecurityResetPasswordJson Definition
        [WebMethod(Description = "WS que realiza operaciones para Cambio de Contraseña de Usuarios")]
        public string WsSecurityResetPasswordJson(string dato)
        {
            ResetPasswordLogic mysqlGet = new ResetPasswordLogic();
            var datos = mysqlGet.SecurityUserResetPasswordJson(dato);
            var response = JsonConvert.SerializeObject(datos, Formatting.Indented);
            return response;
        }
        #endregion

        #region WsSecurityVerifyAccountJson Definition
        [WebMethod(Description = "WS que realiza operaciones para Verificar la Cuenta de Usuarios")]
        public string WsSecurityVerifyAccountJson(string dato)
        {
            VerifyAccountLogic mysqlGet = new VerifyAccountLogic();
            var datos = mysqlGet.SecurityUserVerifyAccountJson(dato);
            var response = JsonConvert.SerializeObject(datos, Formatting.Indented);
            return response;
        }
        #endregion
    }
}
