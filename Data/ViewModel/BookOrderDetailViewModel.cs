using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public class BookOrderDetailViewModel
    {
        public tbBook? book { get; set; }
        public tbOrderDetail? orderDetail { get; set; }
    }
}
