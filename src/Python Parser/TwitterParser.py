from twython import Twython
import time

APP_KEY = '8tLZ3KImFbikHPHYohJIDez1C'
APP_SECRET = '1cYBFd7pFPV161hDPLDS7xXCnFmCpPmlPXcxovMKFTly9YWieI'

twitter = Twython(APP_KEY, APP_SECRET)

#Initialization of variables
start = time.time()
item_count = 0
url = "https://twitter.com/BarackObama"

#Creating and opening file
file = open("tweets.txt", "w+")

#URL Requests
print("Parsing '{}'...\n".format(url))
response = requests.get(url)

soup = BeautifulSoup(response.content, "html.parser")
print(soup.prettify()) #test
#Populating arrays of a single page

        

file.close()
end = time.time()
print ("Finished processing {} items in {} seconds".format(str(item_count), str(end - start)))
