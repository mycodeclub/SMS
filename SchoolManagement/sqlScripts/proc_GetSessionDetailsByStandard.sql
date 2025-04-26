--exec GetSessionDetailsByStandard 0
-- select * from Standards
IF OBJECT_ID('GetSessionDetailsByStandard', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE GetSessionDetailsByStandard;
END
GO

CREATE PROCEDURE GetSessionDetailsByStandard
    @StandardId INT
AS
BEGIN
    SELECT 
        c.UniqueId as StandardId,
        sy.SessionName,
        sy.StartDate,
        sy.EndDate,
        c.StandardName,
        c.FeeAmountPerMonth,
        c.BillingCycle,
        COUNT(s.UniqueId) AS StudentCount
    FROM 
        Students s
    INNER JOIN 
        SessionYears sy ON sy.UniqueId = s.SessionYearId
    INNER JOIN 
        Standards c ON s.StandardId = c.UniqueId
    WHERE 
      (@StandardId = 0 OR  s.StandardId = @StandardId)
        AND s.IsDeleted = 0 -- Only active students
    GROUP BY 
        sy.SessionName, sy.StartDate, sy.EndDate, c.StandardName, c.UniqueId, c.FeeAmountPerMonth, c.BillingCycle
    ORDER BY 
        sy.StartDate;
END
GO
