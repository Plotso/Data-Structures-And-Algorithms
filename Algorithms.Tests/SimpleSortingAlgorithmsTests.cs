namespace Algorithms.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;
    using SortingAlgorithms.Simple;

    public class SimpleSortingAlgorithmsTests
    {
        private IList<int> _randomNumbers;
        private BubbleSortAlgorithm _bubbleSortAlgorithm;
        private CocktailSort _cocktailSort;
        private SelectionSort _selectionSort;
        private InsertionSort _insertionSort;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _bubbleSortAlgorithm = new BubbleSortAlgorithm();
            _cocktailSort = new CocktailSort();
            _selectionSort = new SelectionSort();
            _insertionSort = new InsertionSort();
        }
        
        [SetUp]
        public void Setup()
        {
            _randomNumbers = new List<int> {3, 9, 33, 11, 7, 4, 8, 22, 55, 77, 1, 2, 1, 66, 69, 99, 22, 20};
        }

        [Test]
        public void BubbleSortAlgorithm_Sort_WithRandomList_ShouldOrderCorrectly(
            [Values]SortOrder sortOrder)
        {
            var isAscending = sortOrder == SortOrder.Ascending;
            
            _bubbleSortAlgorithm.Sort(_randomNumbers, sortOrder);

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
        public void CocktailSort_Sort_WithRandomList_ShouldOrderCorrectly()
        {
            
            _cocktailSort.Sort(_randomNumbers);

            _randomNumbers.Should().BeInAscendingOrder();
        }

        [Test]
        public void SelectionSort_Sort_WithRandomList_ShouldOrderCorrectly()
        {
            _selectionSort.Sort(_randomNumbers);

            _randomNumbers.Should().BeInAscendingOrder();
        }
        
        [Test]
        public void InsertionSort_Sort_WithRandomList_ShouldOrderCorrectly()
        {
            _insertionSort.Sort(_randomNumbers);

            _randomNumbers.Should().BeInAscendingOrder();
        }
    }
}