# Author: John Vicencio
# Date: March 25, 2107

# The Tech Academy
# Python: sorting method
# Python 2



# Problem: Sort [67, 45, 2, 13, 1, 998] in ascending order without using sort() method
# Solution:
# Using bubble sort with two loops: outer loop and inner loop
# outer loop: i = 0 to n-1
# inner loop: j = 0 to n-1-i
#Then compare if the left item is greater than the right item
# if so, swap using assignment of the right to the left
# if not, do not swap

list = [67, 45, 2, 13, 1, 998]

def bubbleSort(list):
    for i in range(0, len(list) - 1):
        for j in range(0, len(list) - 1 - i):
            if list[j] > list[j+1]:
                list[j], list[j+1] = list[j+1], list[j]
    return list

print(bubbleSort(list))
