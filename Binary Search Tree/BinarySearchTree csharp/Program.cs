using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree t = new BinarySearchTree();
            t.Insert(15);       
            t.Insert(20);
            t.Insert(10);           
            t.Insert(17);            
            t.Insert(12);            
            t.Insert(22);            
            t.Insert(8);            
            t.Insert(13);            
            t.Insert(24);            
            t.Insert(6);            
            t.Insert(16);            
            t.Insert(18);
            t.PrintPostOrder();
            Console.WriteLine(t.BreadthFirstSearch(24));
            Console.Read();
        }
    }
    class Node
    {
        public int Data { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }
        public Node(int value)
        {
            Data = value;
            Right = null;
            Left = null;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
    class BinarySearchTree
    {
        public Node Root { get; set; }
        public BinarySearchTree()
        {
            Root = null;
        }

        private Node InsertPrivate(int value, Node rootNode)
        {
            Node node = new Node(value);
            if(rootNode == null)
            {
                rootNode = node;
            }
            else
            {
                if(value < rootNode.Data)
                {
                    rootNode.Left = InsertPrivate(value, rootNode.Left);
                }
                else
                {
                    rootNode.Right = InsertPrivate(value, rootNode.Right);
                }
            }
            return rootNode;
        }
               
        public void Insert(int value)
        {
            Root = InsertPrivate(value, Root);            
        }
        private Node LookUpPrivate(int value, Node rootNode)
        {
            if(rootNode.Data == value)
            {
                return rootNode;
            }
            else if(value < rootNode.Data)
            {
                if(rootNode.Left != null)
                {
                    return LookUpPrivate(value, rootNode.Left);
                }
                return null;
            }
            else
            {
                if (rootNode.Right != null)
                {
                    return LookUpPrivate(value, rootNode.Right);
                }
                return null;
            }            
        }
        public Node LookUp(int value)
        {
            return LookUpPrivate(value, Root);
        }
        private void InOrder(Node rootNode)
        {
            if (rootNode != null)
            {
                InOrder(rootNode.Left);
                Console.WriteLine(rootNode.ToString());                
                InOrder(rootNode.Right);
            }
        }
        private void PreOrder(Node rootNode)
        {
            if(rootNode != null)
            {
                Console.WriteLine(rootNode.ToString());
                PreOrder(rootNode.Left);
                PreOrder(rootNode.Right);
            }
        }
        private void PostOrder(Node rootNode)
        {
            if (rootNode != null)
            {
                PostOrder(rootNode.Left);
                PostOrder(rootNode.Right);
                Console.WriteLine(rootNode.ToString());
            }
        }

        public void PrintPreOrder()
        {
            PreOrder(Root);
        }
        public void PrintInOrder()
        {
            InOrder(Root);
        }
        public void PrintPostOrder()
        {
            PostOrder(Root);
        }
        private bool BreadFirstSearchPrivate(Node rootNode, int n)
        {
            Node node = rootNode;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            while(queue.Count > 0)
            {
                node = queue.Dequeue();
                if(node.Data == n)
                {
                    return true;
                }
                if(node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if(node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return false;
        }
        public bool BreadthFirstSearch(int n)
        {
            return BreadFirstSearchPrivate(Root, n);
        }
        private bool DepthFirstSearchPrivate(Node rootNode, int n)
        {
            Node node = rootNode;
            Stack<Node> stack = new Stack<Node>();
            stack.Push(node);
            while(stack.Count > 0)
            {
                node = stack.Pop();
                if(node.Data == n)
                {
                    return true;
                }
                if(node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if(node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
            return false;
        }
        public bool DepthFirstSearch(int n)
        {
            return DepthFirstSearchPrivate(Root, n);
        }
    }    
}
