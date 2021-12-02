using LaboratoreNet2021.Models.Laborator2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratoreNet2021.Controllers.Laborator2
{
    public class FriendController : Controller
    {

        public ActionResult Index()
        {
            Friend friend = new Friend()
            {
                FriendId = Guid.NewGuid().ToString(), //gjenerimi i nje id ne format guid dhe me pas konvertimi ne string
                Name = "Friend1",
                Address = "Bulevardi Zogui i 1 Tirana",
            };
            //ushtrimi 2
            friend.Age = 21;
            if (friend.Age < 18) friend.AgeRange = "Minoren";
            else friend.AgeRange = "Maxhoren";

            //ushtrimi 3
            friend.Gender = "F";

            //ushtrim 4
            friend.CloseFriend = true;

            return View(friend);
        }
    }
}