use master;
go
drop database IF EXISTS Coffee_62134455;
go
CREATE DATABASE Coffee_62134455;
go
use Coffee_62134455;
go

CREATE TABLE DanhMucs_62134455 (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	TenDanhMuc NVARCHAR (255) NOT NULL
);

CREATE TABLE SanPhams_62134455 (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	TenSanPham NVARCHAR (255) NOT NULL,
	Gia decimal(10,2) not null,
	MoTa nvarchar(max),
	HinhAnh NVARCHAR(100),
	Size nvarchar(255) default '',
	GhiChu NVARCHAR(1000),
	id_danhmuc int FOREIGN KEY REFERENCES DanhMucs_62134455(id) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE DonHangs_62134455(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	NgayDatHang datetime not null,
	TenKhachHang NVARCHAR(1000),
	DiaChiNhanHang NVARCHAR(1000) not null,
	SDT NVARCHAR(20) not null,
	TrangThai int,
	GhiChu NVARCHAR(1000),

);

CREATE TABLE ChiTietDonHangs_62134455(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	SoLuong int not null,
	DonGia decimal(10,2), -- dongia nay để thống kê doanh thu , tránh TH người bán thay đổi giá thì thống kế sẽ ko bị ảnh hưởng
	Size varchar(10) default '', 
	GhiChu nvarchar(1000),
	id_sanpham int FOREIGN KEY REFERENCES SanPhams_62134455(id) ON DELETE CASCADE ON UPDATE CASCADE,
	id_donhang int FOREIGN KEY REFERENCES DonHangs_62134455(id) ON DELETE CASCADE ON UPDATE CASCADE,

)

CREATE TABLE TaiKhoans_62134455(
	id INT PRIMARY KEY IDENTITY(1, 1),
	TenNguoiDung NVARCHAR(50),
	Username NVARCHAR(50),
	[Password] NVARCHAR(100),
	VaiTro int, -- 0 quản lý, 1 nhân viên
	NgayTao DATETIME DEFAULT GETDATE(),
	GioiTinh BIT 
)


go

INSERT INTO [dbo].[TaiKhoans_62134455]
           ([TenNguoiDung]
           ,[Username]
           ,[Password]
           ,[VaiTro])
     VALUES(N'Quản Lý 1', 'admin', N'202cb962ac59075b964b07152d234b70', 0), -- pass: 123
		   (N'User Name 1', 'username1', N'202cb962ac59075b964b07152d234b70', 1)
GO


select * from SanPhams_62134455 


go

select * from DanhMucs_62134455;
go 
select * from DonHangs_62134455
go

select * from TaiKhoans_62134455



GO




--delete DanhMucs_62134455
--go
--delete SanPhams_62134455
--go
--delete DonHangs_62134455
--go
--delete ChiTietDonHangs_62134455
--go
--delete TaiKhoans_62134455



