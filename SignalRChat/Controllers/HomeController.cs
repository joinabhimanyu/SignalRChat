using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRChat.Models;
using System.Web.Configuration;
using System.Data;
using System.Data.OleDb;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
                var viewModel = new List<PolicyStatus>();
                var sqlString = "select mm.txt_policy_no_char ,mm.txt_status_desc,mm.num_status_id from gc_life_ps_status mm where mm.txt_policy_no_char = '1804005114P100000013'";
                var connString = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (var conn = new OleDbConnection(connString))
                {
                    var command = new OleDbCommand(sqlString, conn);
                    command.Connection.Open();
                    //IDataReader reader = command.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    viewModel.Add(new PolicyStatus { policy_no = reader[0].ToString(), policy_status = reader[1].ToString(), status_id = reader[2].ToString() });
                    //}
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable ds = new DataTable();
                    adapter.Fill(ds);
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        viewModel.Add(new PolicyStatus { policy_no = ds.Rows[i][0].ToString(), policy_status = ds.Rows[i][1].ToString(), status_id = ds.Rows[i][2].ToString() });
                    }
                    command.Connection.Close();
                    adapter = null;
                    ds = null;
                }
                return View(viewModel);
            }
            else
            {
                Response.Write("You are not logged in, getting redirected to the Login Page....");
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    
        public ActionResult Save(List<PolicyStatus> model,string id)
        {
           
            return  RedirectToAction("Index");
        }

    }
}
