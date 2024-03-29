﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BianryTree tree = new BianryTree();


            string s = "abc";
            s.ToUpper();
            Console.WriteLine(s);    



            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(7);


            Console.WriteLine("Pre Order");
            tree.PreOrderT();

            Console.WriteLine("\n");

            Console.WriteLine("In Order");
            tree.InOrderT();

            Console.WriteLine("\n");

            Console.WriteLine("Post Order");
            tree.PostOrderT();

            Console.WriteLine("\n");

            Console.WriteLine("Finding a node");
            tree.Find(4);

            Console.WriteLine("\n");

            Console.WriteLine("InOrder successor");
            tree.InOrderSuccessor();

            Console.WriteLine("\n");

            Console.WriteLine("Level Order");
            tree.LevelOrderT();

            Console.WriteLine("\n");

            Console.WriteLine("Is BST");
            tree.isBinaryTree();

            Console.WriteLine("\n");

            Console.WriteLine("Height of BST");
            tree.HightOfBST();

            Console.WriteLine("\n");

            Console.WriteLine("No of Nodes");
            tree.NoOfNodes();


            Console.WriteLine("\n");

            Console.WriteLine("Height of a Nodes");
            tree.HeightOfNodes();


            Console.WriteLine("\n");
;

            Console.WriteLine("\n");

            int[,] G = new int[2,3] { { 0,0,1 }, { 1,0,1} };

            var r = tree.getHitProbability(2, 3, G);

            Console.WriteLine(r);

            int[] nums = { 1, 2, 3, 4, 5, 6, 7,8,9,10,11,12,13,14,15 };

            var rrr = tree.Rotate(nums, 3);


        }
    }



    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node(int data)
        {
            this.val = data;
            this.left = null;
            this.right = null;
            this.next = null;
        }
    }




    public class BianryTree
    {

        Node root = null;

        List<int> values = new List<int>();


        public int[] Rotate(int[] nums, int k)
        {

            int j = 0;
            int lastTemp = 0;

            if (k <= nums.Length)
            {
                int size = nums.Length - k;
                lastTemp = nums[size - 1];
                for (int i = size; i < nums.Length; i++)
                {
                    int temp = nums[j];
                    nums[j] = nums[i];
                    nums[i - 1] = temp;
                    j++;
                }

                nums[nums.Length - 1] = lastTemp;
            }

            return nums;
        }



            public void Insert(int data)
        {
            if (root == null)
            {
                Node newNode = new Node(data);
                root = newNode;
            }
            else
            {
                InsertRightORLeftNode(root, data);
            }
        }


        public double getHitProbability(int R, int C, int[,] G)
        {
            double result = 0;
            double counts = 0;
            double iterate = 0;

            if (G != null)
            {
                for (int i = 0; i < R;i++)
                {
                    for (int j = 0; j < C; j++)
                    {
                        iterate += 1;

                        if (G[i, j] >= 1)
                        {
                            counts += 1;
                        }
                    }
                }
            }

            result = counts / iterate;

            return result;
        }


        private void InsertRightORLeftNode(Node node, int data)
        {
            // for inserting left node
            if (data < node.val)
            {
                if (node.left == null)
                {
                    Node left = new Node(data);
                    node.left = left;
                }
                else
                {
                    InsertRightORLeftNode(node.left, data);
                }
            }
            else
            {
                if (node.right == null)
                {
                    Node right = new Node(data);
                    node.right = right;
                }
                else
                {
                    InsertRightORLeftNode(node.right, data);
                }
            }
        }


        public void InOrderSuccessor()
        {
            Successor(root, root.right.right);
        }


        public void Successor(Node root, Node node)
        {
            Node succes = null;

            if(node == null || root == null)
            {
                Console.WriteLine("Nothing");
            }
            else
            {
                if(node.right != null)
                {
                    var val = getMostLeft(node.right);
                    Console.WriteLine("Most Left : " + val);
                }
                else
                {
                    while (root != null)
                    {
                        if (node.val < root.val)
                        {
                            succes = root;
                            root = root.left;
                        }
                        else if (node.val > root.val)
                            root = root.right;
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Successor : " + succes?.val);
                }
                
            }
        }


        public int getMostLeft(Node node)
        {
            if(node.left == null)
            {
                return node.val;
            }
            else
            {
              return getMostLeft(node.left);
            }
        }


        public void PreOrderT()
        {
            if (root != null)
            {
                this.PreOrder(root);
            }
        }


        public void InOrderT()
        {
            if (root != null)
            {
               var r =  this.InOrder(root);
                Console.WriteLine(string.Join(" -> ", r));
            }
        }


        public void PostOrderT()
        {
            if (root != null)
            {
                this.PostOrder(root);
            }
        }


        public void Find(int data)
        {
            var val = Finds(data, root);

            Console.WriteLine("\nFound data : " + val.val);
        }


        public void LevelOrderT()
        {
            if(root != null)
            {
                LevelOrder(root);
            }
        }


        public void isBinaryTree()
        {
            if(root != null)
            {
                var r = isBST(root);
                Console.WriteLine(r);
            }
        }


        public void HightOfBST()
        {
            var r = BSTHeight(root);
            Console.WriteLine(r);
        }


        public void NoOfNodes()
        {
            var r = noOfNodes(root);
            Console.WriteLine(r);
        }


        public void HeightOfNodes()
        {
            var r = heightOfNode(5);
            Console.WriteLine(r);
        }


      




        private void PreOrder(Node nodes)
        {
            Console.Write(nodes.val + " -> ");

            if (nodes.left != null)
            {
                PreOrder(nodes.left);
            }

            if (nodes.right != null)
            {
                PreOrder(nodes.right);
            }

           
        }


        private List<int> InOrder(Node nodes)
        {
            if (nodes.left != null)
            {
                InOrder(nodes.left);
            }

            values.Add(nodes.val);

            if (nodes.right != null)
            {
                InOrder(nodes.right);
            }

            var r = values.Select(c => c * c).Take(5).Distinct().OrderBy(c => c);

            Dictionary<int, string> dict = new Dictionary<int, string>()
            {
                {1, "uuu" },
            };

            return values;
        }

        [Obsolete(message:"",false)]
        private void PostOrder(Node nodes)
        {
            if (nodes.left != null)
            {
                PostOrder(nodes.left);
            }

            if (nodes.right != null)
            {
                PostOrder(nodes.right);
            }

            Console.Write(nodes.val + " -> ");
        }



        // find the node of a particular value
        private Node Finds(int data, Node node)
        {
            if(data == node.val)
            {
                return node;
            }
            else
            {
                if (data < node.val && node.left != null)
                {
                    return Finds(data, node.left);
                }
                else if(data >= node.val && node.right != null)
                {
                    return Finds(data, node.right);
                }
                else
                {
                    return null;
                }
            }
        }


        private void LevelOrder(Node node)
        {
            Queue<Node> QueueNodes = new Queue<Node>();

            QueueNodes.Enqueue(node);

            while (QueueNodes.Count > 0)
            {
                Node current = QueueNodes.Dequeue();
                Console.Write(current.val + " -> ");

                if (current.left != null)
                {
                    QueueNodes.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    QueueNodes.Enqueue(current.right);
                }
            }
        }


        private List<int> SortedList(List<int> data)
        {
            var sorts = new SortedList<int, int>();

            for (int i = 0; i < data.Count(); i++)
            {
                sorts.Add(i, data[i]);
            }

            return sorts.Values.ToList();
        }


        // checking if a tree is a BST
        private bool isBST(Node node)
        {
            var inOrderList = values;
            var orderList = SortedList(values);

            return inOrderList.SequenceEqual(orderList) == true ? true : false;
        }


        private int BSTHeight(Node node)
        {
            if(node == null)
            {
                return -1;
            }
            else
            {
                int leftHeight = BSTHeight(node.left);
                int rightHeight = BSTHeight(node.right);

                return Math.Max(leftHeight, rightHeight) + 1; // 1 is for the root node;
            }
        }



        private int noOfNodes(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = noOfNodes(node.left);
                int rightHeight = noOfNodes(node.right);

                return Math.Max(leftHeight, rightHeight) + 1; // 1 is for the root node;
            }
        }



        private int heightOfNode(int data)
        {
            // first we have to find that node

            var node = Finds(data, root);
            var max = BSTHeight(node);
            return max;
        }



        /*** Print the longest path from root to leaf in a Binary tree
         * 
         * check if the root node is null and return an empty list
         * 
         * Get all the left sub tree from the root node
         * Get all the right sub tree from the right node 
         * Add the root node to the result of the left sub tree and the right sub tree.
         * 
         * Check the left and right which has more length and return the highest;
         * 
         */
        private List<int> LongestPathFromRoot(Node node)
        {
            if(node == null) return new List<int>();

            var left = LongestPathFromRoot(node.left);
            var right = LongestPathFromRoot(node.right);

            if (left.Count > right.Count)
            {
                left.Add(node.val);
            }
            else
            {
                right.Add(node.val);
            }

            return left.Count > right.Count ? left : right;
        }





        /** Get the in order sucessor of a list
         * 
         * Firt check if the root node and the given nood is null and return 0
         * 
         * Check if the right node is not null, if true, move to the most left node and return the least node
         * 
         * Else, if the right node is null, loop through the root node, 
         * 
         * if the left data is less than the root data, set the successor then go to the left node, else, go to the right node
         * 
         */
        private int InOrderSuccessor(Node root, Node node)
        {
            Node successor = null;

            if(root == null || node == null) return 0;

            if(node.right != null)
            {
                return getMostLeft(node.right);
            }
            else
            {
                while(root != null)
                {
                    if(node.val < root.val)
                    {
                        successor = root;
                        root = root.left;   
                    }
                    else if(node.val > root.val)
                    {
                        root = root.right;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return successor.val;
        }


        
        /**
         * Check if a binary tree is a special binary tree. 
         * 
         * Such that all the nodes and sub-nodes has 0 or 2 child nodes.
         * 
         */ 

        private bool isSpecialBinaryTree(Node node)
        {
            bool result = true;

            if (node == null) return result;

            if (node.left != null && node.right == null)
            {
                result = false;
            }
            else if (node.right != null && node.left == null)
            {
                result = false;
            }
            else if(node.right == null && node.left == null)
            {
                result = true; 
            }
            else
            {
                result = (isSpecialBinaryTree(node.left) && isSpecialBinaryTree(node.right));
            }

            return result;
        }



        /***
         * Fine the length of the longest path which contains nodes witht the same exact value.
         * 
         * This path must not pass through the root node.
         * 
         */
        public int longestUnivaluePath(Node node)
        {
            int result = 0;

            if(node == null) return result;

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node next = queue.Dequeue();

                if(node.left != null)
                {
                    if(next.val == node.left.val) result ++;
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    if (next.val == node.right.val) result++;
                    queue.Enqueue(node.right);
                }
            }

            return result;
        }






        public int[] deleteMiddleStackItem(Stack<int> stack, int N)
        {
            int count = stack.Count;
            int[] arr = new int[N];
            int index = 0;

            if (count == 0) return null;

            if((N + 1) % 2 == 1) // odd number 
            {
                index = (N + 1) / 2;
            }
            else // even number
            {
                index = ((N + 1) / 2 - 1);
            }

            for (int i = 0; i < count; i++)
            {
                if(index != i)
                    arr[i] = stack.Pop();
            }

            return arr;
        }
    }



    


}
