//class that takes in and organizes tweets.

/**tweet's need:
*	Message body
*	Topics (#)
*	(@)
*	Links
*/


using System.Collections.Generic;
using System.Text.RegularExpressions;

class Tweet
{
    readonly string _rawTweet;
    Dictionary<string, string> _tweet;

    public Tweet(string tweet)
	{
		_rawTweet = tweet;
	    _tweet = processTweet(tweet);

	}

    //Need to figure out way to get exact strings and make regex's
    private Dictionary<string, string> processTweet(string tweet)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        //mentions @
        Regex mentionRegex = new Regex();
        Match mentionmatch = mentionRegex.Match(tweet);
        if (mentionmatch.Success)
        {
            dict.Add("mention", "");
        }
        //Links
        Regex linkRegex = new Regex();
        Match linkMatch = linkRegex.Match(tweet);
        if (linkMatch.Success)
        {
            dict.Add("link", "");
        }
        //topics #
        Regex topicRegex = new Regex();
        Match topicmatch = topicRegex.Match(tweet);
        if (topicmatch.Success)
        {
            dict.Add("topic", "");
        }
        return dict;
    }
    

    public string getrawTweet()
    {
        return _rawTweet;
    }

    public bool getMentions()
    {
        throw new System.NotImplementedException();
    }

    public bool getTopics()
    {
        throw new System.NotImplementedException();
    }

    public bool getURL()
    {
        throw new System.NotImplementedException();
    }
};
