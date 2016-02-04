using System;
using System.Collections.Generic;
using System.IO;

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

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            return 0;
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
