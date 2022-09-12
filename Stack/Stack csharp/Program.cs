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
        public int Length { get; set; }
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
        public void Pop()
        {
            if(Top != null)
            {
                Node second = Top.Next;
                Top.Next = null;
                Top = second;
                Length--;
            }            
        }
        public int Peek()
        {
            if(Top != null)
            {
                return Top.Data;
            }
            return 0;
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
