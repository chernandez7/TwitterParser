using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParsingEngineTests
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public void Initialize()
        {
            string testTweet = "@john went to the #supermarket http://google.com"
            var tweet = new Tweet(testTweet);
        }

        [ClassCleanup]
        public void Cleanup()
        {
            
        }

        [TestMethod]
        public void TestTweet()
        {
            Assert.IsTrue(new Tweet("@john went to the #supermarket") == tweet);
        }

        [TestMethod]
        public void TestProcessTweet()
        {
            Assert.IsTrue(tweet == TestGetRawTweet.GetTweet());
        }

        [TestMethod]
        public void TestProcessTopics()
        {
            Assert.IsTrue("supermarket" == TestGetRawTweet.GetTopics()[0]);
        }

        [TestMethod]
        public void TestProcessLinks()
        {
            Assert.IsTrue("http://google.com" == TestGetRawTweet.GetLinks()[0]);
        }

        [TestMethod]
        public void TestProcessMentions()
        {
            Assert.IsTrue("john" == TestGetRawTweet.GetMentions()[0]);
        }

        [TestMethod]
        public void TestGetRawTweet()
        {
            Assert.IsTrue("@john went to the #supermarket http://google.com" == tweet.GetRawTweet())
        }

        [TestMethod]
        public void TestGetMentions()
        {
        }

        [TestMethod]
        public void TestGetTopics()
        {
        }

        [TestMethod]
        public void TestGetLinks()
        {
        }
    }
}
