using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            Node n0 = new Node(0);
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            g.AddVertex(n0);
            g.AddVertex(n1);
            g.AddVertex(n2);
            g.AddVertex(n3);
            g.AddVertex(n4);
            g.AddVertex(n5);
            g.AddVertex(n6);
            g.AddEdge(n0, n1);
            g.AddEdge(n0, n2);
            g.AddEdge(n1, n2);
            g.AddEdge(n1, n3);
            g.AddEdge(n2, n4);
            g.AddEdge(n3, n4);
            g.AddEdge(n4, n5);
            g.AddEdge(n5, n6);
            g.ShowConnections();           
            Console.ReadLine();
        }
    }
    class Node
    {
        public int Data { get; set; }
        public Node(int value)
        {
            Data = value;
        }
    }
    class Graph
    {
        public int NumberOfNodes { get; set; }
        public Dictionary<Node,List<Node>> AdjacentList { get; set; }
        public Graph()
        {
            NumberOfNodes = 0;
            AdjacentList = new Dictionary<Node, List<Node>>();
        }
        public void AddVertex(Node node)
        {
            List<Node> list = new List<Node>();
            AdjacentList.Add(node, list);
            NumberOfNodes++;
        }
        public void AddEdge(Node node1, Node node2)
        {
            AdjacentList[node1].Add(node2);
            AdjacentList[node2].Add(node1);
        }
        public void ShowConnections()
        {
            foreach (Node node in AdjacentList.Keys)
            {
                string s = node.Data.ToString();
                s += "-->";
                foreach (Node node2 in AdjacentList[node])
                {
                    s += node2.Data.ToString();
                    s += " ";
                }
                Console.WriteLine(s);
            }
        }
    }
}
