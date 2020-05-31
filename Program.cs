using System;
using System.Collections.Generic;
namespace Dijkstras_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.AddVertice('A', new Dictionary<char, int>() { { 'B', 7 }, { 'C', 8 } });
            g.AddVertice('B', new Dictionary<char, int>() { { 'A', 7 }, { 'F', 2 } });
            g.AddVertice('C', new Dictionary<char, int>() { { 'A', 8 }, { 'F', 6 }, { 'G', 4 } });
            g.AddVertice('D', new Dictionary<char, int>() { { 'F', 8 } });
            g.AddVertice('E', new Dictionary<char, int>() { { 'H', 1 } });
            g.AddVertice('F', new Dictionary<char, int>() { { 'B', 2 }, { 'C', 6 }, { 'D', 8 }, { 'G', 9 }, { 'H', 3 } });
            g.AddVertice('G', new Dictionary<char, int>() { { 'C', 4 }, { 'F', 9 } });
            g.AddVertice('H', new Dictionary<char, int>() { { 'E', 1 }, { 'F', 3 } });
            var path = g.ShortestPath('A', 'E');
            path.ForEach(v => { Console.WriteLine(v); });
        }
    }
}
