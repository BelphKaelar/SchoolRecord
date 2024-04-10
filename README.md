CREATE TABLE [dbo].[ClassTb]
(
	[MaLop] INT NOT NULL PRIMARY KEY, 
    [MaGV] INT NOT NULL, 
    [TenGV] VARCHAR(50) NULL
)

CREATE TABLE [dbo].[StudentScore] (
    [MaDiem]    INT          NOT NULL,
    [MaMon]     INT          NOT NULL,
    [TenMon]    VARCHAR (50) NOT NULL,
    [MaLop]     INT          NOT NULL,
    [MaHS]      INT          NOT NULL,
    [TenHS]     VARCHAR (50) NOT NULL,
    [MaGV]      INT          NOT NULL,
    [TenGV]     VARCHAR (50) NOT NULL,
    [DiemMieng] FLOAT (53)   NULL,
    [Diem15p]   FLOAT (53)   NULL,
    [Diem1Tiet] FLOAT (53)   NULL,
    [DiemGK]    FLOAT (53)   NULL,
    [DiemCK]    FLOAT (53)   NULL,
    PRIMARY KEY CLUSTERED ([MaDiem] ASC)
);

CREATE TABLE [dbo].[StudentTimeTb]
(
	[MaTKB] INT NOT NULL PRIMARY KEY, 
    [Tiet] INT NOT NULL, 
    [Thu2] VARCHAR(50) NULL, 
    [Thu3] VARCHAR(50) NULL, 
    [Thu4] VARCHAR(50) NULL, 
    [Thu5] VARCHAR(50) NULL, 
    [Thu6] VARCHAR(50) NULL, 
    [Thu7] VARCHAR(50) NULL, 
    [CN] VARCHAR(50) NULL, 
    [Ngay] DATE NOT NULL
)

CREATE TABLE [dbo].[TeacherTimeTb]
(
	[MaLich] INT NOT NULL PRIMARY KEY, 
    [Tiet] INT NOT NULL, 
    [Thu2] VARCHAR(50) NULL, 
    [Thu3] VARCHAR(50) NULL, 
    [Thu4] VARCHAR(50) NULL, 
    [Thu5] VARCHAR(50) NULL, 
    [Thu6] VARCHAR(50) NULL, 
    [Thu7] VARCHAR(50) NULL, 
    [CN] VARCHAR(50) NULL, 
    [Ngay] DATE NOT NULL
)

CREATE TABLE [dbo].[Studentscord] (
    [MaHS]    INT          NOT NULL,
    [TenHS]     VARCHAR (50)   NOT NULL,
    [TenMon]    VARCHAR (50) NOT NULL,
	[NgaySinh]      DATE        NOT NULL,
    [DiaChi]    VARCHAR (50)  NOT NULL,
	[TenDangNhap] VARCHAR (53)   NULL,
    [MatKhau]   INT NOT NULL,
    [Lop] VARCHAR (23)   NULL,
    PRIMARY KEY CLUSTERED ([MaHS] ASC)
);

