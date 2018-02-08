using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WePoll.Domain.Managers;
using WePoll.Domain.Models;
using WePoll.Tests.Mock.Repositories;

namespace WePoll.Tests.Managers
{
    [TestClass]
    public class PollManagerTests
    {
        [TestMethod]
        public void ViewPoll()
        {
            //Arrange
            var mockPollRepo = new MockPollRepository();
            var manager = new PollManager(mockPollRepo);
            //Act
            var votes = manager.GetPolls();
            //Asserts
            Assert.IsTrue(votes.Length > 0, "No Vote was cast");
        }
    }
}
