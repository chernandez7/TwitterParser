using System;
using ParsingEngine;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParsingEngineTests
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public void Initialize()
        {
            string testTweet = "@john went to the #supermarket http://google.com";
            var _tweet = new Tweet(testTweet);
        }

        [ClassCleanup]
        public void Cleanup()
        {
            
        }

        [TestMethod]
        public void TestTweet()
        {
            Assert.IsTrue(new Tweet("@john went to the #supermarket") == _tweet);
        }

        [TestMethod]
        public void TestProcessTweet()
        {
            Assert.IsTrue(_tweet == _tweet.GetTweet());
        }

        [TestMethod]
        public void TestProcessTopics()
        {
            var list = new list<string>(1);
            list.add("supermarket");
            Assert.IsTrue(list == _tweet.GetTopics());
        }

        [TestMethod]
        public void TestProcessLinks()
        {
            var list = new list<string>(1);
            list.add("http://google.com");
            Assert.IsTrue(list == _tweet.GetLinks());
        }

        [TestMethod]
        public void TestProcessMentions()
        {
            var list = new list<string>(1);
            list.add("john");
            Assert.IsTrue(list == _tweet.GetMentions());
        }

        [TestMethod]
        public void TestGetRawTweet()
        {
            Assert.IsTrue("@john went to the #supermarket http://google.com" == _tweet.GetRawTweet());
        }

        [TestMethod]
        public void TestGetMentions()
        {
            var list = new list<string>(1);
            list.add("bob");
            Assert.IsFalse(list == _tweet.GetMentions());
        }

        [TestMethod]
        public void TestGetTopics()
        {
            var list = new list<string>(1);
            list.add("coffee shop");
            Assert.IsFalse(list == _tweet.GetTopics());
        }

        [TestMethod]
        public void TestGetLinks()
        {
            var list = new list<string>(1);
            list.add("http://yahoo.com");
            Assert.IsFalse(list == _tweet.GetTopics());
        }
    }
}
