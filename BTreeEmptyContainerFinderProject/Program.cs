using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTreeCreationAndTraversal.Interfaces;
using FactoryOfBusinessObjects;

namespace BTreeEmptyContainerFinderProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Binary Tree Traversal System");
            // Console.ReadLine();
           var bTreeCreationAndTraversalLogicObj= FactoryOfObjects<IGateNodeTree>.Create();

               //  GateNodeTree bTreeCreationAndTraversalLogicObj = new GateNodeTree();
            Console.WriteLine("Please enter depth of the binary tree:");
            try
            {
                var depthOfBinaryTree = Convert.ToInt32(Console.ReadLine());
                //Initialization of Binary Tree of GateNodes
                bTreeCreationAndTraversalLogicObj.InitializeGateNodeTree(depthOfBinaryTree);
                Console.WriteLine("No of balls to pass into binary tree:");
                var noOfBallsToPassIntoBinaryTree = Convert.ToInt32(Console.ReadLine());
                //Traversal Of GateNodes Branches with No oF balls
                var EmptyContainers = bTreeCreationAndTraversalLogicObj.GateNodeTreeTraversalForAllBallsToFindEmptyContainer(noOfBallsToPassIntoBinaryTree);
                Console.WriteLine("Empty Containers(starting first container from left):");
                foreach (var emptyContainer in EmptyContainers)
                {

                    Console.WriteLine( "Node ID : {0}, Container ID {1}",emptyContainer.NodeId, emptyContainer.containerId);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           

        }
    }
}
