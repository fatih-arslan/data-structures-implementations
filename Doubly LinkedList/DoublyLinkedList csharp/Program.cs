using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList dl = new DoublyLinkedList();
            for(int i = 0; i < 10; i++)
            {
                dl.Append(i);
            }
            dl.reverse();
            dl.Print();
            for (int i = 0; i < dl.Length; i++)
            {
                Console.WriteLine(dl[i]);
            }
            
            Console.ReadLine();
        }
    }
    class Node
    {
        public int Data { get; set; }
        public  Node Next { get; set; }
        public  Node Previous { get; set; }
        public Node(int value)
        {
            Data = value;
            Next = null;
            Previous = null;
        }
    }
    class DoublyLinkedList
    {
        public  Node Head { get; set; }
        public Node Tail { get; set; }
        public int Length { get; private set; }
        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Length = 0;
        }
        public Node GoToNode(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            Node traverser;
            int indexCounter;
            if (index > Length / 2)
            {
                indexCounter = Length - 1;
                traverser = Tail;
                while (indexCounter > index)
                {
                    traverser = traverser.Previous;
                    indexCounter--;
                }
            }
            else
            {
                traverser = Head;
                indexCounter = 0;
                while (indexCounter < index)
                {
                    traverser = traverser.Next;
                    indexCounter++;
                }
            }
            return traverser;
        }
        public void Append(int newValue)
        {
            Node node = new Node(newValue);
            if(Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
            Length++;
        }
        public void Prepend(int newValue)
        {
            Node node = new Node(newValue);
            if(Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }
            Length++;
        }
        public void Insert(int index, int newValue)
        {
            Node node = new Node(newValue);
            if(Head == null)
            {
                Head = node;
                Tail = node;
                Length++;
            }
            else
            {
                if(index <= 0)
                {
                    this.Prepend(newValue);
                }
                else if(index >= this.Length)
                {
                    this.Append(newValue);
                }
                else
                {
                    Node previousNode = GoToNode(index - 1); // 0 1 2 3 4 5 6 7 8 9
                    node.Next = previousNode.Next;
                    previousNode.Next.Previous = node;
                    previousNode.Next = node;
                    node.Previous = previousNode;
                    Length++;
                }
            }            
        }
        public void RemoveAt(int index)
        {
            if (Head != null)
            {
                if (index == 0)
                {
                    Node second = Head.Next;
                    if (second != null)
                    {
                        second.Previous = null;
                    }
                    Head.Next = null;
                    Head = second;
                    Length--;
                    if (Length == 0)
                    {
                        Tail = null;
                    }
                }
                else if (index == this.Length - 1)
                {
                    Node secondToLast = Tail.Previous;
                    secondToLast.Next = null;
                    Tail.Previous = null;
                    Tail = secondToLast;
                    Length--;
                }
                else if (0 < index && index < this.Length - 1)
                {
                    Node previousNode = GoToNode(index - 1);
                    Node nodeToRemove = previousNode.Next;
                    previousNode.Next = nodeToRemove.Next;
                    nodeToRemove.Next.Previous = previousNode;
                    nodeToRemove.Next = null;
                    nodeToRemove.Previous = null;
                    Length--;
                }
            }
        }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }

                Node n = GoToNode(index);
                return n.Data;
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }

                Node n = GoToNode(index);
                n.Data = value;
            }
        }
        public void Reverse()
        {
            if(Length > 1)
            {
                Node first = Head;
                Node second = first.Next;
                Head.Next = null;
                Tail = first;
                while(second != null)
                {
                    Node temp = second.Next;
                    second.Next = first;
                    first.Previous = second;
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
            while (traverser != null)
            {
                sb.Append(traverser.Data.ToString());
                sb.Append(" ");
                traverser = traverser.Next;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
