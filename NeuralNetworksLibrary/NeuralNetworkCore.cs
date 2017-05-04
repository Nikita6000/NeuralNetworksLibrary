using System;
using System.Collections.Generic;

namespace NeuralNetworksLibrary
{
    // Parent class for a range of neural network
    public abstract class NeuralNetworkCore
    {
        private static int ID;

       protected int _NetworkID;
        
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
        
        private int GetNewID()
        {
            return ID++;
        }

        public abstract void Run();
    }
}
