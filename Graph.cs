using System.Collections.Generic;
using System.Linq;

namespace Dijkstras_Algorithm
{
    public class Graph
    {
        public Dictionary<char, Dictionary<char,int>> Vertices { get; set; }
        public Graph()
        {
            Vertices = new Dictionary<char, Dictionary<char, int>>();
        }
        public void AddVertice(char name, Dictionary<char, int> neightborsVertices)
        {
            Vertices[name] = neightborsVertices;
        }

        public List<char> ShortestPath(char initial, char goal)
        {
            var path = new List<char>();

            var previous = new Dictionary<char, char>();

            var nodes = new List<char>();
            
            var weight = new Dictionary<char, int>();
            
            foreach (var vertice in Vertices)
            {
                if (vertice.Key == initial)
                    weight[vertice.Key] = 0;
                else
                    weight[vertice.Key] = int.MaxValue;

                nodes.Add(vertice.Key);
            }

            while (nodes.Any())
            {
                nodes.Sort((x, y) => weight[x] - weight[y]);

                var smallest = nodes.First();
                nodes.Remove(smallest);

                if(smallest == goal)
                {
                    path.Add(goal);
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(previous[smallest]);
                        smallest = previous[smallest];
                    }
                    break;
                }

                foreach (var neightbor in Vertices[smallest])
                {
                    if (nodes.Contains(neightbor.Key))
                    {
                        if (weight[smallest] + neightbor.Value < weight[neightbor.Key])
                        {
                            weight[neightbor.Key] = weight[smallest] + neightbor.Value;
                            previous[neightbor.Key] = smallest;
                        }
                    }   
                }
            }
            return path;
        }
    }
}