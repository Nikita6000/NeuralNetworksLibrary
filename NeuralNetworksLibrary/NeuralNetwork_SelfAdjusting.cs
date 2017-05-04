//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace NeuralNetworksLibrary
//{

//    // Network which is adjusting its coefficients according to input AND output
//    public class NeuralNetwork_SelfAdjusting<NodeType, DataType> : NeuralNetworkCore
//        where NodeType : NodeCore<DataType>, new()
//        where DataType : IComparable, new()
//    {
//        static Random rand;

//        // Static constructor
//        static NeuralNetwork_SelfAdjusting()
//        {
//            rand = new Random();
//        }

//        public NeuralNetwork_SelfAdjusting() { }

//        /*       // Override parent methods to use specialized nodes
//               protected override void AddNode()
//               {
//                   _Nodes.Add(new NodeType());
//               }
//               public void AddNode(NodeType NewNode)
//               {
//                   _Nodes.Add(NewNode);
//               }

//               // public constructor 
//               // ConnectionType:
//               // 0 - all connections random
//               // 1 - one forward connection 
//               // 2 - two forward connections
//               //
//               public NeuralNetwork_SelfAdjusting(List<int> NodesInLayer, int ConnectionsType, int AverageNumberOfConnectionsIfRandom = 2)
//               {
//                   // Create empty nodes
//                   for (int layer = 0; layer < NodesInLayer.Count; layer++)
//                       for (int i = 0; i < NodesInLayer[layer]; i++)
//                           AddNode();

//                   int NodesInPreviousLayers = 0;

//                   // Creating connections between nodes
//                   for (int layer = 0; layer < NodesInLayer.Count - 1; layer++)
//                   {
//                       for (int i = NodesInPreviousLayers; i < NodesInPreviousLayers + NodesInLayer[layer]; i++)
//                       {
//                           switch (ConnectionsType)
//                           {
//                               // One forward connection from each node
//                               case 1:
//                                   _Nodes[i].AddConnection(NodesInPreviousLayers + NodesInLayer[layer] + (int)(((double)(i - NodesInPreviousLayers) / NodesInLayer[layer]) * NodesInLayer[layer + 1]));
//                                   break;

//                               // Two forward connections from each node
//                               case 2:
//                                   _Nodes[i].AddConnection(NodesInPreviousLayers + NodesInLayer[layer] + (int)(((double)(i - NodesInPreviousLayers) / NodesInLayer[layer]) * NodesInLayer[layer + 1]));

//                                   // Second connection connecting with node to the left of previous one, if we in the "right" part of network, and to the right otherwise
//                                   if ((i - NodesInPreviousLayers) > NodesInLayer[layer] / 2)
//                                       _Nodes[i].AddConnection(NodesInPreviousLayers + NodesInLayer[layer] + (int)(((double)(i - NodesInPreviousLayers) / NodesInLayer[layer]) * NodesInLayer[layer + 1] - 1));
//                                   else
//                                       _Nodes[i].AddConnection(NodesInPreviousLayers + NodesInLayer[layer] + (int)(((double)(i - NodesInPreviousLayers) / NodesInLayer[layer]) * NodesInLayer[layer + 1] + 1));
//                                   break;

//                               // Random connections, on average we get [AverageNumberOfConnectionsIfRandom] connections from each node
//                               case 0:
//                               default:
//                                   // Cycle through the next layer
//                                   for (int j = NodesInPreviousLayers + NodesInLayer[layer]; j < NodesInPreviousLayers + NodesInLayer[layer] + NodesInLayer[layer + 1]; j++)
//                                   {

//                                       if (rand.Next(NodesInLayer[layer + 1]) < AverageNumberOfConnectionsIfRandom)
//                                       {
//                                           _Nodes[i].AddConnection(j);
//                                       }
//                                   }
//                                   break;
//                           }
//                       }

//                       NodesInPreviousLayers += NodesInLayer[layer];
//                   }
//               }

//               // Run calculation
//               public void RunNetwork()
//               {
//                   foreach (NodeType Node in _Nodes)
//                   {
//                       DataType data = Node.Calculate();

//                       foreach (int NodeID in Node.ConnectedTo)
//                       {
//                           _Nodes[NodeID].SendData(data);
//                       }
//                   }
//               }
//               */
//    }

//}
