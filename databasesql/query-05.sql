--5. For each library branch, retrieve the branch name and the total number of books loaned out from that branch.

SELECT lb.BranchName, COUNT(bl.DateOut) AS [No. of Checked Out]
FROM Library_Branch lb
INNER JOIN Book_Loans bl
ON lb.BranchId = bl.BranchId
GROUP BY lb.BranchName
HAVING COUNT(bl.DateOut) > 0
