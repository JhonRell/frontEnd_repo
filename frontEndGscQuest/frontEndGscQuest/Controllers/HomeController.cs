using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontEndGscQuest.Models;
using System.Net.Http;
using System.Configuration;


namespace BackEndGscQuest.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            HomeModel mymodel = new HomeModel();
            mymodel.EmployeeList = EmployeeList();
            return View("Index", mymodel);
        }

        public IEnumerable<modEmployeeList> EmployeeList()
        {
            IEnumerable<modEmployeeList> ec = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri(ConfigurationManager.AppSettings["API_Path"] + "api/employee/");

            var consumedata = hc.GetAsync("list");
            consumedata.Wait();

            var dataread = consumedata.Result;
            if (dataread.IsSuccessStatusCode)
            {
                var results = dataread.Content.ReadAsAsync<IList<modEmployeeList>>();
                results.Wait();
                ec = results.Result;
            }
            else
            {
                ec = Enumerable.Empty<modEmployeeList>();
                ViewBag.Data = "An error has occurred";
            }

            return ec;
        }
    }

}


