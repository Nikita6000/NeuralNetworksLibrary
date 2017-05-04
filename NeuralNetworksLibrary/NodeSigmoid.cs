using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetworksLibrary
{
    public class NodeSigmoid : NodeCore<double, NodeSigmoid>
    {
        private static double ConnectionChanhingStep;
        private double _Derivative;
        private List<Connection<NodeSigmoid>> _ConnectionsForward;
        private List<Connection<NodeSigmoid>> _ConnectionsBackward;
        
        public double Derivative
        {
            get { return _Derivative; }
            set { _Derivative = value; }
        }
        public List<Connection<NodeSigmoid>> ConnectionsForward
        {
            get { return _ConnectionsForward; }
            set { _ConnectionsForward = value; }
        }
        public List<Connection<NodeSigmoid>> ConnectionsBackward
        {
            get { return _ConnectionsBackward; }
            set { _ConnectionsBackward = value; }
        }

        public NodeSigmoid()
        {
            ConnectionsForward = new List<Connection<NodeSigmoid>>();
            ConnectionsBackward = new List<Connection<NodeSigmoid>>();
        }

        static NodeSigmoid()
        {
            ConnectionChanhingStep = 0.1;
        }

        public override void ConnectToNode(NodeSigmoid NodeToConnect)
        {
            ConnectionsForward.Add(new Connection<NodeSigmoid>(NodeToConnect));
            NodeToConnect.ConnectionsBackward.Add(new Connection<NodeSigmoid>(this));

            // do this because we need to have easy access to a opposite connection while backpropogating
            ConnectionsForward.Last().OppositeConnection = NodeToConnect.ConnectionsBackward.Last();
            NodeToConnect.ConnectionsBackward.Last().OppositeConnection = ConnectionsForward.Last();
        }

        public override void ConnectToNode(NodeSigmoid NodeToConnect, double ConnectionWeight)
        {
            ConnectionsForward.Add(new Connection<NodeSigmoid>(NodeToConnect, ConnectionWeight));
            NodeToConnect.ConnectionsBackward.Add(new Connection<NodeSigmoid>(this, ConnectionWeight));

            // do this because we need to have easy access to a opposite connection while backpropogating
            ConnectionsForward.Last().OppositeConnection = NodeToConnect.ConnectionsBackward.Last();
            NodeToConnect.ConnectionsBackward.Last().OppositeConnection = ConnectionsForward.Last();
        }

        public void Backpropagation()
        {
            double Output = 0, ConnectionChange = 0;

            foreach (double data in IncomingData)
            {
                Output += data;
            }
                
            Derivative *= Output;

            foreach (Connection<NodeSigmoid> Connection in ConnectionsBackward)
            {
                Connection.TargetNode.IncomingData.Add(Derivative * Connection.ConnectionWeight);

                ConnectionChange = System.Math.Abs(Connection.ConnectionWeight) * ConnectionChanhingStep * (2.0 * Utilities.Sigmoid(Derivative * Connection.TargetNode.NodeValue) - 1.0);

                // Its actualy possible to not change this weight, changing it just for easier ConnectionChange  
                Connection.ConnectionWeight -= ConnectionChange;

                // This is an actual forward connection
                Connection.OppositeConnection.ConnectionWeight = Connection.ConnectionWeight;
            }
            
            ClearIncomingData();
        }

        public override void Calculate()
        {
            double output = 0;

            foreach (double data in IncomingData)
            {
                output += data;
            }

            NodeValue = Utilities.Sigmoid(output);

            Derivative = 2.0 * NodeValue * (1.0 - NodeValue);

            // Do this so nodevalue can be [-1, 1]
            NodeValue = NodeValue * 2.0 - 1.0;

            foreach (Connection<NodeSigmoid> Connection in ConnectionsForward)
            {
                Connection.TargetNode.IncomingData.Add(NodeValue * Connection.ConnectionWeight);
            }

            ClearIncomingData();
        }
    }
}
