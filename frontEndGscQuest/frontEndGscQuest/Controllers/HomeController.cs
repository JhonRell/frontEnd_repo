﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontEndGscQuest.Models;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json; //JSON
using System.Net; //WebRequest & WebResponse
using System.Text; //Encoding
using System.IO; //Stream

namespace BackEndGscQuest.Controllers
{
    public class HomeController : Controller
    {
        //Delete Employee
        public ActionResult DeleteEmployee()
        {
            return View();
        }
        [HttpDelete]
        public ActionResult DeleteEmployee(modEmployeeList d)
        {
            Dictionary<string, object> dictprof = JsonConvert.DeserializeObject<Dictionary<string, object>>(User.Identity.Name);
            try
            {
                string msg;
                try
                {
                    WebRequest req;
                    WebResponse res;
                    string postData = "imp_id=" + d.imp_id;


                    req = WebRequest.Create(ConfigurationManager.AppSettings["API_Path"] + "api/employee/delete?" + postData);
                    Byte[] data = Encoding.UTF8.GetBytes(postData);

                    req.Method = "DELETE";
                    req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

                    req.ContentLength = data.Length;
                    Stream stream = req.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();

                    using (res = req.GetResponse())
                    using (var reader = new StreamReader(res.GetResponseStream()))
                    {
                        msg = reader.ReadToEnd();

                        int comVal = msg.CompareTo("Successfully DELETED");
                        if (comVal == 0)

                        {

                            return Content("Successfully DELETED", "text/plain", Encoding.UTF8);
                        }
                        else
                        {

                            return Content(msg, "text/plain", Encoding.UTF8);
                        }
                    }
                }
                catch (WebException ex)
                {
                    HttpWebResponse res = (HttpWebResponse)ex.Response;
                    Stream receiveStream = res.GetResponseStream();
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))

                    {
                        return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                Stream receiveStream = res.GetResponseStream();
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                }
            }
        }

