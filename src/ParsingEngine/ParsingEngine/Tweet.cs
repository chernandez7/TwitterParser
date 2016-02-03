using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParsingEngine
{
    public class Tweet
    {
        private readonly string _rawTweet; //Tweet inputted as text
        private readonly Dictionary<string, List<string>> _tweet; //Compartmentalized version of tweet

        public Tweet(string tweet)
        {
            _rawTweet = tweet;
            _tweet = ProcessTweet(_rawTweet);
        }

        //Help creating the regex strings from:
        //https://regex101.com/
        //http://jes.al/2009/05/how-to-parse-twitter-usernames-hashtags-and-urls-in-c-30/
        //http://code.tutsplus.com/tutorials/8-regular-expressions-you-should-know--net-6149
        private static Dictionary<string, List<string>> ProcessTweet(string tweet)
        {
            var dict = new Dictionary<string, List<string>>();
            var mentionList = ProcessMentions(tweet);
            var linkList = ProcessLinks(tweet);
            var topicList = ProcessTopics(tweet);

            dict.Add("Mentions", mentionList);
            dict.Add("Links", linkList);
            dict.Add("Topics", topicList);

            return dict;
        }

        //Finds all "#" and everything after it until a whitespace occurs.
        private static List<string> ProcessTopics(string tweet)
        {
            //topics #
            var tempList = new List<string>();
            var topicRegex = new Regex("(#)((?:[A-Za-z0-9-_]*))");
            foreach (Match match in topicRegex.Matches(tweet))
            {
                tempList.Add(match.ToString());
            }
            return tempList;
        }

        //Finds all "http://" "https://" until a "." then finds whitespace 
        private static List<string> ProcessLinks(string tweet)
        {
            //Links
            var tempList = new List<string>();
            var linkRegex = new Regex(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/\S\w[\w- ;,./?%&=]\S*)?");
            foreach (Match match in linkRegex.Matches(tweet))
            {
                tempList.Add(match.ToString());
            }
            return tempList;
        }

        //Finds all "@" until a whitespace
        private static List<string> ProcessMentions(string tweet)
        {
            //mentions @
            var tempList = new List<string>();
            var mentionRegex = new Regex("(@)((?:[A-Za-z0-9-_]*))");
            foreach (Match match in mentionRegex.Matches(tweet))
            {
                tempList.Add(match.ToString());
            }
            return tempList;
        }

        //Accessor functions
        public string GetRawTweet() { return _rawTweet; }

        public Dictionary<string, List<string>> GetTweet() { return _tweet; }

        public List<string> GetMentions() { return _tweet["Mentions"]; }

        public List<string> GetTopics() { return _tweet["Topics"]; }

        public List<string> GetLinks() { return _tweet["Links"]; }

        //Essencially a ToString() for Tweets
        public void PrintTweet()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_rawTweet);
            Console.WriteLine();
            foreach (var key in _tweet.Keys)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0}: ", key);
                foreach (var value in _tweet[key])
                {
                    Console.ResetColor();
                    Console.Write(" {0}", value);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine();
            }
        }
    }
} ;
