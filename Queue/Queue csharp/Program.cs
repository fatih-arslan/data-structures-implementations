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
        public int Length { get; private set; }
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
        public int Dequeue()
        {
            if (First == null)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
            int value = First.Data;
            First = First.Next;
            Length--;

            if (First == null)
            {
                Last = null;
            }

            return value;
        }
        public int Peek()
        {
            if (First == null)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return First.Data;
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
