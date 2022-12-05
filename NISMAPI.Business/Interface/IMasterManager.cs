using StaticWebAPI.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NISMAPI.Business.Interface
{
    public interface IMasterManager
    {
        // Get details------------------------
        IEnumerable<dynamic> GetStatusMaster();
        IEnumerable<dynamic> GetSignUpDetailsByStatusID(object filter);
        IEnumerable<dynamic> GetSignUpDetails();

        Int64 InsertStatusMaster(MasterEntity MasterEntity);

        Int64 UpdateStatusMaster(MasterEntity Entity);
        Int64 UpdateSignUpDetails(MasterEntity Entity);

        Int64 DeleteStatusMaster(object filter);

        //Int64 InsertSignUpDetails(MasterEntity MasterEntity);
        dynamic GetRegistrationLogin(object filter);
        IEnumerable<dynamic> GetSignUpDetailsByEmailMobileOtpID(object filter);
        IEnumerable<dynamic> GetSignUpDetailsByID(object filter);
  }
}
