USE [QL_Quancaphe]
GO
/****** Object:  Table [dbo].[tb_Nhanvien]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Nhanvien](
	[manv] [nvarchar](10) NOT NULL,
	[tennv] [nvarchar](50) NULL,
	[diachi] [nvarchar](50) NULL,
	[gioitinh] [nvarchar](10) NULL,
	[ngaysinh] [datetime] NULL,
	[cmnd] [nvarchar](50) NULL,
	[trangthai] [bit] NULL,
	[sdt] [nvarchar](50) NULL,
	[loainv] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[manv] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'001', N'Tú Uyên', N'tp hcm', N'Nữ', CAST(0x0000897C00000000 AS DateTime), N'016597', 1, N'01546', N'Nhân viên bán hàng')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'002', N'Cẩm Nhi', N'tp hcm', N'Khác', CAST(0x00008A1300000000 AS DateTime), N'01646', 1, N'6543', N'Nhân viên bán hàng')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'003', N'5', N'', N'', CAST(0x000089A500000000 AS DateTime), N'5', 0, N'5', N'')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'0034', N'Ngọc Phụng', N'tp hcm', N'Nam', CAST(0x000089A500000000 AS DateTime), N'01646', 0, N'0164', N'Nhân viên quản lý')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'007', N'd', N'', N'', CAST(0x000089A500000000 AS DateTime), N'd', 0, N'd', N'')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'009', N'abc', N'43 nvc', N'Nữ', CAST(0x00008A1F00000000 AS DateTime), N'564123348', 0, N'095557575', N'Nhân viên quản lý')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'1', N'hn', N'1', N'Nam', CAST(0x000089A500000000 AS DateTime), N'1', 1, N'1', N'Nhân viên quản lý')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'2', N'4', N'', N'Nữ', CAST(0x000089A500000000 AS DateTime), N'6', 1, N'5', N'')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'3', N'3', N'3', N'Khác', CAST(0x000089A500000000 AS DateTime), N'3', 1, N'3', N'Nhân viên quản lý')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV001', N'Lý Cẩm Nhi', N'554/37 đường Phạm Thế Hiển', N'Nữ', CAST(0x00008A3100000000 AS DateTime), N'025399758', 1, N'0933388811', N'Nhân viên quản kho')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV002', N'Nguyễn Tuấn Tú Uyên', N'522 đường Mèo', N'Nữ', CAST(0x0000894C00000000 AS DateTime), N'025974613', 1, N'0169877422', N'Nhân viên quản lý')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV003', N'Lê Ngọc Phụng', N'500 đường Trum ', N'Nữ', CAST(0x000089A500000000 AS DateTime), N'025374164', 1, N'0197693323', N'Nhân viên quản kho')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV004', N'Người Tia Chớp', N'số 32 đường Nhanh Kinh Dị', N'Nam', CAST(0x0000884700000000 AS DateTime), N'025747413', 1, N'0122769505', N'Nhân viên bán hàng')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV005', N'Nhẫn Giả', N'số 79 đường Geisha', N'Nam', CAST(0x000086F700000000 AS DateTime), N'025863122', 1, N'0937892555', N'Nhân viên bán hàng')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV006', N'Kẻ Cắp Mặt Trăng', N'số 97 đường Mặt Trăng Sáng Chói', N'Nam', CAST(0x0000847E00000000 AS DateTime), N'081100310', 1, N'0123865332', N'Nhân viên bán hàng')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV007', N'Nguyễn Minh Tùng', N'số 12 đường Ni Sư Quỳnh Liên', N'Nam', CAST(0x00008C1300000000 AS DateTime), N'064531522', 1, N'0937963367', N'Nhân viên bán hàng')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV008', N'Thích Tiền Mặt', N'số 98/2 đường Đầy Vàng', N'Nữ', CAST(0x00008B3900000000 AS DateTime), N'025691113', 1, N'0120408030', N'Nhân viên bán hàng')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV009', N'Phan Thị Lầy', N'số 100 đường Lá Đu Đủ', N'Nữ', CAST(0x0000818C00000000 AS DateTime), N'025397464', 1, N'0973457633', N'Nhân viên bán hàng')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [diachi], [gioitinh], [ngaysinh], [cmnd], [trangthai], [sdt], [loainv]) VALUES (N'NV010', N'Đu Đủ', N'số 32 đường 19 Tháng 5', N'Nam', CAST(0x0000812200000000 AS DateTime), N'023666374', 1, N'0123985589', N'Nhân viên bán hàng')
/****** Object:  Table [dbo].[tb_NCC]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NCC](
	[mancc] [nvarchar](10) NOT NULL,
	[tenncc] [nvarchar](50) NULL,
	[diachi] [nvarchar](50) NULL,
	[trangthai] [bit] NULL,
	[sdt] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_NCC] PRIMARY KEY CLUSTERED 
(
	[mancc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_NCC] ([mancc], [tenncc], [diachi], [trangthai], [sdt]) VALUES (N'NCC001', N'Trung Nguyên', N'Tây Nguyên', 1, N'01245497')
/****** Object:  Table [dbo].[tb_Loai]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Loai](
	[maloai] [nvarchar](10) NOT NULL,
	[trangthai] [bit] NULL,
	[tenloai] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Loai] PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_Loai] ([maloai], [trangthai], [tenloai]) VALUES (N'', NULL, N'')
INSERT [dbo].[tb_Loai] ([maloai], [trangthai], [tenloai]) VALUES (N'001', NULL, N'Macchiato')
INSERT [dbo].[tb_Loai] ([maloai], [trangthai], [tenloai]) VALUES (N'002', NULL, N'Milk Tea')
INSERT [dbo].[tb_Loai] ([maloai], [trangthai], [tenloai]) VALUES (N'003', NULL, N'Cafe')
INSERT [dbo].[tb_Loai] ([maloai], [trangthai], [tenloai]) VALUES (N'004', NULL, N'Juice')
INSERT [dbo].[tb_Loai] ([maloai], [trangthai], [tenloai]) VALUES (N'005', NULL, N'Blended')
INSERT [dbo].[tb_Loai] ([maloai], [trangthai], [tenloai]) VALUES (N'006', NULL, N'Tea')
/****** Object:  Table [dbo].[tb_Khachhang]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Khachhang](
	[makh] [nvarchar](10) NOT NULL,
	[tenkh] [nvarchar](50) NULL,
	[gioitinh] [nchar](10) NULL,
	[ngaysinh] [date] NULL,
	[cmnd] [nvarchar](50) NULL,
	[sdt] [nvarchar](50) NULL,
	[diachi] [nvarchar](50) NULL,
	[trangthai] [bit] NULL,
 CONSTRAINT [PK_tb_Khachhang] PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'001', N'Cẩm Nhi', N'Khác      ', CAST(0x6D1F0B00 AS Date), N'6616', N'0156', N'tp hcm', 0)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'002', N'd', N'Nữ        ', CAST(0x6D1F0B00 AS Date), N'6616', N'0156', N'tp hcm', 0)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'003', N'c', N'Nữ        ', CAST(0x001F0B00 AS Date), N'c', N'c', N'c', 0)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'1', N'1', N'Khác      ', CAST(0xD71E0B00 AS Date), N'22', N'1', N'11', 0)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'a111', N'a', N'          ', CAST(0x521E0B00 AS Date), N'a', N'a', N'', 0)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'a112', N'a', N'          ', CAST(0xD71E0B00 AS Date), N'a', N'a', N'', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'aaa', N'aa', N'Khác      ', CAST(0xD71E0B00 AS Date), N'aa', N'aa', N'', 0)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH000', N'Anonymous', N'Khác      ', CAST(0x01380B00 AS Date), N'000', N'000', N'Internet', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH001', N'Lệnh Hồ Xung', N'Nam       ', CAST(0x21160B00 AS Date), N'025399274', N'0123658271', N'số 532 đường Thôn Vĩ Dạ', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH002', N'Tiểu Long Nữ', N'Nữ        ', CAST(0xBF070B00 AS Date), N'069825774', N'0933344492', N'số 31 đường Tuyệt Tình Cốc', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH003', N'Doãn Chí Bình', N'Nam       ', CAST(0x0E0B0B00 AS Date), N'025899941', N'0936969690', N'số 1 đường Tuyệt Tình Cốc', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH004', N'Dương Quá', N'Nam       ', CAST(0xCB160B00 AS Date), N'025369978', N'0933784122', N'số 30 đường Tuyệt Tình Cốc ', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH005', N'Lý Mạc Sầu', N'Nữ        ', CAST(0x5FF90A00 AS Date), N'015749336', N'0168252431', N'số 230 đường Côn Lôn Sơn', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH006', N'Tuyệt Thịt Sư Thái', N'Nữ        ', CAST(0x2FEC0A00 AS Date), N'025399750', N'0937852819', N'516/37 đường Thái Lọ', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH007', N'Hàn Mạc Tử', N'Nam       ', CAST(0xFB070B00 AS Date), N'093725039', N'0937981985', N'số 1008 đường Thôn Vĩ Dạ', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH008', N'Trần Văn Phéo Chì', N'Nam       ', CAST(0x46080B00 AS Date), N'025399846', N'0166982336', N'số 10 đường Lò Gạch Cũ', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH009', N'Nguyễn Thợ Nỉ', N'Nữ        ', CAST(0xA10F0B00 AS Date), N'025198766', N'0168982336', N'số 50 đường Lò Gạch Cũ', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH010', N'Bác Ba Phi', N'Nam       ', CAST(0xD5EB0A00 AS Date), N'017855472', N'0126689899', N'số 97/125 đường Bốc Phét', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH011', N'Trương Tam Phong', N'Nam       ', CAST(0x3AF90A00 AS Date), N'012525318', N'0122672367', N'số 74/1 đường Võ Đang Sơn', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH012', N'Đoàn Dự', N'Nam       ', CAST(0xFC160B00 AS Date), N'028999753', N'0933777799', N'số 9 đường Đại Lý', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH013', N'Đội Trưởng Đội Quân Hoa Kỳ', N'Nam       ', CAST(0x690A0B00 AS Date), N'015444677', N'0167822311', N'số 15 đường Chợ Lớn', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH014', N'Người Nhọ Nhện', N'Nam       ', CAST(0x6C1F0B00 AS Date), N'022287424', N'0168987987', N'số 10 đường Đen Như Mực, thành phố Hồ Chí Minh', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH015', N'Trương Vô Kỵ', N'Nam       ', CAST(0x74250B00 AS Date), N'075394698', N'0122564546', N'số 352/22 đường Minh Giáo Chủ', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH016', N'Đông Phương Bất Bại', N'Nữ        ', CAST(0x06180B00 AS Date), N'062297787', N'0933304059', N'số 969 đường Khâm Thiêm', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH017', N'Thúy Kiều', N'Nữ        ', CAST(0x06D60A00 AS Date), N'062269131', N'0168974347', N'số 23 đường Phú Mỹ Hưng', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH018', N'Viên Độ Hòa Ma', N'Nữ        ', CAST(0xFBEA0A00 AS Date), N'025399753', N'0933388819', N'số 554 đường Phạm Thế Hiển', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH019', N'Tùng Tỉnh Linh Nại', N'Nữ        ', CAST(0xFF170B00 AS Date), N'025399758', N'0933388810', N'số 516 đường Phạm Thế Hiển', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH020', N'Kim Trọng', N'Nam       ', CAST(0x8F080B00 AS Date), N'025782332', N'0123985586', N'số 89 đường Hồ Tây', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH021', N'Khổng Lồ Xanh', N'Nam       ', CAST(0x8BF60A00 AS Date), N'025464147', N'0122311889', N'số 128 đường Xanh Lè Xanh Lét', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH022', N'Người Bàn Là', N'Nam       ', CAST(0x96F90A00 AS Date), N'035869477', N'0166734252', N'số 999 đường Giàu Nức Tường', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH023', N'Đổ Thánh', N'Nam       ', CAST(0x5F160B00 AS Date), N'013367279', N'0167914974', N'số 144/7 đường Tứ Đổ Tường', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH024', N'Minh Mập Béo', N'Nam       ', CAST(0x97110B00 AS Date), N'014964860', N'0188974352', N'số223/7/30 đường Một Tháng Sáu', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH025', N'Đại Đảo Ưu Tử', N'Nữ        ', CAST(0x1C130B00 AS Date), N'065387787', N'0937778924', N'số 516/30 đường Phạm Thế Hiển', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH026', N'Phồng Tôm', N'Nam       ', CAST(0x841F0B00 AS Date), N'025322231', N'0934682222', N'số 777 đường Đấm Phát Chết Luôn', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH027', N'Chu Bá Thông', N'Nam       ', CAST(0x53EC0A00 AS Date), N'087341691', N'0933367454', N'số 100 đường Toàn Chân Giáo', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH028', N'Mai An Tiêm', N'Nam       ', CAST(0x6D040B00 AS Date), N'047916791', N'0168686223', N'số 352 đường Đầy Dưa Hấu', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH029', N'Arsene Lupin', N'Nam       ', CAST(0xF2EF0A00 AS Date), N'053986955', N'0937796856', N'số 80 đường Walker thành phố London', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH030', N'Mèo Ú', N'Nam       ', CAST(0xF6190B00 AS Date), N'063258712', N'0169233911', N'số 233 đường Nhà Ngủ Gật', 1)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [ngaysinh], [cmnd], [sdt], [diachi], [trangthai]) VALUES (N'KH031', N'Mộc Mèo', N'Nữ        ', CAST(0x731E0B00 AS Date), N'0000666447', N'0932160279', N'số 80 đường Cây củi', 1)
/****** Object:  Table [dbo].[tb_User]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_User](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_User_1] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Sanpham]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Sanpham](
	[masp] [nvarchar](10) NOT NULL,
	[tensp] [nvarchar](50) NULL,
	[maloai] [nvarchar](10) NULL,
	[gianhap] [float] NULL,
	[giaban] [float] NULL,
	[soluong] [int] NULL,
	[trangthai] [bit] NULL,
	[hinhanh] [image] NULL,
 CONSTRAINT [PK_tb_Sanpham] PRIMARY KEY CLUSTERED 
(
	[masp] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'1', N'1', NULL, 1, 1, 1, 0, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'a', N'a', NULL, 100, 100, 10, 0, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'aa', N'aaa', N'', 100, 100, 10, 0, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'b', N'a', NULL, 100, 100, 10, 0, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'c', N'b', NULL, 100, 100, 100, 0, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'f', N'1', NULL, 100, 100, 10, 0, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP001', N'Black Coffee', N'003', 5000, 20000, 20, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP002', N'Kopi Luwak Coffee', N'003', 50000, 250000, 28, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP003', N'Bourbon Coffee', N'003', 30000, 200000, 27, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP004', N'Geisha Coffee', N'003', 15000, 200000, 25, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP005', N'Coffee Mocha', N'003', 7000, 50000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP006', N'Coffee Americano', N'003', 7000, 40000, 27, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP007', N'Hot Espresso', N'003', 5000, 35000, 28, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP008', N'Black Milk Coffee', N'003', 5000, 35000, 28, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP009', N'Capuchino', N'003', 6000, 40000, 24, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP010', N'Chocolate Coffee', N'003', 5000, 40000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP011', N'Caramel Coffee', N'003', 6000, 50000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP012', N'Phin Caramel Freeze', N'005', 7000, 70000, 28, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP013', N'Phin Green Freeze', N'005', 7000, 70000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP014', N'Green Tea Blended', N'005', 6000, 65000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP015', N'Chocomint Blended', N'005', 6000, 65000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP016', N'Cookie Blended', N'005', 7000, 70000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP017', N'Green Milk Tea', N'002', 6000, 50000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP018', N'Banana Juice', N'004', 3000, 40000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP019', N'Apple Juice', N'004', 3000, 40000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP020', N'Strawberry Juice ', N'004', 3000, 40000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP021', N'Peach Juice', N'004', 4000, 45000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP022', N'Lemon Juice', N'004', 3000, 40000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP023', N'Caramel Milk Tea', N'002', 6000, 50000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP024', N'Milk Oolong Tea', N'002', 6000, 50000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP025', N'Black Milk Tea', N'002', 6000, 50000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP026', N'Hokkaido Milk Tea', N'002', 6000, 50000, 29, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP027', N'Peach Macchiato', N'001', 10000, 70000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP028', N'Mango Macchiato', N'001', 7000, 60000, 30, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP029', N'Passion Fuit Macchiato', N'001', 10000, 70000, 27, 1, NULL)
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [maloai], [gianhap], [giaban], [soluong], [trangthai], [hinhanh]) VALUES (N'SP030', N'Matcha Macchiato', N'001', 10000, 70000, 30, 1, NULL)
/****** Object:  View [dbo].[View_NhanVien]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_NhanVien]
AS
SELECT        manv, tennv, diachi, gioitinh, ngaysinh, cmnd, loainv, tendangnhap, sdt
FROM            dbo.tb_Nhanvien
WHERE        (trangthai = 1)
GO
/****** Object:  View [dbo].[View_KhachHang]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_KhachHang]
AS
SELECT        makh, tenkh, gioitinh, ngaysinh, cmnd, sdt, diachi
FROM            dbo.tb_Khachhang
WHERE        (trangthai = 1)
GO
/****** Object:  Table [dbo].[tb_HDN]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HDN](
	[mahdn] [nvarchar](10) NOT NULL,
	[ngaynhap] [datetime] NULL,
	[manv] [nvarchar](10) NULL,
	[tongtien] [float] NULL,
 CONSTRAINT [PK_tb_HDN] PRIMARY KEY CLUSTERED 
(
	[mahdn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_HDB]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HDB](
	[mahdb] [nvarchar](10) NOT NULL,
	[ngayban] [datetime] NULL,
	[manv] [nvarchar](10) NULL,
	[makh] [nvarchar](10) NULL,
	[trangthai] [bit] NULL,
	[motalydoxoa] [nvarchar](max) NULL,
	[tongtien] [float] NULL,
 CONSTRAINT [PK_tb_HDB] PRIMARY KEY CLUSTERED 
(
	[mahdb] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0606183916', CAST(0x0000A78A01336B9E AS DateTime), N'NV001', N'KH000', NULL, NULL, 0)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0606184025', CAST(0x0000A78A0133BBD6 AS DateTime), N'NV001', N'KH000', NULL, NULL, 0)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0606184324', CAST(0x0000A78A01348D7B AS DateTime), N'NV001', N'KH000', NULL, NULL, 0)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0606195128', CAST(0x0000A78A01474019 AS DateTime), N'NV002', N'KH000', NULL, NULL, 0)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0706111149', CAST(0x0000A78B00B885FC AS DateTime), N'NV003', N'KH000', NULL, NULL, 0)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0806175311', CAST(0x0000A78C0126C3C8 AS DateTime), N'NV005', N'KH015', NULL, NULL, 0)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0806180458', CAST(0x0000A78C0129FF04 AS DateTime), N'NV006', N'KH000', NULL, NULL, 0)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0806181010', CAST(0x0000A78C012B6D35 AS DateTime), N'NV009', N'KH005', NULL, NULL, 80000)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0906233735', CAST(0x0000A78D01855AA5 AS DateTime), N'NV004', N'KH000', NULL, NULL, 20000)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'0906234619', CAST(0x0000A78D0187C072 AS DateTime), N'NV009', N'KH017', NULL, NULL, 620000)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'1206160023', CAST(0x0000A7900107C74D AS DateTime), N'NV001', N'KH001', NULL, NULL, 720000)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'1206160928', CAST(0x0000A790010A4619 AS DateTime), N'NV003', N'KH018', NULL, NULL, 200000)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'1706143558', CAST(0x0000A79500F098AD AS DateTime), N'NV001', N'KH000', NULL, NULL, 35000)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'1706150038', CAST(0x0000A79500F75E66 AS DateTime), N'NV001', N'KH000', NULL, NULL, 400000)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'1706150358', CAST(0x0000A79500F84878 AS DateTime), N'NV001', N'KH001', NULL, NULL, 35000)
INSERT [dbo].[tb_HDB] ([mahdb], [ngayban], [manv], [makh], [trangthai], [motalydoxoa], [tongtien]) VALUES (N'1706150611', CAST(0x0000A79500F8E541 AS DateTime), N'NV001', N'KH005', NULL, NULL, 200000)
/****** Object:  Table [dbo].[tb_CTHDN]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CTHDN](
	[mahdn] [nvarchar](10) NOT NULL,
	[tensp] [nvarchar](50) NOT NULL,
	[soluong] [int] NULL,
	[dongia] [float] NULL,
	[mancc] [nvarchar](10) NULL,
	[thanhtien] [float] NULL,
 CONSTRAINT [PK_tb_CTHDN] PRIMARY KEY CLUSTERED 
(
	[mahdn] ASC,
	[tensp] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_CTHDB]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CTHDB](
	[mahdb] [nvarchar](10) NOT NULL,
	[masp] [nvarchar](10) NOT NULL,
	[soluong] [float] NULL,
	[thanhtien] [float] NULL,
 CONSTRAINT [PK_tc_CTHDB] PRIMARY KEY CLUSTERED 
(
	[mahdb] ASC,
	[masp] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606183916', N'SP001', 3, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606183916', N'SP002', 2, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606183916', N'SP003', 1, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606183916', N'SP005', 4, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606183916', N'SP007', 2, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606183916', N'SP010', 3, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606184025', N'SP006', 1, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606184025', N'SP009', 2, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606184324', N'SP008', 1, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606195128', N'SP002', 3, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0606195128', N'SP010', 1, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0806175311', N'SP026', 1, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0806175311', N'SP029', 2, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0806180458', N'SP001', 3, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0806180458', N'SP004', 1, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0806180458', N'SP012', 2, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0806181010', N'SP002', 2, 500000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0806181010', N'SP009', 2, 80000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0906233735', N'SP001', 1, 20000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0906233735', N'SP003', 1, 200000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0906233735', N'SP004', 1, 200000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0906234619', N'SP001', 6, 120000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0906234619', N'SP006', 3, 120000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'0906234619', N'SP009', 4, 160000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'1206160023', N'SP004', 1, 200000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'1206160928', N'SP004', 1, 200000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'1206160928', N'SP005', 0, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'1206160928', N'SP009', 0, 0)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'1706143558', N'SP007', 1, 35000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'1706150038', N'SP003', 2, 400000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'1706150358', N'SP007', 1, 35000)
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [thanhtien]) VALUES (N'1706150611', N'SP004', 1, 200000)
/****** Object:  View [dbo].[View_SanPham]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_SanPham]
AS
SELECT        dbo.tb_Sanpham.masp, dbo.tb_Sanpham.tensp, dbo.tb_Loai.tenloai, dbo.tb_Sanpham.soluong, dbo.tb_Sanpham.gianhap, dbo.tb_Sanpham.giaban
FROM            dbo.tb_Sanpham INNER JOIN
                         dbo.tb_Loai ON dbo.tb_Sanpham.maloai = dbo.tb_Loai.maloai
WHERE        (dbo.tb_Sanpham.trangthai = 1)
GO
/****** Object:  View [dbo].[View_CTHDN]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_CTHDN]
AS
SELECT     dbo.tb_HDN.mahdn, dbo.tb_CTHDN.tensp, dbo.tb_NCC.tenncc, dbo.tb_CTHDN.soluong, dbo.tb_CTHDN.dongia, dbo.tb_CTHDN.thanhtien, dbo.tb_HDN.tongtien
FROM         dbo.tb_HDN INNER JOIN
                      dbo.tb_CTHDN ON dbo.tb_HDN.mahdn = dbo.tb_CTHDN.mahdn INNER JOIN
                      dbo.tb_NCC ON dbo.tb_CTHDN.mancc = dbo.tb_NCC.mancc
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tb_HDN"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_CTHDN"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 126
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "tb_NCC"
            Begin Extent = 
               Top = 6
               Left = 434
               Bottom = 126
               Right = 594
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_CTHDN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_CTHDN'
GO
/****** Object:  View [dbo].[View_CTHDB]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_CTHDB]
AS
SELECT        dbo.tb_CTHDB.mahdb, dbo.tb_CTHDB.masp, dbo.tb_Sanpham.tensp, dbo.tb_Sanpham.giaban, dbo.tb_CTHDB.soluong, dbo.tb_CTHDB.thanhtien
FROM            dbo.tb_CTHDB INNER JOIN
                         dbo.tb_Sanpham ON dbo.tb_CTHDB.masp = dbo.tb_Sanpham.masp INNER JOIN
                         dbo.tb_HDB ON dbo.tb_CTHDB.mahdb = dbo.tb_HDB.mahdb INNER JOIN
                         dbo.tb_Loai ON dbo.tb_Sanpham.maloai = dbo.tb_Loai.maloai
GO
/****** Object:  View [dbo].[HoaDon]    Script Date: 06/17/2017 16:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[HoaDon]
AS
SELECT        dbo.tb_HDB.mahdb, dbo.tb_HDB.ngayban, dbo.tb_HDB.manv, dbo.tb_HDB.makh, dbo.tb_CTHDB.masp, dbo.tb_Sanpham.tensp, dbo.tb_CTHDB.soluong, dbo.tb_CTHDB.thanhtien, dbo.tb_HDB.tongtien
FROM            dbo.tb_CTHDB INNER JOIN
                         dbo.tb_Sanpham ON dbo.tb_CTHDB.masp = dbo.tb_Sanpham.masp INNER JOIN
                         dbo.tb_HDB ON dbo.tb_CTHDB.mahdb = dbo.tb_HDB.mahdb INNER JOIN
                         dbo.tb_Nhanvien ON dbo.tb_HDB.manv = dbo.tb_Nhanvien.manv INNER JOIN
                         dbo.tb_Loai ON dbo.tb_Sanpham.maloai = dbo.tb_Loai.maloai INNER JOIN
                         dbo.tb_Khachhang ON dbo.tb_HDB.makh = dbo.tb_Khachhang.makh
GO
/****** Object:  ForeignKey [FK_tb_CTHDB_tb_HDB]    Script Date: 06/17/2017 16:49:22 ******/
ALTER TABLE [dbo].[tb_CTHDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHDB_tb_HDB] FOREIGN KEY([mahdb])
REFERENCES [dbo].[tb_HDB] ([mahdb])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_CTHDB] CHECK CONSTRAINT [FK_tb_CTHDB_tb_HDB]
GO
/****** Object:  ForeignKey [FK_tb_CTHDB_tb_Sanpham]    Script Date: 06/17/2017 16:49:22 ******/
ALTER TABLE [dbo].[tb_CTHDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHDB_tb_Sanpham] FOREIGN KEY([masp])
REFERENCES [dbo].[tb_Sanpham] ([masp])
GO
ALTER TABLE [dbo].[tb_CTHDB] CHECK CONSTRAINT [FK_tb_CTHDB_tb_Sanpham]
GO
/****** Object:  ForeignKey [FK_tb_CTHDN_tb_HDN]    Script Date: 06/17/2017 16:49:22 ******/
ALTER TABLE [dbo].[tb_CTHDN]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHDN_tb_HDN] FOREIGN KEY([mahdn])
REFERENCES [dbo].[tb_HDN] ([mahdn])
GO
ALTER TABLE [dbo].[tb_CTHDN] CHECK CONSTRAINT [FK_tb_CTHDN_tb_HDN]
GO
/****** Object:  ForeignKey [FK_tb_CTHDN_tb_NCC]    Script Date: 06/17/2017 16:49:22 ******/
ALTER TABLE [dbo].[tb_CTHDN]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHDN_tb_NCC] FOREIGN KEY([mancc])
REFERENCES [dbo].[tb_NCC] ([mancc])
GO
ALTER TABLE [dbo].[tb_CTHDN] CHECK CONSTRAINT [FK_tb_CTHDN_tb_NCC]
GO
/****** Object:  ForeignKey [FK_tb_HDB_tb_Khachhang]    Script Date: 06/17/2017 16:49:22 ******/
ALTER TABLE [dbo].[tb_HDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_HDB_tb_Khachhang] FOREIGN KEY([makh])
REFERENCES [dbo].[tb_Khachhang] ([makh])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_HDB] CHECK CONSTRAINT [FK_tb_HDB_tb_Khachhang]
GO
/****** Object:  ForeignKey [FK_tb_HDB_tb_Nhanvien]    Script Date: 06/17/2017 16:49:22 ******/
ALTER TABLE [dbo].[tb_HDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_HDB_tb_Nhanvien] FOREIGN KEY([manv])
REFERENCES [dbo].[tb_Nhanvien] ([manv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_HDB] CHECK CONSTRAINT [FK_tb_HDB_tb_Nhanvien]
GO
/****** Object:  ForeignKey [FK_tb_HDN_tb_Nhanvien]    Script Date: 06/17/2017 16:49:22 ******/
ALTER TABLE [dbo].[tb_HDN]  WITH CHECK ADD  CONSTRAINT [FK_tb_HDN_tb_Nhanvien] FOREIGN KEY([manv])
REFERENCES [dbo].[tb_Nhanvien] ([manv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_HDN] CHECK CONSTRAINT [FK_tb_HDN_tb_Nhanvien]
GO
/****** Object:  ForeignKey [FK_tb_Sanpham_tb_Loai]    Script Date: 06/17/2017 16:49:22 ******/
ALTER TABLE [dbo].[tb_Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_tb_Sanpham_tb_Loai] FOREIGN KEY([maloai])
REFERENCES [dbo].[tb_Loai] ([maloai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_Sanpham] CHECK CONSTRAINT [FK_tb_Sanpham_tb_Loai]
GO
