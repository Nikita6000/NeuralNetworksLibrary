using System;
using System.Collections.Generic;

namespace NeuralNetworksLibrary
{
    // Parent class for a range of neural network
    public class NeuralNetworkCore
    {
        private static int ID;

       // protected List<NodeCore<DataType>> _Nodes = new List<NodeCore<DataType>>();
        protected int _NetworkID;

      /*  public List<NodeCore<DataType>> Nodes
        {
            get { return _Nodes; }
            set { _Nodes = value; }
        }
        */
        public int NetworkID
        {
            get { return _NetworkID; }
            set { _NetworkID = value; }
        }

        // static constructor, sets ID counter for all inherited networks
        static NeuralNetworkCore()
        {
            ID = 0;
        }

        // public constructor, sets ID for this network
        public NeuralNetworkCore()
        {
            _NetworkID = GetNewID();
        }

        // Add new empty node to network
    /*    protected virtual void AddNode()
        {
            _Nodes.Add(new NodeCore<DataType>());
        }

        // Add node to network
        protected virtual void AddNode(NodeCore<DataType> NewNode)
        {
            _Nodes.Add(NewNode);
        }
    */
        private int GetNewID()
        {
            return ID++;
        }
    }
}
