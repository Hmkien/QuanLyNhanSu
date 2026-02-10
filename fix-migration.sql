-- Script ?? fix l?i migration Department sang PhongBan
-- Ch?y script này trong SQL Server Management Studio ho?c Azure Data Studio

USE HRM_DB;
GO

-- B??c 1: Ki?m tra d? li?u không h?p l?
SELECT 
    COUNT(*) AS 'Invalid Records',
    'ThongTinNguoiDungs có PhongBanId không t?n t?i trong PhongBans' AS Description
FROM ThongTinNguoiDungs 
WHERE PhongBanId IS NOT NULL 
AND PhongBanId NOT IN (SELECT Id FROM PhongBans);
GO

-- B??c 2: Xem chi ti?t các record không h?p l?
SELECT 
    Id,
    FullName,
    PhongBanId,
    'PhongBanId này không t?n t?i trong b?ng PhongBans' AS Issue
FROM ThongTinNguoiDungs 
WHERE PhongBanId IS NOT NULL 
AND PhongBanId NOT IN (SELECT Id FROM PhongBans);
GO

-- B??c 3: Set NULL cho các PhongBanId không h?p l?
UPDATE ThongTinNguoiDungs 
SET PhongBanId = NULL 
WHERE PhongBanId IS NOT NULL 
AND PhongBanId NOT IN (SELECT Id FROM PhongBans);
GO

-- B??c 4: Xóa foreign key c? n?u t?n t?i
IF EXISTS (
    SELECT 1 FROM sys.foreign_keys 
    WHERE name = 'FK_ThongTinNguoiDungs_PhongBans_PhongBanId'
)
BEGIN
    ALTER TABLE [ThongTinNguoiDungs] 
    DROP CONSTRAINT [FK_ThongTinNguoiDungs_PhongBans_PhongBanId];
    PRINT '?ã xóa constraint FK_ThongTinNguoiDungs_PhongBans_PhongBanId';
END
GO

-- B??c 5: T?o l?i foreign key constraint
ALTER TABLE [ThongTinNguoiDungs] 
ADD CONSTRAINT [FK_ThongTinNguoiDungs_PhongBans_PhongBanId] 
FOREIGN KEY ([PhongBanId]) REFERENCES [PhongBans] ([Id]) 
ON DELETE SET NULL;
GO

PRINT 'Migration fix hoàn t?t!';
GO

-- B??c 6: Ki?m tra l?i
SELECT 
    COUNT(*) AS 'Total Records in ThongTinNguoiDungs'
FROM ThongTinNguoiDungs;

SELECT 
    COUNT(*) AS 'Records with NULL PhongBanId'
FROM ThongTinNguoiDungs
WHERE PhongBanId IS NULL;

SELECT 
    COUNT(*) AS 'Records with Valid PhongBanId'
FROM ThongTinNguoiDungs
WHERE PhongBanId IS NOT NULL;
GO
