CREATE TABLE [tempdb].[dbo].[package_item_remote] (
	[id] int,
	[package_id] int,
	[uri] nvarchar(255),
	recurrence_id int,
	CONSTRAINT [package_item_remote_id] PRIMARY KEY ([id]) 
);

CREATE TABLE [tempdb].[dbo].[recurrence] (
	[id] int,
	CONSTRAINT [Recurrence_PrimaryKey_0] PRIMARY KEY ([id]) 
);

CREATE TABLE [tempdb].[dbo].[rule] (
	[id] int,
	[recurrence_id] int,
	[creation_date] datetime NOT NULL ,
	[first_day_of_week] nvarchar (255) NOT NULL ,
	[is_leap_year] bit NOT NULL ,
	[leap_month_value] int NOT NULL ,
	[window_end] datetime NOT NULL ,
	[repeat_forever] bit NOT NULL ,
	[repeat_instances] int NOT NULL ,
	CONSTRAINT [CEN_rule_0] CHECK ([first_day_of_week] IN ('su','mo','tu','we','th','fr','sa' )),
	CONSTRAINT [CMM_rule_1] CHECK ( [leap_month_value] >= 1 AND [leap_month_value] <= 13) ,
	CONSTRAINT [rule_PrimaryKey_0] PRIMARY KEY ([id]) 
);

CREATE TABLE [tempdb].[dbo].[repeat] (
	[id] int,
	[rule_id] int,
	CONSTRAINT [repeat_PrimaryKey_0] PRIMARY KEY ([id]) 
);

CREATE TABLE [tempdb].[dbo].[daily] (
	[repeat_id] int,
	[dayFrequency] int NOT NULL
);

CREATE TABLE [tempdb].[dbo].[weekly] (
	[repeat_id] int,
	[su] bit,
	[mo] bit,
	[tu] bit,
	[we] bit,
	[th] bit,
	[fr] bit,
	[sa] bit,
	[weekFrequency] int
);

CREATE TABLE [tempdb].[dbo].[monthly_by_day] (
	[repeat_id] int,
	[su] bit,
	[mo] bit,
	[tu] bit,
	[we] bit,
	[th] bit,
	[fr] bit,
	[sa] bit,
	[month_frequency] int,
	[week_day_of_month] nvarchar (255) NOT NULL ,
	CONSTRAINT [CEN_monthlyByDay_2] CHECK ([week_day_of_month] IN ('first','second','third','fourth','last' ))
);

CREATE TABLE [tempdb].[dbo].[monthly] (
	[repeat_id] int,
	[month_frequency] int,
	[day] int NOT NULL ,
	[force_exact] bit,
	CONSTRAINT [CMM_monthly_3] CHECK ( [day] >= 1 AND [day] <= 31) 
);

CREATE TABLE [tempdb].[dbo].[yearly_by_day] (
	[repeat_id] int,
	[su] bit,
	[mo] bit,
	[tu] bit,
	[we] bit,
	[th] bit,
	[fr] bit,
	[sa] bit,
	[year_frequency] int,
	[weekday_of_month] nvarchar (255) NOT NULL ,
	[month] int NOT NULL ,
	CONSTRAINT [CEN_yearlyByDay_4] CHECK ([weekday_of_month] IN ('first','second','third','fourth','last' )),
	CONSTRAINT [CMM_yearlyByDay_5] CHECK ( [month] >= 1 AND [month] <= 13) 
);

CREATE TABLE [tempdb].[dbo].[yearly] (
	[repeat_id] int,
	[year_frequency] int,
	[month] int NOT NULL ,
	[day] int NOT NULL ,
	[force_exact] bit,
	CONSTRAINT [CMM_yearly_6] CHECK ( [month] >= 1 AND [month] <= 13) ,
	CONSTRAINT [CMM_yearly_7] CHECK ( [day] >= 1 AND [day] <= 31) 
);

ALTER TABLE [tempdb].[dbo].[daily] 
	ADD     CONSTRAINT [daily_ForeignKey_0_8] FOREIGN KEY ([repeat_id]) REFERENCES [tempdb].[dbo].[repeat] ([id]);

ALTER TABLE [tempdb].[dbo].[weekly] 
	ADD     CONSTRAINT [weekly_ForeignKey_0_9] FOREIGN KEY ([repeat_id]) REFERENCES [tempdb].[dbo].[repeat] ([id]);

ALTER TABLE [tempdb].[dbo].[monthly_by_day] 
	ADD     CONSTRAINT [monthlyByDay_ForeignKey_0_10] FOREIGN KEY ([repeat_id]) REFERENCES [tempdb].[dbo].[repeat] ([id]);

ALTER TABLE [tempdb].[dbo].[monthly] 
	ADD     CONSTRAINT [monthly_ForeignKey_0_11] FOREIGN KEY ([repeat_id]) REFERENCES [tempdb].[dbo].[repeat] ([id]);

ALTER TABLE [tempdb].[dbo].[yearly_by_day] 
	ADD     CONSTRAINT [yearlyByDay_ForeignKey_0_12] FOREIGN KEY ([repeat_id]) REFERENCES [tempdb].[dbo].[repeat] ([id]);

ALTER TABLE [tempdb].[dbo].[yearly] 
	ADD     CONSTRAINT [yearly_ForeignKey_0_13] FOREIGN KEY ([repeat_id]) REFERENCES [tempdb].[dbo].[repeat] ([id]);

ALTER TABLE [tempdb].[dbo].[repeat] 
	ADD     CONSTRAINT [repeat_ForeignKey_1_14] FOREIGN KEY ([rule_id]) REFERENCES [tempdb].[dbo].[rule] ([id]);

ALTER TABLE [tempdb].[dbo].[rule] 
	ADD     CONSTRAINT [rule_ForeignKey_1_15] FOREIGN KEY ([recurrence_id]) REFERENCES [tempdb].[dbo].[recurrence] ([id]);
