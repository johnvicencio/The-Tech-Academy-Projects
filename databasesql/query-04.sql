--4. For each book that is loaned out from the "Sharpstown" branch and whose DueDate is today, retrieve the book title, the borrower's name, and the borrower's address.
--Assuming that '2017-02-26' is 'today'

SELECT b.Title, bor.Name, bor.Address, bl.DueDate
FROM Book b
INNER JOIN Book_Copies bc ON b.BookId = bc.BookId
INNER JOIN Library_Branch lb ON bc.BranchId = lb.BranchId
INNER JOIN Book_Loans bl ON b.BookId = bl.BookId
INNER JOIN Borrower bor ON bor.CardNo = bl.CardNo
WHERE lb.BranchName = 'Sharpstown' AND bl.DueDate= '2017-02-26'
