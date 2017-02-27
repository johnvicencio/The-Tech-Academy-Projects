Problem:

Create a database, fill in data, query, and create at lest a stored procedure or more.

Requirements:

Database schema is provided.

Now populate the tables of the database with dummy data. You may enter in whatever data
you like, but must ensure that the following is true:

1. There is a book called 'The Lost Tribe'.
2. There is a library branch called 'Sharpstown' and one called 'Central'.
3. There are at least 20 books in the BOOK table.
4. There are at least 10 authors in the BOOK_AUTHORS table.
5. Each library branch has at least 10 book titles, and at least two copies of each of those titles.
6. There are at least 8 borrowers in the BORROWER table, and at least 2 of those borrowers have more
than 5 books loaned to them.
7. There are at least 4 branches in the LIBRARY_BRANCH table.
8. There are at least 50 loans in the BOOK_LOANS table.
9. There must be at least one book written by 'Stephen King'

Next, query the following:

1. How many copies of the book titled The Lost Tribe are owned by the library branch whose name
is"Sharpstown"?
2. How many copies of the book titled The Lost Tribe are owned by each library branch?
3. Retrieve the names of all borrowers who do not have any books checked out.
4. For each book that is loaned out from the "Sharpstown" branch and whose DueDate is today,
retrieve the book title, the borrower's name, and the borrower's address.
5. For each library branch, retrieve the branch name and the total number of books loaned out from
that branch.
6. Retrieve the names, addresses, and number of books checked out for all borrowers who have more
than five books checked out.
7. For each book authored (or co-authored) by "Stephen King", retrieve the title and the number of
copies owned by the library branch whose name is "Central"

Next, create a stored procedure:

Then create at least one stored procedure (two or more) based from above queries.

Solution:

* Create database
* Create tables with columns (make sure to add keys like Primary Keys, auto increment according to SQL standards)
  *Book: BookId, Title, PublisherName
  *Book_Authors: BookId, AuthorName
  *Publisher: Name, Address, Phone
  *Book_Copies: BookId, BranchId, No_Of_Copies
  *Book_Loans: BookId, BranchId, CardNo, DateOut, DueDate
  *Library_Branch: BranchId, BranchName, Address
  *Borrower: CardNo, Name, Address, Phone
* Insert records according to the requirements above
* Run queries as per above's requirements
* Create a stored procedure

Implementation:

1. Run the "generatedbscript.sql" which will create the dB, tables, columns, keys and records
2. Run each queries against the database (see query-**.sql)
3. Create and run stored procedure (see stored-procedure.sql)
