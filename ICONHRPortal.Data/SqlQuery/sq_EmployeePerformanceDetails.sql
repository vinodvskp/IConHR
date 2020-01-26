USE [ICONHR]
GO
/****** Object:  StoredProcedure [dbo].[Get_PerformaceDetails]    Script Date: 09/04/2019 11:43:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE  [dbo].[Get_PerformaceDetails] (@pAsEmpId int, @pAsRepMgrId int =null, @pAsPerformaceReviewId int )
As 

BEGIN

SELECT * INTO #TEMP FROM (
  select   a.EMPID,
           d.EmpName,
 a.RepMgrID,
  a.PerformanceReviewID,
          b.segmentid,
 f.SegmentName,
 f.SegmentDescription,
  c.QuestionID,
   g.Question,
c.Answer ,
c.ScoreID,
h.RatingValue

        from [tblEmpPerReviewPerformance] a
  INNER JOIN tblEmpPerReviewSegment b on a.[EmpReviewID]=b.[EmpReviewID]
  INNER JOIN tblEmpPerReviewRating c on  c.EmpReviewSegmentID=b.EmpReviewSegmentID
  LEFT JOIN  tblEmployeeDetails d on d.EmpID=a.empid
  LEFT JOIN tblEmployeeJobDetails e on e.RepMgrID=a.repMgrId
           INNER JOIN tblPerformanceSegment f on f.PerformanceSegmentID=b.SegmentID
  INNER JOIN tblPerformaceSegmentQuestions g on  g.PerformanceQuestionID=c.QuestionID
  INNER JOIN tblPerformanceScore h on  h.ScoreID=c.ScoreID)   AS A


    IF (@pAsRepMgrId !=NULL)
BEGIN 

    SELECT distinct * FROM #TEMP WHERE RepMgrID= @pAsRepMgrId AND  PerformanceReviewID=@pAsPerformaceReviewId
END

ELSE 
   BEGIN
  SELECT distinct * FROM #TEMP WHERE EMPID= @pAsEmpId AND  PerformanceReviewID=@pAsPerformaceReviewId 
END


END	 