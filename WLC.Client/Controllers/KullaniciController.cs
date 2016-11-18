using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WLC.Admin.Infrastructure.Concrete;
using WLC.Domain.Interface;

namespace WLC.Admin.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class KullaniciController : Controller
    {
        private IKullaniciRepo kullaniciRepo;
        public KullaniciController(IKullaniciRepo kr)
        {
            kullaniciRepo = kr;
        }

        public FileContentResult FotoYukle(int kullaniciId)
        {
            return File(System.IO.File.ReadAllBytes(ControllerContext.HttpContext.Server.MapPath("~/Content/Image/userProfile.jpg")), "image/jpeg");
        }

        public FileContentResult SessionFotoYukle()
        {
            return File(System.IO.File.ReadAllBytes(ControllerContext.HttpContext.Server.MapPath("~/Content/Image/userProfile.jpg")), "image/jpeg");
        }

        [HttpPost]
        public string FotoUpload()
        {

            var result = new { Data = "success" };
            return JsonConvert.SerializeObject(result);
        }
    }
}