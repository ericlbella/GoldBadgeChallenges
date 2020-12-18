using System;
using System.Collections.Generic;
using MenuRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuRepository_Tests
{
    [TestClass]
    public class MenuItemRepositoryTests
    {
        private MenuItemRepository _repo;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();

            List<string> ingredients = new List<string>();
            ingredients.Add("Pepperoni");
            ingredients.Add("Sausage");
            ingredients.Add("Tomato");

            _menuItem = new MenuItem(1, "Pizza", "The best pizza in the whole world!", ingredients, 5.00m);

            _repo.AddItemToMenu(_menuItem);
        }

        // Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field
            MenuItem foodItem = new MenuItem();
            foodItem.MealNumber = 1;
            MenuItemRepository repository = new MenuItemRepository();

            // Act --> Get/run the code we want to test
            repository.AddItemToMenu(foodItem);
            MenuItem foodItemFromDirectory = repository.GetMenuItemBytMealNumber(1);

            // Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(foodItemFromDirectory);
        }

        // Update
        [TestMethod]
        public void UpdateExisintMenuItem_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize

            List<string> ingredients = new List<string>();
            ingredients.Add("Pepperoni");
            ingredients.Add("Sausage");
            ingredients.Add("Tomato");

            MenuItem newMenuItem = new MenuItem(1, "Pizza", "The best pizza in the whole world", ingredients, 7.00m);

            // Act
            bool updateResult = _repo.UpdateExistingMenuItem(1, newMenuItem);

            // Assert
            Assert.IsTrue(updateResult);
        }
        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        public void UpdateExistingMenuItem_ShouldMatchGivenBool(int originalMealNumber, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            List<string> ingredients = new List<string>();
            ingredients.Add("Pepperoni");
            ingredients.Add("Sausage");
            ingredients.Add("Tomato");

            MenuItem newMenuItem = new MenuItem(1, "Pizza", "The best pizza in the whole world!", ingredients, 7.00m);

            // Act
            bool updateResult = _repo.UpdateExistingMenuItem(originalMealNumber, newMenuItem);

            // Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }
        
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _repo.RemoveMenuItemFromList(_menuItem.MealNumber);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
