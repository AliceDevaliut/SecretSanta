CREATE TABLE [Event] (
	[id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[name] nvarchar(max) NOT NULL,
	[start_date] date NOT NULL,
	[end_date] date NOT NULL,
	[new_field] decimal(18,0) NOT NULL,
	PRIMARY KEY ([id])
);

CREATE TABLE [User] (
	[id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[event_id] int NOT NULL,
	[name] nvarchar(max) NOT NULL,
	[email] nvarchar(max) NOT NULL UNIQUE,
	[telegram] nvarchar(max) UNIQUE,
	[wishlist] nvarchar(max) NOT NULL,
	PRIMARY KEY ([id])
);

CREATE TABLE [Gift] (
	[id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[user_id] int NOT NULL,
	[description] nvarchar(max) NOT NULL,
	PRIMARY KEY ([id])
);

CREATE TABLE [Draw] (
	[id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[event_id] int NOT NULL,
	[giver_id] int NOT NULL,
	[receiver_id] int NOT NULL,
	PRIMARY KEY ([id])
);

CREATE TABLE [Notification] (
	[id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[event_id] int NOT NULL,
	[user_id] int,
	[notification_type] nvarchar(max) NOT NULL,
	[status] bit NOT NULL,
	[sent] rowversion,
	PRIMARY KEY ([id])
);

CREATE TABLE [ForbiddenPairs] (
	[id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[event_id] int NOT NULL,
	[user1_id] int NOT NULL,
	[user2_id] int NOT NULL,
	[reason] nvarchar(max),
	PRIMARY KEY ([id])
);


ALTER TABLE [User] ADD CONSTRAINT [User_fk1] FOREIGN KEY ([event_id]) REFERENCES [Event]([id]);
ALTER TABLE [Gift] ADD CONSTRAINT [Gift_fk1] FOREIGN KEY ([user_id]) REFERENCES [User]([id]);
ALTER TABLE [Draw] ADD CONSTRAINT [Draw_fk1] FOREIGN KEY ([event_id]) REFERENCES [Event]([id]);

ALTER TABLE [Draw] ADD CONSTRAINT [Draw_fk2] FOREIGN KEY ([giver_id]) REFERENCES [User]([id]);

ALTER TABLE [Draw] ADD CONSTRAINT [Draw_fk3] FOREIGN KEY ([receiver_id]) REFERENCES [User]([id]);
ALTER TABLE [Notification] ADD CONSTRAINT [Notification_fk1] FOREIGN KEY ([event_id]) REFERENCES [Event]([id]);

ALTER TABLE [Notification] ADD CONSTRAINT [Notification_fk2] FOREIGN KEY ([user_id]) REFERENCES [User]([id]);
ALTER TABLE [ForbiddenPairs] ADD CONSTRAINT [ForbiddenPairs_fk1] FOREIGN KEY ([event_id]) REFERENCES [Event]([id]);

ALTER TABLE [ForbiddenPairs] ADD CONSTRAINT [ForbiddenPairs_fk2] FOREIGN KEY ([user1_id]) REFERENCES [User]([id]);

ALTER TABLE [ForbiddenPairs] ADD CONSTRAINT [ForbiddenPairs_fk3] FOREIGN KEY ([user2_id]) REFERENCES [User]([id]);