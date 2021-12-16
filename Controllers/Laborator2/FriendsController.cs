using LaboratoreNet2021.Models.Laborator2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratoreNet2021.Controllers.Laborator2
{
    public class FriendsController : Controller
    {
        // GET: Friends
        public ActionResult Index(int take = 0, int? age = null) // athr int? ose cdo tip varabli ne C# i cili merr e nje pikepyetje nga pas tregon qe tipi lejon edhe int edhe null, nese do e kishim bool? do te thonte qe do kemi vlerat, true, false dhe null
        {
            //kur i deklarojme parametrat ne metode dhe i japim vlere athere variablat njihen si optional, nese ne nuk i kalojme nje vlere si default marrin
            //vleren qe i eshte specifikuar ne koken e metodes


            //Ushtrimi 2 laborator 3
            Friends friends = new Friends();
            Friend friend = new Friend()
            {
                FriendId = Guid.NewGuid().ToString(),
                Name = "Friend1",
                Address = "Bulevardi Zogui i 1 Tirana",
            };

            friend.Age = 21;
            if (friend.Age < 18) friend.AgeRange = "Minoren";
            else friend.AgeRange = "Maxhoren";
            friend.Gender = "F";
            friend.CloseFriend = true;
            friends.MyFriends.Add(friend);

            //mund te riperdorni te njejten instance mjafton ta ri-deklaroni me new
            friend = new Friend()
            {
                FriendId = Guid.NewGuid().ToString(),
                Name = "Friend2",
                Address = "Bulevardi Zogui i 1 Tirana",
            };

            friend.Age = 17;
            if (friend.Age < 18) friend.AgeRange = "Minoren";
            else friend.AgeRange = "Maxhoren";
            friend.Gender = "M";
            friend.CloseFriend = false;
            friends.MyFriends.Add(friend);

            friend = new Friend()
            {
                FriendId = Guid.NewGuid().ToString(),
                Name = "Friend3",
                Address = "Bulevardi Zogui i 1 Tirana",
            };

            friend.Age = 34;
            if (friend.Age < 18) friend.AgeRange = "Minoren";
            else friend.AgeRange = "Maxhoren";
            friend.Gender = "M";
            friend.CloseFriend = false;
            friends.MyFriends.Add(friend);

            friend = new Friend()
            {
                FriendId = Guid.NewGuid().ToString(),
                Name = "Friend4",
                Address = "Bulevardi Zogui i 1 Tirana",
            };

            friend.Age = 23;
            if (friend.Age < 18) friend.AgeRange = "Minoren";
            else friend.AgeRange = "Maxhoren";
            friend.Gender = "F";
            friend.CloseFriend = true;
            friends.MyFriends.Add(friend);

            //ushtrimi 3 laborator 3
            if (take > 0)
            {
                if (take <= friends.MyFriends.Count()) // veprime me lista, gjendet nr i elementeve te listes
                {
                    //marrim aq elemente nga lista sa specifikon take
                    friends.MyFriends = friends.MyFriends.Take(take).ToList();  /// Veprime me lista Mesoni LINQ duke perdorur listat ne C#, .ToList() behet konvertimi qe ta kthejme ne tipin liste
                    return View(friends);
                }

                else
                {
                    return new EmptyResult();
                }
            }

            //Ushtrimi 7
            if (age.HasValue)  //kontrollojme se pari nese mosha ka vlere edhe vlera e moshes eshte me e madhe se 0
            {


                //filtrojme elementet sipas moshes, ku mosha duhet te jete 
                friends.MyFriends = friends.MyFriends.Where(i => i.Age > age.Value).ToList();  /// Veprime me lista Mesoni LINQ duke perdorur listat ne C#, .ToList() behet konvertimi qe ta kthejme ne tipin liste
                if (friends.MyFriends.Count > 0)
                {
                    return View(friends);

                }
                else
                {
                    return Content("Nuk ka asnje friend me moshe me te madhe se sa mosha e specifikuar");
                }
            }
            return View(friends);
        }





        //Ushtrimi 4 dhe 5 Laborator 3

        //per te pasur nje instance te listes te aksesushme nga cdo metode, deklarojme objektin Friends si instance te controllerit
        //ndryshe variabel globale

        private Friends _friends = new Friends()
        {
            //menyra e meposhtme shpjegon se si shtohet nje element Friend ne liste ne momentin e inizializimit te listes
            MyFriends =
            {  new Friend()
            {
                FriendId = Guid.NewGuid().ToString(),
                Name = "Friend1",
                Address = "Bulevardi Zogui i 1 Tirana",
                Age = 21,
                AgeRange ="Minoren",
                CloseFriend = true,
                Gender = "F"
            },
            new Friend()
            {
                FriendId = Guid.NewGuid().ToString(),
                Name = "Friend2",
                Address = "Bulevardi Zogui i 1 Tirana",
                Age = 21,
                AgeRange ="Minoren",
                CloseFriend = true,
                Gender = "M"
            },
             new Friend()
            {
                FriendId = Guid.NewGuid().ToString(),
                Name = "Friend3",
                Address = "Bulevardi Zogui i 1 Tirana",
                Age = 21,
                AgeRange ="Minoren",
                CloseFriend = true,
                Gender = "M"
            },
              new Friend()
            {
                FriendId = Guid.NewGuid().ToString(),
                Name = "Friend4",
                Address = "Bulevardi Zogui i 1 Tirana",
                Age = 21,
                AgeRange ="Minoren",
                CloseFriend = true,
                Gender = "F"
            },
        }
        };

        [HttpGet]
        public ActionResult AfishoFemer()
        {
            // ? ne _friends? ben te mundur edhe trajtimin e null exception, nese instanca _friends do ishte = null atehere null.MyFriends ben throw null exception
            // mirepo nese e vendosim me ? bejme te mundur shmangien e kesaj situate edhe ne kete rast na kthehet null si rezultat ose e thene ndryshe nje liste bosh
            // e njejta logjike ndodh edhe tek MyFriends?

            _friends.MyFriends = _friends?.MyFriends?.Where(i => i.Gender == "F").Select(i => i).ToList();

            return View(_friends);
        }

        [HttpGet]
        public ActionResult AfishoMashkull()
        {
            // ? ne _friends? ben te mundur edhe trajtimin e null exception, nese instanca _friends do ishte = null atehere null.MyFriends ben throw null exception
            // mirepo nese e vendosim me ? bejme te mundur shmangien e kesaj situate edhe ne kete rast na kthehet null si rezultat ose e thene ndryshe nje liste bosh
            // e njejta logjike ndodh edhe tek MyFriends?

            _friends.MyFriends = _friends?.MyFriends?.Where(i => i.Gender == "M").Select(i => i).ToList();

            return View(_friends);
        }


        //Ushtrimi 6 laborator 3

       [HttpGet] public ActionResult ShtoFriend()
        {
            return View();
        }


        //Ushtrimi 6 laborator 3
        [HttpPost]
        public ActionResult ShtoFriend(Friend model)
        {
            if (model.Age <= 0)
            {
                ModelState.AddModelError("Age", "Mosha duhet te jete nje numer pozitiv");
            }
            if (ModelState.IsValid)
            {
                _friends.MyFriends.Add(model);
                foreach (Friend friend in _friends.MyFriends)
                {
                    if (friend.Age < 18) friend.AgeRange = "Minoren";
                    else friend.AgeRange = "Maxhoren";
                }
                return View("Index", _friends);
            }


            return View(model);
        }


    }
}