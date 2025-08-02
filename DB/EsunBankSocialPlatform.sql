USE master;
DROP DATABASE IF EXISTS SocialPlatformDB;
CREATE DATABASE SocialPlatformDB;
GO

USE SocialPlatformDB;

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    PhoneNumber NVARCHAR(20) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
	UserName NVARCHAR(256) NOT NULL,
	Email NVARCHAR(256) NOT NULL,
	Biography NVARCHAR(256) NOT NULL,
    CreatedTime DATETIME DEFAULT GETDATE()
);

CREATE TABLE Posts (
    PostId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    Title NVARCHAR(100),
    Content NVARCHAR(MAX),
    CreatedTime DATETIME DEFAULT GETDATE()
);

CREATE TABLE Comments (
    CommentId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    PostId INT FOREIGN KEY REFERENCES Posts(PostId),
    Content NVARCHAR(MAX),
    CreatedTime DATETIME DEFAULT GETDATE()
);
GO

-- 新增使用者
CREATE PROCEDURE AddUser
    @PhoneNumber NVARCHAR(20),
    @PasswordHash NVARCHAR(256),
    @UserName NVARCHAR(256),
    @Email NVARCHAR(256),
    @Biography NVARCHAR(256)
AS
BEGIN
    INSERT INTO Users (PhoneNumber, PasswordHash, UserName, Email, Biography)
    VALUES (@PhoneNumber, @PasswordHash, @UserName, @Email, @Biography);
END
GO

-- 取得使用者
CREATE PROCEDURE GetUserByPhone
    @PhoneNumber NVARCHAR(20)
AS
BEGIN
    SELECT TOP 1 
		UserId, 
		PhoneNumber, 
		PasswordHash
    FROM Users
    WHERE PhoneNumber = @PhoneNumber;
END
GO

-- 取得最新五筆發文
CREATE PROCEDURE GetLatestFivePosts
AS
BEGIN
    SELECT TOP 5 
        P.PostId,
        P.Title,
		U.UserId,
        U.UserName,
        P.CreatedTime
    FROM Posts P
    INNER JOIN Users U ON P.UserId = U.UserId
    ORDER BY P.CreatedTime DESC;
END
GO

-- 取得所有發文
CREATE PROCEDURE GetAllPosts
AS
BEGIN
    SELECT 
		P.PostId, 
		P.Title,
		U.UserId,
		U.UserName,
		P.Content, 
		P.CreatedTime
    FROM Posts P
    JOIN Users U ON P.UserId = U.UserId
    ORDER BY P.CreatedTime DESC;
END
GO

-- 取得發文詳情
CREATE PROCEDURE GetPostById
    @PostId INT
AS
BEGIN
    SELECT 
        P.PostId,
        P.Title,
        P.Content,
		U.UserId,
        U.UserName,
        P.CreatedTime
    FROM Posts P
    INNER JOIN Users U ON P.UserId = U.UserId
    WHERE P.PostId = @PostId;
END
GO

-- 新增發文
CREATE PROCEDURE CreatePost
    @UserId INT,
    @Title NVARCHAR(100),
    @Content NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Posts (UserId, Title, Content)
    VALUES (@UserId, @Title, @Content);
END