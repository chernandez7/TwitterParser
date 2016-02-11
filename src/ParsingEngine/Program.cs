using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParsingEngine
{
    public class ParsingEngine
    {
        public static int  Main(string[] args)
        {
            var tweetList = GetTweets(); //Get Tweets from txt file

            foreach (var tweet in tweetList)
            {
                tweet.PrintTweet(); //print tweets

                Console.WriteLine();
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want mentions, topics, or links sorted? Or press 'x' to exit.");

                var sortType = Console.ReadLine();

                if (sortType == "mentions")
                {
                    PrintMentions(tweetList);
                }
                else if (sortType == "topics")
                {
                    PrintTopics(tweetList);
                }
                else if (sortType == "links")
                {
                    PrintLinks(tweetList);
                }
                else if (sortType == "x" || sortType == "exit")
                {
                    Console.WriteLine("Closing Application.");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Incorrect parameter given. Please choose from mentions, topics, or links.");
                }
            }

            return 0;
        }

        private static void PrintLinks(List<Tweet> tweetList)
        {
            //Dictionary will hold the topic string and the amount of times it has been used.
            var topicDict = new Dictionary<string, int>(tweetList.Count);
            foreach (var t in tweetList)
            {
                foreach (var link in t.GetLinks())
                {
                    if (topicDict.ContainsKey(link))
                    {
                        topicDict[link]++; //increments usage of topic
                    }
                    else if (link == null)
                    {
                        break;
                    }
                    else
                    {
                        topicDict.Add(link, 1); //populating topicDict
                    }
                }
            }

            //Sorting topics in order of frequency
            //http://stackoverflow.com/a/13854099/3035065 LINQ expression borrowed to sort dictionary by value instead of key
            var output = topicDict.OrderBy(e => e.Value).Select(e => new { frequency = e.Value, word = e.Key }).ToList();
            Console.WriteLine();
            foreach (var entry in output)
            {
                Console.ResetColor();
                Console.Write("{0}: ", entry.word);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}", entry.frequency);
            }
            Console.WriteLine();
        }

        private static void PrintTopics(List<Tweet> tweetList)
        {
            //Dictionary will hold the topic string and the amount of times it has been used.
            var topicDict = new Dictionary<string, int>(tweetList.Count);
            foreach (var t in tweetList)
            {
                foreach (var topic in t.GetTopics())
                {
                    if (topicDict.ContainsKey(topic))
                    {
                        topicDict[topic]++; //increments usage of topic
                    }
                    else if (topic == null)
                    {
                        break;
                    }
                    else
                    {
                        topicDict.Add(topic, 1); //populating topicDict
                    }
                }
            }

            //Sorting topics in order of frequency
            //http://stackoverflow.com/a/13854099/3035065 LINQ expression borrowed to sort dictionary by value instead of key
            var output = topicDict.OrderBy(e => e.Value).Select(e => new {frequency = e.Value, word = e.Key}).ToList();
            Console.WriteLine();
            foreach (var entry in output)
            {
                Console.ResetColor();
                Console.Write("{0}: ", entry.word);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}", entry.frequency);
            }
            Console.WriteLine();
        }

        private static void PrintMentions(List<Tweet> tweetList)
        {
            //Dictionary will hold the topic string and the amount of times it has been used.
            var topicDict = new Dictionary<string, int>(tweetList.Count);
            foreach (var t in tweetList)
            {
                foreach (var mention in t.GetMentions())
                {
                    if (topicDict.ContainsKey(mention))
                    {
                        topicDict[mention]++; //increments usage of topic
                    }
                    else if (mention == null)
                    {
                        break;
                    }
                    else
                    {
                        topicDict.Add(mention, 1); //populating topicDict
                    }
                }
            }

            //Sorting topics in order of frequency
            //http://stackoverflow.com/a/13854099/3035065 LINQ expression borrowed to sort dictionary by value instead of key
            var output = topicDict.OrderBy(e => e.Value).Select(e => new { frequency = e.Value, word = e.Key }).ToList();
            Console.WriteLine();
            foreach (var entry in output)
            {
                Console.ResetColor();
                Console.Write("{0}: ", entry.word);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}", entry.frequency);
            }
            Console.WriteLine();
        }

        //Gets tweets from the text file that is written into from the python parsing script.
        public static List<Tweet> GetTweets()
        {
            var list = new List<Tweet>();
            string line;

            var stream = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"PythonParser\tweets.txt"));
            while ((line = stream.ReadLine()) != null)
            {
                var tempTweet = new Tweet(line);
                list.Add(tempTweet);
            }
            return list;
        }
    }
}
