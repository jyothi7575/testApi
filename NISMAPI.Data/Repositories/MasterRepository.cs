using NISMAPI.Data.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NISMAPI.Data.Repositories
{
    public class MasterRepository : Repository, IMasterRrepository
    {



        //getD Details

        public IEnumerable<T> GetStatusMaster<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetStatusMaster", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertStatusMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertStatusMaster]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateStatusMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateStatusMaster", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
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
                return db.Execute("[SProc_DeleteStatusMaster]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetSignUpDetailsByStatusID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetSignUpDetailsByStatusID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<T> GetSignUpDetails<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetSignUpDetails", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateSignUpDetails(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateSignUpDetails", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    public Int64 InsertSignUpDetails(object filter)
    {
      try
      {
        return db.Query<Int64>("[dbo].[SProc_InsertSignUpDetails]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public T GetRegistrationLogin<T>(object filter)
    {
      try
      {
        return db.Query<T>("[dbo].[SProc_GetRegistrationLogin]", filter, commandType: CommandType.StoredProcedure).FirstOrDefault();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public IEnumerable<T> GetSignUpDetailsByEmailMobileOtpID<T>(object filter)
    {
      try
      {
        return db.Query<T>("SProc_GetSignUpDetailsByEmailMobileOtpID", filter, commandType: CommandType.StoredProcedure);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public IEnumerable<T> GetSignUpDetailsByID<T>(object filter)
    {
      try
      {
        return db.Query<T>("SProc_GetSignUpDetailsByID", filter, commandType: CommandType.StoredProcedure);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

  }
}
