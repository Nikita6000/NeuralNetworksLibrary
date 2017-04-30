using System;
using System.Collections.Generic;

namespace NeuralNetworksLibrary
{
    // Parent class for every node class
    public class NodeCore<DataType>
    where DataType : IComparable, new()
    {
        private static int ID;

        private int _NodeID;
        private List<int> _ConnectedTo = new List<int>();
        private List<DataType> _IncomingData = new List<DataType>();

        public int NodeID
        {
            get { return _NodeID; }
            set { _NodeID = value; }
        }

        // List of Nodes ID, this node is connected to
        public List<int> ConnectedTo
        {
            get { return _ConnectedTo; }
            set { _ConnectedTo = value; }
        }

        // Data for this node to process
        public List<DataType> IncomingData
        {
            get { return _IncomingData; }
            set { _IncomingData = value; }
        }

        public void AddConnection(int NodeIDToConnect)
        {
            if (NodeIDToConnect < ID)
            {
                _ConnectedTo.Add(NodeIDToConnect);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        // Method to send data to THIS node for processing
        public void SendData(DataType data)
        {
            _IncomingData.Add(data);
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

        // In here node do something with incoming data
        public virtual DataType Calculate()
        {
            return new DataType();
        }

        private int GetNewID()
        {
            return ID++;
        }
    }
}
