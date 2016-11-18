using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Newtonsoft.Json;
using WLC.Admin.Infrastructure.Concrete;
using WLC.Domain.Entities;
using WLC.Domain.Interface;

namespace WLC.Admin.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class DefaultController : Controller
    {
        private IWLCTanimRepo wlcTanimRepo;
        public DefaultController(IWLCTanimRepo wtr)
        {
            wlcTanimRepo = wtr;
        }

        public ActionResult Index()
        {
            if (Session["CurrentUserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
                return View();
        }

        public ViewResult Liste()
        {
            return View();
        }

        public string JsonSorgulaList()
        {
            var iDisplayLength = int.Parse(Request["iDisplayLength"]);
            var iDisplayStart = int.Parse(Request["iDisplayStart"]);
            var iSearch = Request["sSearch"];
            var iSortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var iSortDirection = Request["sSortDir_0"];
            var totalRecords = wlcTanimRepo.WLCTanimlar.Count();

            if (iDisplayLength == -1)
            {
                iDisplayLength = totalRecords;
            }

            var filteredList = wlcTanimRepo.WLCTanimlar;
            if (!string.IsNullOrEmpty(iSearch))
            {
                var search = iSearch.ToLower();
                filteredList = wlcTanimRepo.WLCTanimlar.Where(x => (!x.APSAYISI.IsEmpty() && x.APSAYISI.ToLower().Contains(search)) ||
                                                   (!x.FLEXCONNAME.IsEmpty() && x.FLEXCONNAME.ToLower().Contains(search)) ||
                                                   (!x.IL.IsEmpty() && x.IL.ToLower().Contains(search)) ||
                                                   (!x.ILCE.IsEmpty() && x.ILCE.ToLower().Contains(search)) ||
                                                   (!x.IP.IsEmpty() && x.IP.ToLower().Contains(search)) ||
                                                   (!x.OKULADI.IsEmpty() && x.OKULADI.ToLower().Contains(search)) ||
                                                   (!x.OKULKODU.IsEmpty() && x.OKULKODU.ToLower().Contains(search)) ||
                                                   (!x.SUBNET.IsEmpty() && x.SUBNET.ToLower().Contains(search)) ||
                                                   (!x.TESISKODU.IsEmpty() && x.TESISKODU.ToLower().Contains(search)) ||
                                                   (!x.WLC1IP.IsEmpty() && x.WLC1IP.ToLower().Contains(search)) ||
                                                   (!x.WLC1NAME.IsEmpty() && x.WLC1NAME.ToLower().Contains(search)) ||
                                                   (!x.WLC2IP.IsEmpty() && x.WLC2IP.ToLower().Contains(search)) ||
                                                   (!x.WLC2NAME.IsEmpty() && x.WLC2NAME.ToLower().Contains(search)) ||
                                                   (!x.SERVERNAME.IsEmpty() && x.SERVERNAME.ToLower().Contains(search)));
            }

            Func<WLCTanim, string> orderFunc = (item => iSortColumnIndex == 1
                ? item.IL
                : iSortColumnIndex == 2
                    ? item.ILCE
                    : iSortColumnIndex == 3
                        ? item.OKULADI
                        : iSortColumnIndex == 4
                            ? item.OKULKODU
                            : iSortColumnIndex == 5
                                ? item.APSAYISI
                                : iSortColumnIndex == 6
                                    ? item.WLC1NAME
                                    : iSortColumnIndex == 7
                                        ? item.WLC1IP
                                        : iSortColumnIndex == 8
                                            ? item.WLC2IP
                                            : iSortColumnIndex == 9
                                                ? item.WLC2NAME
                                                : iSortColumnIndex == 10
                                                    ? item.SERVERNAME
                                                    : iSortColumnIndex == 11
                                                        ? item.FLEXCONNAME
                                                        : iSortColumnIndex == 12
                                                            ? item.TESISKODU
                                                            : iSortColumnIndex == 13
                                                                ? item.IP
                                                                : item.SUBNET);

            var list = filteredList.Skip(iDisplayStart).Take(iDisplayLength);
            var orderedList = (iSortDirection == "asc") ? list.OrderBy(orderFunc).ToList() : list.OrderByDescending(orderFunc).ToList();

            var result = new
            {
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = (from item in orderedList
                          select new[] 
                            {
                                Convert.ToString(item.ID), 
                                item.IL,
                                item.ILCE,
                                item.OKULADI,
                                item.OKULKODU,
                                item.APSAYISI,
                                item.WLC1NAME,
                                item.WLC1IP,
                                item.WLC2NAME,
                                item.WLC2IP,
                                item.SERVERNAME,
                                item.FLEXCONNAME,
                                item.TESISKODU,
                                item.IP,
                                item.SUBNET,
                                ""
                            })
            };

            return JsonConvert.SerializeObject(result);
        }

        public ViewResult Rapor()
        {
            return View();
        }

    }
}