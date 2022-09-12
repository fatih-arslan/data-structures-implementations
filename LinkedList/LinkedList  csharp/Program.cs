using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList__csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList l = new LinkedList();
            for(int i = 0; i < 10; i++)
            {
                l.Append(i);
            }
            l.Reverse();
            for(int i = 0; i < l.Length; i++)
            {
                Console.WriteLine(l[i]);
            }
            l.Print();
            
            Console.ReadLine();
        }
    }
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node(int value)
        {
            Data = value;
            Next = null;
        }
    }
    class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Length { get; set; }
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Length = 0;
        }
        private Node GoToNode(int index)
        {
            Node traverser = Head;
            int indexCounter = 0;
            while(indexCounter < index)
            {
                traverser = traverser.Next;
                indexCounter++;
            }
            return traverser;
        }
        public void Append(int newValue)
        {
            Node n = new Node(newValue);
            if(Head == null)
            {
                Head = n;
                Tail = n;
            }
            else
            {
                Tail.Next = n;
                Tail = n;
            }
            Length++;
        }
        public void Prepend(int newValue)
        {
            Node n = new Node(newValue);
            if(Head == null)
            {
                Head = n;
                Tail = n;
            }
            else
            {
                n.Next = Head;
                Head = n;
            }
            Length++;
        }
        public void Insert(int index, int newValue)
        {
            Node n = new Node(newValue);
            if (Head == null)
            {
                Head = n;
                Tail = n;
                Length++;
            }
            else
            {
                if(index <= 0)
                {
                    this.Prepend(newValue);
                }
                else if(index >= Length)
                {
                    this.Append(newValue);
                }
                else
                {
                    Node previousNode = GoToNode(index -1);                    
                    n.Next = previousNode.Next;
                    previousNode.Next = n;
                    Length++;
                }
            }            
        }
        public void RemoveAt(int index)
        {
            if(Head != null)
            {
                if(index == 0)
                {
                    Node second = Head.Next;
                    Head.Next = null;
                    Head = second;
                    Length--;
                }
                else if(index == Length - 1) 
                {
                    Node secondToLast = GoToNode(index - 1);                    
                    secondToLast.Next = null;
                    Tail = secondToLast;
                    Length--;
                }
                else if(index > 0 && index < Length - 1)
                {
                    Node previousNode = GoToNode(index -1);                    
                    previousNode.Next= previousNode.Next.Next;
                    Length--;
                }
            }
        }   
        public int this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return Head.Data;
                }
                else if(index == Length - 1)
                {
                    return Tail.Data;
                }
                else if(0 < index && index < Length - 1)
                {
                    Node node = GoToNode(index);
                    return node.Data;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (index == 0)
                {
                    Head.Data= value;
                }
                else if (index == Length - 1)
                {
                    Tail.Data= value;
                }
                else if (0 < index && index < Length - 1)
                {
                    Node node = GoToNode(index);
                    node.Data = value;
                }                
            }
        }
        public void Reverse()
        {
            if(Length > 1)
            {
                Node first = Head;
                Node second = Head.Next;
                Head.Next = null;
                Tail = first;
                while (second != null)
                {
                    Node temp = second.Next;
                    second.Next = first;
                    first = second;
                    second = temp;
                }
                Head = first;
            }
        }
        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            Node traverser = Head;
            while(traverser != null)
            {
                sb.Append(traverser.Data.ToString());
                sb.Append(" ");
                traverser = traverser.Next;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
