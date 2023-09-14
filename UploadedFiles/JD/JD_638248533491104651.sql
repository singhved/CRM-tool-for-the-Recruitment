

USE [Educare]
GO
/****** Object:  Table [dbo].[Degree]    Script Date: 07-07-2023 06:43:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Degree](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[University]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[University](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CandidateId] [int] NULL,
	[DegreeId] [int] NULL,
	[Specialization] [nvarchar](200) NULL,
	[UniversityId] [int] NULL,
	[SchoolName] [nvarchar](200) NULL,
	[StartDate] [date] NULL,
	[Enddate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EducationView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[EducationView]
as
select ed.Id,ed.CandidateId,ed.DegreeId,ed.Specialization,ed.UniversityId,ed.SchoolName,ed.StartDate,ed.Enddate,d.Name as Degree,u.Name as University from Education ed
left join Degree d on ed.DegreeId = d.Id
left join University u on ed.UniversityId = u.Id
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NULL,
	[LevelId] [int] NULL,
	[AffiliationId] [int] NULL,
	[Status] [bit] NULL,
	[SkillCode] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[SubjectCode] [nvarchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[LevelCode] [nvarchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Affiliation]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Affiliation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[AffiliationCode] [nvarchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SkillView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[SkillView]  
as  
select s.*,sb.Name as Subject,l.Name as Level,a.Name as Affiliation from Skill s  
left join Subject sb on s.SubjectId = sb.Id  
left join Level l on s.LevelId = l.Id  
left join Affiliation a on s.AffiliationId = a.Id  
GO
/****** Object:  Table [dbo].[ContactPerson]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[DesignationId] [int] NULL,
	[DepartmentId] [int] NULL,
	[Email] [nvarchar](100) NULL,
	[ContactNo] [nvarchar](15) NULL,
	[WhatsAppNo] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ContactPersonView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ContactPersonView]  
as  
  
select c.Id,c.ClientId,c.Name as ContactPerson,c.DepartmentId,c.DesignationId,c.Email,c.ContactNo,c.WhatsAppNo,d.Name as Department,ds.Name as Designation from ContactPerson c  
left join Department d on c.DepartmentId = d.Id  
left join Designation ds on c.DesignationId = ds.Id
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[ContactPersonId] [int] NULL,
	[SkillId] [int] NULL,
	[Title] [int] NULL,
	[Vacancies] [int] NULL,
	[Experience] [float] NULL,
	[Salary] [float] NULL,
	[Jd] [nvarchar](50) NULL,
	[Location] [nvarchar](2000) NULL,
	[JobSummary] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[Cdate] [date] NULL,
	[CTime] [nvarchar](20) NULL,
	[Recruiter] [int] NULL,
	[AllotedBy] [int] NULL,
	[AllotmentDate] [date] NULL,
	[AllotmentTime] [nvarchar](20) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Branch] [nvarchar](200) NULL,
	[ContactNo] [nvarchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](2000) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[City] [nvarchar](100) NULL,
	[Pincode] [int] NULL,
	[Website] [nvarchar](100) NULL,
	[Status] [bit] NULL,
	[BillingAddress] [nvarchar](2000) NULL,
	[BillingCountryId] [int] NULL,
	[BillingStateId] [int] NULL,
	[BillingCity] [nvarchar](100) NULL,
	[BillingPincode] [int] NULL,
	[BillingEmail] [nvarchar](100) NULL,
	[BillingPhoneNo] [nvarchar](15) NULL,
	[GSTNo] [nvarchar](20) NULL,
	[PaymentTermId] [int] NULL,
	[TAndC] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[ContactNo] [nvarchar](15) NULL,
	[WhatsappNo] [nvarchar](15) NULL,
	[DateOfJoining] [datetime] NULL,
	[EmpCode] [nvarchar](10) NULL,
	[Type] [int] NULL,
	[Division] [int] NULL,
	[DepartmentId] [int] NULL,
	[DesignationId] [int] NULL,
	[ProfilePicture] [nvarchar](100) NULL,
	[Address] [nvarchar](1000) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RequestsView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[RequestsView]
as
select r.Id,r.ClientId,r.ContactPersonId,r.SkillId,r.Title,r.Vacancies,r.Experience,r.Salary,r.Jd,r.Location,
r.JobSummary,r.CreatedBy,r.Cdate,r.CTime,r.Recruiter,r.AllotedBy,r.AllotmentDate,r.AllotmentTime,
c.Name as 'Client',c.Branch,c.Email,c.City,c.Website, ct.Name as 'ContactPerson', ct.Email as 'CPEmail',d1.Name as 'CPDesignation',
sk.SkillCode,l.Name as 'Level',sub.Name as 'Subject',aff.Name as 'Affiliation',d2.Name as 'TitleName',sp.Name as 'SalesPerson',
rec.Name as 'RecruiterName',rh.Name as 'RecruiterHead'
from Requests r
left join Client c on r.ClientId = c.Id
left join ContactPerson ct on r.ContactPersonId = ct.Id
left join Designation d1 on ct.DesignationId=d1.Id
left join Skill sk on r.SkillId = sk.Id
left join Level l on sk.LevelId=l.Id
left join Subject  sub on sk.SubjectId = sub.Id
left join Affiliation aff on sk.AffiliationId = aff.Id
left join Designation d2 on r.Title = d2.Id
left join Users sp on r.CreatedBy=sp.Id
left join Users rec on r.Recruiter=rec.Id
left join Users rh on r.Recruiter=rh.Id
GO
/****** Object:  Table [dbo].[RequestStatus]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Category] [int] NULL,
	[status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RequestStatusView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RequestStatusView]   
AS  
SELECT rs.Id, rs.Name, rs.Category,rs.status as StatusValue, CASE WHEN rs.Category = 0 THEN 'New' WHEN rs.Category = 1 THEN 'In Process' WHEN rs.Category = 2 THEN 'Hold' WHEN rs.Category = 3 THEN 'Won' WHEN rs.Category = 4 THEN 'Lost' END AS CategoryName,  
case when rs.status = 1 then 'Active' when rs.status = 0 then 'Inactive' END AS Status  
FROM RequestStatus rs;  
GO
/****** Object:  Table [dbo].[CandidateStatus]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Category] [int] NULL,
	[status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CandidateStatusView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CandidateStatusView] AS  
SELECT  
    cs.Id,  
    cs.Name,  
    cs.Category,  
 cs.status,  
    CASE  
        WHEN cs.Category = 0 THEN 'New'  
        WHEN cs.Category = 1 THEN 'In Process'  
  WHEN cs.Category = 2 THEN 'Hold'  
        WHEN cs.Category = 3 THEN 'Won'  
        WHEN cs.Category = 4 THEN 'Lost'  
    END AS CategoryName,  
 CASE  
  When cs.status = 0 then 'Inactive' when cs.status = 1 then 'Active' end as StatusName  
FROM  
    CandidateStatus cs; 
GO
/****** Object:  Table [dbo].[PaymentTerms]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentTerms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Days] [int] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ClientView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ClientView]  
as  
select cbd.*,c.Name as Country,cc.Name as BillingCountryName,pt.Name as PaymentTerms,st.Name as BillingStateName,s.Name as State from Client cbd  
left join Country c on cbd.CountryId =c.Id  
left join State s on cbd.StateId = s.Id  
left join Country cc on cbd.BillingCountryId = cc.Id
left join State st on cbd.BillingStateId = st.Id
left join PaymentTerms pt on cbd.PaymentTermId = pt.Id
GO
/****** Object:  View [dbo].[UsersView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[UsersView]
as
select u.*,d.Name as Department,ds.Name as Designation,Case when u.Type=0 then 'Admin' when u.Type=1 then 'Sub-Admin'
when u.Type=2 then 'User' end as 'TypeName', Case when u.Division=0 then 'Opration' when u.Division=1 then 'Sales' end as 'DivisionName',
case when u.Status=0 then 'Active' when u.Status=1 then 'Inactive' end as 'StatusName' from Users u
left join Department d on u.DepartmentId = d.Id
left join Designation ds on u.DesignationId = ds.Id
GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](15) NULL,
	[WhatsAppNo] [nvarchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[DOB] [date] NULL,
	[Address] [nvarchar](2000) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[City] [nvarchar](2000) NULL,
	[Pin] [int] NULL,
	[PrimarySkillId] [int] NULL,
	[SecondarySkilId] [int] NULL,
	[Resume] [nvarchar](100) NULL,
	[Experiance] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CandidateView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[CandidateView]  
as  
select cnd.Id,cnd.Name,cnd.MobileNo,cnd.WhatsAppNo,cnd.Email,cnd.DOB,cnd.Address,
cnd.CountryId,cnd.StateId,cnd.City,cnd.Pin,cnd.PrimarySkillId,cnd.SecondarySkilId,
cnd.Resume,cnd.Experiance,

c.Name as Country,s.Name as State,sk.SkillCode,sk2.SkillCode as 'SecondarySkillCode' from Candidate cnd  
left join Country c on cnd.CountryId = c.Id  
left join State s on cnd.StateId = s.Id  
left join Skill sk on cnd.PrimarySkillId = sk.Id
left join Skill sk2 on cnd.SecondarySkilId = sk2.Id
GO
/****** Object:  View [dbo].[StateView]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[StateView]
as
select s.*,c.Name as CountryName from State s
left join Country c on s.CountryId = c.Id
GO
/****** Object:  Table [dbo].[MappedCandidates]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MappedCandidates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NULL,
	[CandidateId] [int] NULL,
	[MappedBy] [int] NULL,
	[Status] [int] NULL,
	[Cdate] [datetime] NULL,
	[ApprovalBy] [int] NULL,
	[ApprovalDate] [datetime] NULL,
	[VideoLinkSent] [int] NULL,
	[Video] [nvarchar](50) NULL,
	[VidUploadDate] [datetime] NULL,
	[VidStatus] [int] NULL,
	[VidApprovalBy] [int] NULL,
	[VidSubmissions] [int] NULL,
	[SentToClient] [int] NULL,
	[ApprovedByClient] [int] NULL,
	[ClientApprovalDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkExperiance]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkExperiance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CandidateId] [int] NULL,
	[Organization] [nvarchar](500) NULL,
	[Designation] [nvarchar](200) NULL,
	[Startdate] [date] NULL,
	[Enddate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Affiliation] ON 
GO
INSERT [dbo].[Affiliation] ([Id], [Name], [Status], [AffiliationCode]) VALUES (32, N'ICSE', 1, N'IC')
GO
INSERT [dbo].[Affiliation] ([Id], [Name], [Status], [AffiliationCode]) VALUES (33, N'CBSE', 1, N'CB')
GO
SET IDENTITY_INSERT [dbo].[Affiliation] OFF
GO
SET IDENTITY_INSERT [dbo].[Candidate] ON 
GO
INSERT [dbo].[Candidate] ([Id], [Name], [MobileNo], [WhatsAppNo], [Email], [DOB], [Address], [CountryId], [StateId], [City], [Pin], [PrimarySkillId], [SecondarySkilId], [Resume], [Experiance]) VALUES (25, N'Ashutosh', N'732479817394', N'123498791734', N'ashutosh@gmail.com', CAST(N'2007-01-04' AS Date), N'Varanasi Uttar Pradesh', 10, 2, N'Varanasi', 221204, 4, 5, N'Resumes_638243361088534414.png', N'4 Yrs. 5 Month')
GO
SET IDENTITY_INSERT [dbo].[Candidate] OFF
GO
SET IDENTITY_INSERT [dbo].[CandidateStatus] ON 
GO
INSERT [dbo].[CandidateStatus] ([Id], [Name], [Category], [status]) VALUES (1, N'Video Interview Done', 1, 0)
GO
INSERT [dbo].[CandidateStatus] ([Id], [Name], [Category], [status]) VALUES (3, N'Screened', 1, 0)
GO
INSERT [dbo].[CandidateStatus] ([Id], [Name], [Category], [status]) VALUES (4, N'Shortlised', 0, 0)
GO
INSERT [dbo].[CandidateStatus] ([Id], [Name], [Category], [status]) VALUES (5, N'Client Interview WIP', 1, 0)
GO
INSERT [dbo].[CandidateStatus] ([Id], [Name], [Category], [status]) VALUES (6, N'Selected', 1, 0)
GO
INSERT [dbo].[CandidateStatus] ([Id], [Name], [Category], [status]) VALUES (7, N'Rejected', 4, 0)
GO
INSERT [dbo].[CandidateStatus] ([Id], [Name], [Category], [status]) VALUES (8, N'Pending', 1, 1)
GO
INSERT [dbo].[CandidateStatus] ([Id], [Name], [Category], [status]) VALUES (9, N'Joined', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[CandidateStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 
GO
INSERT [dbo].[Client] ([Id], [Name], [Branch], [ContactNo], [Email], [Address], [CountryId], [StateId], [City], [Pincode], [Website], [Status], [BillingAddress], [BillingCountryId], [BillingStateId], [BillingCity], [BillingPincode], [BillingEmail], [BillingPhoneNo], [GSTNo], [PaymentTermId], [TAndC]) VALUES (1, N'Rajveer Singh', N'Noida', N'987654788769', N'rajveersingh@mailinator.com', N'Noida  , Near Noida Electronic City Metro  H Block 28 ', 10, 3, N'Noida , Uttar Pradesh', 201310, N'https://www.degynybydywus.com', 1, N'Noida  , Near Noida Electronic City Metro  H Block 28 ', 10, 2, N'Noida , Uttar Pradesh', 201310, N'billing123@gmail.com', N'0987654345609', N'898679GGGFFFTT78878', 1, N'The business owner set out the rules for your products and services and help manage the expectations for you and your customers.  This type of agreement is also known as Terms of Use or Terms of Service, is an important agreement for all businesses, including small businesses.')
GO
INSERT [dbo].[Client] ([Id], [Name], [Branch], [ContactNo], [Email], [Address], [CountryId], [StateId], [City], [Pincode], [Website], [Status], [BillingAddress], [BillingCountryId], [BillingStateId], [BillingCity], [BillingPincode], [BillingEmail], [BillingPhoneNo], [GSTNo], [PaymentTermId], [TAndC]) VALUES (7, N'Orli Cunningham', N'Do tempore esse a e', N'9875498765477', N'rydyd@mailinator.com', N'Omnis et voluptas eu', 10, 2, N'Autem magnam corpori', 59, N'https://www.zobalilujet.ws', 1, N'Excepturi repellenduhhhh', 10, 2, N'Reiciendis id omnis', 726667878, N'gukixu@mailinator.com', N'9876543', N'Consectetur ut non ', 2, N'Fuga Nulla eos nob')
GO
INSERT [dbo].[Client] ([Id], [Name], [Branch], [ContactNo], [Email], [Address], [CountryId], [StateId], [City], [Pincode], [Website], [Status], [BillingAddress], [BillingCountryId], [BillingStateId], [BillingCity], [BillingPincode], [BillingEmail], [BillingPhoneNo], [GSTNo], [PaymentTermId], [TAndC]) VALUES (8, N'TETST', N'tetssss', N'9876588656887', N'ttt@gmail.com', N'kjhgf', 10, 2, N'HHHH', 222222, N'.......', 0, N'hhh', 10, 2, N'hh', 77777, N'g@mail.com', N'809808', N'8787hh', 2, N'h')
GO
INSERT [dbo].[Client] ([Id], [Name], [Branch], [ContactNo], [Email], [Address], [CountryId], [StateId], [City], [Pincode], [Website], [Status], [BillingAddress], [BillingCountryId], [BillingStateId], [BillingCity], [BillingPincode], [BillingEmail], [BillingPhoneNo], [GSTNo], [PaymentTermId], [TAndC]) VALUES (9, N'TETSTTS', N'tetssss', N'98768879865', N'ttt@gmail.com', N'kjhgf', 10, 13, N'HHHH', 222222, N'.......', 0, N'hhh', 10, 2, N'hh', 77777, N'g@mail.com', N'809808', N'8787', 2, N'b')
GO
INSERT [dbo].[Client] ([Id], [Name], [Branch], [ContactNo], [Email], [Address], [CountryId], [StateId], [City], [Pincode], [Website], [Status], [BillingAddress], [BillingCountryId], [BillingStateId], [BillingCity], [BillingPincode], [BillingEmail], [BillingPhoneNo], [GSTNo], [PaymentTermId], [TAndC]) VALUES (10, N'Nicole Boyer', N'Debitis consequuntur', N'876543792347', N'xejef@mailinator.com', N'Velit qui harum dolo kjhgfdsdrty lkjhgf oiuyt oiuy oiuyfb', 20, 13, N'New Delhi', 110059, N'https://www.zenivuj.co.uk', 1, N'Laboriosam vel comm', 10, 2, N'Voluptate ex molesti', 59, N'wigyruc@mailinator.com', N'876534567', N'987654', 2, N'Mollit iste eveniet')
GO
INSERT [dbo].[Client] ([Id], [Name], [Branch], [ContactNo], [Email], [Address], [CountryId], [StateId], [City], [Pincode], [Website], [Status], [BillingAddress], [BillingCountryId], [BillingStateId], [BillingCity], [BillingPincode], [BillingEmail], [BillingPhoneNo], [GSTNo], [PaymentTermId], [TAndC]) VALUES (11, N'Mariam Watts ', N'Delhi', N'98765438989', N'rovhjtuthajssdhhssi@mailinator.com', N'Sunt ipsa maxime s', 11, 3, N'Tempor labore tempor jhhjggf kdbbwedgu sbjded snbbjhwd sdbj ', 302323, N'https://www.hebisorutogyxu.org', 1, N'Aut ea harum aut sin', 1021, 2, N'Et quis impedit lab', 35, N'fapecalife@mailinator.com', N'0987654', N'22222HHH', 2, N'-0iuygf')
GO
INSERT [dbo].[Client] ([Id], [Name], [Branch], [ContactNo], [Email], [Address], [CountryId], [StateId], [City], [Pincode], [Website], [Status], [BillingAddress], [BillingCountryId], [BillingStateId], [BillingCity], [BillingPincode], [BillingEmail], [BillingPhoneNo], [GSTNo], [PaymentTermId], [TAndC]) VALUES (13, N'Dawn Bird', N'Consequat Et qui qu', N'Dolore sunt rer', N'puwyfuvaf@mailinator.com', N'Aut delectus incidi', 11, 17, N'Blanditiis sunt recu', 53, N'https://www.lifimudo.me.uk', 1, N'Eiusmod odit invento', 11, 1018, N'Et velit velit vero', 74, N'rebefyn@mailinator.com', N'798897980', N'Accusantium voluptat', 1, N'Sed sed adipisicing ')
GO
INSERT [dbo].[Client] ([Id], [Name], [Branch], [ContactNo], [Email], [Address], [CountryId], [StateId], [City], [Pincode], [Website], [Status], [BillingAddress], [BillingCountryId], [BillingStateId], [BillingCity], [BillingPincode], [BillingEmail], [BillingPhoneNo], [GSTNo], [PaymentTermId], [TAndC]) VALUES (23, N'Elijah Kemp', N'Quae et nesciunt ut', N'987654', N'cahuxy@mailinator.com', N'Porro beatae unde cu', 11, 17, N'Hic et accusantium n', 60, N'https://www.gusowyhonudi.info', 1, N'Sit nihil voluptate', 10, 2, N'Sed quia irure sequi', 1, N'manac@mailinator.com', N'87653', N'Quasi corporis est ', 1, N'Facilis dolor veniam')
GO
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactPerson] ON 
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (4, 1, N'Ajeet Singh', 62, 72, N'ajeetsingh@gmail.com', N'87698765476', N'987987654456')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (5, 8, N'hh', 43, 76, N'jjj@gmail.com', N'87', N'77')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (6, 9, N'hh', 43, 76, N'jjj@gmail.com', N'87', N'77')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (7, 10, N'Veda Mercado', 45, 72, N'wixaxar@mailinator.com', N'9876543', N'987654')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (8, 10, N'Dana Talley', 46, 116, N'boce@mailinator.com', N'0987654', N'85555555')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (11, 10, N'Nola Yang', 43, 74, N'muxo@mailinator.com', N'9876543', N'765432345')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (12, 11, N'Keith Cherry', 43, 72, N'culojebabu@mailinator.com', N'0987654', N'878888')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (13, 11, N'Kjhgf', 43, 76, N'hh@gmail.com', N'6666', N'44444')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (14, 10, N'jjj', 46, 76, N'jjj@gmail.com', N'324897298', N'479447894')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (15, 1, N'Ranveer ', 46, 76, N'ranveersingh@gmail.com', N'87380620408', N'982619369729')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (16, 13, N'Lana Suarez', 43, 76, N'jefefonoz@mailinator.com', N'Ex exercitation', N'Earum delectus')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (17, 13, N'sdkjb', 61, 74, N'dsgkk@gmail.com', N'79879', N'789')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (18, 23, N'Hayes Mcclain', 43, 76, N'safejare@mailinator.com', N'876868', N'Dolor ut quasi ')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (19, 23, N'rejdbjdf', 61, 75, N'fjfj@gmail.com', N'383947', N'484848')
GO
INSERT [dbo].[ContactPerson] ([Id], [ClientId], [Name], [DesignationId], [DepartmentId], [Email], [ContactNo], [WhatsAppNo]) VALUES (20, 23, N'lkasj', 62, 76, N'asmd@gmail.com', N'96686778', N'86868')
GO
SET IDENTITY_INSERT [dbo].[ContactPerson] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([Id], [Name], [Status]) VALUES (10, N'INDIA', 1)
GO
INSERT [dbo].[Country] ([Id], [Name], [Status]) VALUES (11, N'US', 1)
GO
INSERT [dbo].[Country] ([Id], [Name], [Status]) VALUES (20, N'EUROPE', 1)
GO
INSERT [dbo].[Country] ([Id], [Name], [Status]) VALUES (1021, N'TEst', 1)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Degree] ON 
GO
INSERT [dbo].[Degree] ([Id], [Name], [Status]) VALUES (1, N'MCA', 1)
GO
INSERT [dbo].[Degree] ([Id], [Name], [Status]) VALUES (6, N'BCA', 0)
GO
INSERT [dbo].[Degree] ([Id], [Name], [Status]) VALUES (7, N'Phd', 1)
GO
SET IDENTITY_INSERT [dbo].[Degree] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([Id], [Name], [Status]) VALUES (71, N'HR', 0)
GO
INSERT [dbo].[Department] ([Id], [Name], [Status]) VALUES (72, N'Finance', 1)
GO
INSERT [dbo].[Department] ([Id], [Name], [Status]) VALUES (74, N'Recruiter ', 0)
GO
INSERT [dbo].[Department] ([Id], [Name], [Status]) VALUES (75, N'Recruiter Head', 1)
GO
INSERT [dbo].[Department] ([Id], [Name], [Status]) VALUES (76, N'Sales  Head  ', 1)
GO
INSERT [dbo].[Department] ([Id], [Name], [Status]) VALUES (81, N'Manager  Head', 0)
GO
INSERT [dbo].[Department] ([Id], [Name], [Status]) VALUES (83, N' Sales', 1)
GO
INSERT [dbo].[Department] ([Id], [Name], [Status]) VALUES (116, N'HR Head', 1)
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Designation] ON 
GO
INSERT [dbo].[Designation] ([Id], [Name], [Status]) VALUES (43, N'Trainee', 1)
GO
INSERT [dbo].[Designation] ([Id], [Name], [Status]) VALUES (44, N'Developer', 0)
GO
INSERT [dbo].[Designation] ([Id], [Name], [Status]) VALUES (45, N'Senior Developer', 1)
GO
INSERT [dbo].[Designation] ([Id], [Name], [Status]) VALUES (46, N'Sales', 0)
GO
INSERT [dbo].[Designation] ([Id], [Name], [Status]) VALUES (61, N'Recruiter ', 1)
GO
INSERT [dbo].[Designation] ([Id], [Name], [Status]) VALUES (62, N'Others', 1)
GO
SET IDENTITY_INSERT [dbo].[Designation] OFF
GO
SET IDENTITY_INSERT [dbo].[Education] ON 
GO
INSERT [dbo].[Education] ([Id], [CandidateId], [DegreeId], [Specialization], [UniversityId], [SchoolName], [StartDate], [Enddate]) VALUES (1, 25, 6, N'CS/EC', 9, N'AKTU', CAST(N'2021-06-07' AS Date), CAST(N'2023-07-05' AS Date))
GO
INSERT [dbo].[Education] ([Id], [CandidateId], [DegreeId], [Specialization], [UniversityId], [SchoolName], [StartDate], [Enddate]) VALUES (2, 25, 7, N'CS/IT', 2, N'AKTU', CAST(N'2023-06-27' AS Date), CAST(N'2025-10-17' AS Date))
GO
INSERT [dbo].[Education] ([Id], [CandidateId], [DegreeId], [Specialization], [UniversityId], [SchoolName], [StartDate], [Enddate]) VALUES (3, 25, 1, N'TEST', 2, N'AKTTT', CAST(N'2023-07-25' AS Date), CAST(N'2023-07-18' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Education] OFF
GO
SET IDENTITY_INSERT [dbo].[Level] ON 
GO
INSERT [dbo].[Level] ([Id], [Name], [Status], [LevelCode]) VALUES (1, N'PGT', 1, N'PGT')
GO
INSERT [dbo].[Level] ([Id], [Name], [Status], [LevelCode]) VALUES (2, N'test', 1, N'TES')
GO
INSERT [dbo].[Level] ([Id], [Name], [Status], [LevelCode]) VALUES (6, N'TGT', 1, N'TGT')
GO
INSERT [dbo].[Level] ([Id], [Name], [Status], [LevelCode]) VALUES (46, N'PRIMARY', 1, N'PRI')
GO
SET IDENTITY_INSERT [dbo].[Level] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentTerms] ON 
GO
INSERT [dbo].[PaymentTerms] ([Id], [Name], [Days], [Status]) VALUES (1, N'15 Days', 15, 1)
GO
INSERT [dbo].[PaymentTerms] ([Id], [Name], [Days], [Status]) VALUES (2, N'10 Days', 10, 1)
GO
SET IDENTITY_INSERT [dbo].[PaymentTerms] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 
GO
INSERT [dbo].[Requests] ([Id], [ClientId], [ContactPersonId], [SkillId], [Title], [Vacancies], [Experience], [Salary], [Jd], [Location], [JobSummary], [CreatedBy], [Cdate], [CTime], [Recruiter], [AllotedBy], [AllotmentDate], [AllotmentTime], [Status]) VALUES (1, 11, 13, 4, 43, 43, 8, 3, N'34.htm', N'Consectetur sit eaq', N'Omnis sunt ut praes', 15, CAST(N'2023-07-06' AS Date), N'01:20 PM', 19, NULL, NULL, NULL, 5)
GO
INSERT [dbo].[Requests] ([Id], [ClientId], [ContactPersonId], [SkillId], [Title], [Vacancies], [Experience], [Salary], [Jd], [Location], [JobSummary], [CreatedBy], [Cdate], [CTime], [Recruiter], [AllotedBy], [AllotmentDate], [AllotmentTime], [Status]) VALUES (4, 1, 8, 8, 62, 22, 3, 222222, N'LOGO.jpg', N'Noida', N'Full Time', 15, CAST(N'2023-07-06' AS Date), N'01:20 PM', 19, 17, CAST(N'2023-07-06' AS Date), N'05:9 PM', 5)
GO
INSERT [dbo].[Requests] ([Id], [ClientId], [ContactPersonId], [SkillId], [Title], [Vacancies], [Experience], [Salary], [Jd], [Location], [JobSummary], [CreatedBy], [Cdate], [CTime], [Recruiter], [AllotedBy], [AllotmentDate], [AllotmentTime], [Status]) VALUES (5, 13, 17, 7, 46, 7, 9, 98754, N'34.htm', N'lkjg', N'lug', 15, CAST(N'2023-07-06' AS Date), N'01:20 PM', NULL, NULL, NULL, NULL, 5)
GO
INSERT [dbo].[Requests] ([Id], [ClientId], [ContactPersonId], [SkillId], [Title], [Vacancies], [Experience], [Salary], [Jd], [Location], [JobSummary], [CreatedBy], [Cdate], [CTime], [Recruiter], [AllotedBy], [AllotmentDate], [AllotmentTime], [Status]) VALUES (6, 23, 18, 8, 61, 20, 7, 41000, N'LOGO.jpg', N'Noida', N'Full Time', 15, CAST(N'2023-07-06' AS Date), N'01:20 PM', NULL, NULL, NULL, NULL, 5)
GO
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
SET IDENTITY_INSERT [dbo].[RequestStatus] ON 
GO
INSERT [dbo].[RequestStatus] ([Id], [Name], [Category], [status]) VALUES (1, N'Pending Interview', 1, 0)
GO
INSERT [dbo].[RequestStatus] ([Id], [Name], [Category], [status]) VALUES (3, N'Review Submitals', 1, 1)
GO
INSERT [dbo].[RequestStatus] ([Id], [Name], [Category], [status]) VALUES (4, N'Submit Candidate', 1, 0)
GO
INSERT [dbo].[RequestStatus] ([Id], [Name], [Category], [status]) VALUES (5, N'New', 0, 1)
GO
INSERT [dbo].[RequestStatus] ([Id], [Name], [Category], [status]) VALUES (6, N'Pending Joining', 1, 0)
GO
INSERT [dbo].[RequestStatus] ([Id], [Name], [Category], [status]) VALUES (7, N'Joined', 3, 0)
GO
INSERT [dbo].[RequestStatus] ([Id], [Name], [Category], [status]) VALUES (8, N'Aborted', 4, 1)
GO
SET IDENTITY_INSERT [dbo].[RequestStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Skill] ON 
GO
INSERT [dbo].[Skill] ([Id], [SubjectId], [LevelId], [AffiliationId], [Status], [SkillCode]) VALUES (4, 1, 1, 32, 1, N'MAT-PGT-IC')
GO
INSERT [dbo].[Skill] ([Id], [SubjectId], [LevelId], [AffiliationId], [Status], [SkillCode]) VALUES (5, 5, 1, 32, 1, N'CHE-PGT-IC')
GO
INSERT [dbo].[Skill] ([Id], [SubjectId], [LevelId], [AffiliationId], [Status], [SkillCode]) VALUES (6, 1, 1, 33, 1, N'MAT-PGT-CB')
GO
INSERT [dbo].[Skill] ([Id], [SubjectId], [LevelId], [AffiliationId], [Status], [SkillCode]) VALUES (7, 9, 1, 32, 1, N'PHY-PGT-IC')
GO
INSERT [dbo].[Skill] ([Id], [SubjectId], [LevelId], [AffiliationId], [Status], [SkillCode]) VALUES (8, 1, 6, 32, 0, N'MAT-TGT-IC')
GO
SET IDENTITY_INSERT [dbo].[Skill] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (2, 10, N'UP', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (3, 10, N'Hariyana', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (13, 10, N'Punjab', 0)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (17, 11, N'Arizona', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1017, 11, N'Alabama', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1018, 11, N'California', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1019, 11, N'Colorado', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1020, 11, N'Georgia', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1021, 20, N' Austria', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1022, 20, N'Belgium', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1023, 20, N'Denmark', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1024, 20, N' Finland', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1025, 10, N'Assam', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1026, 10, N'Bombay', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1027, 10, N'East Punjab', 1)
GO
INSERT [dbo].[State] ([Id], [CountryId], [Name], [Status]) VALUES (1028, 10, N'Madhya Pradesh', 1)
GO
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 
GO
INSERT [dbo].[Subject] ([Id], [Name], [Status], [SubjectCode]) VALUES (1, N'MATH', 1, N'MAT')
GO
INSERT [dbo].[Subject] ([Id], [Name], [Status], [SubjectCode]) VALUES (5, N'Chemestry', 1, N'CHE')
GO
INSERT [dbo].[Subject] ([Id], [Name], [Status], [SubjectCode]) VALUES (9, N'Physics', 1, N'PHY')
GO
INSERT [dbo].[Subject] ([Id], [Name], [Status], [SubjectCode]) VALUES (13, N'Bio', 1, N'BIO')
GO
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Test] ON 
GO
INSERT [dbo].[Test] ([Id], [Name]) VALUES (1, N'VEd')
GO
SET IDENTITY_INSERT [dbo].[Test] OFF
GO
SET IDENTITY_INSERT [dbo].[University] ON 
GO
INSERT [dbo].[University] ([Id], [Name], [Status]) VALUES (2, N'AKTU', 0)
GO
INSERT [dbo].[University] ([Id], [Name], [Status]) VALUES (9, N'TEST', 1)
GO
INSERT [dbo].[University] ([Id], [Name], [Status]) VALUES (10, N'CAT', 1)
GO
SET IDENTITY_INSERT [dbo].[University] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [ContactNo], [WhatsappNo], [DateOfJoining], [EmpCode], [Type], [Division], [DepartmentId], [DesignationId], [ProfilePicture], [Address], [UserName], [Password], [Status]) VALUES (15, N'Aman Sales Head', N'aman@gmail.com', N'76263536252', N'76373627222', CAST(N'2023-06-07T00:00:00.000' AS DateTime), N'EMP102', 1, 1, 76, 45, NULL, N'Moti Nagar', N'Aman', N'aman', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [ContactNo], [WhatsappNo], [DateOfJoining], [EmpCode], [Type], [Division], [DepartmentId], [DesignationId], [ProfilePicture], [Address], [UserName], [Password], [Status]) VALUES (16, N'Admin', N'admin@gmail.com', N'9878675645', N'7676876545', CAST(N'2023-06-08T00:00:00.000' AS DateTime), N'EMP107', 0, 2, NULL, NULL, NULL, N'Greater Noida
Greater Noida Pari Chawk', N'Admin', N'12345', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [ContactNo], [WhatsappNo], [DateOfJoining], [EmpCode], [Type], [Division], [DepartmentId], [DesignationId], [ProfilePicture], [Address], [UserName], [Password], [Status]) VALUES (17, N'Rahul RH', N'rahul@gmail.com', N'3783', N'3844', CAST(N'2023-07-06T00:00:00.000' AS DateTime), N'EMp00', 1, 0, 75, 62, NULL, N'HH', N'rahul', N'rahul', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [ContactNo], [WhatsappNo], [DateOfJoining], [EmpCode], [Type], [Division], [DepartmentId], [DesignationId], [ProfilePicture], [Address], [UserName], [Password], [Status]) VALUES (18, N'Sales', N'sales@gmail.com', N'386387', N'234894', CAST(N'2023-07-06T00:00:00.000' AS DateTime), N'fkj', 2, 1, 83, 43, NULL, N'dfb', N'sales', N'sales', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [ContactNo], [WhatsappNo], [DateOfJoining], [EmpCode], [Type], [Division], [DepartmentId], [DesignationId], [ProfilePicture], [Address], [UserName], [Password], [Status]) VALUES (19, N'Recruiter', N'rescruiter@gmail.com', N'3288', N'38386', CAST(N'2023-07-05T00:00:00.000' AS DateTime), N'ask', 2, 0, 83, 43, NULL, N'fjh', N'recruiter', N'recruiter', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkExperiance] ON 
GO
INSERT [dbo].[WorkExperiance] ([Id], [CandidateId], [Organization], [Designation], [Startdate], [Enddate]) VALUES (1, 25, N'Google T', N'Trainee  T', CAST(N'2023-07-12' AS Date), CAST(N'2023-07-03' AS Date))
GO
INSERT [dbo].[WorkExperiance] ([Id], [CandidateId], [Organization], [Designation], [Startdate], [Enddate]) VALUES (2, 25, N'ABC', N'XYZ', CAST(N'2023-08-04' AS Date), CAST(N'2023-07-05' AS Date))
GO
INSERT [dbo].[WorkExperiance] ([Id], [CandidateId], [Organization], [Designation], [Startdate], [Enddate]) VALUES (3, 25, N'XYZ', N'ABC', CAST(N'2023-07-20' AS Date), CAST(N'2023-07-04' AS Date))
GO
SET IDENTITY_INSERT [dbo].[WorkExperiance] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Affiliat__737584F62F798D87]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Affiliation] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Country__737584F69B2D94FB]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Country] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Degree__737584F600BAE235]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Degree] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Departme__737584F640ABBCE8]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Department] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Departme__737584F6C62B303C]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Department] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Departme__737584F6E2B029C2]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Department] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Designat__737584F6ADDB1C36]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Designation] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Level__737584F603E4033F]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Level] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PaymentT__737584F635199CC9]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[PaymentTerms] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__State__737584F66DCC00A2]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[State] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Subject__737584F60D446016]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Subject] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Test__737584F6EE2B301B]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[Test] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Universi__737584F6B361F6E4]    Script Date: 07-07-2023 06:43:26 PM ******/
ALTER TABLE [dbo].[University] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD FOREIGN KEY([PrimarySkillId])
REFERENCES [dbo].[Skill] ([Id])
GO
ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD FOREIGN KEY([SecondarySkilId])
REFERENCES [dbo].[Skill] ([Id])
GO
ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([BillingCountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([BillingStateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([PaymentTermId])
REFERENCES [dbo].[PaymentTerms] ([Id])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[ContactPerson]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[ContactPerson]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[ContactPerson]  WITH CHECK ADD FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidate] ([Id])
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD FOREIGN KEY([DegreeId])
REFERENCES [dbo].[Degree] ([Id])
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD FOREIGN KEY([UniversityId])
REFERENCES [dbo].[University] ([Id])
GO
ALTER TABLE [dbo].[MappedCandidates]  WITH CHECK ADD FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidate] ([Id])
GO
ALTER TABLE [dbo].[MappedCandidates]  WITH CHECK ADD FOREIGN KEY([RequestId])
REFERENCES [dbo].[Requests] ([Id])
GO
ALTER TABLE [dbo].[MappedCandidates]  WITH CHECK ADD FOREIGN KEY([Status])
REFERENCES [dbo].[CandidateStatus] ([Id])
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD FOREIGN KEY([ContactPersonId])
REFERENCES [dbo].[ContactPerson] ([Id])
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skill] ([Id])
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD FOREIGN KEY([Status])
REFERENCES [dbo].[RequestStatus] ([Id])
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD FOREIGN KEY([Title])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD FOREIGN KEY([AffiliationId])
REFERENCES [dbo].[Affiliation] ([Id])
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([Id])
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[WorkExperiance]  WITH CHECK ADD FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidate] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[AddUpdateContactPerson]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[AddUpdateContactPerson](@Id int, @ClientId int,@Name nvarchar(100), @DesignationId int,@DepartmentId int,@Email nvarchar(100),
@ContactNo nvarchar(15),@WhatsAppNo nvarchar(15))
as 
begin
if(@Id=0)
begin
Insert into ContactPerson(ClientId,Name,DesignationId,DepartmentId,Email,ContactNo,WhatsAppNo)
values(@ClientId,@Name,@DesignationId,@DepartmentId,@Email,@ContactNo,@WhatsAppNo)
end
else
begin
update ContactPerson set ClientId=@ClientId,Name=@Name,DesignationId=@DesignationId,DepartmentId=@DepartmentId,Email=@Email,
ContactNo=@ContactNo,WhatsAppNo=@WhatsAppNo where Id=@Id
end
end
GO
/****** Object:  StoredProcedure [dbo].[AddUpdateEducation]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddUpdateEducation](@Id int,@CandidateId int,@DegreeId int,@Specilization nvarchar(100),@UniversityId int,@SchoolName nvarchar(500)
,@Startdate date,@Enddate date)
as
begin 
if(@Id = 0)
begin
Insert into Education values(@CandidateId,@DegreeId,@Specilization,@UniversityId,@SchoolName,@Startdate,@Enddate)
end
else
begin
Update Education set CandidateId = @CandidateId,DegreeId = @DegreeId,Specialization = @Specilization,UniversityId = @UniversityId,
SchoolName = @SchoolName,StartDate = @Startdate,Enddate = @Enddate where Id=@Id
end
end
GO
/****** Object:  StoredProcedure [dbo].[AddUpdateWorkExperiance]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddUpdateWorkExperiance](@Id int,@CandidateId int,@Organization nvarchar(200),@Designation nvarchar(200),@StartDate date,@EndDate date)
as
begin
If(@Id = 0)
begin
Insert into WorkExperiance values (@CandidateId,@Organization,@Designation,@StartDate,@EndDate)
end
else
begin
Update WorkExperiance set CandidateId = @CandidateId,Organization = @Organization,
Designation = @Designation,Startdate = @StartDate, Enddate = @EndDate where Id = @Id
end
end
GO
/****** Object:  StoredProcedure [dbo].[AllotRecruiter]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[AllotRecruiter](@RequestId int,@RHeadId int, @RecId int, @AllotTime nvarchar(20))
as
begin
Update Requests set Recruiter=@RecId,AllotedBy=@RHeadId,AllotmentDate=GETDATE(),AllotmentTime=@AllotTime where Id=@RequestId
end
GO
/****** Object:  StoredProcedure [dbo].[CandidateStatusList]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[CandidateStatusList]
as
begin
select * from CandidateStatus where status=0 Order by Name
end
GO
/****** Object:  StoredProcedure [dbo].[CheckUser]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckUser](@UserId nvarchar(50),@Password nvarchar(50))
as
begin
declare @res int
select @res=Id from Users where UserName = @UserId COLLATE SQL_Latin1_General_CP1_CS_AS and Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS
select ISNULL(@res,0) as Id
end


GO
/****** Object:  StoredProcedure [dbo].[CreateSkillCodes]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CreateSkillCodes](@SubjectId int, @LevelId int, @AffId int)
AS
BEGIN
    DECLARE @SkillCode NVARCHAR(15)
    
    INSERT INTO Skill (SubjectId, LevelId, AffiliationId)
    VALUES (@SubjectId, @LevelId, @AffId)
    
    SET @SkillCode = CONCAT(
        SCOPE_IDENTITY(),
        '_',
        FORMAT(GETDATE(), 'yyyyMMddHHmmss')
    )
    
    UPDATE Skill
    SET SkillCode = @SkillCode
    WHERE Id = SCOPE_IDENTITY()
    
    SELECT @SkillCode AS SkillCode
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteContactPersons]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[DeleteContactPersons](@Ids nvarchar(200))
as
begin
declare @qry nvarchar(500)
set @qry='DELETE FROM ContactPerson WHERE Id in (' + @Ids + ')'
Exec sp_executesql @qry
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteEducation]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteEducation](@Ids nvarchar(200))  
as  
begin  
declare @qry nvarchar(500)  
set @qry = 'DELETE FROM Education WHERE Id in (' + @Ids+ ')'  
Exec Sp_executesql @qry
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteWorkExperiance]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteWorkExperiance](@Ids nvarchar(200))
 as
 begin
 declare @qry nvarchar(500)
 set @qry = 'DELETE FROM WorkExperiance WHERE Id in (' + @Ids +')'
 Exec sp_executesql @qry
 end
GO
/****** Object:  StoredProcedure [dbo].[GenerateSkillCode]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[GenerateSkillCode] (@SubjectId INT,@LevelId INT,@AffId INT = null)
AS
BEGIN
DECLARE @SkillCode NVARCHAR(15)
if Exists(Select * from Subject where Id=@SubjectId)
begin
 set @SkillCode = (select SubjectCode from Subject where Id=@SubjectId)
end
else
 set @SkillCode = 'XXX'

if Exists(select * from Level where Id=@LevelId)
begin
 set @SkillCode = @SkillCode + '-' + (select LevelCode from Level where Id=@LevelId)
end
else
 set @SkillCode = @SkillCode + '-' + 'XXX'

if(@AffId is not null)
begin
if Exists(select * from Affiliation where Id=@AffId)
begin
 set @SkillCode = @SkillCode + '-' + (select AffiliationCode from Affiliation where Id=@AffId)
end
else
 set @SkillCode = @SkillCode + '-' + 'XX'
end
else 
set @SkillCode = @SkillCode + '-' + 'XX'
SELECT @SkillCode AS SkillCode
END
GO
/****** Object:  StoredProcedure [dbo].[GetAffiliation]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAffiliation]
as
begin
select * from Affiliation
end
GO
/****** Object:  StoredProcedure [dbo].[GetCandidateDataTables]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCandidateDataTables](@CandidateId int)  
as  
begin  
select e.*,d.Name as Degree,u.Name as University from Education  e   
left join Degree d on e.DegreeId = d.Id   
left join University u on e.UniversityId = u.Id  
where CandidateId = @CandidateId  
select * from WorkExperiance 
where CandidateId = @CandidateId
  
end  
GO
/****** Object:  StoredProcedure [dbo].[GetCandidateEducation]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetCandidateEducation](@CandidateId int)
as
begin
select * from Education where CandidateId = @CandidateId
select * from WorkExperiance where CandidateId = @CandidateId
end
GO
/****** Object:  StoredProcedure [dbo].[GetClientContactPerson]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GetClientContactPerson](@ClientId int)
as
begin
Select * from ContactPerson where ClientId=@ClientId
end
GO
/****** Object:  StoredProcedure [dbo].[GetClientDetailsById]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetClientDetailsById](@Id int)
as
begin
select c.Id,c.Name,c.Branch,c.ContactNo,c.Address,c.CountryId,c.StateId,c.City,c.Email,c.Website from Client c where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[GetContactPerson]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetContactPerson](@Id int)
 as
 begin
 select cp.Name,cp.Email,cp.ContactNo,cp.WhatsAppNo,d.Name as Department , ds.Name as Designation from ContactPerson cp 
 left join Department d on cp.DepartmentId = d.Id
 left join Designation ds on cp.DesignationId = ds.Id
 where cp.ClientId = @Id
 end
GO
/****** Object:  StoredProcedure [dbo].[GetContactPersonbyClientId]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[GetContactPersonbyClientId](@Id int)
as
begin
select cp.Id,cp.Name,cp.Email,cp.ContactNo,cp.WhatsAppNo from ContactPerson cp
where ClientId = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[GetContactPersonById]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetContactPersonById](@Id int)
 as
 begin
 Select cp.Id,cp.Name,cp.Email,d.Name as 'Designation' from ContactPerson cp
 left join Designation d on cp.DesignationId=d.Id
 where cp.Id=@Id
 end
GO
/****** Object:  StoredProcedure [dbo].[GetCountry]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCountry]
as
begin
select * from Country where Status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[GetDegree]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDegree]
as
begin
select * from Degree
end
GO
/****** Object:  StoredProcedure [dbo].[GetDepartment]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetDepartment]
as
begin
select * from Department ORDER BY Id Desc
end
GO
/****** Object:  StoredProcedure [dbo].[GetDepartments]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetDepartments]
as
begin
select * from Department order by Name desc
end
GO
/****** Object:  StoredProcedure [dbo].[GetDesignations]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetDesignations]  
as  
begin  
select * from Designation where Status=1 order by Name  
end  
GO
/****** Object:  StoredProcedure [dbo].[GetEducation]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetEducation](@Id int)
 as
 begin
 select e.* from Education e
 left join Degree d on e.DegreeId = d.Id
 left join University u on e.UniversityId = u.Id
 where e.CandidateId = @Id
 end
GO
/****** Object:  StoredProcedure [dbo].[GetLevel]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetLevel]
as
begin
select * from Level
end
GO
/****** Object:  StoredProcedure [dbo].[GetNewCategoryStatusId]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetNewCategoryStatusId](@TableName nvarchar(50))
as
begin
declare @Id int
if(@TableName = 'RequestStatus')
begin
select top 1 @Id=Id from RequestStatus where Category=0 and status=0
end
else if(@TableName = 'CandidateStatus')
begin
select top 1 @Id=Id from CandidateStatus where Category=0 and status=0
end

Select Isnull(@Id,0) as Id
end
GO
/****** Object:  StoredProcedure [dbo].[GetPaymentTerms]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPaymentTerms]
as
begin
select * from PaymentTerms
end
GO
/****** Object:  StoredProcedure [dbo].[GetRecruitersList]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GetRecruitersList]
as
Select Id,Name,Email,ContactNo from Users where Type=2 and Division=0 and Status=1
GO
/****** Object:  StoredProcedure [dbo].[GetSkill]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetSkill]
as
begin
select * from Skill where Status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[GetSkillbyId]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetSkillbyId](@Id int)
as
begin
select s.*,sb.Name as Subject,l.Name as Level,a.Name as Affiliation from Skill s    
left join Subject sb on s.SubjectId = sb.Id    
left join Level l on s.LevelId = l.Id    
left join Affiliation a on s.AffiliationId = a.Id 
where s.Id = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[GetState]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetState]
as
begin
select * from State
end
GO
/****** Object:  StoredProcedure [dbo].[GetSubject]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetSubject]
as
begin
select * from Subject
end
GO
/****** Object:  StoredProcedure [dbo].[GetTableData]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GetTableData](@TableName nvarchar(200))
as
begin
declare @qry nvarchar(2000)
set @qry = 'Select * from ' + @TableName + ' order by Id DESC'
Exec sp_executesql @qry
end
GO
/****** Object:  StoredProcedure [dbo].[GetUniversity]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetUniversity]
as
begin
select * from University
end
GO
/****** Object:  StoredProcedure [dbo].[GetUserWiseRequestList]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[GetUserWiseRequestList](@Uid int,@Type int,@Division int)
as
begin
if(@Type = 0 or @Type = 1)
begin
select r.Id,r.ClientId,r.ContactPersonId,r.SkillId,r.Title,r.Vacancies,r.Experience,r.Salary,r.Jd,r.Location,
r.JobSummary,r.CreatedBy,r.Cdate,r.CTime,r.Recruiter,r.AllotedBy,r.AllotmentDate,r.AllotmentTime,
c.Name as 'Client',c.Branch,c.Email,c.City,c.Website, ct.Name as 'ContactPerson', ct.Email as 'CPEmail',d1.Name as 'CPDesignation',
sk.SkillCode,l.Name as 'Level',sub.Name as 'Subject',aff.Name as 'Affiliation',d2.Name as 'TitleName',sp.Name as 'SalesPerson',
rec.Name as 'RecruiterName',rh.Name as 'RecruiterHead'
from Requests r
left join Client c on r.ClientId = c.Id
left join ContactPerson ct on r.ContactPersonId = ct.Id
left join Designation d1 on ct.DesignationId=d1.Id
left join Skill sk on r.SkillId = sk.Id
left join Level l on sk.LevelId=l.Id
left join Subject  sub on sk.SubjectId = sub.Id
left join Affiliation aff on sk.AffiliationId = aff.Id
left join Designation d2 on r.Title = d2.Id
left join Users sp on r.CreatedBy=sp.Id
left join Users rec on r.Recruiter=rec.Id
left join Users rh on r.Recruiter=rh.Id
end
else if(@Type = 2)
begin
 if(@Division = 0)
 begin
	select r.Id,r.ClientId,r.ContactPersonId,r.SkillId,r.Title,r.Vacancies,r.Experience,r.Salary,r.Jd,r.Location,
	r.JobSummary,r.CreatedBy,r.Cdate,r.CTime,r.Recruiter,r.AllotedBy,r.AllotmentDate,r.AllotmentTime,
	c.Name as 'Client',c.Branch,c.Email,c.City,c.Website, ct.Name as 'ContactPerson', ct.Email as 'CPEmail',d1.Name as 'CPDesignation',
	sk.SkillCode,l.Name as 'Level',sub.Name as 'Subject',aff.Name as 'Affiliation',d2.Name as 'TitleName',sp.Name as 'SalesPerson',
	rec.Name as 'RecruiterName',rh.Name as 'RecruiterHead'
	from Requests r
	left join Client c on r.ClientId = c.Id
	left join ContactPerson ct on r.ContactPersonId = ct.Id
	left join Designation d1 on ct.DesignationId=d1.Id
	left join Skill sk on r.SkillId = sk.Id
	left join Level l on sk.LevelId=l.Id
	left join Subject  sub on sk.SubjectId = sub.Id
	left join Affiliation aff on sk.AffiliationId = aff.Id
	left join Designation d2 on r.Title = d2.Id
	left join Users sp on r.CreatedBy=sp.Id
	left join Users rec on r.Recruiter=rec.Id
	left join Users rh on r.Recruiter=rh.Id
	where r.Recruiter=@Uid
 end
 else if(@Division = 1)
 begin
	select r.Id,r.ClientId,r.ContactPersonId,r.SkillId,r.Title,r.Vacancies,r.Experience,r.Salary,r.Jd,r.Location,
	r.JobSummary,r.CreatedBy,r.Cdate,r.CTime,r.Recruiter,r.AllotedBy,r.AllotmentDate,r.AllotmentTime,
	c.Name as 'Client',c.Branch,c.Email,c.City,c.Website, ct.Name as 'ContactPerson', ct.Email as 'CPEmail',d1.Name as 'CPDesignation',
	sk.SkillCode,l.Name as 'Level',sub.Name as 'Subject',aff.Name as 'Affiliation',d2.Name as 'TitleName',sp.Name as 'SalesPerson',
	rec.Name as 'RecruiterName',rh.Name as 'RecruiterHead'
	from Requests r
	left join Client c on r.ClientId = c.Id
	left join ContactPerson ct on r.ContactPersonId = ct.Id
	left join Designation d1 on ct.DesignationId=d1.Id
	left join Skill sk on r.SkillId = sk.Id
	left join Level l on sk.LevelId=l.Id
	left join Subject  sub on sk.SubjectId = sub.Id
	left join Affiliation aff on sk.AffiliationId = aff.Id
	left join Designation d2 on r.Title = d2.Id
	left join Users sp on r.CreatedBy=sp.Id
	left join Users rec on r.Recruiter=rec.Id
	left join Users rh on r.Recruiter=rh.Id
	where r.CreatedBy=@Uid
 end
end
end
GO
/****** Object:  StoredProcedure [dbo].[GetWorkExperiance]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetWorkExperiance](@Id int)
 as  
 begin  
 select * from WorkExperiance  
 where CandidateId = @Id
 end  
GO
/****** Object:  StoredProcedure [dbo].[RequestStatusList]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[RequestStatusList]
as
begin
Select * from RequestStatus where status=0 order by Name
end
GO
/****** Object:  StoredProcedure [dbo].[StateChoice]    Script Date: 07-07-2023 06:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[StateChoice](@Id int)
as
begin
select * from StateView where CountryId = @Id
end
GO
