CREATE DATABASE BTL_QLNS;
GO

USE BTL_QLNS;
GO

-- Tạo bảng tblNhanVien
CREATE TABLE tblNhanVien (
    iMaNV INT PRIMARY KEY,
    sHoTen NVARCHAR(30),
    dNgaySinh DATETIME,
    fPhuCap FLOAT,
    fLuongCB FLOAT,
    sDienThoai NVARCHAR(12) UNIQUE,
    CCCD NVARCHAR(12) NOT NULL UNIQUE
);
GO

-- Tạo bảng tblHoaDonBan
CREATE TABLE tblHoaDonBan (
    sMaHDBan VARCHAR(20) PRIMARY KEY NOT NULL,
    iMaNV INT FOREIGN KEY REFERENCES tblNhanVien(iMaNV),
    sMaKH VARCHAR(20) NOT NULL,
    dNgayLap DATE NOT NULL
);
GO

-- Tạo bảng tblChiTietHoaDonBan
CREATE TABLE tblChiTietHoaDonBan (
    iID INT PRIMARY KEY NOT NULL,
    sMaHDBan VARCHAR(20) NOT NULL,
    sMaSach VARCHAR(20) NOT NULL, 
    sTenSach NVARCHAR(50) NOT NULL, 
    iSoLuongBan INT NOT NULL,
    fGiaSach FLOAT NOT NULL,
    fThanhTien FLOAT NOT NULL
);
GO

-- Tạo bảng tblHoaDonNhap
CREATE TABLE tblHoaDonNhap (
    sMaHDNhap VARCHAR(20) PRIMARY KEY NOT NULL,
    iMaNV INT FOREIGN KEY REFERENCES tblNhanVien(iMaNV),
    dNgayNhap DATE NOT NULL
);
GO

-- Tạo bảng tblChiTietHoaDonNhap
CREATE TABLE tblChiTietHoaDonNhap (
    iID INT PRIMARY KEY NOT NULL,
    sMaHDNhap VARCHAR(20) NOT NULL,
    sMaSach VARCHAR(20) NOT NULL, 
    iSoLuongNhap INT NOT NULL,
    fGiaSach FLOAT NOT NULL,
    fThanhTien FLOAT NOT NULL
);
GO

-- Tạo bảng tblKhachHang
CREATE TABLE tblKhachHang (
    sMaKH VARCHAR(20) PRIMARY KEY NOT NULL,
    sTenKH NVARCHAR(30) NOT NULL,
    sDiachi NVARCHAR(50) NOT NULL,
    sSdt VARCHAR(12) NOT NULL,
    sEmail NVARCHAR(40) NULL
);
GO

-- Tạo bảng tblNhaXuatBan
CREATE TABLE tblNhaXuatBan (
    sMaNXB VARCHAR(20) PRIMARY KEY NOT NULL,
    sTenNXB NVARCHAR(20) NOT NULL,
    sDiaChi NVARCHAR(50) NOT NULL
);
GO

-- Tạo bảng tblSach
CREATE TABLE tblSach (
    sMaSach VARCHAR(20) PRIMARY KEY NOT NULL,
    sTenSach NVARCHAR(50) NOT NULL,
    fGiaSach FLOAT NOT NULL,
    iSoLuong INT NOT NULL,
    sMaNXB VARCHAR(20) NOT NULL,
    sTheLoai NVARCHAR(20) NULL
);
GO

-- Tạo bảng tblTaiKhoan
CREATE TABLE tblTaiKhoan (
    sTenTk VARCHAR(10) PRIMARY KEY NOT NULL,
    sMatKhau NVARCHAR(20) NOT NULL,
    sTen NVARCHAR(20) NOT NULL,
    iMaNV INT FOREIGN KEY REFERENCES tblNhanVien(iMaNV)
);
GO

-- Tạo các liên kết giữa các bảng
ALTER TABLE tblSach
ADD CONSTRAINT Fk_tblSach_tblNhaXuatBan FOREIGN KEY (sMaNXB)
REFERENCES tblNhaXuatBan(sMaNXB) ON DELETE CASCADE;
GO

