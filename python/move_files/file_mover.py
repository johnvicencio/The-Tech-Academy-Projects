#Python 2
#John Vicencio
# Python Drill: PyDrill_shutil_module_27_idle
# Title: File Mover - Python 2.7  IDLE
#Problem:

# Scenario: Your employer wants a program to move all his .txt files from one folder to another
# with the click of a click of a button. On your desktop make 2 new folders. Call one Folder A &
# the second Folder B. Create 4 random .txt files & put them in Folder A.
# Plan:
# - Move the files from Folder A to Folder B.
# - Print out each file path that got moved onto the shell.
# - Upon viewing Folder A after the execution, the moved files should not be there.
# Guidelines:
# Use Python 2.7 .x on this drill.
# Import the shutil module.
# Run it on the python shell.
# Use the IDLE for this Drill.

#Solution
#The problem assumes a GUI interface that when clicked text files will be
#moved from one folter to another.
#But the guidlines didn't mention Tkinter
#Import all the modules needed
# create an event for moving files when button is clicked
# moving files from one folder to another
# determining text files only to move

import shutil
import os
from Tkinter import *

# Create GUI
root = Tk()
label = Label(root, text="Would you like to move your files?")
label.pack()
button = Button(root, text='YES')

#define the move file event
def move_file(event):
    # Get the current directory origin and destination folders
    origin = os.getcwd() + "/a/"
    destination = os.getcwd() + "/b/"

    # Go through each files that are texts only
    # Then move them
    for file in os.listdir(origin):
        if file.endswith(".txt"):
            source_file = os.path.join(origin, file)
            destination_file = os.path.join(destination, file)
            shutil.move(source_file, destination_file)

button.pack()
button.bind('<Button-1>', move_file)
button.mainloop()
