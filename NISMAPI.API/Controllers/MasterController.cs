using NISMAPI.Business.Interface;
using System.Net.Http;
using System.Net;
using System;
using System.Web.Http;
using log4net;
using System.Reflection;
using StaticWebAPI.Business.Entities;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace NISMAPI.API.Controllers
{
    public class MasterController : ApiController
    {

        public IMasterManager IMasterManager;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MasterController(IMasterManager IMasterManager)
        {
            this.IMasterManager = IMasterManager;
        }



    // Get Details-------------------------------------------------------------------------------------



    [HttpPost]
    [Route("Master/GetToken")]
    public HttpResponseMessage Authenicate([FromBody] UserDetailsEntity entity)
    {
      HttpResponseMessage response;
      try
      {
        string EndPoint = WebConfigurationManager.AppSettings["EndPoint"];
        //var authtoken = "";
        var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", entity.UserName ),
                        new KeyValuePair<string, string> ( "Password", entity.Password )
                    };
        var content = new FormUrlEncodedContent(pairs);
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        using (var client = new HttpClient())
        {
          client.BaseAddress = new Uri(EndPoint);
          var token = client.PostAsync(WebConfigurationManager.AppSettings["AuthEndPoint"], content).Result;

          if (token.IsSuccessStatusCode)
          {
            var authtoken = token.Content.ReadAsAsync<dynamic>().Result.access_token;
            client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", Convert.ToString(authtoken));
            var filter = new { UserName = entity.UserName, Password = entity.Password };
            UserDetailsEntity UserDetailsEntity;
            //LoginEntity LoginEntity;
              var result = client.GetAsync(WebConfigurationManager.AppSettings["GetRegistrationLogin"] + "?UserName=" + entity.UserName + "&Password=" + entity.Password ).Result;
              if (result.IsSuccessStatusCode)
              {
                response = Request.CreateResponse(HttpStatusCode.OK, result);

              }
              else
              {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid UserName/Password");
              }
          }

          else
          {
            response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Cannot generate Token");
          }
        }
        //response = Request.CreateResponse(HttpStatusCode.OK, authtoken);
      }
      catch (Exception ex)
      {
        if (log.IsErrorEnabled)
        {
          log.Error("Post User Error:" + ex);
        }
        response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
      }
      return response;
    }






    [Authorize]
    [HttpGet]
    [Route("Master/GetRegistrationLogin")]
    public HttpResponseMessage GetRegistrationLogin(string UserName, string Password)
    {
      HttpResponseMessage response;
      try
      {
        var filter = new { UserName = UserName, Password = Password };
        object result = IMasterManager.GetRegistrationLogin(filter);
        if(result==null)
        {
          response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,"Bad Request");
        }
        else
        {
          response = Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
      }
      catch (Exception ex)
      {
        if (log.IsErrorEnabled)
        {
          log.Error("Error in GetRegistrationLogin" + ex);
        }
        response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
      }
      return response;
    }

    [HttpGet]
        [Route("Master/GetStatusMaster")]
        public HttpResponseMessage GetStatusMaster()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetStatusMaster();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetStatusMaster in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpPost]
        [Route("Master/InsertStatusMaster")]
        public HttpResponseMessage InsertStatusMaster(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {


                Int64 result = IMasterManager.InsertStatusMaster(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);


            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertStatusMaster", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertStatusMaster");
            }
            return response;
        }

        [HttpPost]
        [Route("Master/UpdateStatusMaster")]
        public HttpResponseMessage UpdateStatusMaster([FromBody] MasterEntity entity)
        {
            HttpResponseMessage response;
            try
            {


                object res = IMasterManager.UpdateStatusMaster(entity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateStatusMaster in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/DeleteStatusMaster")]
        public HttpResponseMessage DeleteStatusMaster(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IMasterManager.DeleteStatusMaster(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteStatusMaster :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteStatusMaster");
            }
            return response;
        }


        [HttpGet]
        [Route("Master/GetSignUpDetailsByStatusID")]
        public HttpResponseMessage GetSignUpDetailsByStatusID(Int64 StatusID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    StatusID = StatusID
                };
                object res = IMasterManager.GetSignUpDetailsByStatusID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetSignUpDetailsByStatusID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetSignUpDetails")]
        public HttpResponseMessage GetSignUpDetails()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetSignUpDetails();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetSignUpDetails in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpPost]
        [Route("Master/UpdateSignUpDetails")]
        public HttpResponseMessage UpdateSignUpDetails([FromBody] MasterEntity entity)
        {
            HttpResponseMessage response;
            try
            {


                object res = IMasterManager.UpdateSignUpDetails(entity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateSignUpDetails in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


    //[HttpPost]
    //[Route("Master/InsertSignUpDetails")]
    //public HttpResponseMessage InsertSignUpDetails(MasterEntity MasterEntity)
    //{
    //  HttpResponseMessage response;
    //  try
    //  {


    //    Int64 result = IMasterManager.InsertSignUpDetails(MasterEntity);
    //    response = Request.CreateResponse(HttpStatusCode.OK, result);


    //  }
    //  catch (Exception ex)
    //  {
    //    if (log.IsErrorEnabled)
    //    {
    //      log.Error("Error in InsertSignUpDetails", ex);
    //    }
    //    response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertStatusMaster");
    //  }
    //  return response;
    //}

    [HttpGet]
    [Route("Master/GetSignUpDetailsByEmailMobileOtpID")]
    public HttpResponseMessage GetSignUpDetailsByEmailMobileOtpID(Int64 ID, Int64 MobileOTP, Int64 EmailOTP)
    {
      HttpResponseMessage response;
      try
      {

        var j = new
        {
          ID = ID,
          MobileOTP = MobileOTP,
          EmailOTP = EmailOTP
        };
        object res = IMasterManager.GetSignUpDetailsByEmailMobileOtpID(j);
        response = Request.CreateResponse(HttpStatusCode.OK, res);
      }
      catch (Exception ex)
      {
        if (log.IsErrorEnabled)
        {
          log.Error(" Error in GetSignUpDetailsByEmailMobileOtpID in Master Controller" + ex);
        }
        response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
      }
      return response;
    }

    [HttpGet]
    [Route("Master/GetSignUpDetailsByID")]
    public HttpResponseMessage GetSignUpDetailsByID(Int64 ID)
    {
      HttpResponseMessage response;
      try
      {
        var j = new
        {
          ID = ID
        };
        object res = IMasterManager.GetSignUpDetailsByID(j);
        response = Request.CreateResponse(HttpStatusCode.OK, res);
      }
      catch (Exception ex)
      {
        if (log.IsErrorEnabled)
        {
          log.Error(" Error in GetSignUpDetailsByID in Master Controller" + ex);
        }
        response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
      }
      return response;
    }
  }
}
