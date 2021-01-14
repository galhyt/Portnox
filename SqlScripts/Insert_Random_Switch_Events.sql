USE [Portnox]
GO

/****** Object:  StoredProcedure [dbo].[Insert_Random_Switch_Events]    Script Date: 1/14/2021 10:15:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Random_Switch_Events]
	-- Add the parameters for the stored procedure here
	@Number_Of_Records int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @Switch_Ips_Tbl Table(Id int identity(1,1), Switch_Ip nvarchar(20))
	insert into @Switch_Ips_Tbl(Switch_Ip)
	select '1.1.1.1'
	union select '192.168.1.1'
	union select '192.168.1.2'
	union select '192.168.1.3'
	union select '192.168.1.4'
	union select '192.168.1.5'

	Declare @Device_Mac_Tbl Table(Id int identity(1,1), Device_Mac Nvarchar(50))
	insert into @Device_Mac_Tbl(Device_Mac)
	select 'AABBCC000001'
	union select 'AABBCC000002'
	union select 'AABBCC000003'
	union select 'AABBCC000004'
	union select 'AABBCC000005'
	union select 'AABBCC000006'

	DECLARE @i INT = 0;

	WHILE @i < @Number_Of_Records
	BEGIN
		declare @Event_Id int, @Switch_Ip nvarchar(20), @Port_Id int, @Device_Mac nvarchar(50)
		set @Event_Id=FLOOR(RAND()*3+1)
		
		select @Switch_Ip=Switch_Ip
		from @Switch_Ips_Tbl
		where Id=FLOOR(RAND()*6+1)

		set @Port_Id = FLOOR(RAND()*90+10)

		select @Device_Mac=Device_Mac
		from @Device_Mac_Tbl
		where Id=FLOOR(RAND()*6+1)

		insert into Switch_Events
		select @Event_Id, @Switch_Ip, @Port_Id, @Device_Mac
		
		SET @i = @i + 1;
	END;
END
GO


