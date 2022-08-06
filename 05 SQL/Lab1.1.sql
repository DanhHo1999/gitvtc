CREATE TABLE tbl_DonVi
(
	MaDV nvarchar(5) not null primary key,
	TenDV nvarchar(50) not null
)
drop table tbl_nhanvien
create table tbl_nhanvien
(
	MaNv nvarchar(5) not null primary key,
	TenNV nvarchar(50) not null,
	NgaySinh Date,
	DiaChi nvarchar(50),
	DienThoai nvarchar(20),
	MaDV nvarchar(5),
	constraint pk_nv_dv foreign key (MaDV) references tbl_DonVi(MaDV)
)
