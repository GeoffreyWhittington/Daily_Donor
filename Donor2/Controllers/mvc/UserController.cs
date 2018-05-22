using System;
using System.Web.Mvc;

// URL IS /CONTROLLERNAME/VIEWNAME

namespace Donor2.Controllers
{
    public class UserController : Controller
    {   
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Donors()
        {
            return View();
        }
        public ActionResult Resources()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Donors(string firstname, string lastname, int number, string street, int zipcode, string occupation)
        {
            GeoffDBEntities db = new GeoffDBEntities();
            Donor payload = new Donor()
            {
                Address = number + " " + street + ", " + zipcode,
                First_Name = firstname,
                Last_Name = lastname,
                Occupation = occupation
            };
            try
            {
                db.Database.Connection.Open();
                db.Donors.Add(payload);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                string didntwork = "didn't work";
            }
            finally
            {
                db.Database.Connection.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Resources(string resourcename, string url)
        {
            GeoffDBEntities db = new GeoffDBEntities();
            Resource payload = new Resource()
            {
                Resource_Name = resourcename,
                URL = url
            };
            try
            {
                db.Database.Connection.Open();
                db.Resources.Add(payload);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string didntwork = "didn't work";
            }
            finally
            {
                db.Database.Connection.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string lastname, string firstname, string emailaddress, string password)
        {
            GeoffDBEntities db = new GeoffDBEntities();
            Login payload = new Login()
            {
                Last_Name = lastname,
                First_Name = firstname,
                Email_Address = emailaddress,
                Password = password
            };
            try
            {
                db.Database.Connection.Open();
                db.Logins.Add(payload);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string didntwork = "didn't work";
            }
            finally
            {
                db.Database.Connection.Close();
            }
            return View();
        }
       
    }
}