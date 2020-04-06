namespace Algorithms.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using NUnit.Framework;
    using SortingAlgorithms.Simple;
    using SortingAlgorithms.Simple.Extensions;

    public class SimpleSortingAlgorithmsExtensionsTests
    {
        private IList<int> _randomNumbers;

        [SetUp]
        public void Setup()
        {
            _randomNumbers = new List<int> {3, 9, 33, 11, 7, 4, 8, 22, 55, 77, 1, 2, 1, 66, 69, 99};
        }
        
        [Test]
        public void BubbleSort_WithRandomList_ShouldOrderCorrectly(
            [Values]SortOrder sortOrder)
        {
            var isAscending = sortOrder == SortOrder.Ascending;

            _randomNumbers.BubbleSort(sortOrder);

            if (isAscending)
            {
                _randomNumbers.Should().BeInAscendingOrder();
            }
            else
            {
                _randomNumbers.Should().BeInDescendingOrder();
            }
        }

        [Test]
        public void SelectionSort_WithRandomList_ShouldSortCorrectly()
        {
            _randomNumbers.SelectionSort();

            _randomNumbers.Should().BeInAscendingOrder();
        }

        [Test]
        public void InsertionSort_WithRandomList_ShouldSortCorrectly()
        {
            _randomNumbers.InsertionSort();

            _randomNumbers.Should().BeInAscendingOrder();
        }
    }
}