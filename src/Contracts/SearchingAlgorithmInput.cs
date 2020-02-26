namespace Contracts
{
    using System.Collections.Generic;
    using Contracts.Interfaces;

    public class SearchingAlgorithmInput : ISearchingAlgorithmInput
    {
        public SearchingAlgorithmInput(IList<int> inputArray, int x)
        {
            InputArray = inputArray ?? new List<int>();
            X = x;
        }

        public int X { get; }

        public IList<int> InputArray { get; }
    }
}
