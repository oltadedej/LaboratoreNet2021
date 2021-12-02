using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaboratoreNet2021.Models.Laborator2
{
    public class Friend
    {
        [Display(Name = "Friend Id")] //ben te mundur afishimin dinamik te properties ne label
        public string FriendId { get; set; }

        [Display(Name = "Friend Name")]
        public string Name { get; set; }

        [Display(Name = "Friend Address")]
        public string Address { get; set; }

        //Ushtrimi 2
        [Display(Name = "Friend Age")]
        public int Age { get; set; }

        [Display(Name = "Friend Age Range")]
        public string AgeRange { get; set; }

        //Ushtrimi 3
        [Display(Name = "Friend Gender")]
        public string Gender { get; set; }

        //Ushtrimi 4
        [Display(Name = "Is Close Friend")]
        public bool CloseFriend { get; set; }


    }
}