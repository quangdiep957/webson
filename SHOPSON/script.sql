USE [SHOPSON]
GO
/****** Object:  Table [dbo].[DANHMUC]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANHMUC](
	[ID] [nvarchar](50) NOT NULL,
	[TENDM] [nvarchar](50) NULL,
 CONSTRAINT [PK_DANHMUC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIOHANG]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIOHANG](
	[ID] [nvarchar](50) NOT NULL,
	[TENSP] [nvarchar](50) NULL,
	[GIA] [nvarchar](50) NULL,
	[THETICH] [nvarchar](50) NULL,
	[MOTA] [nvarchar](max) NULL,
	[TONGTIEN] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](50) NULL,
	[ANH] [nvarchar](50) NULL,
	[MAMAU] [nvarchar](50) NULL,
	[HSD] [date] NULL,
	[TRANGTHAI] [bit] NULL,
	[MASP] [nvarchar](50) NULL,
 CONSTRAINT [PK_GIOHANG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [nvarchar](50) NOT NULL,
	[NGAYLAP] [date] NULL,
	[SOLUONG] [int] NULL,
	[GIA] [float] NULL,
	[TONGTIEN] [float] NULL,
	[MANV] [nvarchar](50) NULL,
	[MAKH] [nvarchar](50) NULL,
	[MATK] [nvarchar](50) NULL,
	[MASP] [nvarchar](50) NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [nvarchar](50) NOT NULL,
	[TENKH] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](50) NULL,
	[PASSWORD] [nchar](10) NULL,
	[DANHGIA] [nvarchar](max) NULL,
	[ANH] [nvarchar](50) NULL,
	[EMAIL] [nchar](10) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISP]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISP](
	[MLSP] [nvarchar](50) NOT NULL,
	[TLSP] [nvarchar](50) NULL,
	[MANCC] [nvarchar](50) NULL,
	[ANH] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAISP] PRIMARY KEY CLUSTERED 
(
	[MLSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MANCC] [nvarchar](50) NOT NULL,
	[TENNCC] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MANCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [nvarchar](50) NOT NULL,
	[TENNV] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[CHUCVU] [nvarchar](50) NULL,
	[LUONG] [float] NULL,
	[ANH] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MASP] [nvarchar](50) NOT NULL,
	[TENSP] [nvarchar](50) NULL,
	[GIA] [float] NULL,
	[THETICH] [nvarchar](50) NULL,
	[TRANGTHAI] [bit] NULL,
	[MOTA] [nvarchar](max) NULL,
	[MLSP] [nvarchar](50) NULL,
	[CAPDO] [nvarchar](50) NULL,
	[MAMAU] [nvarchar](50) NULL,
	[ANH] [nvarchar](50) NULL,
	[HSD] [date] NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[USERNAME] [nvarchar](50) NOT NULL,
	[PASSWORD] [nvarchar](50) NULL,
	[EMAIL] [nvarchar](50) NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THONGKE]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONGKE](
	[MATK] [nvarchar](50) NOT NULL,
	[NGAYLAP] [nvarchar](50) NULL,
	[TONGSPBAN] [nvarchar](50) NULL,
	[TONGTIENBAN] [nvarchar](50) NULL,
 CONSTRAINT [PK_THONGKE] PRIMARY KEY CLUSTERED 
(
	[MATK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TINTUC]    Script Date: 10/7/2021 8:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINTUC](
	[ID] [nvarchar](50) NOT NULL,
	[MOTA] [nvarchar](max) NULL,
	[NGAYDANG] [date] NULL,
	[ANH] [nvarchar](max) NULL,
	[TIEUDE] [nvarchar](max) NULL,
	[TRANGTHAI] [bit] NULL,
 CONSTRAINT [PK_TINTUC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[DANHMUC] ([ID], [TENDM]) VALUES (N'dm1', N'Chống thấm')
INSERT [dbo].[DANHMUC] ([ID], [TENDM]) VALUES (N'DM2', N'Sơn trang trí')
INSERT [dbo].[DANHMUC] ([ID], [TENDM]) VALUES (N'dm3', N'Tin tức-Sự kiện')
INSERT [dbo].[DANHMUC] ([ID], [TENDM]) VALUES (N'dm4', N'Giỏ hàng')
INSERT [dbo].[DANHMUC] ([ID], [TENDM]) VALUES (N'dm5', N'Liên hệ')
INSERT [dbo].[DANHMUC] ([ID], [TENDM]) VALUES (N'dm6', N'Đăng nhập')
GO
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDT], [DIACHI], [PASSWORD], [DANHGIA], [ANH], [EMAIL]) VALUES (N'MKH01', N'BUI MINH HANG', N'0923423433', N'HÀ NAM', N'123456    ', N'ìu', NULL, N'quangdiep ')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDT], [DIACHI], [PASSWORD], [DANHGIA], [ANH], [EMAIL]) VALUES (N'MKH02', NULL, NULL, NULL, N'quangdiep1', N'hello quangdiep1', NULL, N'q@gmail.c ')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [SDT], [DIACHI], [PASSWORD], [DANHGIA], [ANH], [EMAIL]) VALUES (N'MKH10', N'BUI QUANG DIEP', NULL, NULL, N'ac        ', N'em yêu anh', NULL, N'qa@gmail.v')
GO
INSERT [dbo].[LOAISP] ([MLSP], [TLSP], [MANCC], [ANH]) VALUES (N'MLSP01', N'LÓT NỘI', N'MNCC01', N'MLSP01group-1.png')
INSERT [dbo].[LOAISP] ([MLSP], [TLSP], [MANCC], [ANH]) VALUES (N'MLSP02', N'LÓT NGOẠI', N'MNCC01', N'MLSP02group-2.png')
INSERT [dbo].[LOAISP] ([MLSP], [TLSP], [MANCC], [ANH]) VALUES (N'MLSP03', N'CHỐNG THẤM TRẦN', N'MNCC01', N'MLSP03group-3.png')
INSERT [dbo].[LOAISP] ([MLSP], [TLSP], [MANCC], [ANH]) VALUES (N'MLSP04', N'CHỐNG THẤM TƯỜNG', N'MNCC01', N'MLSP04group-4.png')
INSERT [dbo].[LOAISP] ([MLSP], [TLSP], [MANCC], [ANH]) VALUES (N'MLSP05', N'CHỐNG CHUYÊN DỤNG', N'MNCC01', N'MLSP05group-5.png')
GO
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC]) VALUES (N'MNCC01', N'SONBOSS')
GO
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [SDT], [CHUCVU], [LUONG], [ANH]) VALUES (N'MNV01', N'BUI QUANG DIEP', N'0911067145', N'GIÁM ĐỐC', 100000000, N'MNV01diep.jpg')
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [SDT], [CHUCVU], [LUONG], [ANH]) VALUES (N'MNV02', N'BUI MINH TUAN', N'0985679872', N'CHU TICH', 100000000, N'MNV02a.jpg')
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [SDT], [CHUCVU], [LUONG], [ANH]) VALUES (N'MNV03', N'BUI MINH HANG', N'0336482934', N'KẾ TOÁN', 50000000, N'MNV03bg1.jpg')
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [SDT], [CHUCVU], [LUONG], [ANH]) VALUES (N'MNV04', N'BUI DUC ANH', N'0985679872', N'KẾ TOÁN', 100000000, N'MNV041_l.jpg')
GO
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP02', N'SƠN HUMAC', 1400000, N'6L', 1, N'TRANG TRI NHÀ CỬA', N'MLSP05', N'00010002', N'XANH', N'MSP02BOSS-MATT-FINISH.png', CAST(N'2030-09-26' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP03', N'SƠN TRANG TRÍ', 1200000, N'6L', 1, N'TRANG TRI NHÀ CỬA', N'MLSP01', N'00010003', N'XANH LAM', N'MSP03bb.png', CAST(N'2030-09-28' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP04', N'lu tường', 50000, NULL, 1, N'lăn sơn ', N'MLSP01', N'00040001', N'XANH LAM', N'MSP041_a1c0ff1c8dc94e81828f0ef27228f6b2_master.jpg', CAST(N'2030-09-26' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP05', N'SƠN AKALI', 3200000, N'18L', 1, N'TRANG TRI NHÀ CỬA', N'MLSP01', N'00030004', N'FULL', N'MSP05da.png', CAST(N'2030-09-27' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP06', N'BỘT CHÉT', 2000000, N'18L', 1, N'BỘT CHÉT', N'MLSP01', N'00050001', N'TRẮNG', N'MSP06SONBOSS-PUTTY-INTERIOR.png', CAST(N'2030-09-27' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP07', N'SƠN LUXE', 546, N'6L', 1, N'TRANG TRI NHÀ CỬA', N'MLSP01', N'00030001', N'XANH', N'MSP07pmtd.png', CAST(N'2030-09-27' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP08', N'SƠN SB02', 12000000, N'18L', 1, N'CHỐNG THẤM PHA XI', N'MLSP03', N'00030001', N'XÁM', N'MSP08sb02.png', CAST(N'2030-09-27' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP09', N'SƠN TRANG TRÍ', 12000000, N'18L', 1, N'TRANG TRI NHÀ CỬA', N'MLSP01', N'00010003', N'XÁM', N'MSP09bot.png', CAST(N'2030-09-29' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP10', N'SƠN SB13', 12000000, N'18L', 1, N'CHỐNG THẤM PHA XI', N'MLSP01', N'00030003', N'FULL', N'MSP10SB13-5KG.png', CAST(N'2030-09-28' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP11', N'BỘT SPING', 700000, N'1', 1, N'BỘT SPING TRẮNG', N'MLSP03', N'00040001', N'TRẮNG', N'MSP11SPRING-POWDER-PUTTY-FOR-INT-NEW.png', CAST(N'2030-09-29' AS Date))
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [GIA], [THETICH], [TRANGTHAI], [MOTA], [MLSP], [CAPDO], [MAMAU], [ANH], [HSD]) VALUES (N'MSP12', N'SƠN SUPPER SATIN', 2000000, N'3.5L', 1, N'TRANG TRI NHÀ CỬA NỘI THẤT', N'MLSP04', N'00010008', N'XANH LAM', N'MSP12Boss-super-satin.png', CAST(N'2030-09-29' AS Date))
GO
INSERT [dbo].[TAIKHOAN] ([USERNAME], [PASSWORD], [EMAIL]) VALUES (N'ADMIN', N'123456', N'QUANGDIEP957@GMAIL.COM')
INSERT [dbo].[TAIKHOAN] ([USERNAME], [PASSWORD], [EMAIL]) VALUES (N'QUANGDIEP', N'QUANGDIEP1', N'NULLQUANGDIEP957@GMAIL.COM')
GO
INSERT [dbo].[THONGKE] ([MATK], [NGAYLAP], [TONGSPBAN], [TONGTIENBAN]) VALUES (N'MTK01', N'9/26/2021', N'3', N'10500000')
GO
INSERT [dbo].[TINTUC] ([ID], [MOTA], [NGAYDANG], [ANH], [TIEUDE], [TRANGTHAI]) VALUES (N'1', N'Chú thích ảnh Tổng Bí thư Nguyễn Phú Trọng. Ảnh: Trí Dũng/TTXVN Tổng Bí thư Nguyễn Phú Trọng đã phân tích một cách toàn diện, sâu sắc và kỹ lưỡng về con đường mà Việt Nam đã đi từ sau thắng lợi của cuộc Cách mạng Tháng Tám năm 1945 đến nay, đồng thời chỉ rõ trong suốt quá trình lãnh đạo đất nước, Đảng Cộng sản Việt Nam đã vận dụng sáng tạo chủ nghĩa Mác -Lenin vào điều kiện cụ thể của Việt Nam để giải quyết một loạt vấn đề phức tạp, hóc búa. Theo nhà sử học Gerhard Feldbauer, đây là những bài học kinh nghiệm quý báu không chỉ cho Việt Nam mà còn cho nhiều nước trên thế giới.  Ông Gerhard Feldbauer nêu rõ bài viết của Tổng Bí thư Nguyễn Phú Trọng đã đề cập đến những mốc son chói lọi trong lịch sử Việt Nam, với sự kiện Đảng Cộng sản Việt Nam đã lãnh đạo nhân dân Việt Nam thực hiện thành công Cách mạng Tháng Tám, và ngày 2/9/1945, Chủ tịch Hồ Chí Minh đã trịnh trọng tuyên bố với thế giới về sự ra đời của nước Việt Nam Dân chủ Cộng hòa. Nhà sử học chia sẻ: “Chúng ta hiện đang sống trong giai đoạn thăng trầm của cuộc đấu tranh cách mạng, trong đó Việt Nam là một ví dụ chỉ cho chúng ta thấy rằng con đường đi đến một xã hội mới-  xã hội mà ở đó không còn cảnh người bóc lột người- nhất định sẽ thành công dù cho phải trải qua bao chông gai chăng nữa”.  Ông Gerhard Feldbauer nhấn mạnh sau khi hệ thống xã hội chủ nghĩa ở Liên Xô và Đông Âu tan rã vào những năm 1989-1990, Đảng Cộng sản Việt Nam và những người cộng sản kiên trung đã không chùn bước trên con đường xây dựng chủ nghĩa xã hội. Ngày nay, Đảng Cộng sản Việt Nam đã có hơn 5,1 triệu đảng viên, trong đó 60% là những người trẻ tuổi. Những con số này bác bỏ hoàn toàn những luận điệu xuyên tạc rằng những người trẻ tuổi ở Việt Nam không còn quan tâm đến chính trị hay chủ nghĩa xã hội nữa.  Nhà báo Feldbauer nhắc lại rằng Tổng Bí thư Nguyễn Phú Trọng vẫn luôn xác định “phải kiên trì con đường mà Chủ tịch Hồ Chí Minh và Đảng, nhân dân ta đã lựa chọn”. Quốc hội Việt Nam cũng đã nhấn mạnh rằng tăng trưởng và phát triển về mặt kinh tế không có nghĩa là xa rời mục tiêu xây dựng chủ nghĩa xã hội. Đó là điều hoàn toàn đúng đắn. Người dân Việt Nam đồng tình với quan điểm của lãnh đạo Đảng và Nhà nước, rằng đất nước đang tiến lên trên con đường xây dựng một xã hội “thực sự vì con người, không phải bóc lột và vì lợi nhuận”- một xã hội “tiến bộ và bình đẳng, … nhân ái, đoàn kết, tương trợ vì các giá trị nhân văn”. Cách Việt Nam ứng phó với đại dịch COVID-19 cho thấy rõ điều đó. Ngoài ra, Việt Nam cũng có nhiều đóng góp cho sự phát triển quan hệ hợp tác giữa các quốc gia châu Á và trên thế giới, trên cơ sở láng giềng hữu nghị.  Theo ông Gerhard Feldbauer, bài viết của Tổng Bí thư Nguyễn Phú Trọng cho thấy Việt Nam đang trên con đường tiến tới một nền kinh tế công nghiệp hiện đại theo định hướng xã hội chủ nghĩa. Từ một quốc gia nghèo nàn, lạc hậu về kinh tế do hậu quả của chiến tranh, Việt Nam đã vươn lên trở thành một trong những nền kinh tế năng động nhất thế giới và tăng trưởng nhanh nhất khu vực Đông Nam Á với tốc độ tăng trưởng hằng năm đạt từ 6-8% thời kỳ trước đại dịch COVID-19, cuộc sống của người dân tốt hơn nhiều, nguồn cung cấp lương thực-thực phẩm được đảm bảo, giới trẻ có đầy đủ cơ hội tiếp cận giáo dục đào tạo, riêng thành phố Hồ Chí Minh đã có 50 trường đại học và cao đẳng. Kể từ khi thực hiện đường lối Đổi mới, Việt Nam đã ký kết nhiều hiệp định song phương và gia nhập các tổ chức quốc tế như Quỹ Tiền tệ quốc tế (IMF), Ngân hàng thế giới (WB) và gần đây nhất là Hiệp định Thương mại tự do với Liên minh châu Âu (EVFTA); duy trì quan hệ hợp tác kinh tế- thương mại với Mỹ,…  Ông Gerhard Feldbauer cho rằng EVFTA đã giúp Việt Nam mở rộng vị thế là đối tác thương mại lớn thứ hai của EU trong ASEAN. Trong năm 2018, Việt Nam xuất khẩu hàng hóa và dịch vụ trị giá hơn 35 tỷ euro sang các nước EU, bao gồm quần áo, điện thoại di động và phụ tùng; đồng thời nhập khẩu hơn 10 tỷ euro hàng hóa từ EU. Xuất khẩu của Việt Nam sang EU chỉ thấp hơn 10 tỷ euro so với tổng khối lượng xuất khẩu của nhóm các nền kinh tế Mercosur (Brazil, Argentina, Paraguay và Uruguay) sang EU trong năm 2018. Điều này cho thấy Việt Nam hoàn toàn không chỉ là nhà cung cấp nguyên liệu thô mà còn là một địa điểm sản xuất hàng hóa quan trọng cho các nước EU.  Về những thách thức mà Việt Nam có thể đối mặt trên con đường đi lên chủ nghĩa xã hội, nhà sử học Feldbauer cho rằng trong quá trình hợp tác, một số đối tác bên ngoài luôn tìm cách thúc đẩy khu vực kinh tế tư bản tư nhân ở Việt Nam lấn át khu vực kinh tế nhà nước nhằm phá hoại con đường đi lên chủ nghĩa xã hội ở Việt Nam. Tuy nhiên, Việt Nam luôn giữ vững lập trường, bác bỏ mọi âm mưu tác động đến quyền lãnh đạo của Việt Nam trong lĩnh vực kinh tế. Đây là yếu tố quyết định, đảm bảo cho sự thành công của Việt Nam trên con đường đã chọn. Bên cạnh đó, tệ nạn tham nhũng cũng là một thách thức, đòi hỏi Việt Nam tiếp tục mạnh tay xử lý triệt để.   Nhà sử học Đức nêu rõ điểm mấu chốt của việc tiếp tục con đường xã hội chủ nghĩa là khẳng định vai trò lãnh đạo của Đảng Cộng sản Việt Nam, kiên quyết ngăn chặn mọi ý đồ từ bên ngoài hòng hạ thấp hoặc loại bỏ vai trò lãnh đạo của Đảng trong tương lai. Đảng cũng cần gắn bó mật thiết với nhân dân trong mọi lĩnh vực. Ông Feldbauer tin tưởng rằng đất nước Việt Nam có một đội ngũ tiên phong, kiên cường chiến đấu theo nghĩa chân thực nhất, và với sự lãnh đạo của Đảng Cộng sản, đất nước Việt Nam luôn vượt qua những giai đoạn khó khăn nhất trong lịch sử.  Học giả Đức cũng chia sẻ rằng ông đã nhiều lần được gặp Chủ tịch Hồ Chí Minh. Ông nhấn mạnh mọi thắng lợi của cách mạng Việt Nam đều có vai trò to lớn của Chủ tịch Hồ Chí Minh - vị lãnh tụ của dân tộc Việt Nam. Bản Di chúc của Người chứa chan tình yêu thương đối với nhân dân, với đất nước; đồng thời thể hiện niềm tin sắt đá rằng cách mạng nhất định sẽ thắng lợi vẻ vang. Ông cũng đề cao tinh thần chiến đấu bất khuất kiên cường, không biết mệt mỏi của nhân dân Việt Nam, coi đây là điều kiện tiên quyết giúp tạo nên những thắng lợi của cách mạng Việt Nam.   Nhà sử học Gerhard Feldbauer, sinh năm 1933, nguyên là phóng viên của hãng thông tấn ADN của CHDC Đức tại Hà Nội. Ông đã cùng vợ - phóng viên ảnh Irene- làm việc tại Hà Nội từ năm 1967 đến năm 1970 với tư cách là phóng viên của hãng thông tấn AND. Sau đó, ông làm việc cho ADN ở Rome (Italy) từ năm 1973 đến năm 1979. Ông nhận bằng Tiến sĩ về lịch sử Việt Nam. Năm 1980, ông chuyển sang ngành ngoại giao và là Đại sứ tại Zaire (nay thuộc Cộng hòa Dân chủ Congo). Ông đã viết 15 cuốn sách (trong đó có 4 tác phẩm về Việt Nam) và nhiều tài liệu khác. Hiện ông tiếp tục cộng tác, viết bài cho nhiều tờ báo ở Đức.', CAST(N'2021-10-06' AS Date), N'1post4.png', N'Bài viết của Tổng Bí thư Nguyễn Phú Trọng chỉ rõ những kinh nghiệm vận dụng sáng tạo chủ nghĩa Mác-Lenin', 1)
INSERT [dbo].[TINTUC] ([ID], [MOTA], [NGAYDANG], [ANH], [TIEUDE], [TRANGTHAI]) VALUES (N'2', N'Chống thấm cho hồ cá Koi', CAST(N'2021-10-06' AS Date), N'2post5.png', N'Chống thấm cho hồ cá Koi', 1)
GO
ALTER TABLE [dbo].[GIOHANG]  WITH CHECK ADD  CONSTRAINT [FK_GIOHANG_SANPHAM] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GIOHANG] CHECK CONSTRAINT [FK_GIOHANG_SANPHAM]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHACHHANG] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_KHACHHANG]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NHANVIEN]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_SANPHAM] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_SANPHAM]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_THONGKE] FOREIGN KEY([MATK])
REFERENCES [dbo].[THONGKE] ([MATK])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_THONGKE]
GO
ALTER TABLE [dbo].[LOAISP]  WITH CHECK ADD  CONSTRAINT [FK_LOAISP_NHACUNGCAP] FOREIGN KEY([MANCC])
REFERENCES [dbo].[NHACUNGCAP] ([MANCC])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LOAISP] CHECK CONSTRAINT [FK_LOAISP_NHACUNGCAP]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAISP] FOREIGN KEY([MLSP])
REFERENCES [dbo].[LOAISP] ([MLSP])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_LOAISP]
GO
