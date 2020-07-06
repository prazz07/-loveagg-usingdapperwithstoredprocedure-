USE [HRDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Student]
  @StudentId varchar(50)
  ,@Name varchar(MAX)
  ,@Roll varchar (6)
  ,@OperationType int
AS
BEGIN TRAN
   IF (@OperationType  =1)--insert
   BEGIN
          SET @StudentId=(SELECT COUNT(*) FROM Student)+1
          Insert into Student (StudentId,[Name],Roll)
             VALUES(@StudentId,@Name,@Roll)

          SELECT * FROM Student WHERE StudentId=@StudentId
  END

  ELSE IF(@OperationType=2) --Update
  BEGIN
     IF(@StudentId=0)
           BEGIN
              ROLLBACK
                  RAISERROR(N'Invalid Student !!!~',16,1);
              RETURN
           END


           UPDATE Student SET[Name] =@Name
                               ,Roll=@Roll
                        WHERE StudentId=@StudentId
          SELECT * FROM Student WHERE StudentId=@StudentId
        END
  ELSE IF(@OperationType=3) --DELETE
  BEGIN
     IF(@StudentId=0)
     BEGIN
         ROLLBACK
             RAISERROR(N'Invalid Student!!!~',16,1);
        RETURN
    END

    DELETE FROM Student WHERE StudentId=@StudentId
  END
COMMIT TRAN


