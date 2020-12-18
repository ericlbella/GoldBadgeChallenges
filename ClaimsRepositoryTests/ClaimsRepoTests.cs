using System;
using ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsRepositoryTests
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private ClaimsRepository _repo;
        private Claims _claims;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _claims = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime (2018, 4, 27),true);
            _repo.AddClaimsToQueue(_claims);
        
        }
       
        
        // Add Method
        [TestMethod]
        public void AddToQueue_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field
            Claims claims = new Claims();
            claims.ClaimID = 1;
            ClaimsRepository repository = new ClaimsRepository();

            // Act --> Get/run the code we want to test
            repository.AddClaimsToQueue(claims);
            Claims claimsFromDirectory = repository.GetClaimsByClaimID(1);

            // Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(claimsFromDirectory);
        }
    }
}
