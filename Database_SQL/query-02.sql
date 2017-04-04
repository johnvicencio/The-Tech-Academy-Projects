--2. How many copies of the book titled The Lost Tribe are owned by each library branch?
--Assuming that the database used is correct if not do 'USE Library', then 'GO' to be sure

SELECT b.Title, lb.BranchName, bc.No_Of_Copies
FROM Book b
INNER JOIN Book_Copies bc ON b.BookId = bc.BookId
INNER JOIN Library_Branch lb ON bc.BranchId = lb.BranchId
WHERE b.Title = 'The Lost Tribe'
