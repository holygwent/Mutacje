using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutacjaDrzew_Repozytorium
{
    public class Wierzcholek 
    {
        public string Name { get; private set; }

        public Wierzcholek(string name)
        {
            Name = name;
        }






        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
