create database QL_SINHVIEN
use QL_SINHVIEN
create table tbl_monhoc
(
MaMH nvarchar(10) not null primary key,
TenMH nvarchar (50) not null
)
create table tbl_truong
(
MaTruong nvarchar(10) not null primary key,
TenTruong nvarchar(50) not null
)
create table tbl_sinhvien
(
MaSV nvarchar(10) not null primary key,
TenSV nvarchar(50)not null,
Phai nvarchar(5),
NgaySinh date,
MaTruong nvarchar(10)not null,
constraint fk_sv_t foreign key (MaTruong) references tbl_truong(MaTruong)
)
create table tbl_diem
(
MaSV nvarchar(10)not null,
MaMH nvarchar(10)not null,
DiemTB float not null,
primary key (MaSV,MaMH),
constraint fk_diem_monhoc foreign key (MaMH)references tbl_monhoc(MaMH),
constraint fk_diem_sinhvien foreign key(MaSV)references tbl_sinhvien(MaSV)
)

insert into tbl_truong values ('MT01',N'ĐH Bách Khoa')
insert into tbl_truong values ('MT02',N'ĐH Kinh Tế')
insert into tbl_truong values ('MT03',N'ĐH Sư Phạm')
insert into tbl_truong values ('MT04',N'ĐH Giao Thông')
insert into tbl_truong values ('MT05',N'VTCA')

insert into tbl_sinhvien values ('SV001',N'Nguyễn Văn Hùng',N'Nam','1990-03-12','MT01')
insert into tbl_sinhvien values ('SV002',N'Trần Diệu Nhi',N'Nữ','1990-06-22','MT02')
insert into tbl_sinhvien values ('SV003',N'Phạm Minh Đăng',N'Nam','1990-12-09','MT03')
insert into tbl_sinhvien values ('SV004',N'Nguyễn Anh Đào',N'Nữ','1991-08-12','MT01')
insert into tbl_sinhvien values ('SV005',N'Trần Văn Hưng',N'Nam','1990-09-12','MT02')

insert into tbl_monhoc values ('MH01',N'Thiết kế WEB')
insert into tbl_monhoc values ('MH02',N'Lập Trình WEB')
insert into tbl_monhoc values ('MH03',N'ASP.NET')
insert into tbl_monhoc values ('MH04',N'SQL Server')
insert into tbl_monhoc values ('MH05',N'HTML và CSS')
insert into tbl_monhoc values ('MH06',N'Lập trình căn bản')

insert into tbl_diem values ('SV001','MH01',9)
insert into tbl_diem values ('SV001','MH02',6.5)
insert into tbl_diem values ('SV001','MH03',8.5)
insert into tbl_diem values ('SV001','MH04',7)
insert into tbl_diem values ('SV002','MH01',8)
insert into tbl_diem values ('SV002','MH02',6.8)
insert into tbl_diem values ('SV002','MH03',7.5)
insert into tbl_diem values ('SV002','MH04',9)
insert into tbl_diem values ('SV003','MH01',8)
insert into tbl_diem values ('SV003','MH02',8)
insert into tbl_diem values ('SV003','MH03',5)
insert into tbl_diem values ('SV003','MH04',8)
insert into tbl_diem values ('SV004','MH01',8.5)
insert into tbl_diem values ('SV004','MH02',8.6)
insert into tbl_diem values ('SV004','MH03',5.8)
insert into tbl_diem values ('SV004','MH04',8.5)
insert into tbl_diem values ('SV005','MH01',7)
insert into tbl_diem values ('SV005','MH02',9.6)
insert into tbl_diem values ('SV005','MH03',8.8)
insert into tbl_diem values ('SV005','MH04',8.5)

insert into tbl_truong values ('MT06',N'ĐH KHTN')
insert into tbl_sinhvien values ('SV006',N'Trần Văn Minh',N'Nam','1990-09-12','MT06')
insert into tbl_sinhvien values ('SV007',N'Nguyễn Thị Ánh',N'Nữ','1991-08-12','MT06')
insert into tbl_diem values ('SV006','MH01',3.5)
insert into tbl_diem values ('SV006','MH02',2.5)
insert into tbl_diem values ('SV006','MH03',5.5)
insert into tbl_diem values ('SV006','MH05',3.5)
insert into tbl_diem values ('SV007','MH03',7.5)
insert into tbl_diem values ('SV007','MH06',4.5)




SELECT * FROM tbl_sinhvien as sv
inner join tbl_truong as t on t.MaTruong = sv.MaTruong
inner join tbl_diem as d on d.MaSV=sv.MaSV
inner join tbl_monhoc as mh on mh.MaMH=d.MaMH

