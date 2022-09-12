using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();
            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }
            q.Dequeue();
            q.Print();
            Console.ReadLine();
        }
    }
    class Node
    {
        public int Data { get; set; }
        public  Node Next { get; set; }
        public Node(int value)
        {
            Data = value;
        }
    }
    class Queue
    {
        public  Node First { get; set; }
        public Node Last { get; set; }
        public int Length { get; set; }
        public Queue()
        {
            First = null;
            Last = null;
            Length = 0;
        }
        public void Enqueue(int value)
        {
            Node n = new Node(value);
            if(First == null)
            {
                First = n;
                Last = n;
            }
            else
            {
                Last.Next = n;
                Last = n;
            }
            Length++;
        }
        public void Dequeue()
        {
            if(First != null)
            {
                Node second = First.Next;
                First.Next = null;
                First = second;
            }            
        }
        public int Peek()
        {
            if(First != null)
            {
                return First.Data;
            }
            return 0;
        }
        public void Print()
        {
            Node n = First;
            StringBuilder sb = new StringBuilder();
            while(n != null)
            {
                sb.Append(n.Data.ToString());
                sb.Append(" ");
                n = n.Next;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
