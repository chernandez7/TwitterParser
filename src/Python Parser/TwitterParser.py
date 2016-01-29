from twython import Twython
from twython import TwythonStreamer
import time

#Initialization of variables
url = "https://twitter.com/BarackObama"
APP_KEY = '8tLZ3KImFbikHPHYohJIDez1C'
APP_SECRET = '1cYBFd7pFPV161hDPLDS7xXCnFmCpPmlPXcxovMKFTly9YWieI'
OAUTH_TOKEN = '4861151506-7ZtKF6s8Ve2mO9bswUIGxNh5OHL4LqvTEkQ3USw'
OAUTH_TOKEN_SECRET = '4EbmpgVJ2C3tgB99wkkVMAL7eMwF9IfKtP2TWNorOeecy'
twitter = Twython(APP_KEY, APP_SECRET)
start = time.time()

class MyStreamer(TwythonStreamer):
    def on_success(self, data):
        if 'text' in data:
            print (data['text'].encode('utf-8'))

    def on_error(self, status_code, data):
        print (status_code)

        # Want to stop trying to get data because of the error?
        # Uncomment the next line!
        #self.disconnect()
        

#Creating and opening file
file = open("tweets.txt", "w+")

stream = MyStreamer(APP_KEY, APP_SECRET,
                    OAUTH_TOKEN, OAUTH_TOKEN_SECRET)
stream.statuses.filter(track='obama')

#URL Requests
print("Parsing '{}'...\n".format(url))

        

file.close()
end = time.time()
print ("Finished processing in {} seconds".format(str(end - start)))
