using System;
using MenuRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuRepository_Tests
{
    [TestClass]
    public class MenuItemTests
    {
        [TestMethod]
        public void SetMenuID_ShouldSetCorrectInt()

        {
            // Arrange
            MenuItem foodItem = new MenuItem();
            foodItem.MealNumber = 1;

            // Act
            int expected = 1;
            int actual = foodItem.MealNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
