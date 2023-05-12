using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.CountApiRequest
{
    public class CountApiRequest : ICountApiRequest
    {
        public async Task<BookUserCount> GetCount()
        {
            string url = $"api/home/getcount";
            var data = await ApiRequest<BookUserCount>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

    }
}
