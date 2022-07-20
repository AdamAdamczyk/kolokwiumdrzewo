using System;
using System.Collections.Generic;

namespace kolokwiumdrzewo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node(1, "1");
            Node node2 = new Node(2, "2");
            Node node3 = new Node(3, "3");
            Node node4 = new Node(4, "4");
            Node node5 = new Node(4, "5");

            node1.AddNext(node2);
            node1.AddNext(node5);

            node2.AddNext(node3);
            node2.AddNext(node4);

            //         1
            //        / \
            //       2   5
            //      / \
            //     3   4

            Console.WriteLine($"Total count for node {node1.GetName()} = {node1.CountAll()}"); //4
            Console.WriteLine();

            Console.WriteLine($"Total count for node {node2.GetName()} = {node2.CountAll()}"); //2
            Console.WriteLine();

            node1.Remove(node2);

            Console.WriteLine($"Total count for node {node1.GetName()} = {node1.CountAll()}"); //1
            Console.WriteLine();


            Console.WriteLine($"Total count for node {node5.GetName()} = {node5.CountAll()}"); //0
        }
    }

    class Node
    {
        public int Id;
        public string Name;
        public Node Parent;
        public List<Node> children;



        public Node(int id, string Name)
        {
            this.Id = id;
            this.Name = Name;
            children = new List<Node>();
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public int Count()
        {
                return children.Count;
        }

        public int CountAll(bool CountOnlyChilds = true)
        {
            int i = 1; 
            if (CountOnlyChilds) 
            {
                i = 0;
            }

            if (Count() != 0)  
            {
                for (int j = 0; j < Count(); j++) 
                {
                    var children2 = children[j];
                    i += children2.CountAll(false);
                };
            }
            return i;
        }

        public Node GetParent()
        {
            return Parent;
        }

        public void AddNext(Node nowy)
        {
            nowy.Parent = this;
            children.Add(nowy);
        }

        public void Remove(Node usun)
        {
            children.Remove(usun);
        }

        public Node ToBegining()
        {
            if (Parent != null)
                return Parent.ToBegining();

            return this;
        }
    }
}
