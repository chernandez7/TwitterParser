#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
#Warn  ; Enable warnings to assist with detecting common errors.
#SingleInstance
SetWorkingDir %A_ScriptDir%

; This script will run the Twitter Parser Python script that will update the tweets of whatever username is given.

; Command line parameter code taken from an old program of mine to send updates through text messages
ParameterAmount = %0%
UserName = %1%

if (ParameterAmount > 1)
{
  MsgBox "Too many parameters! Exiting program"
  return
}

if (ParameterAmount == 0)
{
  MsgBox "Not enough parameters! Exiting program"
  return
}

;Parameter passed to python script here
Run python TwitterParser.py %UserName%

return