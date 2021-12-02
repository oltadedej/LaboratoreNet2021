using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoreNet2021.Models.Laborator2
{
    public class Friends
    {
        public Friend MyFriend { get; set; }
        public List<Friend> MyFriends { get; set; }

        public Friends()
        {
            MyFriends = new List<Friend>();// ne pergjithesi listat i deklarojme si instanca te reja per te shmangur Null exception ne kod
            //te cilet ndodhin nese aksesoj nje element te listes te tille si  friends[0], ose nese dua te shtoj nje element ne liste pa e deklaruar njehere listen si objekt i ri
            ////dhe nese lista eshte null jep error
        }
    }
}