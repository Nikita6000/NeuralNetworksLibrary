using System;

namespace NeuralNetworksLibrary
{
    public static class Utilities
    {
        public static double Sigmoid(double value)
        {
            double k = Math.Exp(value);
            return k / (1.0 + k);
        }
    }
}
