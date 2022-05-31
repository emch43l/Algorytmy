using System;
using System.Text;
using System.Collections.Generic;

namespace Lab_11
{
    interface Igraph
    {
        bool AddDirectedEdge(int source, int target, int weight);
        bool AddUnDirectedEdge(int source, int target, int weight);
        void LevelTraversal(int source, Action<int> action);
    }

    class AdMatrix : Igraph
    {
        private int[,] _matrix;

        public AdMatrix(int size)
        {
            _matrix = new int[size, size];
        }

        public bool AddDirectedEdge(int source, int target, int weight)
        {
            //kod sprawdzający source i target i  zwracający false dla niepoprawnych source i target
            _matrix[source, target] = weight;
            return true;
        }

        public bool AddUnDirectedEdge(int source, int target, int weight)
        {
            return AddDirectedEdge(source, target, weight) && AddDirectedEdge(target, source, weight);
        }

        public void LevelTraversal(int source, Action<int> action)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < _matrix.GetLength(0); row++)
            {
                sb.Append($"wierzchołek {row} połączony z: ");
                for (int col = 0; col < _matrix.GetLength(1); col++)
                    if (_matrix[row, col] != 0)
                        sb.Append($"{col} ");
                sb.Append($"\n");
            }

            return sb.ToString();
        }
    }

    record Edge
    {
        public int Node { get; set; }
        public double Weight { get; set; }

    }

    class AdList : Igraph
    {
        Dictionary<int, HashSet<Edge>> _edges = new Dictionary<int, HashSet<Edge>>();
        public bool AddDirectedEdge(int source, int target, int weight)
        {
            if (!_edges.ContainsKey(source))
                _edges.Add(source, new HashSet<Edge>());
            if (!_edges.ContainsKey(target))
                _edges.Add(target, new HashSet<Edge>());
            return _edges[source].Add(new Edge() { Node = target, Weight = weight });
        }

        public bool AddUnDirectedEdge(int source, int target, int weight)
        {
            return AddDirectedEdge(source, target, weight) && AddDirectedEdge(target, source, weight);
        }

        public void LevelTraversal(int source, Action<int> action)
        {
            Queue<int> q = new Queue<int>();
            ISet<int> visited = new HashSet<int>();
            q.Enqueue(source);
            while(q.Count > 0)
            {
                int node = q.Dequeue();
                if (visited.Contains(node))
                    continue;
                action.Invoke(node);
                visited.Add(node);
                HashSet<Edge> children = _edges[node];
                foreach (Edge edge in children)
                    q.Enqueue(edge.Node);
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Igraph graph = new AdList();
            graph.AddDirectedEdge(0, 1, 1);
            graph.AddDirectedEdge(1, 3, 1);
            graph.AddDirectedEdge(2, 3, 1);
            graph.AddDirectedEdge(3, 0, 1);
            graph.AddDirectedEdge(0, 2, 1);
            graph.AddDirectedEdge(3, 2, 1);
            //Console.WriteLine(graph);
            graph.LevelTraversal(1, x => Console.WriteLine(x));
        }
    }
}
