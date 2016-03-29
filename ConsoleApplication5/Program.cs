using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using Google.Apis.Customsearch.v1.Data;

namespace ConsoleApplication5
{
    class Program

    {
        static void Main(string[] args)
        {

            string query = "prednisone";
            var results = GoogleSearch.Search(query);
            foreach (Result result in results)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Title: {0}", result.Title);
                Console.WriteLine("Link: {0}", result.Link);
            }

                List<String> list_pn = new List<String>();
                List<String> list_npn = new List<String>();
                List<String> list_cdm = new List<String>();
                List<String> list_cdm_term2 = new List<String>();
                List<String> list_cdm_term3 = new List<String>();
                List<String> list_cdm_term4 = new List<String>();
                List<String> list_cdm_desc = new List<String>();
                List<String> cdm_desc;//= new List<String>();
                List<String> cdm_desc_sub= new List<String>();
                List<String> cdm_desc_last = new List<String>();
           
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\pn\WriteLines2.txt");
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"D:\pn\WriteLines3.txt");
                System.IO.StreamWriter file_term2 = new System.IO.StreamWriter(@"D:\pn\term2.txt");
                System.IO.StreamWriter file_term3 = new System.IO.StreamWriter(@"D:\pn\term3.txt");
                System.IO.StreamWriter file_term4 = new System.IO.StreamWriter(@"D:\pn\term4.txt");
                System.IO.StreamWriter file_term2_result = new System.IO.StreamWriter(@"D:\pn\term2_result.txt");
                System.IO.StreamWriter file_term3_result = new System.IO.StreamWriter(@"D:\pn\term3_result.txt");
                System.IO.StreamWriter file_term4_result = new System.IO.StreamWriter(@"D:\pn\term4_result.txt");
                System.IO.StreamWriter file_cdm_desc_sub= new System.IO.StreamWriter(@"D:\pn\cdm_desc_sub.txt");
                System.IO.StreamWriter file_cdm_desc_last = new System.IO.StreamWriter(@"D:\pn\cdm_desc_last.txt");
                System.IO.StreamWriter file_cdm_desc_sub_result = new System.IO.StreamWriter(@"D:\pn\cdm_desc_sub_result.txt");
                System.IO.StreamWriter file_cdm_desc_last_result = new System.IO.StreamWriter(@"D:\pn\cdm_desc_last_result.txt");

                System.IO.StreamWriter file_np = new System.IO.StreamWriter(@"D:\npn\WriteLines2.txt");
                System.IO.StreamWriter file1_np = new System.IO.StreamWriter(@"D:\npn\WriteLines3.txt");
                System.IO.StreamWriter file_term2_np = new System.IO.StreamWriter(@"D:\npn\term2.txt");
                System.IO.StreamWriter file_term3_np = new System.IO.StreamWriter(@"D:\npn\term3.txt");
                System.IO.StreamWriter file_term4_np = new System.IO.StreamWriter(@"D:\npn\term4.txt");
                System.IO.StreamWriter file_term2_result_np = new System.IO.StreamWriter(@"D:\npn\term2_result.txt");
                System.IO.StreamWriter file_term3_result_np = new System.IO.StreamWriter(@"D:\npn\term3_result.txt");
                System.IO.StreamWriter file_term4_result_np = new System.IO.StreamWriter(@"D:\npn\term4_result.txt");
                System.IO.StreamWriter file_cdm_desc_sub_np = new System.IO.StreamWriter(@"D:\npn\cdm_desc_sub_np.txt");
                System.IO.StreamWriter file_cdm_desc_last_np = new System.IO.StreamWriter(@"D:\npn\cdm_desc_last_np.txt");
                System.IO.StreamWriter file_cdm_desc_sub_result_np = new System.IO.StreamWriter(@"D:\npn\cdm_desc_sub_result_np.txt");
                System.IO.StreamWriter file_cdm_desc_last_result_np = new System.IO.StreamWriter(@"D:\npn\cdm_desc_last_result_np.txt");
    
                Databaseaccess databaseaccess = new Databaseaccess();
                databaseaccess.dbaction(list_pn, list_npn, list_cdm, list_cdm_term2, list_cdm_term3, list_cdm_term4);

                Levenshteindistance levenshteindistance = new Levenshteindistance();
                levenshteindistance.ld(list_cdm, list_pn,file,file1);
                levenshteindistance.ld(list_cdm_term2, list_pn,file_term2 ,file_term2_result);
                levenshteindistance.ld(list_cdm_term3, list_pn,file_term3 ,file_term3_result);
                levenshteindistance.ld(list_cdm_term4, list_pn, file_term4, file_term4_result);

                levenshteindistance.ld(list_cdm, list_npn, file_np, file1_np);
                levenshteindistance.ld(list_cdm_term2, list_npn, file_term2_np, file_term2_result_np);
                levenshteindistance.ld(list_cdm_term3, list_npn, file_term3_np, file_term3_result_np);
                levenshteindistance.ld(list_cdm_term4, list_npn, file_term4_np, file_term4_result_np);

                cdm_desc = databaseaccess.dbactionweight(list_cdm_desc);

                foreach(var items in cdm_desc)
                {
                    cdm_desc_sub.Add(Substringclass.Truncate(items, 15));
                    cdm_desc_last.Add(Substringclass.Truncate_last(items,15));
                }

                cdm_desc_sub.RemoveAll(x => x == null);
                cdm_desc_last.RemoveAll(x => x == null);

                levenshteindistance.ld(cdm_desc_sub, list_pn, file_cdm_desc_sub, file_cdm_desc_sub_result);
                levenshteindistance.ld(cdm_desc_last, list_pn, file_cdm_desc_last, file_cdm_desc_last_result);
                levenshteindistance.ld(cdm_desc_sub, list_npn, file_cdm_desc_sub_np, file_cdm_desc_sub_result_np);
                levenshteindistance.ld(cdm_desc_last, list_npn, file_cdm_desc_last_np, file_cdm_desc_last_result_np);

        }
    }
}
