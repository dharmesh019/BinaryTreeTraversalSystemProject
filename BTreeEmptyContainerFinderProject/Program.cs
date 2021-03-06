﻿using System;
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
           
            bool trycount=true;
            while (trycount)
            {
                try
                {
                   var bTreeCreationAndTraversalLogicObj = FactoryOfObjects<IGateNodeTree>.Create();

                    Console.WriteLine("Welcome to Binary Tree Traversal System");
                    Console.WriteLine("Please enter depth of the binary tree ( Less than or equal to 10):");
                    var depthOfBinaryTree = Convert.ToInt32(Console.ReadLine());
                    if (depthOfBinaryTree > 10)
                        continue;



                    //Initialization of Binary Tree of GateNodes
                    bTreeCreationAndTraversalLogicObj.InitializeGateNodeTree(depthOfBinaryTree);

                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Initial state of binary tree including gate direction for each node.");
                    //displaying the initial stage of the binary tree
                    var allnodes= bTreeCreationAndTraversalLogicObj.GateAllNodes();
                    foreach(var node in allnodes)
                    {
                        Console.WriteLine("Node ID : {0} , Gate Direction: {1} , Container ID: {2} ", node.NodeId, node.NodeStatus == 1 ? "Left" : "Right", node.containerId > 0 ? node.containerId.ToString(): "");
                    }
                    Console.WriteLine("In above, Containers are the leaf nodes of the binary tree where balls will be stored!");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine("No of balls to pass into binary tree:");
                    var noOfBallsToPassIntoBinaryTree = Convert.ToInt32(Console.ReadLine());
                    //Traversal Of GateNodes Branches with No oF balls
                    var emptyContainers = bTreeCreationAndTraversalLogicObj.GateNodeTreeTraversalForAllBallsToFindEmptyContainer(noOfBallsToPassIntoBinaryTree);

                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Total Empty Containers:{0}", emptyContainers.Count());
                    Console.WriteLine("Empty Containers( starting first container from left.):");
                    foreach (var emptyContainer in emptyContainers)
                    {

                        Console.WriteLine("Node ID : {0}, Container ID {1}", emptyContainer.NodeId, emptyContainer.containerId);
                    }
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Press 0 to exit or any other key to continue.");
                    var res= Console.ReadLine();
                    if (res == "0") trycount = false;
                   
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                    trycount = true;
                    continue;
                }

            }
           

        }
    }
}
