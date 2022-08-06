create database QL_HOADON
use QL_HOADON

create table tbl_KhachHang
(MaKH nvarchar(10)not null primary key,
TenKH nvarchar(50) not null,
DcKH nvarchar(100))

create table tbl_NhanVien
(MaNV nvarchar(10) not null primary key,
TenNV nvarchar(50)not null,
DCNV nvarchar(100),
DT varchar(15))

create table tbl_SanPham
(MaSP nvarchar(10)not null primary key,
TenSP nvarchar(50)not null,
DVi nvarchar(10)not null,
DonGia int not null)

create table tbl_HoaDon
(MaHD nvarchar(10)not null primary key,
MaKH nvarchar(10) not null,
MaNV nvarchar(10)not null,
NgayLapHD date,
NgayNhanHang date
constraint fk_hoadon_nhanvien foreign key(MaNV)references tbl_NhanVien(MaNV),
constraint fk_hoadon_khachhang foreign key(MaKH)references tbl_KhachHang(MakH))

create table tbl_CTHhoaDon
(MaHD nvarchar(10)not null,
MaSP nvarchar(10)not null,
SoLuong int not null,
primary key(MaHD,MaSP),
constraint fk_cthoadon_sanpham foreign key(MaSP)references tbl_SanPham(MaSP),
constraint fk_cthoadon_hoadon foreign key(MaHD)references tbl_hoadon(MaHD))


insert into tbl_NhanVien values ('NV1','Nguyễn Văn Linh','16 Dương Quảng Hàm','0909090909')
insert into tbl_NhanVien values ('NV2','Trần Thị Phương','31 Quang Trung','0909090909')
insert into tbl_NhanVien values ('NV3','Nguyễn Đồng','12 Bạch Đằng','0909090909')

insert into tbl_SanPham values ('BD','Bếp điện','cái',5000000)
insert into tbl_SanPham values ('MT','Máy tính','cái',8000000)
insert into tbl_SanPham values ('NCD','Nồi cơm điện','cái',1000000)
insert into tbl_SanPham values ('QD','Quạt điện','cái',1200000)
insert into tbl_SanPham values ('TL','Tủ lạnh','cái',12000000)

insert into tbl_KhachHang values ('KH001','Hoàng Thái','Gò vấp,HCM')
insert into tbl_KhachHang values ('KH002','Lê Trinh','Quận 3,HCM')
insert into tbl_KhachHang values ('KH003','Trần Đại','Quận 1,HCM')
insert into tbl_KhachHang values ('KH004','Phạm Lai','Bình Thạnh,HCM')

insert into tbl_CTHhoaDon values ('HD001','BD',2)
insert into tbl_CTHhoaDon values ('HD001','NCD',3)
insert into tbl_CTHhoaDon values ('HD001','TL',1)
insert into tbl_CTHhoaDon values ('HD002','MT',1)
insert into tbl_CTHhoaDon values ('HD002','QD',3)
insert into tbl_CTHhoaDon values ('HD003','MT',5)

insert into tbl_HoaDon values ('HD001','KH001','NV1','2010-01-01','2010-01-02')
insert into tbl_HoaDon values ('HD002','KH002','NV2','2011-02-01','2011-02-01')
insert into tbl_HoaDon values ('HD003','KH003','NV3','2011-03-02','2011-04-02')
insert into tbl_HoaDon values ('HD004','KH003','NV1','2011-04-03','2011-04-03')