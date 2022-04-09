using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BianryTree tree = new BianryTree();
            LinkedList list = new LinkedList();

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

            list.insertNode(1);
            list.insertNode(2);
            list.insertNode(3);

            list.PrintNode();

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
        public int data;
        public Node left;
        public Node right;
        public Node next;

        public Node(int data)
        {
            this.data = data;
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
            if (data < node.data)
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
                        if (node.data < root.data)
                        {
                            succes = root;
                            root = root.left;
                        }
                        else if (node.data > root.data)
                            root = root.right;
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Successor : " + succes?.data);
                }
                
            }
        }


        public int getMostLeft(Node node)
        {
            if(node.left == null)
            {
                return node.data;
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

            Console.WriteLine("\nFound data : " + val.data);
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
            Console.Write(nodes.data + " -> ");

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

            values.Add(nodes.data);

            if (nodes.right != null)
            {
                InOrder(nodes.right);
            }

            return values;
        }


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

            Console.Write(nodes.data + " -> ");
        }



        // find the node of a particular value
        private Node Finds(int data, Node node)
        {
            if(data == node.data)
            {
                return node;
            }
            else
            {
                if (data < node.data && node.left != null)
                {
                    return Finds(data, node.left);
                }
                else if(data >= node.data && node.right != null)
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
                Node current = QueueNodes.Peek();

                Console.Write(current.data + " -> ");

                if (current.left != null)
                {
                    QueueNodes.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    QueueNodes.Enqueue(current.right);
                }

                if (QueueNodes.Count > 0)
                {
                    var remove = QueueNodes.Dequeue();
                }
            }
        }


        private List<int> SortedList(List<int> data)
        {
            data.Sort();
            var sorts = new SortedList<int, int>();

            for(int i =0; i < data.Count(); i++)
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

            if (inOrderList.SequenceEqual(orderList))
            {
                return true;
            }
            else
            {
                return false;
            }
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
    }



    public class LinkedList
    {
        Node head = null;

        public void insertNode(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }


        public void PrintNode()
        {
            Node current = head;

            while(current != null)
            {
                Console.WriteLine(current.data + "->");
                current = current.next;
            } 

        }
    }


}
