#Python 2
#John Vicencio

# Python Drill: PyDrill_scripting_27_idle
# Title: Daily File Transfer scripting project - Python 2.x - IDLE
#
# Scenario: Your company's users create or edit a collection of text files
# throughout the day. These text files represent data about customer
# orders.
# Once per day, any files that are new, or that were edited within the
# previous 24 hours, must be sent to the home office. To facilitate this,
# these new or updated files need to be copied to a specific 'destination'
# folder on a computer, so that a special file transfer program can grab
# them and transfer them to the home office.
# The process of figuring out which files are new or recently edited, and
# copying them to the 'destination' folder, is currently being done
# manually. This is very expensive in terms of manpower.
# You have been asked to create a script that will automate this task,
# saving the company a lot of money over the long term.
# Guidelines:
# Use Python 2.x for this drill.
# You should create two folders; one to hold the files that get created or
# modified throughout the day, and another to receive the folders that your
# script determines should be copied over daily.
# To aid in your development efforts, you should create .txt files to add
# to the first folder, using Notepad or similar program. You should also
# copy some older text files in there if you like. You should use files
# that you can edit, so that you can control whether they are meant to be
# detected as 'modified in the last 24 hours' by your program.

#Solution:
#Requirement needed a new file created and modified file create
#within the 'previous 24 hours' meaning a day before but not more than a day
#Any changes outside that range will not be moved
#Psuedo code:
#import all libaries
#define a move_daily_file function
#Look at the file modified time (mtime)
#Move it only if after current 24 hours (or one day) but not more than 2 days

import shutil
import os
from datetime import datetime, timedelta


def move_daily_file():
    # Get the current directory origin and destination folders
    origin = os.getcwd() + "/a/"
    destination = os.getcwd() + "/b/"
    now = datetime.now()
    # Go through each files that are texts only
    # Then move them
    for file in os.listdir(origin):

        #only text files will be moved
        if file.endswith(".txt"):
            source_file = os.path.join(origin, file)
            file_stamp = os.stat(source_file).st_mtime # get the modified time of file
            file_created = datetime.fromtimestamp(file_stamp) # translate to datetime to be calculated
            diff = (now - file_created).days # get the days of the difference
            # start moving them if previous 24 hours but not more than that
            if (diff <= 1):
                destination_file = os.path.join(destination, file)
                shutil.move(source_file, destination_file)

move_daily_file()
