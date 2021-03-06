USE [master]
GO
/****** Object:  Database [ShopQuanAoLite]    Script Date: 23/05/2018 7:56:58 PM ******/
CREATE DATABASE [ShopQuanAoLite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopQuanAoLite', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ShopQuanAoLite.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ShopQuanAoLite_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ShopQuanAoLite_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ShopQuanAoLite] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopQuanAoLite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopQuanAoLite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopQuanAoLite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopQuanAoLite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopQuanAoLite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopQuanAoLite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopQuanAoLite] SET  MULTI_USER 
GO
ALTER DATABASE [ShopQuanAoLite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopQuanAoLite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopQuanAoLite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopQuanAoLite] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ShopQuanAoLite] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopQuanAoLite', N'ON'
GO
USE [ShopQuanAoLite]
GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[MaBL] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [text] NULL,
	[NgayBL] [date] NULL,
	[MaKH] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[MaBL] ASC,
	[MaKH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [int] NOT NULL,
	[MaSP] [int] NULL,
	[TenSP] [nvarchar](100) NULL,
	[DonGia] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hang]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hang](
	[MaH] [int] IDENTITY(1,1) NOT NULL,
	[TenH] [nvarchar](50) NULL,
	[AnhBia] [nvarchar](255) NULL,
 CONSTRAINT [PK_Hang] PRIMARY KEY CLUSTERED 
(
	[MaH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HinhAnh]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnh](
	[MaHinhAnh] [int] IDENTITY(1,1) NOT NULL,
	[TenHinhAnh] [nvarchar](200) NULL,
	[MaSP] [int] NULL,
 CONSTRAINT [PK_HinhAnh] PRIMARY KEY CLUSTERED 
(
	[MaHinhAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[NgayLapHD] [date] NULL,
	[MaKH] [int] NULL,
	[DiaChiGiaoHang] [nvarchar](255) NULL,
	[TrangThai] [bit] NULL,
	[GhiChu] [nvarchar](255) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[DiaChi] [text] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[SoDienThoai] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuangCao]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuangCao](
	[MaQC] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnhQC] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuangCao] PRIMARY KEY CLUSTERED 
(
	[MaQC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuanTriVien]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanTriVien](
	[MaAdmin] [int] IDENTITY(1,1) NOT NULL,
	[TenAdmin] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[TaiKhoan] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](100) NULL,
	[PhanLoai] [bit] NULL,
 CONSTRAINT [PK_QuanTriVien] PRIMARY KEY CLUSTERED 
(
	[MaAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 23/05/2018 7:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](255) NULL,
	[GiaKhuyenMai] [bigint] NULL,
	[GiaBan] [bigint] NULL,
	[MaH] [int] NULL,
	[SoLuong] [int] NULL,
	[ThongTin] [nvarchar](1000) NULL,
	[ngayNhapHang] [date] NULL,
	[AnhBia] [nvarchar](255) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Hang] ON 

INSERT [dbo].[Hang] ([MaH], [TenH], [AnhBia]) VALUES (1, N'Khác', N'images/hang/anhbia/Khac.png')
INSERT [dbo].[Hang] ([MaH], [TenH], [AnhBia]) VALUES (15, N'BROTHER', N'images/hang/anhbia/239px-Brother_logo.svg.png')
INSERT [dbo].[Hang] ([MaH], [TenH], [AnhBia]) VALUES (16, N'CANON', N'images/hang/anhbia/canon.png')
INSERT [dbo].[Hang] ([MaH], [TenH], [AnhBia]) VALUES (17, N'EPSON', N'images/hang/anhbia/Epson_logo.svg_.png')
INSERT [dbo].[Hang] ([MaH], [TenH], [AnhBia]) VALUES (18, N'HP', N'images/hang/anhbia/hp.png')
INSERT [dbo].[Hang] ([MaH], [TenH], [AnhBia]) VALUES (19, N'SAMSUNG', N'images/hang/anhbia/samsung.png')
SET IDENTITY_INSERT [dbo].[Hang] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (1, N'ntluong94', N'111111', N'77777', N'bbbbbbbb', N'4444@gmail.com', N'4444444444')
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (3, N'ntluong96', N'222222', N'Nguyen11', N'665hjkhjk', N'ntuong84426@gmail.com', N'2232327777')
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (4, N'ntluong97', N'111111', N'dfdsfsdfdsfds', N'dsfsdfdfds', N'ntluong827@gmail.com', N'34453453')
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (20, N'ntluong95', N'222222', N'Nguyen Thanh Luong', N'èefedfd', N'ntluong823@gmail.com', N'09754645410')
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (21, N'ntluong99', N'111111', N'Nguyen Thanh Luong', N'376 fff', N'ntluong823@gmail.com', N'0975645410')
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (22, N'sdfsdf', N'111111', N'sdfsdf', N'', N'sdfsdf@gmail.com', N'34324234')
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (28, N'ntluong999', N'111111', N'nguyen thanh luong', N'666', N'ntluong94@mail.com', N'34543543')
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (38, N'ntluong94333', N'111111', N'nguyen thanh luong', N'asdada', N'ntluong823@gmail.com', N'0975645410')
INSERT [dbo].[KhachHang] ([MaKH], [TenDangNhap], [MatKhau], [HoTen], [DiaChi], [Email], [SoDienThoai]) VALUES (39, N'ntluong94555', N'111111', N'nguyen thanh luong', N'asdada', N'ntluong823@gmail.com', N'0975645410')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[QuangCao] ON 

INSERT [dbo].[QuangCao] ([MaQC], [HinhAnhQC]) VALUES (22, N'/images/quangcao/Slider2.png')
SET IDENTITY_INSERT [dbo].[QuangCao] OFF
SET IDENTITY_INSERT [dbo].[QuanTriVien] ON 

INSERT [dbo].[QuanTriVien] ([MaAdmin], [TenAdmin], [Email], [TaiKhoan], [MatKhau], [PhanLoai]) VALUES (1, N'Nguyễn Thành Lượng', N'ntluong823@gmail.com', N'admin', N'admin@ntluong94', 1)
INSERT [dbo].[QuanTriVien] ([MaAdmin], [TenAdmin], [Email], [TaiKhoan], [MatKhau], [PhanLoai]) VALUES (3, N'Lâm Chí Trung', N'chungit.dt1994@gmail.com', N'admin01', N'admin@chungit', 1)
SET IDENTITY_INSERT [dbo].[QuanTriVien] OFF
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [Fk_KhachHangBL] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [Fk_KhachHangBL]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [Fk_SanPhamBL] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [Fk_SanPhamBL]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_SanPham]
GO
ALTER TABLE [dbo].[HinhAnh]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamHA] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[HinhAnh] CHECK CONSTRAINT [FK_SanPhamHA]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [Fk_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [Fk_KhachHang]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_Hang] FOREIGN KEY([MaH])
REFERENCES [dbo].[Hang] ([MaH])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_Hang]
GO
USE [master]
GO
ALTER DATABASE [ShopQuanAoLite] SET  READ_WRITE 
GO
