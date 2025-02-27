USE [master]
GO
/****** Object:  Database [IB_Math]    Script Date: 7/25/2022 10:14:06 PM ******/
CREATE DATABASE [IB_Math]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IB_Math', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\IB_Math.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IB_Math_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\IB_Math_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IB_Math] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IB_Math].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IB_Math] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IB_Math] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IB_Math] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IB_Math] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IB_Math] SET ARITHABORT OFF 
GO
ALTER DATABASE [IB_Math] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IB_Math] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IB_Math] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IB_Math] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IB_Math] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IB_Math] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IB_Math] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IB_Math] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IB_Math] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IB_Math] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IB_Math] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IB_Math] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IB_Math] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IB_Math] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IB_Math] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IB_Math] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IB_Math] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IB_Math] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IB_Math] SET  MULTI_USER 
GO
ALTER DATABASE [IB_Math] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IB_Math] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IB_Math] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IB_Math] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IB_Math] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IB_Math] SET QUERY_STORE = OFF
GO
USE [IB_Math]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 7/25/2022 10:14:06 PM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[CourseQueAns]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseQueAns](
	[CourseQueAns_id] [int] IDENTITY(1,1) NOT NULL,
	[Course_Que] [varchar](max) NOT NULL,
	[Course_Ans] [varchar](max) NOT NULL,
	[Course_id] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[CreatedBy] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[DeletedBy] [datetime] NULL,
 CONSTRAINT [PK_CourseQueAns] PRIMARY KEY CLUSTERED 
(
	[CourseQueAns_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Course_id] [int] IDENTITY(1,1) NOT NULL,
	[Course_name] [varchar](max) NOT NULL,
	[Course_concept] [varchar](max) NULL,
	[Course_files] [varchar](max) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[CreatedBy] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[DeletedBy] [datetime] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DaigtestAns]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaigtestAns](
	[DiagtestAns_id] [int] IDENTITY(1,1) NOT NULL,
	[Diagtest_Score] [varchar](max) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[CreatedBy] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[DeletedBy] [datetime] NULL,
	[student_id] [int] NULL,
	[Course_Id] [int] NULL,
 CONSTRAINT [PK_DaigtestQueAns] PRIMARY KEY CLUSTERED 
(
	[DiagtestAns_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiagnosticTest]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiagnosticTest](
	[Course_id] [int] NOT NULL,
	[Diagtest_id] [int] IDENTITY(1,1) NOT NULL,
	[Diagtest_name] [varchar](max) NOT NULL,
	[Diagtest_que] [varchar](max) NOT NULL,
	[Option1] [varchar](max) NOT NULL,
	[Option2] [varchar](max) NOT NULL,
	[Option3] [varchar](max) NOT NULL,
	[Option4] [varchar](max) NOT NULL,
	[Weightage] [int] NOT NULL,
	[CraetedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[CreatedBy] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[Deletedby] [datetime] NULL,
	[Diagtest_answer] [nvarchar](max) NULL,
	[QueType] [bit] NULL,
 CONSTRAINT [PK_DiagnosticTest] PRIMARY KEY CLUSTERED 
(
	[Diagtest_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Role_id] [int] IDENTITY(1,1) NOT NULL,
	[Role_name] [varchar](max) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[CreatedBy] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[DeletedBy] [datetime] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_id] [int] IDENTITY(1,1) NOT NULL,
	[User_name] [varchar](max) NULL,
	[User_password] [varchar](max) NOT NULL,
	[User_fname] [varchar](max) NOT NULL,
	[User_email] [varchar](max) NOT NULL,
	[User_age] [int] NOT NULL,
	[User_class] [varchar](max) NULL,
	[User_grade] [nvarchar](50) NULL,
	[User_academicposition] [varchar](max) NULL,
	[CreatedBy] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[DeletedBy] [datetime] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[User_Role] [varchar](max) NULL,
	[User_diagtestflag] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersCourses]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersCourses](
	[UsersCourses_id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [int] NOT NULL,
	[Course_id] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[CreatedBy] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[DeletedBy] [datetime] NULL,
 CONSTRAINT [PK_UsersCourses] PRIMARY KEY CLUSTERED 
(
	[UsersCourses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersDiagnostictest]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersDiagnostictest](
	[UsersDiagtest_id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [int] NOT NULL,
	[Diagtest_id] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[CreatedBy] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[DeletedBy] [datetime] NULL,
 CONSTRAINT [PK_UsersDiagnostictest] PRIMARY KEY CLUSTERED 
(
	[UsersDiagtest_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_DiagnosticTest]    Script Date: 7/25/2022 10:14:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_DiagnosticTest] ON [dbo].[DiagnosticTest]
(
	[Course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CourseQueAns]  WITH CHECK ADD  CONSTRAINT [FK_CourseQueAns_Courses] FOREIGN KEY([Course_id])
REFERENCES [dbo].[Courses] ([Course_id])
GO
ALTER TABLE [dbo].[CourseQueAns] CHECK CONSTRAINT [FK_CourseQueAns_Courses]
GO
ALTER TABLE [dbo].[DaigtestAns]  WITH CHECK ADD  CONSTRAINT [FK_DaigtestAns_Courses] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Courses] ([Course_id])
GO
ALTER TABLE [dbo].[DaigtestAns] CHECK CONSTRAINT [FK_DaigtestAns_Courses]
GO
ALTER TABLE [dbo].[DiagnosticTest]  WITH CHECK ADD  CONSTRAINT [FK_DiagnosticTest_DiagnosticTest] FOREIGN KEY([Diagtest_id])
REFERENCES [dbo].[DiagnosticTest] ([Diagtest_id])
GO
ALTER TABLE [dbo].[DiagnosticTest] CHECK CONSTRAINT [FK_DiagnosticTest_DiagnosticTest]
GO
ALTER TABLE [dbo].[DiagnosticTest]  WITH CHECK ADD  CONSTRAINT [FK_DiagnosticTest_DiagnosticTest1] FOREIGN KEY([Diagtest_id])
REFERENCES [dbo].[DiagnosticTest] ([Diagtest_id])
GO
ALTER TABLE [dbo].[DiagnosticTest] CHECK CONSTRAINT [FK_DiagnosticTest_DiagnosticTest1]
GO
ALTER TABLE [dbo].[DiagnosticTest]  WITH CHECK ADD  CONSTRAINT [FK_DiagnosticTest_DiagnosticTest2] FOREIGN KEY([Diagtest_id])
REFERENCES [dbo].[DiagnosticTest] ([Diagtest_id])
GO
ALTER TABLE [dbo].[DiagnosticTest] CHECK CONSTRAINT [FK_DiagnosticTest_DiagnosticTest2]
GO
ALTER TABLE [dbo].[UsersCourses]  WITH CHECK ADD  CONSTRAINT [FK_UsersCourses_Courses] FOREIGN KEY([Course_id])
REFERENCES [dbo].[Courses] ([Course_id])
GO
ALTER TABLE [dbo].[UsersCourses] CHECK CONSTRAINT [FK_UsersCourses_Courses]
GO
ALTER TABLE [dbo].[UsersCourses]  WITH CHECK ADD  CONSTRAINT [FK_UsersCourses_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([User_id])
GO
ALTER TABLE [dbo].[UsersCourses] CHECK CONSTRAINT [FK_UsersCourses_Users]
GO
ALTER TABLE [dbo].[UsersDiagnostictest]  WITH CHECK ADD  CONSTRAINT [FK_UsersDiagnostictest_DiagnosticTest] FOREIGN KEY([Diagtest_id])
REFERENCES [dbo].[DiagnosticTest] ([Diagtest_id])
GO
ALTER TABLE [dbo].[UsersDiagnostictest] CHECK CONSTRAINT [FK_UsersDiagnostictest_DiagnosticTest]
GO
ALTER TABLE [dbo].[UsersDiagnostictest]  WITH CHECK ADD  CONSTRAINT [FK_UsersDiagnostictest_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([User_id])
GO
ALTER TABLE [dbo].[UsersDiagnostictest] CHECK CONSTRAINT [FK_UsersDiagnostictest_Users]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStudentScore]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetStudentScore]
as 
begin

SELECT  SUM(Cast(Diagtest_Score as int)) as Score, C.Course_name,C.Course_id,U.User_fname
FROM DaigtestAns D  inner join Users U on d.student_id = U.User_id 
inner join Courses C on D.Course_Id = C.Course_id

Group by C.Course_name,C.Course_id,U.User_fname

 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStudentwiseScore]    Script Date: 7/25/2022 10:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetStudentwiseScore]

( 

 @inp_UserId int = null
)
as 
begin
SELECT  SUM(Cast(Diagtest_Score as int)) as Score,U.User_fname
FROM DaigtestAns D  inner join Users U on d.student_id = U.User_id
WHERE U.User_id = @inp_UserId
Group by U.User_fname
end
GO
USE [master]
GO
ALTER DATABASE [IB_Math] SET  READ_WRITE 
GO
