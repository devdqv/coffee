use master;
go
drop database IF EXISTS Coffee_Sale;
go
CREATE DATABASE Coffee_Sale;
go
use Coffee_Sale;
go

CREATE TABLE DanhMucs (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	TenDanhMuc NVARCHAR (255) NOT NULL
);

CREATE TABLE SanPhams (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	TenSanPham NVARCHAR (255) NOT NULL,
	Gia decimal(10,2) not null,
	MoTa nvarchar(max),
	HinhAnh NVARCHAR(100),
	Size nvarchar(255) default '',
	GhiChu NVARCHAR(1000),
	id_danhmuc int FOREIGN KEY REFERENCES DanhMucs(id) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE DonHangs(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	NgayDatHang datetime not null,
	TenKhachHang NVARCHAR(1000),
	DiaChiNhanHang NVARCHAR(1000) not null,
	SDT NVARCHAR(20) not null,
	TrangThai int,
	GhiChu NVARCHAR(1000),

);

CREATE TABLE ChiTietDonHangs(
	id INT IDENTITY (1, 1) PRIMARY KEY,
	SoLuong int not null,
	DonGia decimal(10,2), -- dongia nay để thống kê doanh thu , tránh TH người bán thay đổi giá thì thống kế sẽ ko bị ảnh hưởng
	Size varchar(10) default '', 
	GhiChu nvarchar(1000),
	id_sanpham int FOREIGN KEY REFERENCES SanPhams(id) ON DELETE CASCADE ON UPDATE CASCADE,
	id_donhang int FOREIGN KEY REFERENCES DonHangs(id) ON DELETE CASCADE ON UPDATE CASCADE,

)

CREATE TABLE TaiKhoans(
	id INT PRIMARY KEY IDENTITY(1, 1),
	TenNguoiDung NVARCHAR(50),
	Username NVARCHAR(50),
	[Password] NVARCHAR(100),
	VaiTro int, -- 0 quản lý, 1 nhân viên
	NgayTao DATETIME DEFAULT GETDATE(),
	GioiTinh BIT 
)


go

INSERT INTO [dbo].[TaiKhoans]
           ([TenNguoiDung]
           ,[Username]
           ,[Password]
           ,[VaiTro])
     VALUES(N'Quản Lý 1', 'admin', N'202cb962ac59075b964b07152d234b70', 0), -- pass: 123
		   (N'User Name 1', 'username1', N'202cb962ac59075b964b07152d234b70', 1)
GO


select * from SanPhams 


go

select * from DanhMucs;
go 
select * from DonHangs
go

select * from TaiKhoans



GO




--delete DanhMucs
--go
--delete SanPhams
--go
--delete DonHangs
--go
--delete ChiTietDonHangs
--go
--delete TaiKhoans



