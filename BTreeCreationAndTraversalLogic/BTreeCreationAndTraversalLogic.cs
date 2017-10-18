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

        public GateNodeTree()
        {
            _bTreeGateNodes = new List<GateNode>();
        }

       public void CreateGateNodeTree(int Depth)
       {
           int totalNodesToCreate = (int) Math.Pow(2, Depth);
           for (int nodeIndex = 1; nodeIndex <= totalNodesToCreate; nodeIndex++)
           {
               CreateGateNode(nodeIndex);
           }
       }

        void CreateGateNode(int NodeId)
        {
            GateNode gateNodeObj = new GateNode();
            gateNodeObj.NodeId = NodeId;
            Random r = new Random();
            gateNodeObj.NodeStatus =(byte) r.Next(1, 2);

            gateNodeObj.ParentGateNodeId = Convert.ToInt32(NodeId / 2.0);
            
            //Adding binary children of the GateNode
            gateNodeObj.AddChild(NodeId * 2);
            gateNodeObj.AddChild((NodeId * 2) + 1);

            _bTreeGateNodes.Add(gateNodeObj);
        }


    }
}
