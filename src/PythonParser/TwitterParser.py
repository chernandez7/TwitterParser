from twython import Twython
import time
import sys
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
    p = re.compile(r"<.*?>")
    return p.sub('', data)

#Initialization of variables
total = len(sys.argv)
start = time.time()

#Checking if parameters are entered
if total == 2:
    User_Name = sys.argv[1]
elif total >= 2:
    print ("Only the twitter username is needed as a parameter")
    print ("Too many parameters given. Program Closing.")
    exit()
else:
    print ("Only the twitter username is needed as a parameter")
    print ("Not enough parameters. Program Closing.")
    exit()
url = "https://twitter.com/{}".format(User_Name)
#Twitter API Variables needed for authentication
APP_KEY = '8tLZ3KImFbikHPHYohJIDez1C'
APP_SECRET = '1cYBFd7pFPV161hDPLDS7xXCnFmCpPmlPXcxovMKFTly9YWieI'
OAUTH_TOKEN = '4861151506-7ZtKF6s8Ve2mO9bswUIGxNh5OHL4LqvTEkQ3USw'
OAUTH_TOKEN_SECRET = '4EbmpgVJ2C3tgB99wkkVMAL7eMwF9IfKtP2TWNorOeecy'
twitter = Twython(APP_KEY, APP_SECRET)

file = open("tweets.txt", "w+")

#Requests to API to get tweets from a specific user
print("Parsing '{}'...\n".format(url))
user_tweets = twitter.get_user_timeline(screen_name=User_Name,
                                        count = 500, include_rts=False)
#Iteration through dictionary to write it to a file
for tweet in user_tweets:
    tweet['text'] = Twython.html_for_tweet(tweet)
    out = tweet['text']
    outfile = str(remove_html_tags(out).encode('ascii', 'ignore'))
    file.write(outfile[2:-1] + "\n")


        
#Cleanup
file.close()
end = time.time()
print ("Finished processing in {} seconds".format(str(end - start)))



