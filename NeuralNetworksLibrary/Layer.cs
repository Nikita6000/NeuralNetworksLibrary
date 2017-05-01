using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworksLibrary
{
    // for organizing nodes
    class Layer<NodeType, DataType>
        where NodeType : NodeCore<DataType>
        where DataType : IComparable, new()
    {

    }
}