SELECT sv.MaSV, TenSV, TenTruong, TenMH,DiemTB FROM tbl_sinhvien as sv
inner join tbl_truong as t on t.MaTruong = sv.MaTruong
inner join tbl_diem as d on d.MaSV=sv.MaSV
inner join tbl_monhoc as mh on mh.MaMH=d.MaMH

SELECT * FROM tbl_diem
SELECT * FROM tbl_monhoc
SELECT * FROM tbl_sinhvien
SELECT * FROM tbl_truong


/* CÂU 2 */
SELECT SV.MaSV, TenSV, TenTruong, DiemTB 
FROM tbl_sinhvien AS SV 
INNER JOIN tbl_truong AS T ON SV.MaTruong=T.MaTruong
INNER JOIN tbl_diem AS D ON D.MaSV=SV.MaSV
WHERE DiemTB<5 AND TenTruong LIKE N'%TN%'


/* CÂU 3 */
SELECT sv.MaSV,sv.TenSV,TenMH,DiemTB FROM
tbl_monhoc AS MH 
INNER JOIN tbl_diem as D on D.MaMH=mh.MaMH
INNER JOIN tbl_sinhvien as sv ON sv.MaSV=d.MaSV
where 
		TenSV like N'%Nguyễn%' 
		and DiemTB <5


/* Câu 4 */
SELECT top 3 sv.MaSV, sv.TenSV,TenMH, DiemTB FROM
tbl_sinhvien AS sv 
INNER JOIN tbl_diem AS d ON d.MaSV=sv.MaSV
INNER JOIN tbl_monhoc as mh ON mh.MaMH=d.MaMH
where TenMH like '%SQL%'
ORDER BY DiemTB desc


/* Câu 5 */
SELECT distinct  sv.MaSV, TenSV, Phai, TenTruong FROM
tbl_truong as t 
INNER JOIN tbl_sinhvien as sv ON t.MaTruong=sv.MaTruong
INNER JOIN tbl_diem as d ON d.MaSV=sv.MaSV
where TenTruong like N'%ác%' and DiemTB between 7 and 7.9

/* Câu 6 */
SELECT * FROM 
	
			tbl_sinhvien	as sv
inner join	tbl_truong		as t	on t.MaTruong = sv.MaTruong
inner join	tbl_diem		as d	on d.MaSV=sv.MaSV
inner join	tbl_monhoc		as mh	on mh.MaMH=d.MaMH

WHERE ngaysinh = (SELECT MAX(ngaysinh)FROM tbl_sinhvien) 

CREATE VIEW TABLES AS 
SELECT sv.MaSV,TenSV,Phai,NgaySinh,t.MaTruong,TenTruong,mh.MaMH,TenMH,DiemTB FROM 
			tbl_sinhvien	as sv
inner join	tbl_truong		as t	on t.MaTruong = sv.MaTruong
inner join	tbl_diem		as d	on d.MaSV=sv.MaSV
inner join	tbl_monhoc		as mh	on mh.MaMH=d.MaMH


SELECT * FROM TABLES

/* Tạo thủ tục đưa ra bảng điểm của 1 môn học bất kỳ Gồm: MaSV,TenSV,MaMH,TenMH,DiemTB */
CREATE PROC PROC1
@MAMH nvarchar(10)
AS
SELECT MASV,TENSV,MAMH,TENMH,DIEMTB FROM TABLES
WHERE MAMH=@MAMH

EXEC PROC1 'MH01'


/* Tạo thủ tục đưa ra bảng điểm của 1 SV bất kỳ Gồm: MaSV,MaMH,DiemTB */
CREATE PROC PROC2
@MASV nvarchar(10)
AS
SELECT MASV,MAMH,TENMH,DIEMTB FROM TABLES
WHERE MASV =@MASV

EXEC PROC2 'SV001'


/* Tạo thủ tục đưa ra Trung Bình Các Môn của 1 SV bất kỳ Gồm: MaSV,TenSV,Trung Bình Các Môn */
CREATE PROC PROC3
@MASV NVARCHAR(10)
AS
SELECT MASV,TENSV,AVG(DIEMTB) AS N'Trung Bình Các Môn' FROM TABLES WHERE MASV=@MASV GROUP BY MASV,TENSV

EXEC PROC3 'SV001'


/* Tạo thủ tục đưa ra sinh viên có điểm cao nhất của 1 môn học bất kỳ gồm: MaSV,TenSV,MaMH,DiemTB */
CREATE PROC TOP1
@MAMH NVARCHAR(10)
AS
SELECT TOP 1 MASV,TENSV,MAMH,TENMH,DIEMTB FROM TABLES 
WHERE MAMH=@MAMH ORDER BY DIEMTB DESC

EXEC TOP1 'MH03'


