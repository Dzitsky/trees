using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trees
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 
            //var list = new List<int[]>();
            //list.Add(new int[] { 5, 6, 7 });
            //list.Add(new int[] { 5, 3, 4 });
            //var count = 0;
            //for (var i = 0; i < list.Count; i++) // 2
            //{
            //    for (var j = 0; j < list.Count; j++) // 3
            //    {
            //        // 2*3=6
            //        var item = list[i][j];
            //        if (item == 5)
            //        { 
            //            count++;                    
            //        }
            //    }            
            //}
            #endregion

            //var root = new Node()
            //{
            //    Value = "Корень",
            //    Left = new Node() { Value = "Левая ветка" },
            //    Right = new Node() { Value = "Правая ветка" }
            //};

            Console.WriteLine("Enter numbers. Use 0 for finish.");
            Node root = null;

            while (true)
            {
                var s = Console.ReadLine();
                var d = double.Parse(s);
                if (d == 0)
                {
                    break;
                }
                if (root == null)
                {
                    root = new Node()
                    {
                        Value = d
                    };
                }
                else
                {
                    AddNode(root, new Node
                    {
                        Value = d
                    });
                }
            }

            Console.WriteLine("Sorted numbers:");
            Traverse(root);

            Console.WriteLine("What number to find?  Use 0 for finish.");
            while (true)
            {
                var s = Console.ReadLine();
                var d = double.Parse(s);
                if (d == 0)
                {
                    break;
                }
                var (node, level) = FindNode(root, d, level: 1);
                if (node == null)
                {
                    Console.WriteLine("Not found.");
                }
                else
                {
                    Console.WriteLine($"Find {node.Value}, level: {level}");
                }
            }

            static void AddNode(Node root, Node toAdd)
            {
                if (toAdd.Value < root.Value)
                {
                    //Идем в левое поддерево
                    if (root.Left != null)
                    {
                        AddNode(root.Left, toAdd);
                    }
                    else
                    {
                        root.Left = toAdd;
                    }
                }
                else
                {
                    //Идем в правое поддерево
                    if (root.Right != null)
                    {
                        AddNode(root.Right, toAdd);
                    }
                    else
                    {
                        root.Right = toAdd;
                    }
                }
            }

            static (Node node, int level) FindNode(Node root, double number, int level)
            {
                if (number < root.Value)
                {
                    //ищем в левом поддереве
                    if (root.Left != null)
                    {
                        return FindNode(root.Left, number, level + 1);
                    }
                    return (null, -1);
                }
                if (number > root.Value)
                {
                    //ищем в правом поддереве
                    if (root.Right != null)
                    {
                        return FindNode(root.Right, number, level + 1);
                    }
                    return (null, -1);
                }
                return (root, level);
            }

            static void Traverse(Node originiNode)
            {

                if (originiNode.Left != null)
                {
                    Traverse(originiNode.Left);
                }

                Console.WriteLine(originiNode.Value);

                if (originiNode.Right != null)
                {
                    Traverse(originiNode.Right);
                }
            }
        }

        public class Node {

            public double Value { get; set; }   

            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }
}

