using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticWebAPI.Business.Entities
{
    public class MasterEntity
    {
        
        public string Short { get; set; }
        public Int64 ID { get; set; }
        public string UniqueRegistraionNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string CountryCode { get; set; }
        public string EmailID { get; set; }
        public string Username { get; set; }
        public Int64 MobileOTP { get; set; }
        public Int64 EmailOTP { get; set; }

        public string Password { get; set; }
        public Int64 StatusID { get; set; }
        public string Remarks { get; set; }








    }
}


