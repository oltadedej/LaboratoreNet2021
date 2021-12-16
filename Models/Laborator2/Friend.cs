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
        [Required(ErrorMessage ="Plotesoni Friend Id")]// ben te mundur qe property te jete e detyrueshme duke shfaqur edhe mesazhin perkates
        public string FriendId { get; set; }
        [Required(ErrorMessage = "Plotesoni Friend Name")]
        [Display(Name = "Friend Name")]
        public string Name { get; set; }

        [Display(Name = "Friend Address")]
        [StringLength(maximumLength:15, ErrorMessage = "Duhet te kete nje gjatesi maximumi per 15 karakteresh!")]  //kufizon gjatesine e nje stringu 
        public string Address { get; set; }

        [Required(ErrorMessage = "Plotesoni Friend Age")]
        [Display(Name = "Friend Age")]
        public int Age { get; set; }

        [Display(Name = "Friend Age Range")]
        public string AgeRange { get; set; }

        [Required(ErrorMessage = "Selectoni Gender")]
        [Display(Name = "Friend Gender")]
        public string Gender { get; set; }

        
        [Display(Name = "Is Close Friend")]
        public bool CloseFriend { get; set; }


    }
}