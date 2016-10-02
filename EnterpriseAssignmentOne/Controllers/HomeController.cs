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
        /// <summary>
        /// When the user navigates to the index page
        /// </summary>
        /// <returns>The index page, with some text</returns>
        public ViewResult Index()
        {
            //returns "Sheridan" to be used on the index page
            return View("Sheridan" as object);
        }



        /// <summary>
        /// When the user navigates to the RsvpForm page, using GET
        /// </summary>
        /// <returns>The RsvpForm page</returns>
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }



        /// <summary>
        /// When the user submits a form on the RsvpForm page
        /// </summary>
        /// <param name="guestResponse">The results of the form completion</param>
        /// <returns>Either the Thanks page, upon successful form completion, or the
        /// RsvpForm page, upon there being an error in the form.</returns>
        [HttpPost]
        public ViewResult RsvpForm(CompetitionInvite guestResponse)
        {
            //if the form was successfully completed
            if (ModelState.IsValid)
            {
                //if the guest said that they were going to come
                if (Request.Form["btnsubmit"].Equals("Accept Invitation"))
                {
                    //validate their attendance
                    guestResponse.WillAttend = true;

                    //save their invite
                    SaveInvite(guestResponse);
                }

                //navigate the user to the Thanks page, with also their response
                return View("Thanks", guestResponse);
            }
            else
            {
                //the RsvpForm page, so the user can attempt again to successfully complete the form
                return View();
            }
                
        }


        /// <summary>
        /// When the user navigates to the ShowLatestAttendees page
        /// </summary>
        /// <returns>The ShowLatestAttendees page</returns>
        public ViewResult ShowLatestAttendees()
        {
            return View();
        }



        /// <summary>
        /// To save the guests invite, so a list of all attending guests can be viewed.
        /// </summary>
        /// <param name="response">The latest guest invite that is attending</param>
        private void SaveInvite(CompetitionInvite response)
        {
            //the list of currently attending guests
            List<CompetitionInvite> acceptList = HttpContext.Cache["ACCEPT_LIST"] as List<CompetitionInvite>;

            //if the list was empty
            if (acceptList == null)
            {
                //make a new list
                acceptList = new List<CompetitionInvite>();
                HttpContext.Cache["ACCEPT_LIST"] = acceptList;
            }

            //add the response to the list
            acceptList.Add(response);
        }
    }
}