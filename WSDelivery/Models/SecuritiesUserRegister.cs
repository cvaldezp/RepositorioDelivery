using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDelivery.Models
{
    public class SecuritiesUserRegister
    {
        public int security_user_id { get; set; }
        public string security_user_name { get; set; }
        public string security_user_last_name { get; set; }
        public string security_user_identification { get; set; }
        public string security_user_address { get; set; }
        public string security_user_mail { get; set; }
        public Nullable<System.DateTime> security_user_date_of_birth { get; set; }
        public string security_user_password { get; set; }
        public bool security_user_mail_verified { get; set; }
        public System.Guid security_user_activation_code { get; set; }
        public string security_user_state { get; set; }
        public string security_user_reset_password_code { get; set; }
        public Nullable<System.DateTime> user_creation_date { get; set; }
        public Nullable<System.DateTime> user_modification_date { get; set; }
        public string security_user_type { get; set; }
    }
}