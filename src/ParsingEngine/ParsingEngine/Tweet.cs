using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParsingEngine
{
    class Tweet
    {
        readonly string _rawTweet;
        readonly Dictionary<string, string> _tweet;

        public Tweet(string tweet)
        {
            _rawTweet = tweet;
            _tweet = ProcessTweet(tweet);

        }

        //Need to figure out way to get exact strings and make regex's
        private Dictionary<string, string> ProcessTweet(string tweet)
        {
            var dict = new Dictionary<string, string>();
            //mentions @
            var mentionRegex = new Regex("(@)");
            var mentionmatch = mentionRegex.Match(tweet);
            if (mentionmatch.Success)
            {
                dict.Add("mention", mentionmatch.Value);
            }
            //Links
            var linkRegex = new Regex("http(s)");
            var linkMatch = linkRegex.Match(tweet);
            if (linkMatch.Success)
            {
                dict.Add("link", linkMatch.Value);
            }
            //topics #
            var topicRegex = new Regex("(#)");
            var topicmatch = topicRegex.Match(tweet);
            if (topicmatch.Success)
            {
                dict.Add("topic", topicmatch.Value);
            }
            return dict;
        }
    

        public string GetrawTweet()
        {
            return _rawTweet;
        }

        public string GetMentions()
        {
            if (_tweet.ContainsKey("mention"))
            {
                return _tweet["mention"];
            }
            else
            {
                Console.WriteLine("No mentions exist.");
                return null;
            }
        }

        public string GetTopics()
        {
            if (_tweet.ContainsKey("topic"))
            {
                return _tweet["topic"];
            }
            else
            {
                Console.WriteLine("No topics exist.");
                return null;
            }
        }

        public string GetUrl()
        {
            if (_tweet.ContainsKey("link"))
            {
                return _tweet["link"];
            }
            else
            {
                Console.WriteLine("No link exist.");
                return null;
            }
        }

        public void PrintTweet(Dictionary<string, string> dict)
        {
            foreach (var key in dict.Keys)
            {
                foreach (var v in dict[key])
                {
                    Console.Write("{0}, ", v);
                }
                Console.WriteLine();
            }
        }
    };
}
