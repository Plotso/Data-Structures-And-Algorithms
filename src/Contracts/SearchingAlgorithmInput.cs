namespace Contracts
{
    using System.Collections.Generic;
    using Contracts.Interfaces;

    public class SearchingAlgorithmInput : ISearchingAlgorithmInput
    {
        private readonly IList<int> _inputArray;
        private readonly int _x;

        public SearchingAlgorithmInput(IList<int> inputArray, int x)
        {
            //ToDo: check for null values because it's Contracts are a separate project
            _inputArray = inputArray;
            _x = x;
        }

        public int X => _x;

        public IList<int> InputArray => _inputArray;
    }
}
