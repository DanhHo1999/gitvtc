create database QL_BANHANG
use QL_BANHANG
create table tbl_hang(
HangID nvarchar(10) not null primary key,
TenHang nvarchar(50) not null,
DonVi nvarchar(10) not null,
DonGia int not null
)
create table tbl_khach(
KhachID nvarchar(10) not null primary key,
TenKhach nvarchar(50) not null,
DiaChi nvarchar(50),
Email nvarchar(50),
Picture nvarchar(10)
)
create table tbl_hoadon
(
HoaDonID nvarchar(10) not null primary key,
NgayBan date not null,
KhachID nvarchar(10) not null
)
create table tbl_hangban
(
	HangID nvarchar(10) not null,
	HoaDonID nvarchar(10) not null,
	primary key (HangID,HoaDonID),
	SoLuong int not null
)
alter table tbl_hoadon add constraint pk_hd_k foreign key (KhachID) references tbl_khach(KhachID)
alter table tbl_hangban add constraint pk_hb_hd foreign key (HoaDonID) references tbl_hoadon(HoaDonID)
alter table tbl_hangban add 
constraint pk_hb_h foreign key (HangID) references tbl_hang(HangID)
alter table tbl_hangban add constraint pc_sl check(SoLuong>0)

insert into tbl_hang values ('H001',N'Bàn Phím',N'Cái',10)
insert into tbl_hang values ('H002',N'Ram',N'Thanh',200)
insert into tbl_hang values ('H003',N'Màn Hình',N'Màn',300)
insert into tbl_hang values ('H004',N'Máy in',N'Cái',150)
insert into tbl_hang values ('H005',N'Ổ cứng',N'Ổ',100)

insert into tbl_khach values ('K001',N'Nguyễn Văn An',N'Hà Nội','an@gmail.com','Hinh 1')
insert into tbl_khach values ('K002',N'Trần Minh Chiến',N'Đà nẵng','chien@gmail.com','Hinh 2')
insert into tbl_khach values ('K003',N'Nguyễn Thị Hồng',N'Long An','hong@gmail.com','Hinh 3')
insert into tbl_khach values ('K004',N'Nguyễn Thu Trang',N'Hồ Chí Minh','trang@gmail.com','Hinh 4')
insert into tbl_khach values ('K005',N'Phạm Tuấn Ngọc',N'Hà Nội','ngoc@gmail.com','Hinh 5')
insert into tbl_khach values ('K006',N'Phạm Thành Danh',N'Hồ Chí Minh','danh@gmail.com','Hinh 6')

insert into tbl_hoadon values ('HD01','2021-03-12','K001')
insert into tbl_hoadon values ('HD02','2021-04-01','K002')
insert into tbl_hoadon values ('HD03','2021-08-09','K001')
insert into tbl_hoadon values ('HD04','2021-12-12','K003')
insert into tbl_hoadon values ('HD05','2022-01-12','K004')
insert into tbl_hoadon values ('HD06','2022-01-26','K005')
insert into tbl_hoadon values ('HD07','2022-02-02','K006')
insert into tbl_hoadon values ('HD08','2022-03-01','K002')
insert into tbl_hoadon values ('HD09','2022-03-11','K001')

insert into tbl_hangban values ('H001','HD01',4)
insert into tbl_hangban values ('H001','HD02',5)
insert into tbl_hangban values ('H001','HD04',4)
insert into tbl_hangban values ('H001','HD05',4)
insert into tbl_hangban values ('H002','HD01',2)
insert into tbl_hangban values ('H002','HD04',8)
insert into tbl_hangban values ('H002','HD06',4)
insert into tbl_hangban values ('H003','HD01',12)
insert into tbl_hangban values ('H003','HD02',8)
insert into tbl_hangban values ('H003','HD07',4)
insert into tbl_hangban values ('H004','HD03',4)
insert into tbl_hangban values ('H004','HD08',4)
insert into tbl_hangban values ('H005','HD03',11)

SELECT * FROM tbl_hangban ORDER BY HoaDonID

SELECT HangID,SUM(SoLuong) AS 'Sum', COUNT(SoLuong) AS 'Count',Avg(SoLuong) as 'Avg'
FROM tbl_hangban
GROUP BY HangID


SELECT * FROM tbl_hangban

SELECT COUNT(*)
FROM tbl_hangban

SELECT top 3 HangID,COUNT(*)
FROM tbl_hangban
GROUP BY hangID
ORDER BY count(*) ASC, hangid ASC

SELECT top 3 HangID,COUNT(*)
FROM tbl_hangban
GROUP BY hangID
ORDER BY count(*) DESC,hangid DESC


SELECT * FROM tbl_hangban
SELECT * FROM tbl_hoadon

SELECT * FROM 
tbl_hoadon as hd 
INNER JOIN tbl_hangban as hb ON hb.HoaDonID = hd.HoaDonID
inner join tbl_khach as k on k.KhachID=hd.KhachID
inner join tbl_hang as h on h.HangID=hb.HangID
Group by k.KhachID 

