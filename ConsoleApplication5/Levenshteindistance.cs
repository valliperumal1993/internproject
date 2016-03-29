using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Levenshteindistance
    {

        public void ld(List<string> list_cdm, List<string> list_pn, System.IO.StreamWriter file, System.IO.StreamWriter file1)
        {
            int x;
            int k;
            int[] index = new int[5];
            List<int> temp=new List<int>();
            List<int> distinct1=new List<int>();
            Tuple<string, string, int> result;
            var h = new List<Tuple<string, string, int>>();
            for (int i = 0; i < list_cdm.Count; i++)
            {
                for (int j = 0; j < list_pn.Count; j++)
                {
                    x = levenshtein.Compute(list_cdm[i], list_pn[j]);//(cdm,pn,levdis) 
                    temp.Add(x);
                   
                }

                distinct1 = temp.Distinct().ToList();
                distinct1.Sort();

                for (k = 0; k < 3; k++)
                {
                    
                    index[k] = distinct1[k];

                    for (int m = 0; m < list_pn.Count; m++)
                    {
                        if (index[k] == temp[m])
                        {
                         
                            file.WriteLine(i + "\t" + list_cdm[i] + "\t" + "\t" + list_pn[m] + "\t" + index[k]);

                            result = Tuple.Create(list_cdm[i], list_pn[m], index[k]);
                            h.Add(result);
                        }

                    }
                }


                for (int m = 0; m < 3; m++)
                {
                    file1.WriteLine(h[m]);
                }
                h.Clear();
                distinct1.Clear();
                temp.Clear();
            }


        }

    }
}
