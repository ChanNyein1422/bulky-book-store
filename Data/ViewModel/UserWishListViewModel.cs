using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public class UserWishListViewModel
    {
        public tbBook? book { get; set; }
        public tbWishList? wishList { get; set; }
    }
}