SELECT * FROM 
tbl_hoadon as hd 
INNER JOIN tbl_hangban as hb ON hb.HoaDonID = hd.HoaDonID
inner join tbl_khach as k on k.KhachID=hd.KhachID
inner join tbl_hang as h on h.HangID=hb.HangID

SELECT top 3 k.KhachID, TenKhach,TenHang, NgayBan, SoLuong from
tbl_hoadon as hd 
INNER JOIN tbl_hangban as hb ON hb.HoaDonID = hd.HoaDonID
inner join tbl_khach as k on k.KhachID=hd.KhachID
inner join tbl_hang as h on h.HangID=hb.HangID
order by SoLuong asc

SELECT k.KhachID, TenKhach,TenHang, NgayBan, SoLuong from
tbl_hoadon as hd 
INNER JOIN tbl_hangban as hb ON hb.HoaDonID = hd.HoaDonID
inner join tbl_khach as k on k.KhachID=hd.KhachID
inner join tbl_hang as h on h.HangID=hb.HangID
where NgayBan between'2021-01-01' and '2022-12-31' and TenKhach like N'Nguyễn%'



Select * from 
tbl_hoadon as hd 
INNER JOIN tbl_hangban as hb ON hb.HoaDonID = hd.HoaDonID
inner join tbl_khach as k on k.KhachID=hd.KhachID



/* đưa ra danh sách số lượng mặt hàng h001 của từng khách hàng gồm: tên khách hàng, tổng số lượng mặt hàng H001 */

SELECT TenKhach,SoLuong from
tbl_hoadon as hd 
INNER JOIN tbl_hangban as hb ON hb.HoaDonID = hd.HoaDonID
inner join tbl_khach as k on k.KhachID=hd.KhachID
inner join tbl_hang as h on h.HangID=hb.HangID
where h.HangID='H001'

SELECT TenKhach,Sum(SoLuong) as SoLuong  from
tbl_hoadon as hd 
INNER JOIN tbl_hangban as hb ON hb.HoaDonID = hd.HoaDonID
inner join tbl_khach as k on k.KhachID=hd.KhachID
where HangID='H001'
Group By TenKhach having Sum(SoLuong)>4

/* Đưa ra Mã K H trong danh sách hóa đơn */
SELECT DISTINCT KhachID from tbl_hoadon 

/* Đưa ra danh sách các khách hàng không mua hàng trong tháng 1 */


SELECT DISTINCT KhachID from tbl_hoadon WHERE KhachID NOT IN 
(SELECT DISTINCT KhachID from tbl_hoadon WHERE month(ngayban) IN (1,2) AND year(ngayban) IN (2021))












/*View*/

/*tạo view đưa ra danh sách gồm: khachId, Tenkhach, HoaDonID, ngày bán*/
create view v_dskh1 as
select hd.KhachID, TenKhach, HoaDonID, NgayBan
from tbl_hoadon hd inner join tbl_khach k on hd.KhachID = k.KhachID

select * from v_dskh1

drop view v_dskh1

/*Đưa ra danh sách tổng số lượng mặt hàng H001 > 4 của từng khách hàng
gồm: Tên khách hàng, tổng số lượng hàng H001*/
create view dskh2 as
select TenKhach, sum(SoLuong) as 'TongSL'
from tbl_hangban hb inner join tbl_hoadon hd on hb.HoaDonID = hd.HoaDonID
inner join tbl_khach k on hd.KhachID = k.KhachID
inner join tbl_hang h on hb.HangID = h.HangID
where hb.HangID = 'H001'
group by k.KhachID, TenKhach
having sum(SoLuong) > 4

select * from dskh2

/*tạo view đưa ra danh sách các mặt hàng được bán trong 3 tháng 3,6,9
có số lượng > 5 gồm: HangID, TenHang, NgayBan, So luog*/
create view dskh3 as
select hb.HangID, TenHang, NgayBan, SoLuong as 'Hang duoc ban trong 3 thang'
from tbl_hangban hb inner join tbl_hoadon hd on hb.HoaDonID = hd.HoaDonID
inner join tbl_khach k on hd.KhachID = k.KhachID
inner join tbl_hang h on hb.HangID = h.HangID
where month(NgayBan) in (3,6,9)
group by hb.HangID, TenHang, NgayBan, SoLuong
having sum(SoLuong) > 5

select * from dskh3
/*tạo view đưa ra các danh sách KH có tổng tiền mua cao nhất gồm:
KhachID, TenKhach, tongtien*/
create view dskh4 as
select k.KhachID, TenKhach, NgayBan, Sum(DonGia*SoLuong) as 'TongTienHD'
from tbl_hangban hb inner join tbl_hoadon hd on hb.HoaDonID = hd.HoaDonID
inner join tbl_khach k on hd.KhachID = k.KhachID
inner join tbl_hang h on hb.HangID = h.HangID
group by k.KhachID, TenKhach, NgayBan

select * from dskh4

