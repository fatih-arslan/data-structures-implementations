using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            for(int i = 0; i < 10; i++)
            {
                s.Push(i);
            }
            s.Pop();
            Console.WriteLine(s.Peek());
            s.Print();
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
            Next = null;
        }
    }
    class Stack
    {
        public Node Top { get; set; }
        public Node Bottom { get; set; }
        public int Length { get; private set; }
        public Stack()
        {
            Top = null;
            Bottom = null;
            Length = 0;
        }
        public void Push(int value)
        {
            Node n = new Node(value);
            if (Top == null)
            {
                Top = n;
                Bottom = n;
            }
            else
            {
                n.Next = Top;
                Top = n;
            }            
            Length++;
        }
        public int Pop()
        {
            if (Top == null)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            int value = Top.Data;
            Top = Top.Next;
            Length--;

            if (Top == null)
            {
                Bottom = null;
            }

            return value;
        }
        public int Peek()
        {
            if (Top == null)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return Top.Data;
        }
        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            Node n = Top;
            while (n != null)
            {
                sb.Append(n.Data.ToString());
                sb.Append(' ');
                n = n.Next;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
