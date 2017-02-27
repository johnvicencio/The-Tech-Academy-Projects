--7. For each book authored (or co-authored) by "Stephen King", retrieve the title and the number of copies owned by the library branch whose name is "Central"

SELECT lb.BranchName, SUM(No_Of_Copies) AS [No. of Book Copies]
FROM Book_Authors ba INNER JOIN Book bk ON ba.BookId = bk.BookId
INNER JOIN Book_Copies bc ON bc.BookId = bk.BookId
INNER JOIN Library_Branch lb ON bc.BranchId = lb.BranchId
GROUP BY lb.BranchName
HAVING lb.BranchName = 'Central'