/* Tạo thủ tục đưa ra danh sách SV chưa thi (chưa có điểm) của 1 môn học bất kỳ gồm MaSV,TenSV. */
CREATE PROC PROC4
@MaMH NVARCHAR(10)
AS

SELECT MASV,TENSV FROM TABLES 
WHERE MASV NOT IN 
	(SELECT DISTINCT MASV FROM TABLES WHERE MAMH=@MAMH) 
GROUP BY MASV,TENSV


EXEC PROC4 'MH04'



/* TRIGGER */

CREATE TRIGGER THEM_MONHOC_TRIGGER
ON TBL_MONHOC
FOR INSERT,DELETE
AS
BEGIN
	PRINT N'BẠN ĐÃ THỰC HIỆN THÀNH CÔNG'
END

INSERT INTO tbl_monhoc VALUES ('MH07',N'MÔN 7')
DELETE FROM tbl_monhoc WHERE MaMH = 'MH07'


/* TẠO TRIGGER KIỂM TRA GIÁ TRỊ ĐIỂM PHẢI <= 10 */

CREATE TRIGGER DIEM_10_TRIGGER ON TBL_DIEM
FOR INSERT
AS
BEGIN
	IF (SELECT DIEMTB FROM inserted) > 10
		BEGIN
		PRINT N'THÊM THẤT BẠI';
		ROLLBACK TRAN;
		END
	ELSE
		PRINT N'THÊM THÀNH CÔNG';
END

INSERT INTO tbl_diem VALUES ('SV001','MH05',11)
DELETE FROM tbl_diem WHERE  MASV = 'SV001' AND MAMH='MH05'

INSERT INTO tbl_diem VALUES ('SV001','MH05',1)
DELETE FROM tbl_diem WHERE  MASV = 'SV001' AND MAMH='MH05'
UPDATE tbl_diem SET DiemTB = 5 WHERE  MASV = 'SV001' AND MAMH='MH05'
SELECT * FROM tbl_diem WHERE  MASV = 'SV001' AND MAMH='MH05'


DROP TRIGGER KHONG_SUA_DIEM_TRIGGER


CREATE TRIGGER KHONG_SUA_DIEM_TRIGGER ON TBL_DIEM
FOR UPDATE
AS 
BEGIN
	IF UPDATE(DIEMTB)
	BEGIN PRINT N'KHÔNG ĐƯỢC SỬA CỘT ĐIỂM' 
	ROLLBACK TRAN;
	END
END

DROP TRIGGER SOLUONG_XOA_TRIGGER
CREATE TRIGGER SOLUONG_XOA_TRIGGER ON TBL_DIEM
AFTER DELETE
AS
BEGIN
	DECLARE @NUM NCHAR;
	SELECT @NUM= COUNT(1)FROM DELETED;
	PRINT N'SỐ LƯỢNG BẢN GHI ĐÃ XÓA Ở BẢN ĐIỂM LÀ '+ @NUM;
END



insert into tbl_sinhvien values ('SV007',N'Nguyễn Thị Ánh',N'Nữ','1991-08-12','MT06')
insert into tbl_diem values ('SV007','MH03',7.5)
insert into tbl_diem values ('SV007','MH06',4.5)

CREATE TRIGGER XOA_SINHVIEN_TRIGGER ON TBL_SINHVIEN
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM tbl_diem WHERE MASV = (SELECT MASV FROM deleted)
	DELETE FROM tbl_sinhvien WHERE MASV = (SELECT MASV FROM deleted)
END

DELETE FROM tbl_sinhvien WHERE MASV='SV007'

DROP TRIGGER UPDATE_SCHOOL_ID_TRIGGER
CREATE TRIGGER UPDATE_SCHOOL_ID_TRIGGER ON TBL_TRUONG
INSTEAD OF UPDATE
AS BEGIN
ALTER TABLE TBL_SINHVIEN DROP CONSTRAINT fk_sv_t
UPDATE TBL_TRUONG	SET MaTruong = (SELECT MaTruong FROM inserted) WHERE MaTruong=(SELECT MaTruong FROM deleted)
UPDATE TBL_SINHVIEN SET MaTruong = (SELECT MaTruong FROM inserted) WHERE MaTruong=(SELECT MaTruong FROM deleted)
ALTER TABLE TBL_SINHVIEN ADD  CONSTRAINT fk_sv_t FOREIGN KEY(MaTruong) REFERENCES TBL_TRUONG(MaTruong)
PRINT N'THÀNH CÔNG'
END


UPDATE tbl_truong SET MaTruong = 'MT01' WHERE MaTruong='MT99'
UPDATE tbl_truong SET MaTruong = 'MT99' WHERE MaTruong='MT01'


SELECT * FROM TABLES 
/*  */
/*  */


