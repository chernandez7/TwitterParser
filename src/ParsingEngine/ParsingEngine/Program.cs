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
            var testTweet = new Tweet("@franky goes to #hollywood #cali #test. See http://cnn.com. @frunky");

            testTweet.PrintTweet();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            return 0;
        }
    }
}