ALTER TABLE tblChiTietHoaDonNhap
ADD CONSTRAINT Fk_tblChiTietHoaDonNhap_tblHoaDonNhap FOREIGN KEY (sMaHDNhap)
REFERENCES tblHoaDonNhap(sMaHDNhap) ON DELETE CASCADE;
GO

ALTER TABLE tblChiTietHoaDonNhap
ADD CONSTRAINT Fk_tblChiTietHoaDonNhap_tblSach FOREIGN KEY (sMaSach)
REFERENCES tblSach(sMaSach) ON DELETE CASCADE;
GO

ALTER TABLE tblHoaDonBan
ADD CONSTRAINT Fk_sMaKH FOREIGN KEY (sMaKH)
REFERENCES tblKhachHang(sMaKH) ON DELETE CASCADE;
GO

ALTER TABLE tblChiTietHoaDonBan
ADD CONSTRAINT Fk_tblChiTietHoaDonBan_tblHoaDonBan FOREIGN KEY (sMaHDBan)
REFERENCES tblHoaDonBan(sMaHDBan) ON DELETE CASCADE;
GO

ALTER TABLE tblChiTietHoaDonBan
ADD CONSTRAINT Fk_tblChiTietHoaDonBan_tblSach FOREIGN KEY (sMaSach)
REFERENCES tblSach(sMaSach) ON DELETE CASCADE;
GO



-- Chèn dữ liệu vào bảng tblNhanVien
INSERT INTO tblNhanVien (iMaNV, sHoTen, dNgaySinh, fPhuCap, fLuongCB, sDienThoai, CCCD)
VALUES 
(1, N'Nguyễn Văn An', '1990-05-10', 2000000, 8000000, '0912345678', '012345678901'),
(2, N'Trần Thị Bích', '1992-08-15', 1500000, 7500000, '0923456789', '012345678902'),
(3, N'Lê Văn Cường', '1988-12-20', 1000000, 6000000, '0934567890', '012345678903');
GO

-- Chèn dữ liệu vào bảng tblKhachHang
INSERT INTO tblKhachHang (sMaKH, sTenKH, sDiachi, sSdt, sEmail)
VALUES
('KH01', N'Phạm Văn Đức', N'Số 1, Đường Hoàng Quốc Việt, Cầu Giấy, Hà Nội', '0945678901', 'phamvanduc@example.com'),
('KH02', N'Hoàng Thị Lan', N'Số 2, Đường Nguyễn Chí Thanh, Đống Đa, Hà Nội', '0956789012', 'hoangthilan@example.com'),
('KH03', N'Nguyễn Văn Minh', N'Số 3, Đường Kim Mã, Ba Đình, Hà Nội', '0967890123', 'nguyenvanminh@example.com');
GO

-- Chèn dữ liệu vào bảng tblNhaXuatBan
-- Chèn dữ liệu vào bảng tblNhaXuatBan
INSERT INTO tblNhaXuatBan (sMaNXB, sTenNXB, sDiaChi)
VALUES
('NXB01', N'NXB Kim Đồng', N'Số 55, Đường Quang Trung, Hai Bà Trưng, Hà Nội'),
('NXB02', N'NXB Trẻ', N'Số 45, Đường Lý Tự Trọng, Quận 1, TP Hồ Chí Minh'),
('NXB03', N'NXB Giáo Dục', N'Số 81, Đường Lý Thường Kiệt, Hoàn Kiếm, Hà Nội');
GO


-- Chèn dữ liệu vào bảng tblSach
INSERT INTO tblSach (sMaSach, sTenSach, fGiaSach, iSoLuong, sMaNXB, sTheLoai)
VALUES
('S01', N'Những người khốn khổ', 120000, 100, 'NXB01', N'Tiểu thuyết'),
('S02', N'Truyện Kiều', 150000, 200, 'NXB02', N'Truyện thơ'),
('S03', N'Thép đã tôi thế đấy', 180000, 150, 'NXB03', N'Văn học Nga');
GO

