using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace GateNodeTreeCreationAndTraversal
{

    public enum NodeFlowDirection
    {
        Left = 1,
        Right = 2
    }
    //public class GateNode
    //{
        
    //    private int _gateNodeId;
    //    private int _parentGateNodeId;
    //    private IList<int> _childrenGateNodeIds;
    //    private bool _isNodeVisited;
    //    private byte _nodeStatus;
    //    private int _nodeId;
    //    private int _containerId;

    //    public IEnumerable<int> ChildrenGateNodes
    //    {
    //        get { return _childrenGateNodeIds; }

    //    }
    //    public GateNode()
    //    {
    //        _isNodeVisited = false;
    //        _childrenGateNodeIds = new List<int>();
    //    }
    //    public void AddChild(int child)
    //    {
            
    //            _childrenGateNodeIds.Add(child);
            
    //    }

    //    public Boolean IsNodeVisited
    //    {
    //        get { return _isNodeVisited; }
    //        set { _isNodeVisited = value; }
    //    }
    //    public int GateNodeId
    //    {
    //        get { return _gateNodeId; }
    //        set { _gateNodeId = value; }
    //    }
    //    public int ParentGateNodeId
    //    {
    //        get { return _parentGateNodeId; }
    //        set { _parentGateNodeId = value; }
    //    }

    //    public byte NodeStatus
    //    {
    //        get { return _nodeStatus; }
    //        set { _nodeStatus = value; }
    //    }

    //    public int NodeId
    //    {
    //        get { return _nodeId; }
    //        set { _nodeId = value; }
    //    }

    //    public int containerId
    //    {
    //        get { return _containerId; }
    //        set { _containerId = value; }
    //    }

    //}

   
}