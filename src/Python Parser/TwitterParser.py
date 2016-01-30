from twython import Twython
from twython import TwythonStreamer
import time
import json
import re

'''
The Basis of this script started out as a modification
of another parsing script that I wrote over winter break.
Had trouble using the BeautifulSoup library to parse tweets so
ended up switching to the twitter API and the twython wrapper
to work on this script in python. Json is being used to write out the
tweets in a text form from dictionaries for easier use.

The goal of this script is to get some tweets from a person and store
them in a text file to be used in a C# application that will organize and
interpret them accordingly.

Inspired by the instructions and documentation of twython itself:
https://github.com/ryanmcgrath/twython
'''
def remove_html_tags(data):
    '''
    Function found on:
    http://love-python.blogspot.com/2008/07/strip-html-tags-using-python.html
    '''
    p = re.compile(r'<.*?>')
    return p.sub('', data)

#Initialization of variables
start = time.time()
#Twitter API Variables needed for authentication
APP_KEY = '8tLZ3KImFbikHPHYohJIDez1C'
APP_SECRET = '1cYBFd7pFPV161hDPLDS7xXCnFmCpPmlPXcxovMKFTly9YWieI'
OAUTH_TOKEN = '4861151506-7ZtKF6s8Ve2mO9bswUIGxNh5OHL4LqvTEkQ3USw'
OAUTH_TOKEN_SECRET = '4EbmpgVJ2C3tgB99wkkVMAL7eMwF9IfKtP2TWNorOeecy'
twitter = Twython(APP_KEY, APP_SECRET)

file = open("tweets.txt", "w+")

#Requests to API to get tweets from a specific user
print("Parsing '{}'...\n".format("https://twitter.com/BarackObama"))
user_tweets = twitter.get_user_timeline(screen_name='BarackObama',
                                        count = 200, include_rts=False)
#Iteration through dictionary to write it to a file
for tweet in user_tweets:
    tweet['text'] = Twython.html_for_tweet(tweet)
    out = tweet['text'] + "\n"
    print (remove_html_tags(out))
    #file.write(json.dumps(tweet['text'], indent = 4) + '\n\n')
    outfile = str(remove_html_tags(out).encode('ascii', 'ignore')) + '\n'
    file.write(outfile[2:])


        
#Cleanup
file.close()
end = time.time()
print ("Finished processing in {} seconds".format(str(end - start)))



