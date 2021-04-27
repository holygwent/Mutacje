using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutacjaDrzew_Repozytorium
{
    public class Krawedz
    {
        public Wierzcholek I { get; set; }
        public Wierzcholek J { get; set; }
        public int Weight { get; set; }

        public Krawedz(Wierzcholek i, Wierzcholek j)
        {
            I = i;
            J = j;
        }

        public override string ToString()
        {
            return $"{I}>{J}";
        }
    }
}
