using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworksLibrary
{
    public class ConnectionsList
    {
        private List<List<int>> _ConnectionMatrix;
        private Dictionary<Tuple<int, int>, double> _Weight;
        
        public List<List<int>> ConnectionMatrix
        {
            get { return _ConnectionMatrix; }
            set { _ConnectionMatrix = value; }
        }
        public Dictionary<Tuple<int, int>, double> Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
    

        public ConnectionsList()
        {
            //   OutputNodeID = new List<int>();
            //   InputNodeID = new List<int>();

            ConnectionMatrix = new List<List<int>>();
            Weight = new Dictionary<Tuple<int, int>, double>();
        }
        
        public ConnectionsList(int NumberOfNodes)
        {
            ConnectionMatrix = new List<List<int>>();
            Weight = new Dictionary<Tuple<int, int>, double>();

            for (int i = 0; i < NumberOfNodes; i++)
            {
                ConnectionMatrix.Add(new List<int>());
            }
        }

        public void AddConnection(int Output_Node_ID, int Input_Node_ID, double Connection_Weight)
        {
            if (ConnectionMatrix.Count <= Output_Node_ID)
            {
                for (int i = ConnectionMatrix.Count; i < Output_Node_ID + 1; i++)
                {
                    ConnectionMatrix.Add(new List<int>());
                }
            }

            ConnectionMatrix[Output_Node_ID].Add(Input_Node_ID);

            Weight.Add(Tuple.Create(Output_Node_ID, Input_Node_ID), Connection_Weight);
        }

        // returns a weight of connection between specified nodes
        public double ConnectionWeight (int Output_Node_ID, int Input_Node_ID)
        {
            return Weight[Tuple.Create(Output_Node_ID, Input_Node_ID)];
        }

        // Code = 1 & default - multyplication
        // Code = 2 - sum
        // Code = 3 - replacement
        public void ChangeConnectionWeight(int Output_Node_ID, int Input_Node_ID, double ChangeValue, int Code)
        {
            switch (Code)
            {
                case 3:
                    Weight[Tuple.Create(Output_Node_ID, Input_Node_ID)] = ChangeValue;
                    break;
                case 2:
                    Weight[Tuple.Create(Output_Node_ID, Input_Node_ID)] += ChangeValue;
                    break;
                case 1:
                default:
                    Weight[Tuple.Create(Output_Node_ID, Input_Node_ID)] *= ChangeValue;
                    break;
            }

        }
        
        // returns a double array of connections, with come out of node with ID = i
        public double[] this[int NodeID]
        {
            get
            {
                double[] Output = new double[ConnectionMatrix[NodeID].Count];

                for (int j = 0; j < ConnectionMatrix[NodeID].Count; j++)
                {
                    Output[j] = Weight[Tuple.Create(NodeID, ConnectionMatrix[NodeID][j])];
                }

                return Output;
            }
        }

        public double[] ConnectedTo (int NodeID)
        {
            List<double> Output = new List<double>();

            for (int OutpuConnectionNodeID = 0; OutpuConnectionNodeID < ConnectionMatrix.Count; OutpuConnectionNodeID++)
            {
                if (ConnectionMatrix[OutpuConnectionNodeID].Contains(NodeID))
                {
                    Output.Add(ConnectionWeight(OutpuConnectionNodeID, NodeID));
                }
            }

            return Output.ToArray();
        }
    }
}
