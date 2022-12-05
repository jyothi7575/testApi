using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NISMAPI.Data.Interface
{
    public interface IMasterRrepository
    {
      
         Int64 DeleteStatusMaster(object filter);


         IEnumerable<T> GetSignUpDetailsByStatusID<T>(object filter);
         IEnumerable<T> GetSignUpDetails<T>();
         IEnumerable<T> GetStatusMaster<T>();
         T GetRegistrationLogin<T>(object filter);
         IEnumerable<T> GetSignUpDetailsByEmailMobileOtpID<T>(object filter);
         IEnumerable<T> GetSignUpDetailsByID<T>(object filter);


         Int64 UpdateSignUpDetails(object filter);
         Int64 UpdateStatusMaster(object filter);


         Int64 InsertStatusMaster(object filter);
         Int64 InsertSignUpDetails(object filter);



  }
}
