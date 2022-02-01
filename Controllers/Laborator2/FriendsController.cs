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
            //perdoret lista statike

            //ushtrimi 3 laborator 3
            if (take > 0)
            {
                if (take <= _friends.MyFriends.Count()) // veprime me lista, gjendet nr i elementeve te listes
                {
                    //marrim aq elemente nga lista sa specifikon take
                    _friends.MyFriends = _friends.MyFriends.Take(take).ToList();  /// Veprime me lista Mesoni LINQ duke perdorur listat ne C#, .ToList() behet konvertimi qe ta kthejme ne tipin liste
                    return View(_friends);
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
                _friends.MyFriends = _friends.MyFriends.Where(i => i.Age > age.Value).ToList();  /// Veprime me lista Mesoni LINQ duke perdorur listat ne C#, .ToList() behet konvertimi qe ta kthejme ne tipin liste
                if (_friends.MyFriends.Count > 0)
                {
                    return View(_friends);

                }
                else
                {
                    return Content("Nuk ka asnje friend me moshe me te madhe se sa mosha e specifikuar");
                }
            }
            return View(_friends);
        }





        //Ushtrimi 4 dhe 5 Laborator 3

        //per te pasur nje instance te listes te aksesushme nga cdo metode, deklarojme objektin Friends si instance te controllerit
        //ndryshe variabel globale

        private Friends _friends = new Friends()
        {
            //menyra e meposhtme shpjegon se si shtohet nje element Friend ne liste ne momentin e inizializimit te listes
            MyFriends =
            {  new LaboratoreNet2021.Models.Laborator2.Friend()
            {
                FriendId = "Id1", //do i japim Id Statike per arsye sepse sa here qe therrasim Guid.NewGuid() na gjenerohet nje id e re. Ne db id jane te konfiguruara dhe nuk ndryshojne
                Name = "Friend1",
                Address = "Bulevardi Zogui i 1 Tirana",
                Age = 21,
                AgeRange ="Minoren",
                CloseFriend = true,
                Gender = "F"
            },
            new LaboratoreNet2021.Models.Laborator2.Friend()
            {
                FriendId = "Id2",
                Name = "Friend2",
                Address = "Bulevardi Zogui i 1 Tirana",
                Age = 21,
                AgeRange ="Minoren",
                CloseFriend = true,
                Gender = "M"
            },
             new LaboratoreNet2021.Models.Laborator2.Friend()
            {
                FriendId = "Id3",
                Name = "Friend3",
                Address = "Bulevardi Zogui i 1 Tirana",
                Age = 21,
                AgeRange ="Minoren",
                CloseFriend = true,
                Gender = "M"
            },
              new LaboratoreNet2021.Models.Laborator2.Friend()
            {
                FriendId = "Id4",
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

        [HttpGet]
        public ActionResult ShtoFriend()
        {
            return View();
        }


        //Ushtrimi 6 laborator 3
        [HttpPost]
        public ActionResult ShtoFriend(LaboratoreNet2021.Models.Laborator2.Friend model)
        {
            if (model.Age <= 0)
            {
                ModelState.AddModelError("Age", "Mosha duhet te jete nje numer pozitiv");
            }
            if (ModelState.IsValid)
            {
                _friends.MyFriends.Add(model);
                foreach (LaboratoreNet2021.Models.Laborator2.Friend friend in _friends.MyFriends)
                {
                    if (friend.Age < 18) friend.AgeRange = "Minoren";
                    else friend.AgeRange = "Maxhoren";
                }
                return View("Index", _friends);
            }


            return View(model);
        }


        #region Laborator 4 
        // Region ne C# sherben per te grupuar se bashku metoda

        //Ushtrimi 1 Delete Friends.
        //do perdoret lista statike e objekteve e krijuar ne laborator 3 ne menyre qe te kemi ID e njejta
        //nese do kishim nje lidhje me bazen e te dhenave, kjo liste do merrej nga baza e te dhenave

        [HttpGet]
        public ActionResult DeleteFriend(string friendId)
        {
            var friend = _friends.MyFriends.Where(i => i.FriendId == friendId).FirstOrDefault();
            if (friend is null) //eshte njesoj sikur te shkruajme friend==null
            {
                //view e configuruar nga .Net qe ben handle errors
                return View("Error");

            }
            return View(friend);
        }
        public ActionResult DeleteShok(string friendId)
        {
            var friend = _friends.MyFriends.Where(i => i.FriendId == friendId).FirstOrDefault();
            if (friend is null) //eshte njesoj sikur te shkruajme friend==null
            {
                //view e configuruar nga .Net qe ben handle errors
                return View("Error");

            }
            _friends.MyFriends.Remove(friend);
            return View("Index", _friends);
        }


        [HttpGet]
        public ActionResult UpdateFriend(string friendId)
        {
            var friend = _friends.MyFriends.Where(i => i.FriendId == friendId).FirstOrDefault();
            if (friend is null) //eshte njesoj sikur te shkruajme friend==null
            {
                //view e configuruar nga .Net qe ben handle errors
                return View("Error");

            }
            return View(friend);
        }

        [HttpPost]
        public ActionResult UpdateFriend(LaboratoreNet2021.Models.Laborator2.Friend friendModel)
        {
            if (ModelState.IsValid)
            {
                var friend = _friends.MyFriends.Where(i => i.FriendId == friendModel.FriendId).FirstOrDefault();
                if (friend is null) //eshte njesoj sikur te shkruajme friend==null
                {
                    //view e configuruar nga .Net qe ben handle errors
                    return View("Error");

                }
                //modifikimi mund te behet ne dy menyra
                //1. heqim elementin e vjeter dhe shtojme te riun
                //2. per cdo property te objektit te vjeter i japim vlere nga objekti qe marrim si parameter
                // Nese do kemi rastin e lidhjes me bazen e te dhenave athere update menaxhohet vete nga EntityFramework, ndryshe quhet ORM (object Relation Mapper) dhe i menaxhon ORM updatin ne menyre gjenerike

                //Rasti i Pare
                _friends.MyFriends.Remove(friend);
                _friends.MyFriends.Add(friendModel);

                //Rasti i dyte
                foreach (var item in _friends.MyFriends)
                {
                    if (item.FriendId == friendModel.FriendId)  //ky kushti na mundeson qe modifikimi te behet vetem per elementin qe kemi kaluar nga forma
                    {
                        item.Name = friendModel.Name;
                        item.AgeRange = friendModel.AgeRange;
                        item.CloseFriend = friendModel.CloseFriend;
                        item.Gender = friendModel.Gender;
                        item.Age = friendModel.Age;
                        item.Address = friendModel.Address;
                    }
                }
                return View("Index", _friends);
            }
            else return View(friendModel);
        }

        #endregion

        [HttpGet]
        public ActionResult AfishoFromDB()
        {
            //friend from db
            var friends = new List<Friend>();

            //lidhja me bazen e te dhenave
            using (FriendsDBEntities db = new FriendsDBEntities())
            {
                //akesesimi i tabeles ne bazen e te dhenave
                friends = db.Friends.ToList();

            }
            return View(friends);
        }
    }

}