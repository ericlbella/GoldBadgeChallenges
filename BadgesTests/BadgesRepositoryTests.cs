using System;
using System.Collections.Generic;
using BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgesTests
{
    [TestClass]
    public class BadgesRepositoryTests
    {
        private BadgeRepostiory _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepostiory();
            _badge = new Badge(12345, new List<string>() { "A5", "A7" });
            _repo.AddBadgeToDictionary(_badge);
        }

        // Add Method
        [TestMethod]
        public void AddToDictionary_ShouldGetNotNull()
        {
            // Arrange--> Setting up the playing field
            Badge badge = new Badge();
            badge.BadgeID = 12345;
            BadgeRepostiory repository = new BadgeRepostiory();

            // Act--> Get/run the code we want to test
            repository.AddBadgeToDictionary(_badge);
            KeyValuePair<int, List<string>> badgeKey = repository.GetBadgeByBadgeID(12345);

            // Assert--> Use the assert class to verify the expected outcome
            Assert.IsNotNull(badgeKey.Key);
            Assert.IsNotNull(badgeKey.Value);
        }

        // Update
        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            // Arrange
            // TestInitialize
            Badge newBadge = new Badge(12345, new List<string>() { "A5", "A7" });

            //Act--> Get/run the code we want to test
            _repo.UpdateDoorToBadge(newBadge.BadgeID, "A1");
            
            // Assert
            Assert.IsTrue(newBadge.Doors.Count==3);
        }
        [TestMethod]
        public void DeleteDoorFromExistingBadge()
        {
            //  Arrange

            // Act
            _repo.RemoveDoorFromBadge(_badge.BadgeID, "A5");

            // Assert
            Assert.IsTrue(_badge.Doors.Count == 1);

        }

    }
}