        //enable Employee
        public ActionResult EnabledEmployee()
        {
            return View();
        }
        [HttpPut]
        public ActionResult EnabledEmployee(modEmployeeList en)
        {
            Dictionary<string, object> dictprof = JsonConvert.DeserializeObject<Dictionary<string, object>>(User.Identity.Name);
            try
            {
                string msg;
                try
                {
                    WebRequest req;
                    WebResponse res;
                    string postData = "imp_id=" + en.imp_id;


                    req = WebRequest.Create(ConfigurationManager.AppSettings["API_Path"] + "api/employee/enabled?" + postData);
                    Byte[] data = Encoding.UTF8.GetBytes(postData);

                    req.Method = "PUT";
                    req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

                    req.ContentLength = data.Length;
                    Stream stream = req.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();

                    using (res = req.GetResponse())
                    using (var reader = new StreamReader(res.GetResponseStream()))
                    {
                        msg = reader.ReadToEnd();

                        int comVal = msg.CompareTo("Successfully Enabled");
                        if (comVal == 0)

                        {

                            return Content("Successfully Enabled", "text/plain", Encoding.UTF8);
                        }
                        else
                        {

                            return Content(msg, "text/plain", Encoding.UTF8);
                        }
                    }
                }
                catch (WebException ex)
                {
                    HttpWebResponse res = (HttpWebResponse)ex.Response;
                    Stream receiveStream = res.GetResponseStream();
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))

                    {
                        return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                Stream receiveStream = res.GetResponseStream();
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                }
            }
        }

        //remove Employee
        public ActionResult RemoveEmployee()
        {
            return View();
        }
        [HttpPut]
        public ActionResult RemoveEmployee(modEmployeeList r)
        {
            Dictionary<string, object> dictprof = JsonConvert.DeserializeObject<Dictionary<string, object>>(User.Identity.Name);
            try
            {
                string msg;
                try
                {
                    WebRequest req;
                    WebResponse res;
                    string postData = "imp_id=" + r.imp_id;


                    req = WebRequest.Create(ConfigurationManager.AppSettings["API_Path"] + "api/employee/remove?" + postData);
                    Byte[] data = Encoding.UTF8.GetBytes(postData);

                    req.Method = "PUT";
                    req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

                    req.ContentLength = data.Length;
                    Stream stream = req.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();

                    using (res = req.GetResponse())
                    using (var reader = new StreamReader(res.GetResponseStream()))
                    {
                        msg = reader.ReadToEnd();

                        int comVal = msg.CompareTo("Successfully Disabled");
                        if (comVal == 0)

                        {

                            return Content("Successfully Disabled", "text/plain", Encoding.UTF8);
                        }
                        else
                        {

                            return Content(msg, "text/plain", Encoding.UTF8);
                        }
                    }
                }
                catch (WebException ex)
                {
                    HttpWebResponse res = (HttpWebResponse)ex.Response;
                    Stream receiveStream = res.GetResponseStream();
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))

                    {
                        return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                Stream receiveStream = res.GetResponseStream();
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                }
            }
        }

        //edit Employee
        public ActionResult EditEmployee()
        {
            return View();
        }
        
        [HttpPut]
        public ActionResult EditEmployee(modEmployeeList e)
        {
            Dictionary<string, object> dictprof = JsonConvert.DeserializeObject<Dictionary<string, object>>(User.Identity.Name);
            try
            {
                string msg;
                try
                {
                    WebRequest req;
                    WebResponse res;
                    string postData = "imp_id=" + e.imp_id
                    + "&imp_firstName=" + e.imp_firstName
                    + "&imp_lastName=" + e.imp_lastName
                    + "&imp_username=" + e.imp_username
                    + "&imp_password=" + e.imp_password;
                    req = WebRequest.Create(ConfigurationManager.AppSettings["API_Path"] + "api/employee/update?" + postData);
                    Byte[] data = Encoding.UTF8.GetBytes(postData);

                    req.Method = "PUT";
                    req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

                    req.ContentLength = data.Length;
                    Stream stream = req.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();

                    using (res = req.GetResponse())
                    using (var reader = new StreamReader(res.GetResponseStream()))
                    {
                        msg = reader.ReadToEnd();

                        int comVal = msg.CompareTo("Successfully Saved");
                        if (comVal == 0)

                        {

                            return Content("Successfully Saved", "text/plain", Encoding.UTF8);
                        }
                        else
                        {

                            return Content(msg, "text/plain", Encoding.UTF8);
                        }
                    }
                }
                catch (WebException ex)
                {
                    HttpWebResponse res = (HttpWebResponse)ex.Response;
                    Stream receiveStream = res.GetResponseStream();
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))

                    {
                        return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                Stream receiveStream = res.GetResponseStream();
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                }
            }
        }

        //add Employee
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(modEmployeeList p)
        {
            Dictionary<string, object> dictprof = JsonConvert.DeserializeObject<Dictionary<string, object>>(User.Identity.Name);
            try
            {
                string msg;
                try
                {
                    WebRequest req;
                    WebResponse res;
                    string postData = "imp_id=" + p.imp_id
                    + "&imp_firstName=" + p.imp_firstName
                    + "&imp_lastName=" + p.imp_lastName
                    + "&imp_username=" + p.imp_username
                    + "&imp_password=" + p.imp_password;
                    req = WebRequest.Create(ConfigurationManager.AppSettings["API_Path"] + "api/employee/add?" + postData);
                    Byte[] data = Encoding.UTF8.GetBytes(postData);

                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

                    req.ContentLength = data.Length;
                    Stream stream = req.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();

                    using (res = req.GetResponse())
                    using (var reader = new StreamReader(res.GetResponseStream()))
                    {
                        msg = reader.ReadToEnd();

                        int comVal = msg.CompareTo("Successfully Saved");
                        if (comVal == 0)

                        {

                            return Content("Successfully Saved", "text/plain", Encoding.UTF8);
                        }
                        else
                        {

                            return Content(msg, "text/plain", Encoding.UTF8);
                        }
                    }
                }
                catch (WebException ex)
                {
                    HttpWebResponse res = (HttpWebResponse)ex.Response;
                    Stream receiveStream = res.GetResponseStream();
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))

                    {
                        return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                Stream receiveStream = res.GetResponseStream();
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    return Content(readStream.ReadToEnd(), "text/plain", Encoding.UTF8);
                }
            }
        }

        //employee Details
        public ActionResult EmployeeDetails()
        {
            HomeModel mymodel = new HomeModel();
            mymodel.EmployeeList = GetEmployeeDetails();
            return View("EmployeeDetails", mymodel);
        }

        [HttpGet]
        public IEnumerable<modEmployeeList> GetEmployeeDetails()
        {
            IEnumerable<modEmployeeList> ec = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri(ConfigurationManager.AppSettings["API_Path"] + "api/employee/");
            var consumedata = hc.GetAsync("details?imp_id=" + Request.QueryString["imp_id"].ToString());
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

        [HttpGet]
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