-- Chèn dữ liệu vào bảng tblHoaDonBan
INSERT INTO tblHoaDonBan (sMaHDBan, iMaNV, sMaKH, dNgayLap)
VALUES
('HDB01', 1, 'KH01', '2024-07-01'),
('HDB02', 2, 'KH02', '2024-07-02'),
('HDB03', 3, 'KH03', '2024-07-03');
GO

-- Chèn dữ liệu vào bảng tblChiTietHoaDonBan
INSERT INTO tblChiTietHoaDonBan (iID, sMaHDBan, sMaSach, sTenSach, iSoLuongBan, fGiaSach, fThanhTien)
VALUES
(1, 'HDB01', 'S01', N'Những người khốn khổ', 2, 120000, 240000),
(2, 'HDB02', 'S02', N'Truyện Kiều', 1, 150000, 150000),
(3, 'HDB03', 'S03', N'Thép đã tôi thế đấy', 3, 180000, 540000);
GO

-- Chèn dữ liệu vào bảng tblHoaDonNhap
INSERT INTO tblHoaDonNhap (sMaHDNhap, iMaNV, dNgayNhap)
VALUES
('HDN01', 1, '2024-06-15'),
('HDN02', 2, '2024-06-16'),
('HDN03', 3, '2024-06-17');
GO

-- Chèn dữ liệu vào bảng tblChiTietHoaDonNhap
INSERT INTO tblChiTietHoaDonNhap (iID, sMaHDNhap, sMaSach, iSoLuongNhap, fGiaSach, fThanhTien)
VALUES
(1, 'HDN01', 'S01', 50, 120000, 6000000),
(2, 'HDN02', 'S02', 70, 150000, 10500000),
(3, 'HDN03', 'S03', 40, 180000, 7200000);
GO

-- Chèn dữ liệu vào bảng tblTaiKhoan
INSERT INTO tblTaiKhoan (sTenTk, sMatKhau, sTen, iMaNV)
VALUES
('user01', 'password01', N'Nguyễn Văn An', 1),
('user02', 'password02', N'Trần Thị Bích', 2),
('user03', 'password03', N'Lê Văn Cường', 3);
GO

-- Tạo trigger

-- Tạo trigger update giá trong kho sẽ lớn hơn giá nhập 10000
CREATE TRIGGER trg_GiaSachTrongKho
ON tblChiTietHoaDonNhap
FOR INSERT, UPDATE
AS
BEGIN
           	DECLARE @maSach VARCHAR(20)
           	DECLARE @gianhap FLOAT
           	SELECT @maSach = Inserted.sMaSach, @gianhap = Inserted.fGiaSach FROM Inserted
           	UPDATE dbo.tblSach SET fGiaSach = @gianhap + 10000  WHERE sMaSach = @maSach
END
GO

-- Tạo trigger cập nhật hàng trong kho sau khi nhập hàng hoặc cập nhật 
CREATE TRIGGER trg_SoLuongSachNhap ON tblChiTietHoaDonNhap AFTER INSERT AS 
BEGIN
	UPDATE tblSach
	SET iSoLuong = iSoLuong + (
		SELECT iSoLuongNhap
		FROM inserted
		WHERE sMaSach = tblSach.sMaSach )
	FROM tblSach JOIN inserted ON tblSach.sMaSach = inserted.sMaSach
END
GO

-- Tạo trigger cập nhật hàng trong kho sau khi cập nhật nhập hàng 
CREATE TRIGGER trg_CapNhatSoSachNhap on tblChiTietHoaDonNhap after update AS
BEGIN
   UPDATE tblSach SET iSoLuong = iSoLuong +
	   (SELECT iSoLuongNhap FROM inserted WHERE sMaSach = tblSach.sMaSach) -
	   (SELECT iSoLuongNhap FROM deleted WHERE sMaSach = tblSach.sMaSach)
   FROM tblSach 
   JOIN deleted ON tblSach.sMaSach = deleted.sMaSach
end
GO

