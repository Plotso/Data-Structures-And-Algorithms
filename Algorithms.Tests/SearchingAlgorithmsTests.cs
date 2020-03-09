namespace Algorithms.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using FluentAssertions;
    using SearchingAlgorithms.InputBased;

    public class SearchingAlgorithmsTests
    {
        private const int X = 333;
        private readonly IList<int> _numbersList = Enumerable.Range(1, 1500).ToList();

        private BinarySearchAlgorithm _binarySearchAlgorithm;
        private LinearSearchAlgorithm _linearSearchAlgorithm;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _binarySearchAlgorithm = new BinarySearchAlgorithm();
            _linearSearchAlgorithm = new LinearSearchAlgorithm();
        }

        [Test]
        public void BinarySearchAlgorithm_BinarySearch_WithExistingItem_ShouldFindCorrectIndex(
            [Values]bool isRecursive)
        {
            var input = GetSearchingAlgorithmInput();
            var indexOfX = _binarySearchAlgorithm.BinarySearch(input, isRecursive);

            indexOfX.Should().NotBeNull();
            indexOfX.Should().Be(X - 1);
        }

        [Test]
        public void LinearSearchAlgorithm_LinearSearch_WithExistingItem_ShouldFindCorrectIndex()
        {
            var input = GetSearchingAlgorithmInput();
            var indexOfX = _linearSearchAlgorithm.LinearSearch(input);

            indexOfX.Should().NotBeNull();
            indexOfX.Should().Be(X - 1);
        }
        
        [Test]
        public void BinarySearchAlgorithm_BinarySearch_WithMissingItem_ShouldReturnNull(
            [Values]bool isRecursive)
        {
            var input = GetSearchingAlgorithmInput(false);
            var indexOfX = _binarySearchAlgorithm.BinarySearch(input, isRecursive);

            indexOfX.Should().BeNull();
        }
        
        [Test]
        public void LinearSearchAlgorithm_LinearSearch_WithMissingItem_ShouldReturnNull()
        {
            var input = GetSearchingAlgorithmInput(false);
            var indexOfX = _linearSearchAlgorithm.LinearSearch(input);

            indexOfX.Should().BeNull();
        }
        
        private SearchingAlgorithmInput GetSearchingAlgorithmInput(bool isElementInsideList = true) 
            => new SearchingAlgorithmInput(_numbersList, isElementInsideList ? X : _numbersList.Last() + 1);
    }
}