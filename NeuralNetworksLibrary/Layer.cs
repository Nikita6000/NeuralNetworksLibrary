using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworksLibrary
{
    // for organizing nodes
    class Layer<NodeType>
        where NodeType : NodeCore<double, NodeType>, new()
    {
        private List<NodeType> _Nodes;

        public List<NodeType> Nodes
        {
            get { return _Nodes; }
            set { _Nodes = value; }
        }


        public Layer()
        {
            Nodes = new List<NodeType>();
        }

        public Layer(int NumberOfNodes)
        {
            Nodes = new List<NodeType>();

            for (int i = 0; i < NumberOfNodes; i++)
            {
                Nodes.Add(new NodeType());
            }
        }

        public void ConnectLayer(Layer<NodeType> NextLayer, Random rand)
        {
            foreach (NodeType NodeInThisLayer in this.Nodes)
            {
                foreach (NodeType NodeInNextLayer in NextLayer.Nodes)
                {
                    NodeInThisLayer.ConnectToNode(NodeInNextLayer, rand.NextDouble() * 2.0 - 1.0);
                }
            }
        }
        
        public void Calculate()
        {
            foreach (NodeType Node in Nodes)
            {
                Node.Calculate();
            }
        }
    }
}
