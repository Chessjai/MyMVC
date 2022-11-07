using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> e = new List<Employee>();
            var e1 = new Employee() { EmpID = 1, EmpName = "JAI", EmpSalary = 21000 };
            var e2 = new Employee() { EmpID = 2, EmpName = "Ram", EmpSalary = 52000 };
            var e3 = new Employee() { EmpID = 3, EmpName = "Kisan", EmpSalary = 71000 };
            var e4 = new Employee() { EmpID = 4, EmpName = "Alwin", EmpSalary = 25000 };
            e.Add(e1);
            e.Add(e2);
            e.Add(e3);
            e.Add(e4);

            return View(e);
        }


        [HttpGet]
        public ActionResult MobilesShop() 
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=JAIKUMAR\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=arjungym";
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {

            }
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            //com.CommandText = "insert into Mobile(ID,ModelName,Price,ShopName) values('11','jay','Valaja','MZ')";

            com.CommandText = "select * from Mobiles";
            com.ExecuteNonQuery();
            SqlDataReader dr = com.ExecuteReader();
            List<Mobile> mob = new List<Mobile>();

            while (dr.Read())
            {
                Mobile m = new Mobile();
                m.ID = dr[0].ToString();
                m.ModelName = dr[1].ToString();
                m.ModelNumber = dr[2].ToString();
                m.Price = dr[3].ToString();
                m.ShopName = dr[4].ToString();
                mob.Add(m);

                //if (Convert.ToInt32(dr[0]) > 34)
                //    //{
                //    //    Console.WriteLine(dr[0].ToString());

                //    //    Console.WriteLine(dr[1].ToString());
                //    //}
                //}
                //DataSet ds = new DataSet();
                //SqlDataAdapter da = new SqlDataAdapter(com);
                //da.Fill(ds);


            }
            con.Close();
            return View(mob);

        }



        [HttpGet]
        public ActionResult MobilesShopPost()
        {
            return View();
        }
        [HttpPost]

        public ActionResult MobilesShopPost(Mobile mob)
        {
            //create veg --- insert query
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=JAIKUMAR\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=arjungym";
            //       
            con.Open();

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "insert into Mobiles values('" + mob.ID + "','" + mob.ModelName + "','" + mob.ModelNumber + "','" + mob.Price + "','" + mob.ShopName + "')";
            com.ExecuteNonQuery();
            
            return RedirectToAction("MobilesShop");
        }
        public ActionResult LogIn()
        {
            return View("Index");
        }
    }
}

