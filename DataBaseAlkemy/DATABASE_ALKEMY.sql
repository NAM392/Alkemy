USE [Alkemy]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/5/2021 11:57:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[courseId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Credits] [int] NOT NULL,
	[maximum_quantity_students] [int] NOT NULL,
	[professorId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[courseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inscription]    Script Date: 2/5/2021 11:57:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscription](
	[inscriptionID] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [int] NOT NULL,
	[courseId] [int] NOT NULL,
 CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED 
(
	[inscriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 2/5/2021 11:57:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[loginid] [int] IDENTITY(1,1) NOT NULL,
	[master_user] [nvarchar](max) NULL,
	[pass_] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[loginid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 2/5/2021 11:57:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[professorId] [int] IDENTITY(1,1) NOT NULL,
	[dni] [int] NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[Age] [int] NOT NULL,
	[active] [int] NOT NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[professorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2/5/2021 11:57:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[studentId] [int] IDENTITY(1,1) NOT NULL,
	[dni] [int] NOT NULL,
	[file] [int] NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[Age] [int] NOT NULL,
	[active] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[studentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Professor_professorId] FOREIGN KEY([professorId])
REFERENCES [dbo].[Professor] ([professorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Professor_professorId]
GO
ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Course_courseId] FOREIGN KEY([courseId])
REFERENCES [dbo].[Course] ([courseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Course_courseId]
GO
ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Student_studentId] FOREIGN KEY([studentId])
REFERENCES [dbo].[Student] ([studentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Student_studentId]
GO
