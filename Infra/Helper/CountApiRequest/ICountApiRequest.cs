using Data.Models;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.CountApiRequest
{
    public interface ICountApiRequest
    {
        Task<BookUserCount> GetCount();
    }
}