/*Tạo view đưa ra 1 khách hàng có tổng tiền đã mua cao nhất:
gồm: MaKhach, TenKhach, Tong tien mua hàng*/
create view dskh5 as
select top 1 k.KhachID, TenKhach, Sum(DonGia*SoLuong) as 'Tổng tiền'
from tbl_hangban hb inner join tbl_hoadon hd on hb.HoaDonID = hd.HoaDonID
inner join tbl_khach k on hd.KhachID = k.KhachID
inner join tbl_hang h on hb.HangID = h.HangID
group by k.KhachID, TenKhach
order by Sum(DonGia*SoLuong) desc

select * from dskh5

/* tạo view đưa ra doanh thu các tháng
gồm: Tháng, doanh thu*/
create view v_dskh6 as
select month(NgayBan) as 'Tháng', Sum(DonGia*SoLuong) as 'doanh thu'
from tbl_hangban hb inner join tbl_hoadon hd on hb.HoaDonID = hd.HoaDonID
inner join tbl_khach k on hd.KhachID = k.KhachID
inner join tbl_hang h on hb.HangID = h.HangID
group by hd.NgayBan
order by month(NgayBan) 

create view dskh6 as
select *,month(NgayBan) as 'thang' from dskh4

select thang, sum(TongTienHD) as 'DoanhThu' from dskh6
group by thang



/*tạo thủ tục đưa ra danh sách các hóa đơn của K001
gồm: HoaDonID,NgayBan, KhachID, TenKhach*/
select hd.HoaDonID, NgayBan, hd.KhachID, TenKhach
from tbl_hangban hb inner join tbl_hoadon hd on hb.HoaDonID = hd.HoaDonID
inner join tbl_khach k on hd.KhachID = k.KhachID
inner join tbl_hang h on hb.HangID = h.HangID
where hd.KhachID = N'K001'

/*tạo thủ tục đưa ra danh sách các hóa đơn của các khách hàng
gồm: HoaDonID,NgayBan, KhachID, TenKhach*/
create proc sp_DSHD1
as 
select hd.HoaDonID, NgayBan, hd.KhachID, TenKhach
from tbl_hangban hb inner join tbl_hoadon hd on hb.HoaDonID = hd.HoaDonID
inner join tbl_khach k on hd.KhachID = k.KhachID
inner join tbl_hang h on hb.HangID = h.HangID

exec sp_DSHD1


/*tạo thủ tục đưa ra danh sách các hóa đơn của một mã khách hàng bất kì
gồm: HoaDonID,NgayBan, KhachID, TenKhach*/
create proc sp_DSHD2
@KhachID nvarchar(10)
as

select HoaDonID, NgayBan, KhachID, TenKhach from all_tables 
where KhachID=@KhachID



exec sp_DSHD2 'K003'

/*tạo thủ tục đưa ra danh sách các hóa đơn đã bán của một KhachID bất kì
gồm: MaKhach, TenKhach, Tong tien mua hàng*/
create proc proc3
@KhachID nvarchar(10)
as
select KhachID,TenKhach,HoaDonID,count(SoLuong) as N'Số Lượng Loại Hàng',sum(SoLuong*dongia)as N'Tổng Tiền' from all_tables 
where khachID=@KhachID
group by HoaDonID,KhachID,TenKhach

Exec proc3 'K003'
drop proc proc3



/*Tạo thủ tục đưa ra các mặt hàng đã bán của hóa đơn bất kì
gồm: Hangid, ten hang, so luong , don gia*/

create proc proc4
@HoaDonID nvarchar(10)
as
select HoaDonID,HangID,TenHang,SoLuong,DonGia from all_tables
where HoaDonID=@HoaDonID

exec proc4 'HD01'


/*Tạo thủ tục đua ra tổng tiền của 1 khách hàng bất kì
gồm: Mã Khách, Tên khách, tổng tiền*/
create proc proc5
@KhachID nvarchar(10)
as

select KhachID,TenKhach,Sum(SoLuong*DonGia)as'TongTien' from all_tables
where khachID=@KhachID 
group by KhachID,TenKhach

exec proc5 'K001'


/* Tạo thủ tục Chèn vào 4 dữ liệu vào 4 bảng trong CSDL */
/* Tạo thủ tục đưa ra bảng điểm của 1 môn học bất kỳ Gồm: MaSV,TenSV,MaMH,TenMH,DiemTB */
/* Tạo thủ tục đưa ra bảng điểm của 1 SV bất kỳ Gồm: MaSV,MaMH,DiemTB */
/* Tạo thủ tục đưa ra Trung Bình Các Môn của 1 SV bất kỳ Gồm: MaSV,TenSV,Trung Bình Các Môn */
/* Tạo thủ tục đưa ra sinh viên có điểm cao nhất của 1 môn học bất kỳ gồm: MaSV,TenSV,MaMH,DiemTB */
/* Tạo thủ tục đưa ra danh sách SV chưa thi (chưa có điểm) của 1 môn học bất kỳ gồm MaSV,TenSV. */
/*  */
/*  */
/*  */
/*  */
select * from all_tables order by KhachID

