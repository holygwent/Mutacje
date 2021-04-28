using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutacjaDrzew_Repozytorium
{
    public class Drzewo 
    {
        //lista wierzchołkow
        public List<Wierzcholek> V { get; set; }
        //lista krawedzi
        public List<Krawedz> E { get; set; }
        //konstruktor
     
        //konstruktor
        public Drzewo(List<Krawedz> e)
        {
            V = new List<Wierzcholek>();
            E = new List<Krawedz>(e);

            for (int i = 0; i < e.Count; i++)
            {
                if (!V.Any(x => x.Name == e[i].I.Name)) V.Add(e[i].I);
                if (!V.Any(x => x.Name == e[i].J.Name)) V.Add(e[i].J);
            }
        }
       //otrzymanie wag
     
        public int GetEdgesWeight()
        {
            var sum = 0;
            foreach (var edge in E)
            {
                sum += edge.Weight;
            }
            return sum;
        }
        //otrzymanie sasiadów
        public HashSet<Wierzcholek> GetNeighbors(Wierzcholek v)
        {
            var neighbors = new HashSet<Wierzcholek>();
            foreach (var e in E)
            {
                if (e.I.Name == v.Name) neighbors.Add(e.J);
                else if (e.J.Name == v.Name) neighbors.Add(e.I);
            }
            return neighbors;
        }
        public void Mutation()
        {
            // Wylosowanie krawedzi do usuniecia
            var randomEdge = GetRandomEdge();
            E.Remove(randomEdge);

            // Znalezienie sasiadow  usunietej krawedzi
            var neighborsVerticeI = GetNeighbors(randomEdge.I);


            var neighborsVerticeJ = GetNeighbors(randomEdge.J);

            // Sprawdzenie czy wierzcholek krawedzi konczy sie lisciem
            if (neighborsVerticeI.Count() == 0)
            {
            
                var v = V.Where(x => x.Name != randomEdge.I.Name).ToList();
                CreateRandomEdge(randomEdge.I, v);
                return;
            }
            else if (neighborsVerticeJ.Count() == 0)
            {
                var v = V.Where(x => x.Name != randomEdge.J.Name).ToList();
                CreateRandomEdge(randomEdge.J, v);
                return;
            }

            var allNeighbors = new List<Wierzcholek>(neighborsVerticeJ);
            allNeighbors.Add(randomEdge.J);

        
            for (int i = 0; i < allNeighbors.Count; i++)
            {
            
                var iNeighbors = GetNeighbors(allNeighbors[i]);
      
                var withoutDuplicates = iNeighbors.Where(x => !allNeighbors.Any(y => x.Name == y.Name));
                allNeighbors.AddRange(withoutDuplicates);
            }

           
            List<Wierzcholek> verticesDiffrence = V.Where(x => !allNeighbors.Contains(x)).ToList();
            // Utworzenie nowej krawedzi dla usuniętej
            CreateRandomEdge(randomEdge.J, verticesDiffrence);
        }
      
        public void CreateRandomEdge(Wierzcholek from, List<Wierzcholek> candidates)
        {
            var randomIndex = new Random().Next(candidates.Count);
            var newEdge = new Krawedz(from, candidates[randomIndex]);
            E.Add(newEdge);
        }
        public Krawedz GetRandomEdge()
        {
            var randomIndex = new Random().Next(E.Count);
            return E[randomIndex];
        }
        public void Wypisz()
        {
            Console.Write("Waga = {0} ", GetEdgesWeight());
            foreach (var edge in E)
            {
                Console.Write("{0}>", edge);
            }
            Console.WriteLine();
        }
        //wypisywanie
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append($"{GetEdgesWeight()};");
            foreach (var edge in E)
            {
                result.Append($"{edge};");
            }
            return result.ToString();
        }
        //ustawienie wag
        public void SetEdgesWeight(MacierzWag w)
        {
            foreach (var edge in E)
            {
                edge.Weight = w.GetEdgeWeight(edge);
            }
        }
    }
}
