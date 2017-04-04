--3. Retrieve the names of all borrowers who do not have any books checked out.

SELECT b.CardNo, b.Name, b.Address, b.Phone, bl.DateOut
FROM Borrower b
INNER JOIN Book_Loans bl
ON b.CardNo = bl.CardNo
WHERE bl.DateOut IS NULL
