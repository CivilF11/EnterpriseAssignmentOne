using EnterpriseAssignmentOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseAssignmentOne.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }



        [HttpPost]
        public ViewResult RsvpForm(CompetitionInvite guestResponse)
        {
            //if (ModelState.IsValid)
            //{
            //    // TODO: Email response to the party organizer
            //    return View("Thanks", guestResponse);
            //}
            //else
            //{
            //    // there is a validation error
            //    return View();
            //}


            if (ModelState.IsValid)
            {
                if (guestResponse.WillAttend == true)
                {
                    SaveInvite(guestResponse);
                }

                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
            

            
        }


        public ViewResult ShowLatestAttendees()
        {
            return View();
        }



        private void SaveInvite(CompetitionInvite response)
        {
            List<CompetitionInvite> acceptList = HttpContext.Cache["ACCEPT_LIST"] as List<CompetitionInvite>;

            if (acceptList == null)
            {
                acceptList = new List<CompetitionInvite>();
                HttpContext.Cache["ACCEPT_LIST"] = acceptList;
            }


            acceptList.Add(response);
        }
    }
}