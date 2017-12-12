using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WePoll.Domain.Managers;
using WePoll.Domain.Models;

namespace WePoll.Tests.Managers
{
    [TestClass]
    public class PollManagerTests
    {
        [TestMethod]
        public void ViewPoll()
        {
            //Arrange
            var manager = new PollManager();
            var mockVotes = new PollModel[] { };
            //Act
            var votes = manager.ViewPoll();
            //Asserts
            Assert.IsTrue(votes.Length > 0, "No Vote was cast");
        }
    }
}
