using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeCreationAndTraversalLogic
{
    public class GateNodeTree
    {
        private IList<GateNode> _bTreeGateNodes;
        private int _totalNodesToCreate;
        public GateNodeTree()
        {
            _bTreeGateNodes = new List<GateNode>();
            
        }

       public void CreateGateNodeTree(int depth)
       {
           _totalNodesToCreate = (int) Math.Pow(2, depth);
           for (int nodeIndex = 1; nodeIndex <= _totalNodesToCreate; nodeIndex++)
           {
               CreateGateNode(nodeIndex);
           }
       }

        void CreateGateNode(int nodeId)
        {
            GateNode gateNodeObj = new GateNode();
            gateNodeObj.NodeId = nodeId;
            Random r = new Random();
            gateNodeObj.NodeStatus =(byte) r.Next(1, 2);

            gateNodeObj.ParentGateNodeId = Convert.ToInt32(nodeId / 2.0);
            
            //Adding binary children of the GateNode
            gateNodeObj.AddChild(nodeId * 2);
            gateNodeObj.AddChild((nodeId * 2) + 1);

            _bTreeGateNodes.Add(gateNodeObj);
        }

       public IEnumerable<GateNode> TreeTraversalToFindEmptyContainer(int currentNodeId)
       {
           if (currentNodeId <= _totalNodesToCreate)
           {
               var currentNode = _bTreeGateNodes.First(n => n.NodeId == currentNodeId);
               currentNode.IsNodeVisited = true;
               var nodeFlowDirectionValue = (NodeFlowDirection) currentNode.NodeStatus;
               currentNode.NodeStatus = (NodeFlowDirection) currentNode.NodeStatus == NodeFlowDirection.Left
                   ? (byte) NodeFlowDirection.Right
                   : (byte) NodeFlowDirection.Left;

               if (nodeFlowDirectionValue == NodeFlowDirection.Left)
                   TreeTraversalToFindEmptyContainer(currentNode.NodeId * 2);
               else
                   TreeTraversalToFindEmptyContainer((currentNode.NodeId * 2) + 1);
               return new List<GateNode>();
           }
           else
           {
               return _bTreeGateNodes.Where(x => x.IsNodeVisited == false &&  !x.ChildrenGateNodes.Any()).ToList();
           }
       }
    }
}
