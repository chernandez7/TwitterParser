#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn  ; Enable warnings to assist with detecting common errors.
#SingleInstance
#Persistent

; This script will run in the background and update the python parsing script to update the text file of tweets at a certain interval.
; Scheduler runs immediately but sleeps for 1 hour, so program will run hourly.

; Runs Scheduler function right when the program starts and will do so when possible.
SetTimer, Scheduler, 0

return

Scheduler:
	; Call to python exe goes here when it's created
	sleep 3600000 ;1 hour

return