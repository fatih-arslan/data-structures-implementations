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
            t.Insert(9);
            t.Insert(11);
            t.Print();            
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
    }
    class BinarySearchTree
    {
        public Node Root { get; set; }
        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int value)
        {
            if(Root == null)
            {
                Root = new Node(value);
            }
            else
            {
                InsertPrivate(Root, value);
            }
        }

        private void InsertPrivate(Node root, int value)
        {
            if(value < root.Data)
            {
                if(root.Left == null)
                {
                    root.Left = new Node(value);
                }
                else
                {
                    InsertPrivate(root.Left, value);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = new Node(value);
                }
                else
                {
                    InsertPrivate(root.Right, value); 
                }
            }
        }

        public Node Search(int value)
        {
            return SearchPrivate(Root, value);
        }     

        private Node SearchPrivate(Node root, int value)
        {
            if(root == null || root.Data == value)
            {
                return root;
            }
            if(value < Root.Data)
            {
                return SearchPrivate(root.Left, value);
            }
            else
            {
                return SearchPrivate(root.Right, value);
            }
        }     

        private void InOrder(Node rootNode)
        {
            if (rootNode != null)
            {
                InOrder(rootNode.Left);
                Console.Write(rootNode + " ");                
                InOrder(rootNode.Right);
            }
        }
        private void PreOrder(Node rootNode)
        {
            if(rootNode != null)
            {
                Console.Write(rootNode + " ");
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
                Console.Write(rootNode + " ");
            }
        }

        public void PreOrderTraversal()
        {
            PreOrder(Root);
        }
        public void InOrderTraversal()
        {
            InOrder(Root);
        }
        public void PostOrderTraversal()
        {
            PostOrder(Root);
        }

        public void BreadthFirstSearch()
        {
            if (Root == null)
            {
                return;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                Console.Write(node.Data + " ");

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        public void DepthFirstSearch()
        {
            if (Root == null)
            {
                return;
            }
            Stack<Node> stack = new Stack<Node>();
            stack.Push(Root);

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                Console.Write(node.Data + " ");


                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
            }            
        }  
        
        public void Print()
        {
            if (Root == null)
            {
                return;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                int levelSize = queue.Count;
                int tabSize = 50 - levelSize;
                Console.Write(new string(' ', tabSize));
                for(int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();
                    Console.Write(node.Data + " ");

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
                Console.WriteLine();
            }
        }
    }    
}
