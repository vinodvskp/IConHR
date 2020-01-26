USE [ICONHR]
GO
/****** Object:  StoredProcedure [dbo].[Get_MgrPerformaceDetails]    Script Date: 09/09/2019 6:24:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [dbo].[Get_MgrPerformaceDetails] (@pAsEmpId int, @pAsRepMgrId int =null, @pAsPerformaceReviewId int )
As 

BEGIN

SELECT * INTO #TEMP FROM (
  select   a.EMPID,
           d.EmpName,
 a.RepMgrID,
  a.PerformanceReviewID,
          b.PerformanceSegmentID as segmentid,
 f.SegmentName,
 f.SegmentDescription,
  c.PerformanceQuestionID as QuestionID,
   g.Question,
c.Answer ,
c.ScoreID,
h.RatingValue

        from [tblMgrPerReviewPerformance] a
  INNER JOIN tblMgrPerReviewSegment b on a.[MgrReviewID]=b.[MgrReviewID]
  INNER JOIN tblMgrPerReviewRating c on  c.MgrReviewSegmentID=b.MgrReviewSegmentID
  LEFT JOIN  tblEmployeeDetails d on d.EmpID=a.empid
  LEFT JOIN tblEmployeeJobDetails e on e.RepMgrID=a.repMgrId
           INNER JOIN tblPerformanceSegment f on f.PerformanceSegmentID=b.PerformanceSegmentID
  INNER JOIN tblPerformaceSegmentQuestions g on  g.PerformanceQuestionID=c.PerformanceQuestionID
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


