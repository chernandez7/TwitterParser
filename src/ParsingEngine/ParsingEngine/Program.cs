using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ParsingEngine
{
    class Program
    {
        public static int  Main(string[] args)
        {
            var testTweet = new Tweet("@franky goes to #hollywood #cali #test. See http://cnn.com.");

            Console.WriteLine(testTweet.GetrawTweet());
            PrintList(testTweet.GetMentions());
            PrintList(testTweet.GetTopics());
            PrintList(testTweet.GetLink());
            Console.ReadLine();
            //testTweet.PrintTweet();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            return 0;
        }

        private static void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
