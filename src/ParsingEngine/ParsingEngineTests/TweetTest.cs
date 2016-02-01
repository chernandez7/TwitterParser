using System;
using ParsingEngine;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParsingEngineTests
{
    [TestClass]
    public class TweetTest
    {
        private readonly Tweet _tweet = new Tweet("@john went to the #supermarket http://google.com");

        [TestMethod]
        public void TestTweet()
        {
            Assert.IsTrue(new Tweet("@john went to the #supermarket http://google.com").GetRawTweet() == _tweet.GetRawTweet());
        }

        [TestMethod]
        public void TestProcessTweet()
        {
            //Assert.IsTrue(_tweet == _tweet.GetTweet());
        }

        [TestMethod]
        public void TestProcessTopics()
        {
            var list = new List<string>(1) {"#supermarket"};
            Assert.IsTrue(list[0] == _tweet.GetTopics()[0]);
        }

        [TestMethod]
        public void TestProcessLinks()
        {
            var list = new List<string>(1) {"http://google.com"};
            Assert.IsTrue(list[0] == _tweet.GetLinks()[0]);
        }

        [TestMethod]
        public void TestProcessMentions()
        {
            var list = new List<string>(1) {"@john"};
            Assert.IsTrue(list[0] == _tweet.GetMentions()[0]);
        }

        [TestMethod]
        public void TestGetRawTweet()
        {
            Assert.IsTrue("@john went to the #supermarket http://google.com" == _tweet.GetRawTweet());
        }

        [TestMethod]
        public void TestGetMentions()
        {
            var list = new List<string>(1) {"bob"};
            Assert.IsFalse(list == _tweet.GetMentions());
        }

        [TestMethod]
        public void TestGetTopics()
        {
            var list = new List<string>(1) {"coffee shop"};
            Assert.IsFalse(list == _tweet.GetTopics());
        }

        [TestMethod]
        public void TestGetLinks()
        {
            var list = new List<string>(1) {"http://yahoo.com"};
            Assert.IsFalse(list == _tweet.GetTopics());
        }
    }
}
