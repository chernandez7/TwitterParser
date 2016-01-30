//class that takes in and organizes tweets.

/**tweet's need:
*	Message body
*	Topics (#)
*	(@)
*	Links
*/


using System.Collections.Generic;

class Tweet
{
    readonly string _rawTweet;
    Dictionary<string, string> _tweet;

    public Tweet(string tweet)
	{
		_rawTweet = tweet;
	    //_tweet = processTweet(tweet);

	}

    /*
    private Dictionary<string, string> processTweet(string tweet)
    {
        throw new System.NotImplementedException();
    }
    */

    public string getrawTweet()
    {
        return _rawTweet;
    }
};
