use master;
go
drop database IF EXISTS Coffee_62134455;
go
CREATE DATABASE Coffee_62134455;
go
use Coffee_62134455;
go
CREATE TABLE [dbo].[ChiTietDonHangs_62134455](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](10, 2) NULL,
	[Size] [varchar](10) NULL,
	[GhiChu] [nvarchar](1000) NULL,
	[id_sanpham] [int] NULL,
	[id_donhang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucs_62134455]    Script Date: 12/20/2023 10:26:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucs_62134455](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHangs_62134455]    Script Date: 12/20/2023 10:26:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHangs_62134455](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NgayDatHang] [datetime] NOT NULL,
	[TenKhachHang] [nvarchar](1000) NULL,
	[DiaChiNhanHang] [nvarchar](1000) NOT NULL,
	[SDT] [nvarchar](20) NOT NULL,
	[TrangThai] [int] NULL,
	[GhiChu] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPhams_62134455]    Script Date: 12/20/2023 10:26:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhams_62134455](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](255) NOT NULL,
	[Gia] [decimal](10, 2) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[Size] [nvarchar](255) NULL,
	[GhiChu] [nvarchar](1000) NULL,
	[id_danhmuc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoans_62134455]    Script Date: 12/20/2023 10:26:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoans_62134455](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenNguoiDung] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[VaiTro] [int] NULL,
	[NgayTao] [datetime] NULL,
	[GioiTinh] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietDonHangs_62134455] ADD  DEFAULT ('') FOR [Size]
GO
ALTER TABLE [dbo].[SanPhams_62134455] ADD  DEFAULT ('') FOR [Size]
GO
ALTER TABLE [dbo].[TaiKhoans_62134455] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[ChiTietDonHangs_62134455]  WITH CHECK ADD FOREIGN KEY([id_donhang])
REFERENCES [dbo].[DonHangs_62134455] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonHangs_62134455]  WITH CHECK ADD FOREIGN KEY([id_sanpham])
REFERENCES [dbo].[SanPhams_62134455] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhams_62134455]  WITH CHECK ADD FOREIGN KEY([id_danhmuc])
REFERENCES [dbo].[DanhMucs_62134455] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [Coffee_62134455] SET  READ_WRITE 
GO
