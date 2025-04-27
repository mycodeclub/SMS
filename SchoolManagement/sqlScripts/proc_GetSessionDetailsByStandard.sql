-- exec GetSessionDetailsByStandard 2,0 
IF OBJECT_ID('GetSessionDetailsByStandard', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE GetSessionDetailsByStandard;
END
GO

CREATE PROCEDURE GetSessionDetailsByStandard
    @SessionId INT, -- new required parameter
    @StandardId INT  -- optional parameter
AS
BEGIN
    -- Check if SessionId is 0, raise an error
    IF (@SessionId = 0)
    BEGIN
        RAISERROR ('SessionId is required and cannot be zero.', 16, 1);
        RETURN;
    END

    SELECT 
        c.UniqueId AS StandardId,
        s.SessionYearId AS SessionId,
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
        s.SessionYearId = @SessionId -- Required Session filter
        AND (@StandardId = 0 OR s.StandardId = @StandardId)
        AND s.IsDeleted = 0 -- Only active students
    GROUP BY 
        sy.SessionName, sy.StartDate, sy.EndDate, c.StandardName, c.UniqueId, c.FeeAmountPerMonth, c.BillingCycle,s.SessionYearId
    ORDER BY 
        sy.StartDate;
END
GO
