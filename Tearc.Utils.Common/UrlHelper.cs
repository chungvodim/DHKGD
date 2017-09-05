using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tearc.Utils.Common
{
    public static class UrlHelper
    {
        public static string AppendQueryString(string baseUrl, string key, string value)
        {
            var uriBuilder = new UriBuilder(baseUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[key] = value;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri.AbsoluteUri;
        }

        public static bool IsLocalPath(string filePath)
        {
            if (filePath.StartsWith("http:\\"))
            {
                return false;
            }

            if (filePath.StartsWith("https:\\"))
            {
                return false;
            }

            return new Uri(filePath).IsFile;
        }
    }
}
