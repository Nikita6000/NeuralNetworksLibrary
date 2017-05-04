using System;
using System.Collections.Generic;

namespace NeuralNetworksLibrary
{
    // Parent class for every node class
    public abstract class NodeCore<DataType, NodeType>
    where DataType : IComparable, new()
        where NodeType : NodeCore<DataType, NodeType>
    {
        private static int ID;

        private int _NodeID;
        private List<DataType> _IncomingData = new List<DataType>();    // Data for this node to process
        private DataType _NodeValue;

        public int NodeID
        {
            get { return _NodeID; }
            set { _NodeID = value; }
        }

        public List<DataType> IncomingData
        {
            get { return _IncomingData; }
            set { _IncomingData = value; }
        }

        public DataType NodeValue
        {
            get { return _NodeValue; }
            set { _NodeValue = value; }
        }
        
      
        // Method to send data to THIS node for processing
        public void SendData(DataType data)
        {
            IncomingData.Add(data);
        }

        // Method for clearing incoming data list
        public void ClearIncomingData()
        {
            IncomingData.Clear();
        }

        // Static constructor to initialize static ID
        static NodeCore()
        {
            ID = 0;
        }

        // Constructor, wich sets ID for this Node
        public NodeCore()
        {
            NodeID = GetNewID();
        }
        
        private int GetNewID()
        {
            return ID++;
        }

        // Method for node to do some internal calculations
        public abstract void Calculate();
        public abstract void ConnectToNode(NodeType NodeToConnect);
        public abstract void ConnectToNode(NodeType NodeToConnect, DataType ConnectionWeight);
    }
}