-- Tạo trigger cập nhật hàng trong kho sau khi hủy nhập hàng 
create TRIGGER trg_HuySoSachNhap ON tblChiTietHoaDonNhap FOR DELETE AS 
BEGIN
	UPDATE tblSach
	SET iSoLuong = iSoLuong - (SELECT iSoLuongNhap FROM deleted WHERE sMaSach = tblSach.sMaSach)
	FROM tblSach 
	JOIN deleted ON tblSach.sMaSach = deleted.sMaSach
END
GO

-- Tạo trigger cập nhật hàng trong kho sau khi bán hàng hoặc cập nhật 
CREATE TRIGGER trg_SoLuongSachBan ON tblChiTietHoaDonBan AFTER INSERT AS 
BEGIN
	UPDATE tblSach
	SET iSoLuong = iSoLuong - (
		SELECT iSoLuongBan
		FROM inserted
		WHERE sMaSach = tblSach.sMaSach )
	FROM tblSach JOIN inserted ON tblSach.sMaSach = inserted.sMaSach
END
GO

-- Tạo trigger cập nhật hàng trong kho sau khi cập nhật bán hàng 
CREATE TRIGGER trg_CapNhatSoSachBan on tblChiTietHoaDonBan after update AS
BEGIN
   UPDATE tblSach SET iSoLuong = iSoLuong -
	   (SELECT iSoLuongBan FROM inserted WHERE sMaSach = tblSach.sMaSach) +
	   (SELECT iSoLuongBan FROM deleted WHERE sMaSach = tblSach.sMaSach)
   FROM tblSach 
   JOIN deleted ON tblSach.sMaSach = deleted.sMaSach
end
GO

-- Tạo trigger cập nhật hàng trong kho sau khi hủy bán hàng 
create TRIGGER trg_HuySoSachBan ON tblChiTietHoaDonBan FOR DELETE AS 
BEGIN
	UPDATE tblSach
	SET iSoLuong = iSoLuong + (SELECT iSoLuongBan FROM deleted WHERE sMaSach = tblSach.sMaSach)
	FROM tblSach 
	JOIN deleted ON tblSach.sMaSach = deleted.sMaSach
END
GO

-- Tạo thủ tục

-- Tạo proc check user và password
CREATE PROC proc_login
@user varchar(10),
@pass nvarchar(20)
AS
BEGIN
	SELECT * FROM tblTaiKhoan WHERE sTenTk = @user and sMatKhau = @pass
END
GO

-- Tạo proc quên mật khẩu
CREATE PROC proc_quenmatkhau
@user varchar(10)
AS
BEGIN
	SELECT * FROM tblTaiKhoan WHERE sTenTk = @user 
END
GO

-- Tạo proc hiện hóa đơn nhập
CREATE PROC proc_hoadonnhap
@smahdnhap VARCHAR(20)
AS
BEGIN
	select tblHoaDonNhap.sMaHDNhap, sMaSach, iSoLuongNhap, fGiaSach, fThanhTien, iMaNV, dNgayNhap 
	FROM tblChiTietHoaDonNhap inner join tblHoaDonNhap on tblHoaDonNhap.sMaHDNhap = tblChiTietHoaDonNhap.sMaHDNhap 
	WHERE tblHoaDonNhap.sMaHDNhap = @smahdnhap
END
GO

EXEC proc_hoadonnhap @smahdnhap = HDNhap_01
GO

-- Tạo proc hiện hóa đơn bán
CREATE PROC proc_hoadonban
@smahdban VARCHAR(20)
AS
BEGIN
	select tblHoaDonBan.sMaHDBan, sMaSach, iSoLuongBan, fGiaSach, fThanhTien, dNgayLap, tblHoaDonBan.sMaKH, sTenSach
	FROM tblChiTietHoaDonBan inner join tblHoaDonBan on tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan 
	WHERE tblHoaDonBan.sMaHDBan = @smahdban
END
GO

EXEC proc_hoadonban @smahdban = HDBan_01
GO

SELECT * FROM tblTaiKhoan WHERE sTenTk <> 'admin'
GO

select * from tblChiTietHoaDonNhap where sMaSach = 'MS_01'
GO
-


drop proc proc_hoadonnhap