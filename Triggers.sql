
CREATE TRIGGER tg_ThemCTHDB
ON tb_CTHDB
FOR INSERT
AS
begin
	declare @sl int = (select soluong from inserted)
	declare @masp nvarchar(10) = (select masp from inserted)
	declare @mahdb nvarchar(10) = (select mahdb from inserted)
	update tb_Sanpham set soluong = soluong - @sl where masp = @masp
	--update tb_CTHDB set thanhtien = soluong * (select giaban from tb_Sanpham where masp = @masp) where masp = @masp
	--update tb_HDB set tongtien = tongtien+ (select thanhtien from tb_CTHDB where masp = @masp) where mahdb = @mahdb
end

CREATE TRIGGER tg_SuaCTHDB
ON tb_CTHDB
FOR update
AS
begin
	declare @sl int = (select soluong from inserted)
	declare @maspt nvarchar(10) = (select masp from inserted)
	declare @mahdb nvarchar(10) = (select mahdb from inserted)
	update tb_Sanpham set soluong = soluong - @sl where masp = @maspt
	--update tb_CTHDB set thanhtien = soluong * (select giaban from tb_Sanpham where masp = @maspt) where masp = @maspt
	--update tb_HDB set tongtien = tongtien+ (select thanhtien from tb_CTHDB where masp = @maspt) where mahdb = @mahdb

	declare @sls int = (select soluong from deleted)
	declare @maspx nvarchar(10) = (select masp from deleted)
	update tb_Sanpham set soluong = soluong + @sls where masp = @maspx
	--update tb_CTHDB set thanhtien = (thanhtien - (soluong * (select giaban from tb_Sanpham where masp = @maspx))) where masp = @maspx
	--update tb_HDB set tongtien = tongtien+ (select thanhtien from tb_CTHDB where masp = @maspx) where mahdb = @mahdb

end

CREATE TRIGGER tg_XoaCTHDB
ON tb_CTHDB
FOR Delete
AS
begin
	declare @sl int = (select soluong from deleted)
	declare @maspx nvarchar(10) = (select masp from deleted)
	declare @mahdb nvarchar(10) = (select mahdb from inserted)
	update tb_Sanpham set soluong = soluong + @sl where masp = @maspx
	--update tb_CTHDB set thanhtien = (thanhtien - (soluong * (select giaban from tb_Sanpham where masp = @maspx))) where masp = @maspx
	--update tb_HDB set tongtien = tongtien- (select thanhtien from tb_CTHDB where masp = @maspx) where mahdb = @mahdb
end


