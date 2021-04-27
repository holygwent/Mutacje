using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutacjaDrzew_Repozytorium
{
    public class MacierzWag
    {
        public int[,] W { get; private set; }
        public List<Wierzcholek> V { get; private set; }

        public MacierzWag(List<Wierzcholek> v)
        {
            V = v;
            Tworzenie(v.Count);


        }


        public int GetEdgeWeight(Krawedz e)
        {
            var i = V.FindIndex(x => x.Name == e.I.Name);
            var j = V.FindIndex(x => x.Name == e.J.Name);




            return W[i, j];
        }

        public void Tworzenie(int verticeCount)
        {

            W = new int[verticeCount, verticeCount];

            int count = 1;
            for (int i = 0; i < verticeCount; i++)
            {
                for (int j = i; j < verticeCount; j++)
                {
                    if (j == i)
                    {
                        W[i, j] = 0;
                        continue;
                    }
                    W[i, j] = count;
                    W[j, i] = count;
                    count++;
                }




            }



        }
       
    }
}
