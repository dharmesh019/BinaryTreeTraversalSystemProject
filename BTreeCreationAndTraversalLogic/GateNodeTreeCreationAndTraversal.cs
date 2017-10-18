using BTreeCreationAndTraversal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GateNodeTreeCreationAndTraversal
{
   

    public class GateNodeTree : IGateNodeTree
    {
        #region private properties and methods
        private const int Two = 2;
        private const int RootNodeId = 1;
        private IList<GateNode> _bTreeGateNodes;
        private int _totalNodesToCreate;
        private void GetTotalNodesToCreate(int depth)
        {
            _totalNodesToCreate = 1;
            for (int i = 1; i <= depth; i++)
            {
                _totalNodesToCreate += (int)Math.Pow(Two, i);
            }
        }
        //Create one gate node
        private void CreateGateNode(int nodeId, Random r, int containerId)
        {
            GateNode gateNodeObj = new GateNode();
            gateNodeObj.NodeId = nodeId;
            //generate Random NodeStatus number 1 or 2 (Left or Right)
            gateNodeObj.NodeStatus = Convert.ToByte((r.Next(1, 400) % Two) + 1);
            gateNodeObj.ParentGateNodeId = Convert.ToInt32(nodeId / Two);
            gateNodeObj.containerId = containerId;
            //Adding binary children of the GateNode
            if (nodeId * Two <= _totalNodesToCreate)
            {
                gateNodeObj.AddChild(nodeId * Two);
                gateNodeObj.AddChild((nodeId * Two) + 1);
            }
            _bTreeGateNodes.Add(gateNodeObj);
        }
        //Tree Traversal for 1 ball from the root node 
        private void TreeTraversal(int currentNodeId)
        {
            //Traverse only up to total no of nodes to avoid error
            if (currentNodeId <= _totalNodesToCreate)
            {
                var currentNode = _bTreeGateNodes.First(n => n.NodeId == currentNodeId);
                //update the node's visisted status to true
                currentNode.IsNodeVisited = true;
                var nodeFlowDirectionValue = (NodeFlowDirection)currentNode.NodeStatus;
                //update the node flow direction
                currentNode.NodeStatus = (NodeFlowDirection)currentNode.NodeStatus == NodeFlowDirection.Left
                    ? (byte)NodeFlowDirection.Right
                    : (byte)NodeFlowDirection.Left;

                //Recursive function call to get to the end of the binary tree
                if (nodeFlowDirectionValue == NodeFlowDirection.Left)
                    TreeTraversal(currentNode.NodeId * Two);
                else
                    TreeTraversal((currentNode.NodeId * Two) + 1);

            }

        }
        #endregion

        public GateNodeTree()
        {
            _bTreeGateNodes = new List<GateNode>();
            
        }

        public void InitializeGateNodeTree(int depth)
       {
           Random r = new Random();
           int containerId = 0;
           //Get Total nodes to create  
           GetTotalNodesToCreate(depth);
            //Create All nodes
           for (int nodeIndex = 1; nodeIndex <= _totalNodesToCreate; nodeIndex++)
           {
               if ((int) Math.Pow(2, depth) <= nodeIndex)
               {
                   containerId++;
                    CreateGateNode(nodeIndex, r, containerId);
           }
               else
                   CreateGateNode(nodeIndex, r, containerId);
           }
       }
     
        //Traverse through binary tree for passsed number of balls and return empty containers at the end
        public IEnumerable<GateNode> GateNodeTreeTraversalForAllBallsToFindEmptyContainer(int noOfBalls)
        {
            for (int ballIndex = 0; ballIndex < noOfBalls; ballIndex++)
            {
                TreeTraversal(RootNodeId);
            }
            return _bTreeGateNodes.Where(x => x.IsNodeVisited == false && x.containerId > 0).ToList();
        }
    }
}
