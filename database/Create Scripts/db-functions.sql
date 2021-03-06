/****** Object:  UserDefinedFunction [dbo].[iqFindSubscriptionCountByService]    Script Date: 01/25/2007 22:18:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqFindSubscriptionCountByService]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[iqFindSubscriptionCountByService]
GO
/****** Object:  UserDefinedFunction [dbo].[iqGetShapesByScopeAsString]    Script Date: 01/25/2007 22:18:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqGetShapesByScopeAsString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[iqGetShapesByScopeAsString]
GO
/****** Object:  UserDefinedFunction [dbo].[iqGetMethodsByRoleTemplateAsString]    Script Date: 01/25/2007 22:18:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqGetMethodsByRoleTemplateAsString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[iqGetMethodsByRoleTemplateAsString]
GO
/****** Object:  UserDefinedFunction [dbo].[iqFindSubscriptionCountByService]    Script Date: 01/25/2007 22:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqFindSubscriptionCountByService]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[iqFindSubscriptionCountByService] (
	@service_id int
)

RETURNS int

AS

BEGIN

	DECLARE @cnt int

	SELECT @cnt = count(*) FROM subscription WHERE service_id = @service_id

	RETURN @cnt

END

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[iqGetShapesByScopeAsString]    Script Date: 01/25/2007 22:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqGetShapesByScopeAsString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION dbo.iqGetShapesByScopeAsString (
	@scope_id int
)

RETURNS nvarchar(2048)

AS 
	
BEGIN

	DECLARE @output nvarchar(2048), @select nvarchar(128), @type nchar(1)
	
	DECLARE csr CURSOR FOR
		SELECT
			[select],
			type
		FROM
			shape
		WHERE
			scope_id = @scope_id
		
	OPEN csr
	
	FETCH NEXT FROM csr INTO @select, @type
	
	SET @output = '''' 

	-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
	WHILE (@@FETCH_STATUS = 0) BEGIN
		
		IF (@type = ''I'') BEGIN
			SET @output = @output + ''<span class="include">'' + @select + ''</span>''
		END
		
		IF (@type = ''E'') BEGIN
			SET @output = @output + ''<span class="exclude">'' + @select + ''</span>''
		END
		
		SET @output = @output + '', ''
		
		-- This is executed as long as the previous fetch succeeds.
		FETCH NEXT FROM csr INTO @select, @type
	END

	CLOSE csr
	DEALLOCATE csr
	
	IF (LEN(@output) > 2) BEGIN
		SET @output = LEFT(@output, LEN(@output) - 1)
	END
	
	IF (LEN(@output) = 0) BEGIN
		SET @output = ''-''
	END
	
	RETURN @output

END' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[iqGetMethodsByRoleTemplateAsString]    Script Date: 01/25/2007 22:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqGetMethodsByRoleTemplateAsString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION dbo.iqGetMethodsByRoleTemplateAsString (
	@role_template_id int
)

RETURNS nvarchar(2048)

AS 
	
BEGIN

	DECLARE @output nvarchar(2048), @name nvarchar(64)
	
	DECLARE csr CURSOR FOR
		SELECT
			mt.name
		FROM
			role_template_method rtm,
			method_type mt
		WHERE
			rtm.role_template_id = @role_template_id
		AND
			mt.id = rtm.method_type_id
		ORDER BY
			mt.name
		
	OPEN csr
	
	FETCH NEXT FROM csr INTO @name
	
	SET @output = ''''

	-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
	WHILE (@@FETCH_STATUS = 0) BEGIN
		
		SET @output = @output + ''<span class="rtm">'' + @name + ''</span>'' + '', ''
		
		-- This is executed as long as the previous fetch succeeds.
		FETCH NEXT FROM csr INTO @name
	END

	CLOSE csr
	DEALLOCATE csr		
	
	IF (LEN(@output) > 2) BEGIN
		SET @output = LEFT(@output, LEN(@output) - 1)
	END
	
	IF (LEN(@output) = 0) BEGIN
		SET @output = ''-''
	END
	
	RETURN @output

END' 
END

GO
