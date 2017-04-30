using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworksLibrary
{
    public class ConnectionsList<WeightType>
        where WeightType : IComparable, new()
    {
        private List<List<int>> _ConnectionMatrix;
        private Dictionary<Tuple<int, int>, WeightType> _Weight;
        
        public List<List<int>> ConnectionMatrix
        {
            get { return _ConnectionMatrix; }
            set { _ConnectionMatrix = value; }
        }
        public Dictionary<Tuple<int, int>, WeightType> Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
    

        public ConnectionsList()
        {
            //   OutputNodeID = new List<int>();
            //   InputNodeID = new List<int>();

            ConnectionMatrix = new List<List<int>>();
            Weight = new Dictionary<Tuple<int, int>, WeightType>();
        }
        
        public ConnectionsList(int NumberOfNodes)
        {
            ConnectionMatrix = new List<List<int>>();
            Weight = new Dictionary<Tuple<int, int>, WeightType>();

            for (int i = 0; i < NumberOfNodes; i++)
            {
                ConnectionMatrix.Add(new List<int>());
            }
        }

        public void AddConnection(int Output_Node_ID, int Input_Node_ID, WeightType Connection_Weight)
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
        public WeightType ConnectionWeight (int Output_Node_ID, int Input_Node_ID)
        {
            return Weight[Tuple.Create(Output_Node_ID, Input_Node_ID)];
        }

        // returns a WeightType array of connections, with come out of node with ID = i
        public WeightType[] this[int i]
        {
            get
            {
                WeightType[] Output = new WeightType[ConnectionMatrix[i].Count];

                for (int j = 0; j < ConnectionMatrix[i].Count; j++)
                {
                    Output[j] = Weight[Tuple.Create(i, ConnectionMatrix[i][j])];
                }

                return Output;
            }
        }
    }
}
