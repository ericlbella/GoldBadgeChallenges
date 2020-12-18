using System;
using ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsRepositoryTests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void SetClaimsID_ShouldSetCorrectInt()
        {
            // Arrange
            Claims claims = new Claims();
            claims.ClaimID = 1;

            // Act
            int expected = 1;
            int actual = claims.ClaimID;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
