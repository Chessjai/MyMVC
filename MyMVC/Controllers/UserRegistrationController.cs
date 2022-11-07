using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        
            public ActionResult Index()
            {
                List<UserReg> e = new List<UserReg>();
            var e1 = new UserReg() { UserID = 1, Name = "Jai",Email="jai1@gmail.com",Password="123455",Gender="Male" };
                var e2 = new UserReg() { UserID = 2, Name = "Jkumar", Email = "ja11@gmail.com", Password = "12r455", Gender = "Male" };
                var e3 = new UserReg() { UserID = 3, Name = "jegan", Email = "jy1@gmail.com", Password = "po3455", Gender = "Male" };
                var e4 = new UserReg() { UserID = 4, Name = "jaga", Email = "jewi1@gmail.com", Password = "oi3455", Gender = "Male" };
                e.Add(e1);
                e.Add(e2);
                e.Add(e3);
                e.Add(e4);

                return View(e);
            }
        [HttpGet]
        public ActionResult Login()
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

            com.CommandText = "select * from UserRegistration";
            com.ExecuteNonQuery();
            SqlDataReader dr = com.ExecuteReader();
            List<UserReg> reg = new List<UserReg>();

            while (dr.Read())
            {
                UserReg r = new UserReg();
                r.UserID = Convert.ToInt32(dr[0]);
                r.Name = dr[1].ToString();
                r.Email = dr[2].ToString();
                r.Password = dr[3].ToString();
                r.Gender = dr[4].ToString();
                reg.Add(r);


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
            return View(reg);

        }
            [HttpPost]
            public ActionResult LogIn()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Registration(UserReg reg)
        {
            //create veg --- insert query
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=JAIKUMAR\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=arjungym";
            //       
            con.Open();

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "insert into UserRegistration values('" + reg.Name + "','" + reg.Email + "','" + reg.Password + "','" + reg.Gender + "')";
            com.ExecuteNonQuery();

            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(UserLoginModel log)
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

            com.CommandText = "select * from UserRegistration";
            com.ExecuteNonQuery();
            SqlDataReader dr = com.ExecuteReader();
            List<UserReg> reg = new List<UserReg>();

            while (dr.Read())
            {
                UserReg r = new UserReg();
                r.UserID = Convert.ToInt32(dr[0]);
                r.Name = dr[1].ToString();
                r.Email = dr[2].ToString();
                r.Password = dr[3].ToString();
                r.Gender = dr[4].ToString();
                reg.Add(r);
            }
            con.Close();

          var Res = reg.Where(x => x.Email == log.Email && x.Password == log.Password).FirstOrDefault();
            if (Res==null)
            {
                return RedirectToAction("Registration");
            }
            else
            {

                return RedirectToAction("MobilesShop","Employee");
            }
        }

    }
}