-- exec GetSessionDetailsByStandard 1,1
 -- select * from Standards

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

    -- Get session details
    SELECT 
        c.UniqueId AS StandardId,
        sy.UniqueId AS SessionId,
        sy.SessionName,
        sy.StartDate,
        sy.EndDate,
        c.StandardName,
        c.FeeAmountPerMonth,
        c.BillingCycle,
        ISNULL(COUNT(s.UniqueId), 0) AS StudentCount
    FROM 
        Standards c
    CROSS JOIN 
        SessionYears sy
    LEFT JOIN 
        Students s ON s.StandardId = c.UniqueId 
        AND s.SessionYearId = sy.UniqueId 
        AND s.IsDeleted = 0
    WHERE 
        sy.UniqueId = @SessionId
        AND (@StandardId = 0 OR c.UniqueId = @StandardId)
    GROUP BY 
        sy.SessionName, 
        sy.StartDate, 
        sy.EndDate, 
        c.StandardName, 
        c.UniqueId, 
        c.FeeAmountPerMonth, 
        c.BillingCycle,
        sy.UniqueId
    ORDER BY 
        c.StandardName;
END
GO
