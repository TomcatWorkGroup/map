using Microsoft.AspNetCore.Mvc;

namespace BaiduMapApp.Controllers
{
    public class MapController : Controller
    {
        
        public IActionResult Baidu()
        {
            dynamic data;
            if (Request.Method.ToLower().Equals("get"))
            {
                data = Request.Query;
            }
            else
            {
                data = Request.Form;
            }
            string city = data["city"];
            string address = data["address"];
            string ovLayList = data["ovlaylist"];
            string initzl = data["InitZoomLevel"];
            string _InitLng = data["initlng"];
            string _InitLat = data["initlat"];
            //this.Address = "张家口市阳原县";
            if (string.IsNullOrEmpty(_InitLng) || string.IsNullOrEmpty(_InitLat))
            {
                ViewBag.InitLng = -1;// 107.716449;//
                ViewBag.InitLat = -1;// 26.212691;//
            }
            else
            {
                ViewBag.InitLng = double.Parse(_InitLng);
                ViewBag.InitLat = double.Parse(_InitLat);
            }

            if (!string.IsNullOrEmpty(initzl))
            {
                ViewBag.InitZoomLevel = int.Parse(initzl);
            }
            else
            {
                ViewBag.InitZoomLevel = 4;
            }
            string zl = data["ZoomLevel"];
            if (!string.IsNullOrEmpty(zl))
            {
                ViewBag.ZoomLevel = int.Parse(zl);
            }
            else
            {
                ViewBag.ZoomLevel = 12;
            }



            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(city))
            {
                ViewBag.Address = "";
                ViewBag.City = "";
            }
            else
            {
                ViewBag.Address = address;
                ViewBag.City = city;
            }


            if (string.IsNullOrEmpty(ovLayList))
            {
                ViewBag.OvLayList = "[]";
            }
            else
            {
                ViewBag.OvLayList = ovLayList;
            }
            return View();
        }
    }
}
