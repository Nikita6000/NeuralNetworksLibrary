using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworksLibrary
{
    class FFNNLayer : Layer<NodeSigmoid>
    {
        public void Backpropagation()
        {
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                Nodes[i].Backpropagation();
            }
        }

        public FFNNLayer()
        {

        }

        public FFNNLayer(int NumberOfNodes)
        {
            Nodes = new List<NodeSigmoid>();

            for (int i = 0; i < NumberOfNodes; i++)
            {
                Nodes.Add(new NodeSigmoid());
            }
        }

        public void InputData(double[] inputData)
        {
            for (int i = 0; i < inputData.Length && i < Nodes.Count; i++)
            {
                Nodes[i].IncomingData.Add(inputData[i]);
            }

            if (inputData.Length != Nodes.Count)
            {
                // throw some non crytical exception
            }
        }

        public void CalculateError (double[] ExpectedOutput)
        {
            double Error = 0;

            for (int i = 0; i < ExpectedOutput.Length && i < Nodes.Count; i++)
            {
                Error += System.Math.Abs(ExpectedOutput[i] - Nodes[i].NodeValue);
            }

            foreach (NodeSigmoid Node in Nodes)
            {
                Node.Derivative *= Error;
            }

            if (ExpectedOutput.Length != Nodes.Count)
            {
                // throw some non crytical exception
            }
        }
    }
}
