using System;
using System.Collections.Generic;
using System.Linq;   

namespace NeuralNetworksLibrary
{
    class FFNN : NeuralNetworkCore
    {
        private ConnectionsList _Connections;
        private List<List<NodeSigmoid>> _Nodes;

        public ConnectionsList Connections
        {
            get { return _Connections; }
            set { _Connections = value; }
        }
        public List<List<NodeSigmoid>> Nodes
        {
            get { return _Nodes; }
            set { _Nodes = value; }
        }

        private static Random rand;

        static FFNN()
        {
            rand = new Random();
        }

        public FFNN()
        {
            Connections = new ConnectionsList();
            Nodes = new List<List<NodeSigmoid>>();
        }

        public FFNN(List<int> NodesInHiddenLayers)
        {
            Connections = new ConnectionsList(NodesInHiddenLayers.Sum());
            Nodes = new List<List<NodeSigmoid>>();


            for (int i = 0; i < NodesInHiddenLayers.Count; i++)
            {
                Nodes.Add(new List<NodeSigmoid>());

                for (int j = 0; j < NodesInHiddenLayers[i]; j++)
                {
                    Nodes[i].Add(new NodeSigmoid());
                }
            }

            for (int i = 0; i < NodesInHiddenLayers.Count - 1; i++)
            {
                for (int j = 0; j < NodesInHiddenLayers[i]; j++)
                {
                    for (int k = 0; k < NodesInHiddenLayers[i+1]; k++)
                    {
                        Connections.AddConnection(Nodes[i][j].NodeID, Nodes[i+1][k].NodeID, rand.NextDouble());
                    }
                }
            }

            for (int i = 0; i < NodesInHiddenLayers.Last(); i++)
            {
                Connections.AddConnection(Nodes[NodesInHiddenLayers.Count - 1][i].NodeID, -1, rand.NextDouble());
            }
        }

        public double Calculate (double[] InputData)
        {
            double output = 0;

            if(InputData.Length != Nodes[0].Count)
            {
                throw new IndexOutOfRangeException();
            }

            // Add input in the first layer
            for (int i = 0; i < InputData.Length; i++)
            {
                Nodes[0][i].IncomingData.Add(InputData[i]);
            }

            // Go through every hidden layer
            for (int layer = 0; layer < Nodes.Count - 1; layer++)
            {
                for (int j = 0; j < Nodes[layer].Count; j++)
                {
                    double NodeValue = Nodes[layer][j].Calculate();

                    for (int k = 0; k < Connections[Nodes[layer][j].NodeID].Length; k++)
                    {
                        Nodes[layer + 1][k].IncomingData.Add(NodeValue);
                    }

                }
            }

            // sum data from last layer in the output
            for (int i = 0; i < Nodes.Last().Count; i++)
            {
                output += Nodes[Nodes.Count - 1][i].Calculate() * Connections[Nodes[Nodes.Count - 1][i].NodeID][i];
            }

            return output;
        }
        
        public void ConnectionAdjustmets (double Output, double DesiredOutput)
        {
            // This is probably not correct
            for (int i = 0; i < Nodes.Last().Count; i++)
            {
                Nodes.Last()[i].Derivative *= Connections.ConnectionWeight(Nodes.Last()[i].NodeID, -1);

                Connections.ChangeConnectionWeight(Nodes.Last()[i].NodeID, -1, Nodes.Last()[i].CalculatedData * (DesiredOutput - Output), 2);
            }
            
            // Go through every hidden layer
            for (int layer = Nodes.Count - 1; layer > 0; layer--)
            {
                for (int j = 0; j < Nodes[layer].Count; j++)
                {
                    for (int k = 0; k < Nodes[layer - 1].Count; k++)
                    {
                        double Multiplier = Nodes[layer][j].Derivative * Nodes[layer - 1][k].CalculatedData;

                        Multiplier *= (DesiredOutput - Output);

                        // This is probably not correct
                        Nodes[layer - 1][k].Derivative += Connections.ConnectionWeight(Nodes[layer - 1][k].NodeID, Nodes[layer][j].NodeID)* Nodes[layer][j].Derivative;

                        Connections.ChangeConnectionWeight(Nodes[layer - 1][k].NodeID, Nodes[layer][j].NodeID, Multiplier, 2);
                    }
                }
            }
        }
    }
}
