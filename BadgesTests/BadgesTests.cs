using System;
using BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgesTests
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void SetID_ShouldSetCorrectInt()
        {
            Badge badge = new Badge();

            badge.BadgeID = 12345;

            int expected = 12345;
            int actual = badge.BadgeID;

            Assert.AreEqual(expected, actual);
        }
    }
}
