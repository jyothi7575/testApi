using NISMAPI.Business.Interface;
using NISMAPI.Data.Interface;
using NISMAPI.Data.Repositories;
using StaticWebAPI.Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NISMAPI.Business.Managers
{
    public class MasterManager : IMasterManager
    {
        public IMasterRrepository IMasterRrepository;
        public MasterManager(IMasterRrepository IMasterRrepository)
        {
            this.IMasterRrepository = IMasterRrepository;
        }



        // Get Details--------------------------------------------------------
        public IEnumerable<dynamic> GetStatusMaster()
        {
            try
            {
                return IMasterRrepository.GetStatusMaster<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertStatusMaster(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    Short = MasterEntity.Short
                };
                return IMasterRrepository.InsertStatusMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateStatusMaster(MasterEntity Entity)
        {
            try
            {
                var filter = new
                {
                    ID = Entity.ID,
                    Short = Entity.Short



                };
                return IMasterRrepository.UpdateStatusMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteStatusMaster(object filter)
        {
            try
            {
                return IMasterRrepository.DeleteStatusMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetSignUpDetailsByStatusID(object filter)
        {
            try
            {
                return IMasterRrepository.GetSignUpDetailsByStatusID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetSignUpDetails()
        {
            try
            {
                return IMasterRrepository.GetSignUpDetails<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Int64 UpdateSignUpDetails(MasterEntity Entity)
        {
            try
            {
                var filter = new
                {
                    ID = Entity.ID,
                    UniqueRegistraionNumber = Entity.UniqueRegistraionNumber,
                    FirstName=Entity.FirstName,
                    MiddleName = Entity.MiddleName,
                    MobileNumber = Entity.MobileNumber,
                    CountryCode = Entity.CountryCode,
                    EmailID = Entity.EmailID,
                    Username = Entity.Username,
                    MobileOTP = Entity.MobileOTP,
                    EmailOTP = Entity.EmailOTP,
                    Password = Entity.Password,
                    StatusID = Entity.StatusID,
                    Remarks = Entity.Remarks,

              };
                return IMasterRrepository.UpdateSignUpDetails(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    public Int64 InsertSignUpDetails(MasterEntity MasterEntity)
    {
      try
      {
        var filter = new
        {
          FirstName = MasterEntity.FirstName,
          MiddleName= MasterEntity.MiddleName,
          LastName = MasterEntity.LastName,
          MobileNumber = MasterEntity.MobileNumber,
          CountryCode = MasterEntity.CountryCode,
          EmailID = MasterEntity.EmailID,
          Username = MasterEntity.Username,
          MobileOTP = MasterEntity.MobileOTP,
          EmailOTP = MasterEntity.EmailOTP,
          Password = MasterEntity.Password,
          StatusID = MasterEntity.StatusID,
          Remarks = MasterEntity.Remarks
        };
        return IMasterRrepository.InsertSignUpDetails(filter);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public dynamic GetRegistrationLogin(object filter)
    {
      try
      {
        return IMasterRrepository.GetRegistrationLogin<dynamic>(filter);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public IEnumerable<dynamic> GetSignUpDetailsByEmailMobileOtpID(object filter)
    {
      try
      {
        return IMasterRrepository.GetSignUpDetailsByEmailMobileOtpID<dynamic>(filter);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public IEnumerable<dynamic> GetSignUpDetailsByID(object filter)
    {
      try
      {
        return IMasterRrepository.GetSignUpDetailsByID<dynamic>(filter);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


  }
}


