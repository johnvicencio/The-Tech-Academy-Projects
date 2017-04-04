--The stored procedure has two parameters so that users can search for the book title
--or that resembles the title using the LIKE pattern
--Parameters will look for Book Title and BranchName (but that if there was no entry, all books searched will return all branches)

CREATE PROCEDURE spFindNoOfCopiesOfBookTitleInWhatBranch @BookTitle varchar(200), @BranchName varchar(200) = NULL
AS
  SELECT b.Title, lb.BranchName, bc.No_Of_Copies
  FROM Book b
  INNER JOIN Book_Copies bc ON b.BookId = bc.BookId
  INNER JOIN Library_Branch lb ON bc.BranchId = lb.BranchId
  WHERE b.Title LIKE '%' + @BookTitle + '%' AND BranchName = ISNULL(@BranchName, BranchName)
GO


--Now you can call the stored procedure with these samples
--Make sure to uncomment where you see 'EXEC' and enter one or two parameters accordingly

--Example1: Search for any book with 'A' in it at Sharpstown branch
--EXEC spFindNoOfCopiesOfBookTitleInWhatBranch 'A', 'Sharpstown'


--Example1: Search for any book with 'A' on any branch 
--EXEC spFindNoOfCopiesOfBookTitleInWhatBranch 'A'
