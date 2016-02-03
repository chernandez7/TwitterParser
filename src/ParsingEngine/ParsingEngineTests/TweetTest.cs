using System;
using ParsingEngine;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsingEngine = ParsingEngine.ParsingEngine;

namespace ParsingEngineTests
{
    [TestClass]
    public class TweetTest
    {
        private readonly Tweet _tweet = new Tweet("@john went to the #supermarket http://google.com");

        //ADD: Process functions test regex strings used.

        //Checking for GetRawTweet() function to work properly and return the original string used to create the tweet. Should work even when using newly created tweets.
        [TestMethod]
        public void TestGetRawTweet()
        {
            var newTweet = new Tweet("@child1 the #child did not go to the supermarket today google.com");

            Assert.IsTrue("@john went to the #supermarket http://google.com" == _tweet.GetRawTweet());
            Assert.IsFalse("@john did not go to the #supermarket http://google.com" == _tweet.GetRawTweet());
            Assert.IsTrue("@child1 the #child did not go to the supermarket today google.com" == newTweet.GetRawTweet());
            Assert.IsFalse("@child1 the #child did not go to the recrd store today google.com" == _tweet.GetRawTweet());
        }

        //Checking for GetMentions() function to get the correct mentions in a list.
        [TestMethod]
        public void TestGetMentions()
        {
            var testList = new List<string>(1) {"bob"};
            var testList2 = new List<string>(1) { "@john" };

            Assert.IsTrue(testList2[0] == _tweet.GetMentions()[0]);
            Assert.IsFalse(testList2[0] != _tweet.GetMentions()[0]);
            Assert.IsTrue(testList != _tweet.GetMentions());
            Assert.IsFalse(testList == _tweet.GetMentions());
        }

        //Checks GetTopics() function to get the correct topics in a list.
        [TestMethod]
        public void TestGetTopics()
        {
            var testList = new List<string>(1) { "coffee shop" };
            var testList2 = new List<string>(1) { "#supermarket" };

            Assert.IsTrue(testList != _tweet.GetTopics());
            Assert.IsFalse(testList == _tweet.GetTopics());
            Assert.IsTrue(testList2[0] == _tweet.GetTopics()[0]);
            Assert.IsFalse(testList2[0] != _tweet.GetTopics()[0]);
        }

        //Checks GetLinks() function to get the correct topics in a list.
        [TestMethod]
        public void TestGetLinks()
        {
            var testList = new List<string>(1) { "http://yahoo.com" };
            var testList2 = new List<string>(1) { "http://google.com" };

            Assert.IsTrue(testList != _tweet.GetTopics());
            Assert.IsFalse(testList == _tweet.GetTopics());
            Assert.IsTrue(testList2[0] == _tweet.GetLinks()[0]);
            Assert.IsFalse(testList2[0] != _tweet.GetLinks()[0]);
        }

        [TestMethod]
        public void TestRegexStrings()
        {
            //Testing Topic regex string "(#)((?:[A-Za-z0-9-_]*))"
            //Checking different tests like spaces and other markers interfering with the topic marker.
            var testTweet = new Tweet("#test # test ##test #@test @#test")
            var list = new List<string>(6)
            {
                "test", "", "test", "@test", "test"
            };
            Assert.IsTrue(testTweet.GetTopics() == list);

            //Testing (@)((?:[A-Za-z0-9-_]*))
            //Checking different tests like spaces and other markers interfering with the topic marker.
            var testTweet2 = new Tweet("@test @ test @@test #@test @#test");
            var list2 = new List<string>(6)
            {
                "test", "", "test", "@test", "test"
            };
            Assert.IsTrue(testTweet2.GetMentions() == list2);

            var testTweet3 = new Tweet("http:// https:// google.com website.net")
            var list3 = new List<string>(6)
                {
                    "http://", "https://", "google.com", "website.net"
                };
            Assert.IsTrue(testTweet3.GetLinks() == list3);
        }
    }
}
