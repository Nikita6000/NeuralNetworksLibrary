using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworksLibrary
{
    // Node which can only multyply incoming data by changing coefficient
    public class Node_Linear : NodeCore<double>
    {
        protected double _Coefficient;

        // constructor
        public Node_Linear()
        {
            _Coefficient = 1.0;
        }

        public Node_Linear(double Coefficient)
        {
            _Coefficient = Coefficient;
        }

        public override double Calculate()
        {
            double NodeValue = 0;

            foreach (double signal in IncomingData)
            {
                NodeValue += _Coefficient * signal;
            }

            return NodeValue;
        }
    }
}
