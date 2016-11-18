using WLC.Admin.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WLC.Admin.Controllers
{
    [SessionExpireFilter]
    public class NavController : Controller
    {
        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}