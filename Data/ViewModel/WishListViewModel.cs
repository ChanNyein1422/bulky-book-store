using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public class WishListViewModel
    {
        public tbBook? book { get; set; }

        public bool? isWishListed { get; set; }
        public int? WishListCount { get; set; }
    }
}
