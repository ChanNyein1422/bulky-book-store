using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper
{
    public struct baseUrls
    {
        public const string bulkybookroute = "https://localhost:7149/";
        
    }
    public struct Request
    {
        public const string bulkybookapi = "BulkyBook";
    }

    public static class Router
    {

        public static string route(this string Route, string project)
        {
            string? route = null;
            switch (project)
            {
                case Request.bulkybookapi:
                    route = $"{baseUrls.bulkybookroute}{Route}";
                    break;
                default:
                    throw new ArgumentException("Invalid Route");
            }
            return route;
        }
    }
}
