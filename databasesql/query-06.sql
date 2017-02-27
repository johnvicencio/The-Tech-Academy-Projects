--6. Retrieve the names, addresses, and number of books checked out for all borrowers who have more than five books checked out.

SELECT bor.CardNo, bor.Name, bor.Address, COUNT(bl.DateOut) AS [No. Books Checked Out]
FROM Borrower bor
INNER JOIN Book_Loans bl
ON bor.CardNo = bl.CardNo
GROUP BY bor.CardNo, bor.Name, bor.Address
HAVING COUNT(bl.DateOut) > 5
