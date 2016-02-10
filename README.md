# TwitterParser

#Idea so far:

Python Parsing script using Twitter API with Twython wrapper saves tweets in a text file. Located in TwitterParser/src/ParsingEngine/bin/Debug/PythonParser/

C# Application to properly sort tweets in data structures.
C# Unit Tests to ensure that the above application is working.
AutoHotKey script to run the parser to update tweets. (Also located with the python parser)

#To update the tweets:

Run "TwitterParser.exe", it takes a parameter, the username of the twitter account.

Ex. $ TwitterParser.exe BarackObama

This would run and Parse Barack Obama's twitter page for the 200 most recent tweets and store them in tweets.txt.

#To Run the engine:
Either Open "ParsingEngine.sln" in an IDE or run the executable "tweet.exe".
This should give all the tweets from the parser and label their mentions, topics, and links given.


-Christopher Hernandez
