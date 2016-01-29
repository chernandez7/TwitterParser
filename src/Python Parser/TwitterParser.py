from bs4 import BeautifulSoup
import sys
import time
import requests

#Initialization of variables
start = time.time()
item_count = 0
url = "https://twitter.com/BarackObama"

#Creating and opening file
file = open("tweets.txt", "w+")

#URL Requests
sys.stdout.write("Parsing '{}'...\n".format(url))
response = requests.get(url)

soup = BeautifulSoup(response.content, "html.parser")
print(soup.prettify()) #test
#Populating arrays of a single page

        

file.close()
end = time.time()
print ("Finished processing {} items in {} seconds".format(str(item_count), str(end - start)))
