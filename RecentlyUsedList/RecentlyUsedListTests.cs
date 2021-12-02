using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Xunit;

namespace RecentlyUsedList
{
    public class RecentlyUsedListTests
    {
        private RecentlyUsedList _recentlyUsedList;

        private void Arange()
        {
            _recentlyUsedList = new RecentlyUsedList();
        }

        [Fact]
        public void Add_WithValidValue_AddsItem()
        {
            // Arange
            Arange();

            // Act
            _recentlyUsedList.Add("FirstList");

            // Assert
            Assert.True(_recentlyUsedList.Count > 0);
        }

        [Fact]
        public void Add_WithNotUniqueItems_AddsUniquItems()
        {
            // Arange
            Arange();
            var expectedlist = ToList("FifthItem", "FourthItem", "ThirdItem", "SecondItem", "FirstItem");

            // Act
            _recentlyUsedList.Add("FirstItem");
            _recentlyUsedList.Add("SecondItem");
            _recentlyUsedList.Add("SecondItem");
            _recentlyUsedList.Add("ThirdItem");
            _recentlyUsedList.Add("FourthItem");
            _recentlyUsedList.Add("FifthItem");

            // Assert
            Assert.Equal(_recentlyUsedList.ToList(), expectedlist);
        }

        [Fact]
        public void Add_WithValidValues_AddsItemsInLifoOrder()
        {
            // Arange
            Arange();
            var expectedlist = ToList("FifthItem", "FourthItem", "ThirdItem", "SecondItem", "FirstItem");

            // Act
            _recentlyUsedList.Add("FirstItem");
            _recentlyUsedList.Add("SecondItem");
            _recentlyUsedList.Add("ThirdItem");
            _recentlyUsedList.Add("FourthItem");
            _recentlyUsedList.Add("FifthItem");

            // Assert
            Assert.Equal(_recentlyUsedList.ToList(), expectedlist);
        }

        [Fact]
        public void Add_WithItemsExcidedCapacity_AddsItemsLimitedWithListSize()
        {
            // Arange
            Arange();
            var expectedlist = ToList("FifthItem", "FourthItem", "ThirdItem", "SecondItem", "FirstItem");

            // Act
            _recentlyUsedList.Add("FirstItem");
            _recentlyUsedList.Add("SecondItem");
            _recentlyUsedList.Add("SecondItem");
            _recentlyUsedList.Add("ThirdItem");
            _recentlyUsedList.Add("FourthItem");
            _recentlyUsedList.Add("FifthItem");
            _recentlyUsedList.Add("SixthItem"); //This should not be considered
            _recentlyUsedList.Add("SeventhItem"); //This should not be considered

            // assert
            Assert.Equal(_recentlyUsedList.ToList(), expectedlist);
        }

        [Theory]
        [InlineData("FirstItem", 4)]
        [InlineData("SecondItem", 3)]
        [InlineData("ThirdItem", 2)]
        [InlineData("FourthItem", 1)]
        [InlineData("FifthItem", 0)]
        public void GetListItem_WithValidIndex_ReturnsCorrectItem(string expectedlistitem, int index)
        {
            // Arange
            Arange();
            _recentlyUsedList.Add("FirstItem");
            _recentlyUsedList.Add("SecondItem");
            _recentlyUsedList.Add("ThirdItem");
            _recentlyUsedList.Add("FourthItem");
            _recentlyUsedList.Add("FifthItem");

            // Act
            var actuallistitem = _recentlyUsedList.GetListItem(index);

            // Assert
            Assert.Equal(actuallistitem.ToList(), expectedlistitem);
        }

        [Fact]
        public void CreateNewList_WithDefaultConstructor_GetsCorrectListSize()
        {
            // Arange
            Arange();
            const int expectedlistSize = 5;

            // Act Assert
            Assert.Equal(_recentlyUsedList.Size, expectedlistSize);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1)]
        public void GetListItem_WithNotValidValue_ThrowsArgumentException(int index)
        {
            // Arange
            Arange();
            _recentlyUsedList.Add("FirstItem");
            _recentlyUsedList.Add("SecondItem");
            _recentlyUsedList.Add("ThirdItem");
            _recentlyUsedList.Add("FourthItem");
            _recentlyUsedList.Add("FifthItem");

            // Act Assert
            var exception = Assert.Throws<ArgumentException>(() => _recentlyUsedList.GetListItem(index));
        }

        [Fact]
        public void CreateNewList_WithSizeDefinedInConstructor_GetsCorrectListSize()
        {
            // Arange
            var listSize = 10;
            var sizeableList = new RecentlyUsedList(listSize);

            // Act Assert
            Assert.Equal(listSize, sizeableList.Size);
        }

        private static List<string> ToList(params string[] items) => items.ToList();
    }
}
