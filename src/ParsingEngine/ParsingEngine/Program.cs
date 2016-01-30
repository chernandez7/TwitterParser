using System;
using System.Collections.Generic;
using System.IO;

namespace ParsingEngine
{
    class Program
    {
        public static int  Main(string[] args)
        {
            var tweetList = GetTweets();

            foreach (var tweet in tweetList)
            {
                tweet.PrintTweet();
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            return 0;
        }

        private static List<Tweet> GetTweets()
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
