using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace MutacjaDrzew_Repozytorium
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new List<Wierzcholek>();
            for (int i = 0; i < 10; i++)
            {
                v.Add(new Wierzcholek(i.ToString()));
            }
          
            var wm = new MacierzWag(v);

          

       

            //Odczytanie z pliku
            List<Drzewo> drzewa = new List<Drzewo>();
            using (StreamReader file = new StreamReader(@"C:\Users\48502\Documents\drzewa_poprawne_kopia_csv.csv"))
            {
                file.ReadLine();
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine().Split(';');
                    var e = new List<Krawedz>();
                    for (int i = 2; i < line.Length - 1; i++)
                    {
                        var column = line[i].Split('>');
                        var edge = new Krawedz(new Wierzcholek(column[0]), new Wierzcholek(column[1]));
                        edge.Weight = wm.GetEdgeWeight(edge);
                        e.Add(edge);
                    }
                    drzewa.Add(new Drzewo(e));
                }
            }




            // Utworzenie pliku mutacji
            using (StreamWriter file = new StreamWriter(@"C:\Users\48502\Documents\mutacja_zrobiona.csv"))
            {


                file.WriteLine("Index;Waga;Krawedzie;"); 


                for (int i = 0; i < 100; i++)
                {
                    drzewa[i].Mutation();
                    drzewa[i].SetEdgesWeight(wm);
                    var sb = new StringBuilder();
                    sb.Append($"{i+1};");
                    sb.Append(drzewa[i]);
                    file.WriteLine(sb); 
                }
            }

            
        }
    }
}
