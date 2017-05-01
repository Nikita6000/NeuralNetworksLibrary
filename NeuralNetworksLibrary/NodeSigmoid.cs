using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworksLibrary
{
    class NodeSigmoid : NodeCore<double>
    {
        private double _CalculatedData;
        private double _Derivative;

        public double CalculatedData
        {
            get { return _CalculatedData; }
            set { _CalculatedData = value; }
        }
        public double Derivative
        {
            get { return _Derivative; }
            set { _Derivative = value; }
        }


        public override double Calculate()
        {
            double output = 0;

            foreach (double data in IncomingData)
            {
                output += data;
            }

            CalculatedData = Utilities.Sigmoid(output);
            Derivative = CalculatedData * (1.0 - CalculatedData);

            return CalculatedData;
        }
    }
}
