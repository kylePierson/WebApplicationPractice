using BlueChipTSA.Data_Access;
using BlueChipTSA.Models;
using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueChipTSA.Controllers
{
    public class HomeController : Controller
    {
        IParkDAL parkDAL;
        ICampgroundDAL campgroundDAL;
        IMailingListDAL mailingListDAL;

        public HomeController(IParkDAL parkDAL, ICampgroundDAL campgroundDAL, IMailingListDAL mailingListDAL)
        {
            this.parkDAL = parkDAL;
            this.campgroundDAL = campgroundDAL;
            this.mailingListDAL = mailingListDAL;
        }

        public ActionResult Index()
        {
            int yosemiteId = 1;
            Park model = parkDAL.GetPark(yosemiteId);
            model.Campgrounds = campgroundDAL.GetCampgroundsForPark(yosemiteId);
            return View("Index", model);
        }

        public ActionResult ViewCampground(int campgroundId)
        {
            Campground model = campgroundDAL.GetCampground(campgroundId);
            return View("ViewCampground", model);
        }

        public ActionResult About()
        {
            int yosemiteId = 1;
            Park model = parkDAL.GetPark(yosemiteId);
            model.Campgrounds = campgroundDAL.GetCampgroundsForPark(yosemiteId);
            return View("About", model);
        }

        public ActionResult EmailSignUp()
        {
            NewEmail model = new NewEmail();
            return View("EmailSignUp", model);
        }

        [HttpPost]
        public ActionResult EmailSignUp(NewEmail newEmail)
        {
            if (!ModelState.IsValid)
            {
                return View("EmailSignUp", newEmail);
            }

            mailingListDAL.AddEmail(newEmail);
            //SendEmail(newEmail);

            return RedirectToAction("Index");
        }

        public ActionResult ContactUs()
        {
            return View("ContactUs");
        }

        private void SendEmail(NewEmail newEmail)
        {
            dynamic email = new Email("NewEmailPage");
            email.To = newEmail.EmailAddress;
            email.FirstName = newEmail.FirstName;
            email.Send();
        }
    }
}