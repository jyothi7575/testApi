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
  public class BackOfficeManager : IBackOfficeManager
  {
   

    public IBackOfficeRepository IBackOfficeRrepository;
    public BackOfficeManager(IBackOfficeRepository IBackOfficeRrepository)
    {
      this.IBackOfficeRrepository = IBackOfficeRrepository;
    }



  
  }
}
