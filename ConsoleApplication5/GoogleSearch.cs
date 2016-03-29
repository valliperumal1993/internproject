using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;

namespace ConsoleApplication5
{
    class GoogleSearch
    {
        //API Key
        private static string API_KEY = "AIzaSyDm-BKa-Tnjo8LaCCnbh2JAzXgI-2Ju61Q";
        //The custom search engine identifier
        private static string cx = "008016315968636110456:95yal29vmek";

        public static CustomsearchService Service = new CustomsearchService(
            new BaseClientService.Initializer
            {
                ApplicationName = "Pharma data",
                ApiKey = API_KEY,
            });

        public static IList<Result> Search(string query)
        {
            Console.WriteLine("Executing google custom search for query: {0} ...", query);

            CseResource.ListRequest listRequest = Service.Cse.List(query);
            listRequest.Cx = cx;

            Search search = listRequest.Execute();
            return search.Items;
        }

    }
}
