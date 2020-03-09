namespace Algorithms.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;
    using SearchingAlgorithms.Extensions;

    public class SearchingAlgorithmsExtensionsTests
    {
        private const int X = 333;
        private static readonly IList<int> _numbersList = Enumerable.Range(1, 1500).ToList();
        private static int _nonExistingElement = _numbersList.Last() + 1;
        
        [Test]
        public void BinarySearch_WithExistingItem_ShouldFindCorrectIndex()
        {
            var indexOfX = _numbersList.BinarySearch(X);

            indexOfX.Should().NotBeNull();
            indexOfX.Should().Be(X - 1);
        }

        [Test]
        public void LinearSearch_WithExistingItem_ShouldFindCorrectIndex()
        {
            var indexOfX = _numbersList.LinearSearch(X);

            indexOfX.Should().NotBeNull();
            indexOfX.Should().Be(X - 1);
        }
        
        [Test]
        public void BinarySearch_WithMissingItem_ShouldReturnNull()
        {
            var indexOfX = _numbersList.BinarySearch(_nonExistingElement);

            indexOfX.Should().BeNull();
        }
        
        [Test]
        public void LinearSearch_WithMissingItem_ShouldReturnNull()
        {
            var indexOfX = _numbersList.LinearSearch(_nonExistingElement);

            indexOfX.Should().BeNull();
        }
    }
}