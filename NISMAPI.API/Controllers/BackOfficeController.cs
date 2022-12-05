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
    public class BackOfficeController : ApiController
    {
        public IBackOfficeManager IBackOfficeManager;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BackOfficeController(IBackOfficeManager IBackOfficeManager)
        {
            this.IBackOfficeManager = IBackOfficeManager;
        }

  }
}
