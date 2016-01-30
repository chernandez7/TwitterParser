using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace ParsingEngine
{
    class Tweet
    {
        readonly string _rawTweet;
        private readonly Dictionary<string, string> _tweet;
        private List<string> _mentionList;
        private List<string> _linkList;
        private List<string> _topicList;

        public Tweet(string tweet)
        {
            _mentionList = new List<string>(10);
            _linkList = new List<string>(10);
            _topicList = new List<string>(10);

            _rawTweet = tweet;
            _tweet = ProcessTweet(_rawTweet);
        }

        //Need to figure out way to get exact strings and make regex's
        //Help creating the regex string from: https://regex101.com/
        private Dictionary<string, string> ProcessTweet(string tweet)
        {
            var dict = new Dictionary<string, string>();
            //mentions @
            var mentionRegex = new Regex("(@)((?:[A-Za-z0-9-_]*))");
            var mentionmatch = mentionRegex.Match(tweet);
            if (mentionmatch.Success)
            {
                dict.Add("mention", mentionmatch.Value);
                _mentionList.Add(mentionmatch.Value);
            }
            //Links
            var linkRegex = new Regex(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/\S\w[\w- ;,./?%&=]\S*)?");
            var linkMatch = linkRegex.Match(tweet);
            if (linkMatch.Success)
            {
                dict.Add("link", linkMatch.Value);
                _mentionList.Add(linkMatch.Value);
            }
            //topics #
            var topicRegex = new Regex("(#)((?:[A-Za-z0-9-_]*))");
            var topicMatch = topicRegex.Match(tweet);
            if (topicMatch.Success)
            {
                dict.Add("topic", topicMatch.Value);
                _mentionList.Add(topicMatch.Value);
            }
            return dict;
        }
    

        public string GetrawTweet()
        {
            return _rawTweet;
        }

        public List<string> GetMentions()
        {    
            return _mentionList;
        }

        public List<string> GetTopics()
        {
            return _topicList;
        }

        public List<string> GetLink()
        {
            return _linkList;
        }

        public void PrintTweet()
        {
            foreach (var key in _tweet.Keys)
            {
                foreach (var v in _tweet[key])
                {
                    Console.Write("{0}, ", v);
                }
                Console.WriteLine();
            }
        }
    };
}
