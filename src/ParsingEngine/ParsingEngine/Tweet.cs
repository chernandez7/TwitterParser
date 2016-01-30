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

        //Help creating the regex string from: https://regex101.com/
        private Dictionary<string, string> ProcessTweet(string tweet)
        {
            var dict = new Dictionary<string, string>();
            //mentions @
            var mentionRegex = new Regex("(@)((?:[A-Za-z0-9-_]*))");
            var mentionMatch = mentionRegex.Match(tweet);
            for (var i = 0; i <mentionMatch.Groups.Count; i++)
            {
                dict.Add("mention", mentionMatch.Groups[i].ToString());
                _mentionList.Add(mentionMatch.Value);
            }
            //Links
            var linkRegex = new Regex(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/\S\w[\w- ;,./?%&=]\S*)?");
            var linkMatch = linkRegex.Match(tweet);
            for (var i = 0; i < linkMatch.Groups.Count; i++)
            {
                dict.Add("link", linkMatch.Groups[i].ToString());
                _mentionList.Add(linkMatch.Value);
            }
            //topics #
            var topicRegex = new Regex("(#)((?:[A-Za-z0-9-_]*))");
            var topicMatch = topicRegex.Match(tweet);
            for (var i = 0; i < topicMatch.Groups.Count; i++)
            {
                dict.Add("topic", topicMatch.Groups[i].ToString());
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
            foreach (KeyValuePair<string, string> kvp in _tweet)
            {
                Console.WriteLine("{0}\t{1}",
                    kvp.Key, kvp.Value);
            }
        }
    };
}
