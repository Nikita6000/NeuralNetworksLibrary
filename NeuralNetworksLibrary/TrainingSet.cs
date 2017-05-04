using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworksLibrary
{
    public class TrainingSet<DataType>
        where DataType : IComparable, new()
    {
        private List<DataType[]> _InputData;
        private List<DataType[]> _DesiredOutput;

        public List<DataType[]> InputData
        {
            get { return _InputData; }
            set { _InputData = value; }
        }
        public List<DataType[]> DesiredOutput
        {
            get { return _DesiredOutput; }
            set { _DesiredOutput = value; }
        }

        public TrainingSet()
        {
            InputData = new List<DataType[]>();
            DesiredOutput = new List<DataType[]>();
        }

        public TrainingSet(List<DataType[]> inputData, List<DataType[]> desiredOutput)
        {
            InputData = inputData;
            DesiredOutput = desiredOutput;
        }

        public void AddTrainingInstance (DataType[] inputData, DataType[] desiredOutput)
        {
            InputData.Add(inputData);
            DesiredOutput.Add(desiredOutput);
        }
        public void AddTrainingInstance (DataType[] inputData, DataType   desiredOutput)
        {
            DataType[] VariableAsArray = { desiredOutput };

            InputData.Add(inputData);
            DesiredOutput.Add(VariableAsArray);
        }
        public void AddTrainingInstance (DataType   inputData, DataType[] desiredOutput)
        {
            DataType[] VariableAsArray = { inputData };

            InputData.Add(VariableAsArray);
            DesiredOutput.Add(desiredOutput);
        }
        public void AddTrainingInstance (DataType   inputData, DataType   desiredOutput)
        {
            DataType[] InputAsArray = { inputData };
            DataType[] OutputAsArray = { desiredOutput };

            InputData.Add(InputAsArray);
            DesiredOutput.Add(OutputAsArray);
        }
    }
}
