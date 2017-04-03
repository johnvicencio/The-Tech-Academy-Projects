#
# Python Ver:   3.6.1
#
# Author:       John Vicencio
#
# Purpose:      To move text files that were modified within 24 hours
#
# Tested OS:  This code was written and tested to work with MacOS and Windows 10 through Parallel.


import shutil
import os
from tkinter import *
from tkinter import messagebox
from tkinter import filedialog
from datetime import datetime, timedelta

# Set global variables
original_path = []
destination_path = []

# Define original folder path
def original_folder():
    dirname = filedialog.askdirectory()
    origin = dirname + "/"
    original_path.append(origin)
    messagebox.showinfo("Message", "Original Folder Selected")

# Define desitination folder path
def destination_folder():
    dirname = filedialog.askdirectory()
    destination = dirname + "/"
    destination_path.append(destination)
    messagebox.showinfo("Message", "Desitnation Folder Selected")

#define the move file event
def move_file():
    # Get the current directory origin and destination folders
    # From the global list array variables
    origin = original_path[0]
    destination = destination_path[0]
    now = datetime.now()
    
    # Go through each files that are texts only
    # Then move them
    for file in os.listdir(origin):
        if file.endswith(".txt"):
            source_file = os.path.join(origin, file)
            file_stamp = os.stat(source_file).st_mtime # get the modified time of file
            file_created = datetime.fromtimestamp(file_stamp) # translate to datetime to be calculated
            diff = (now - file_created).days # get the days of the difference
            # start moving them if previous 24 hours but not more than that
            if (diff <= 1):
                destination_file = os.path.join(destination, file)
                shutil.move(source_file, destination_file)
    messagebox.showinfo("Message", "All Text Files Moved to Destination Folder")


# Create GUI
root = Tk()

label_source = Label(root, text="Folder source: ")
label_source.pack()

button_source = Button(root, text='Folder From', command = original_folder)
button_source.pack()

label_destination = Label(root, text="Folder desitination: ")
label_destination.pack()

button_destination = Button(root, text='Folder To', command = destination_folder)
button_destination.pack()

label = Label(root, text="Would you like to move your files?")
label.pack()
button = Button(root, text='Move Now', command = move_file)
button.pack()
button.mainloop()
