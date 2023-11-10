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
        //delete employee
        [HttpDelete]
        [Route("api/employee/delete", Name = "delete_Employee")]
        public HttpResponseMessage delete_Employee(string imp_id)
        {
            using (MySqlConnection SQLCON = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                try
                {
                    if (SQLCON.State == ConnectionState.Closed)

                    {

                        SQLCON.Open();
                        MySqlCommand sqlComm = new MySqlCommand();
                        sqlComm.Connection = SQLCON;

                        sqlComm.CommandText = "DELETE FROM `employee` WHERE `imp_id` = @imp_id LIMIT 1";

                        sqlComm.Parameters.Add(new MySqlParameter("@imp_id", imp_id));
                        sqlComm.ExecuteNonQuery(); //EXECUTE MYSQL QUEUE STRING
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent("Successfully Deleted");

                        return response;
                    }
                    else
                    {

                        response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                        response.Content = new StringContent("Unable to connect to the database server", Encoding.UTF8);

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                    response.Content = new StringContent("There is an error in performing this action: " + ex.ToString(), Encoding.Unicode);

                    return response;
                }
                finally //ALWAYS CLOSE AND DISPOSE THE CONNECTION AFTER USING
                {
                    SQLCON.Close();
                    SQLCON.Dispose();

                }
            }
        }
        //enabled employee
        //API ROUTE: api/employee/enabled?emp_id=101-a123
        [HttpPut]
        [Route("api/employee/enabled", Name = "Recover_Employee")]
        public HttpResponseMessage Recover_Employee(string imp_id)
        {
            using (MySqlConnection SQLCON = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                try
                {
                    if (SQLCON.State == ConnectionState.Closed)

                    {

                        SQLCON.Open();
                        MySqlCommand sqlComm = new MySqlCommand();
                        sqlComm.Connection = SQLCON;

                        sqlComm.CommandText = "UPDATE `employee` SET `imp_account_status` = 'Active' WHERE `imp_id` = @imp_id LIMIT 1";

                        sqlComm.Parameters.Add(new MySqlParameter("@imp_id", imp_id));
                        sqlComm.ExecuteNonQuery(); //EXECUTE MYSQL QUEUE STRING
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent("Successfully Enabled");

                        return response;
                    }
                    else
                    {

                        response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                        response.Content = new StringContent("Unable to connect to the database server", Encoding.UTF8);

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                    response.Content = new StringContent("There is an error in performing this action: " + ex.ToString(), Encoding.Unicode);

                    return response;
                }
                finally //ALWAYS CLOSE AND DISPOSE THE CONNECTION AFTER USING
                {
                    SQLCON.Close();
                    SQLCON.Dispose();

                }
            }
        }
        
        //delete employee
        //API ROUTE: api/employee/remove?emp_id=101-a123
        [HttpPut]
        [Route("api/employee/remove", Name = "Delete_Employee_Remove")]
        public HttpResponseMessage Delete_Employee_Remove(string imp_id)
        {
            using (MySqlConnection SQLCON = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                try
                {
                    if (SQLCON.State == ConnectionState.Closed)

                    {

                        SQLCON.Open();
                        MySqlCommand sqlComm = new MySqlCommand();
                        sqlComm.Connection = SQLCON;

                        sqlComm.CommandText = "UPDATE `employee` SET `imp_account_status` = 'Inactive' WHERE `imp_id` = @imp_id LIMIT 1";

                        sqlComm.Parameters.Add(new MySqlParameter("@imp_id", imp_id));
                        sqlComm.ExecuteNonQuery(); //EXECUTE MYSQL QUEUE STRING
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent("Successfully Removed");

                        return response;
                    }
                    else
                    {

                        response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                        response.Content = new StringContent("Unable to connect to the database server", Encoding.UTF8);

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                    response.Content = new StringContent("There is an error in performing this action: " + ex.ToString(), Encoding.Unicode);

                    return response;
                }
                finally //ALWAYS CLOSE AND DISPOSE THE CONNECTION AFTER USING
                {
                    SQLCON.Close();
                    SQLCON.Dispose();

                }
            }
        }
        //employee details for Edit
        [HttpGet]
        [Route("api/employee/editDetails", Name = "Get_Employee_EditDetails")]
        public IHttpActionResult Get_Employee_EditDetails(string imp_id)
        {
            List<modEmployeeList> stats = new List<modEmployeeList>();
            using (MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    try
                    {
                        sqlConn.Open();
                        using (MySqlCommand msqlcom = new MySqlCommand("SELECT *FROM employee WHERE imp_id = @imp_id LIMIT 1", sqlConn))
                        {
                            msqlcom.Parameters.Add(new MySqlParameter("@imp_id", imp_id));
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
        
        //Edit
        //API ROUTE: api/employee/update?emp_id=101-a123&password=newpass
        [HttpPut]
        [Route("api/employee/update", Name = "Edit_Employee")]
        public HttpResponseMessage Edit_Employee(string imp_id, string imp_firstName, string imp_lastName, string imp_username, string imp_password)
        {
            using (MySqlConnection SQLCON = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                try
                {
                    if (SQLCON.State == ConnectionState.Closed)
                    {
                        SQLCON.Open();

                        MySqlCommand sqlComm = new MySqlCommand();

                        sqlComm.Connection = SQLCON;

                        sqlComm.CommandText = "UPDATE `employee` SET `imp_firstName` = @imp_firstName, `imp_lastName` = @imp_lastName, `imp_username` = @imp_username, `imp_password` = @imp_password WHERE `imp_id` = @imp_id LIMIT 1";

                        sqlComm.Parameters.Add(new MySqlParameter("@imp_id", imp_id));
                        sqlComm.Parameters.Add(new MySqlParameter("@imp_firstName", imp_firstName));
                        sqlComm.Parameters.Add(new MySqlParameter("@imp_lastName", imp_lastName));
                        sqlComm.Parameters.Add(new MySqlParameter("@imp_username", imp_username));
                        sqlComm.Parameters.Add(new MySqlParameter("@imp_password", imp_password));
                        sqlComm.ExecuteNonQuery(); //EXECUTE MYSQL QUEUE STRING
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent("Successfully Updated");

                        return response;
                    }
                    else
                    {

                        response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                        response.Content = new StringContent("Unable to connect to the database server", Encoding.UTF8);

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                    response.Content = new StringContent("There is an error in performing this action: " + ex.ToString(), Encoding.Unicode);

                    return response;
                }
                finally //ALWAYS CLOSE AND DISPOSE THE CONNECTION AFTER USING
                {
                    SQLCON.Close();
                    SQLCON.Dispose();

                }
            }
        }

        //Add Employee
        private HttpResponseMessage response;
        [HttpPost]
        [Route("api/employee/add", Name = "Post_Employee_Add")]
        public HttpResponseMessage Post_Employee_Add(string imp_id, string imp_firstName, string imp_lastName, string imp_username, string imp_password)
        {
            using (MySqlConnection SQLCON = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                try
                {
                    if (SQLCON.State == ConnectionState.Closed)

                    {

                        SQLCON.Open();

                        MySqlCommand sqlComm = new MySqlCommand();

                        sqlComm.Connection = SQLCON;

                        sqlComm.CommandText = "INSERT INTO `gscquest`.`employee`(`imp_id`, `imp_firstName`, `imp_lastName`, `imp_username`, `imp_password`, `imp_account_status`) VALUES (@imp_id, @imp_firstName, @imp_lastName, @imp_username, @imp_password, 'active')";

                        sqlComm.Parameters.Add(new MySqlParameter("@imp_id", imp_id));
                        sqlComm.Parameters.Add(new MySqlParameter("@imp_firstName", imp_firstName));
                        sqlComm.Parameters.Add(new MySqlParameter("@imp_lastName", imp_lastName));
                        sqlComm.Parameters.Add(new MySqlParameter("@imp_username", imp_username));
                        sqlComm.Parameters.Add(new MySqlParameter("@imp_password", imp_password));
                        sqlComm.ExecuteNonQuery(); //EXECUTE MYSQL QUEUE STRING
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent("Successfully Saved");

                        return response;
                    }
                    else
                    {

                        response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                        response.Content = new StringContent("Unable to connect to the database server", Encoding.UTF8);

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                    response.Content = new StringContent("There is an error in performing this action: " + ex.ToString(), Encoding.Unicode);

                    return response;
                }
                finally //ALWAYS CLOSE AND DISPOSE THE CONNECTION AFTER USING
                {
                    SQLCON.Close();
                    SQLCON.Dispose();

                }
            }
        }

        //employee details
        [HttpGet]
        [Route("api/employee/details", Name = "Get_Employee_Details")]
        public IHttpActionResult Get_Employee_Details(string imp_id)
        {
            List<modEmployeeList> stats = new List<modEmployeeList>();
            using (MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    try
                    {
                        sqlConn.Open();
                        using (MySqlCommand msqlcom = new MySqlCommand("SELECT *FROM employee WHERE imp_id = @imp_id LIMIT 1", sqlConn))
                        {
                            msqlcom.Parameters.Add(new MySqlParameter("@imp_id", imp_id));
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
        
        //Employee list
        [HttpGet]
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
