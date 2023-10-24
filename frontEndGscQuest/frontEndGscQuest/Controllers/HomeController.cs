using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontEndGscQuest.Models;
using System.Net.Http;
using System.Configuration;
//using Newtonsoft.Json; //JSON
//using System.Net; //WebRequest & WebResponse
//using System.Text; //Encoding
//using System.IO; //Stream

namespace BackEndGscQuest.Controllers
{
    public class HomeController : Controller
    {
        ////add Employee
        
        //public ActionResult AddEmployee()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddEmployee(modEmployeeList p)
        //{
        //    Dictionary<string, object> dictprof = JsonConvert.DeserializeObject<Dictionary<string, object>>(User.Identity.Name);
        //    try
        //    {
        //        string msg;
        //        try
        //        {
        //            WebRequest req;
        //            WebResponse res;
        //            string postData = "imp_id=" + p.imp_id
        //            + "&firstName=" + p.imp_firstName
        //            + "&lastName=" + p.imp_lastName
        //            + "&username=" + p.imp_username
        //            + "&password=" + p.imp_password;
        //            req = WebRequest.Create(ConfigurationManager.AppSettings["API_Path"] + "api/employee/add?" + postData);
        //            Byte[] data = Encoding.UTF8.GetBytes(postData);

        //            req.Method = "POST";
        //            req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

        //            req.ContentLength = data.Length;
        //            Stream stream = req.GetRequestStream();
        //            stream.Write(data, 0, data.Length);
        //            stream.Close();

        //            using (res = req.GetResponse())
        //            using (var reader = new StreamReader(res.GetResponseStream()))
        //            {
        //                msg = reader.ReadToEnd();

        //                int comVal = msg.CompareTo("Successfully Saved");
        //                if (comVal == 0)

        //                {

        //                    return Content("Successfully Saved", "text/plain", Encoding.UTF8);
        //                }
        //                else
        //                {

        //                    return Content(msg, "text/plain", Encoding.UTF8);
        //                }
        //            }
        //        }
        //        catch (WebException ex)
        //        {
        //            HttpWebResponse res = (HttpWebResponse)ex.Response;
        //            Stream receiveStream = res.GetResponseStream();
        //            using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))

        //            {
        //                return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
        //            }
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        HttpWebResponse res = (HttpWebResponse)ex.Response;
        //        Stream receiveStream = res.GetResponseStream();
        //        using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
        //        {
        //            return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
        //        }
        //    }
        //}

        //employee Details
        public ActionResult EmployeeDetails()
        {
            HomeModel mymodel = new HomeModel();
            mymodel.EmployeeList = GetEmployeeDetails();
            return View("EmployeeDetails", mymodel);
        }

        public IEnumerable<modEmployeeList> GetEmployeeDetails()
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

        //employee List
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


