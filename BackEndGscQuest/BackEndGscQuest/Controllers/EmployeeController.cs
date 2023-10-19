using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Text;
using System.Data;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {

        [Route("api/employee/list", Name = "Get_Employee_List")]
        public IHttpActionResult Get_Employee_List()
        {
            List<modEmployeeList> stats = new List<modEmployeeList>();
            using (MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    try
                    {

                        sqlConn.Open();
                        using (MySqlCommand msqlcom = new MySqlCommand("SELECT *FROM employee", sqlConn))
                        {
                            using (MySqlDataReader dtReader = msqlcom.ExecuteReader())
                            {
                                if (dtReader.HasRows)

                                {

                                    while (dtReader.Read())

                                    {

                                        modEmployeeList dataObj = new modEmployeeList();
                                        dataObj.imp_id = dtReader["imp_id"].ToString();
                                        dataObj.imp_firstName = dtReader["imp_firstName"].ToString();
                                        dataObj.imp_lastName = dtReader["imp_lastName"].ToString();
                                        dataObj.imp_username = dtReader["imp_username"].ToString();
                                        dataObj.imp_password = dtReader["imp_password"].ToString();
                                        dataObj.imp_account_status = dtReader["imp_account_status"].ToString();

                                        stats.Add(dataObj);

                                    }

                                    return Ok(stats);

                                }
                                else
                                {

                                    return NotFound();
                                }
                            }
                        }
                    }

                    catch (Exception ex)
                    {

                        return Content(HttpStatusCode.InternalServerError, ex);
                    }
                }
                else
                {
                    return InternalServerError();
                }
            }
        }

        //CLASS MODEL FOR THE EMPLOYEE LIST
        public class modEmployeeList
        {

            public string imp_id { get; set; }
            public string imp_firstName { get; set; }
            public string imp_lastName { get; set; }
            public string imp_username { get; set; }
            public string imp_password { get; set; }
            public string imp_account_status { get; set; }
        }
    }
}
