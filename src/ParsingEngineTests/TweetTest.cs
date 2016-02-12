using ParsingEngine;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParsingEngineTests
{
    [TestClass]
    public class TweetTest
    {
        private readonly Tweet _tweet = new Tweet("@john went to the #supermarket http://google.com");

        //Checking for GetRawTweet() function to work properly and return the original string used to create the tweet. Should work even when using newly created tweets.
        [TestMethod]
        public void TestGetRawTweet()
        {
            var newTweet = new Tweet("@child1 the #child did not go to the supermarket today google.com");

            Assert.IsTrue("@john went to the #supermarket http://google.com" == _tweet.GetRawTweet());
            Assert.IsFalse("@john did not go to the #supermarket http://google.com" == _tweet.GetRawTweet());
            Assert.IsTrue(newTweet.GetLength() == 65);

            Assert.IsTrue("@child1 the #child did not go to the supermarket today google.com" == newTweet.GetRawTweet());
            Assert.IsFalse("@child1 the #child did not go to the recrd store today google.com" == _tweet.GetRawTweet());
        }

        //Checking for GetMentions() function to get the correct mentions in a list.
        [TestMethod]
        public void TestGetMentions()
        {
            var testTweet = new Tweet("@john @bob message");
            var testList = new List<string>(1) {"bob"};
            var testList2 = new List<string>(1) { "@john" };

            Assert.IsTrue(testList2[0] == _tweet.GetMentions()[0]);
            Assert.IsFalse(testList == _tweet.GetMentions());

            Assert.IsTrue(testTweet.GetMentions().Contains("@john"));
            Assert.IsTrue(testTweet.GetMentions().Contains("@bob"));
            Assert.IsFalse(testTweet.GetMentions().Contains("@message"));

            Assert.IsTrue(testTweet.GetMentions().Count == 2);

        }

        //Checks GetTopics() function to get the correct topics in a list.
        [TestMethod]
        public void TestGetTopics()
        {
            var testTweet = new Tweet("#coffeeshop #supermarket message");
            var testList = new List<string>(1) { "coffee shop" };
            var testList2 = new List<string>(1) { "#supermarket" };

            Assert.IsTrue(testList != _tweet.GetTopics());
            Assert.IsTrue(testList2[0] == _tweet.GetTopics()[0]);

            Assert.IsTrue(testTweet.GetTopics().Contains("#coffeeshop"));
            Assert.IsTrue(testTweet.GetTopics().Contains("#supermarket"));
            Assert.IsFalse(testTweet.GetTopics().Contains("#message"));

            Assert.IsTrue(testTweet.GetTopics().Count == 2);
        }

        //Checks GetLinks() function to get the correct topics in a list.
        [TestMethod]
        public void TestGetLinks()
        {
            var testTweet = new Tweet("yahoo.com google.com message");
            var testList = new List<string>(1) { "http://yahoo.com" };
            var testList2 = new List<string>(1) { "http://google.com" };

            Assert.IsFalse(testList == _tweet.GetTopics());
            Assert.IsTrue(testList2[0] == _tweet.GetLinks()[0]);

            Assert.IsTrue(testTweet.GetLinks().Contains("yahoo.com"));
            Assert.IsTrue(testTweet.GetLinks().Contains("google.com"));
            Assert.IsFalse(testTweet.GetLinks().Contains("message"));

            Assert.IsTrue(testTweet.GetLinks().Count == 2);
        }

        [TestMethod]
        public void TestRegexStrings()
        {
            //Testing Topic regex string "(#)((?:[A-Za-z0-9-_]*))"
            //Checking different tests like spaces and other markers interfering with the topic marker.
            var testTweet = new Tweet("#test # test ##test #@test @#test");

            Assert.IsTrue(testTweet.GetTopics().Contains("#test"));
            Assert.IsTrue(testTweet.GetTopics().Contains("#"));

            Assert.IsFalse(testTweet.GetTopics().Contains("test"));
            Assert.IsFalse(testTweet.GetTopics().Contains("##test"));
            Assert.IsFalse(testTweet.GetTopics().Contains("#@test"));
            Assert.IsFalse(testTweet.GetTopics().Contains("@#test"));

            //Testing "(@)((?:[A-Za-z0-9-_]*))"
            //Checking different tests like spaces and other markers interfering with the topic marker.
            var testTweet2 = new Tweet("@test @ test @@test #@test @#test");

            Assert.IsTrue(testTweet2.GetMentions().Contains("@test"));
            Assert.IsTrue(testTweet2.GetMentions().Contains("@"));

            Assert.IsFalse(testTweet2.GetMentions().Contains(" test"));
            Assert.IsFalse(testTweet2.GetMentions().Contains("@@test"));
            Assert.IsFalse(testTweet2.GetMentions().Contains("#@test"));
            Assert.IsFalse(testTweet2.GetMentions().Contains("@#test"));
            Assert.IsFalse(testTweet2.GetMentions().Contains("test"));

            //Testing "(http(s)?://)?([\w-]+\.)+[\w-]+(/\S\w[\w- ;,./?%&=]\S*)?"
            //Checking different tests like spaces and other markers interfering with the topic marker.
            var testTweet3 = new Tweet("http:// https:// google.com https://google.com website.net http://website.net");

            Assert.IsTrue(testTweet3.GetLinks().Contains("google.com"));
            Assert.IsTrue(testTweet3.GetLinks().Contains("https://google.com"));
            Assert.IsTrue(testTweet3.GetLinks().Contains("http://website.net"));
            Assert.IsTrue(testTweet3.GetLinks().Contains("website.net"));

            Assert.IsFalse(testTweet3.GetLinks().Contains("http://"));
            Assert.IsFalse(testTweet3.GetLinks().Contains("https://"));
        }
    }
}
