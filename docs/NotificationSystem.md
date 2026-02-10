# Hệ thống Notification Toast

## Tổng quan
Hệ thống thông báo toast hiện đại thay thế alert() truyền thống, hỗ trợ 4 loại thông báo với màu sắc và icon khác nhau.

## Các loại thông báo

### 1. Success (Thành công) - Màu xanh lá
```javascript
Notification.success('Đã thêm mới thành công');
Notification.success('Đã cập nhật dữ liệu', 3000); // duration tùy chỉnh
```

### 2. Error (Lỗi) - Màu đỏ
```javascript
Notification.error('Có lỗi xảy ra');
Notification.error('Không tìm thấy dữ liệu', 4000);
```

### 3. Warning (Cảnh báo) - Màu vàng
```javascript
Notification.warning('Đã huỷ duyệt');
Notification.warning('Cảnh báo: Dữ liệu sẽ bị mất', 3500);
```

### 4. Info (Thông tin) - Màu xanh dương
```javascript
Notification.info('Đang xử lý...');
Notification.info('Thông tin đã được ghi nhận', 3000);
```

## Sử dụng trong các action

### Thêm mới
```javascript
$.post(url, data)
    .done(function(res) {
        if (res.success) {
            Notification.success('Đã thêm mới thành công');
            setTimeout(function() { location.reload(); }, 1500);
        } else {
            Notification.error(res.message || 'Có lỗi xảy ra');
        }
    })
    .fail(function() {
        Notification.error('Có lỗi xảy ra khi thêm mới');
    });
```

### Cập nhật
```javascript
$.post(url, data)
    .done(function(res) {
        if (res.success) {
            Notification.success('Đã cập nhật thành công');
            setTimeout(function() { location.reload(); }, 1500);
        } else {
            Notification.error(res.message);
        }
    });
```

### Xóa
```javascript
$.post('/Controller/DeleteAjax', { id: id })
    .done(function(res) {
        if (res.success) {
            Notification.success('Đã xóa thành công');
            setTimeout(function() { location.reload(); }, 1500);
        } else {
            Notification.error(res.message || 'Có lỗi xảy ra khi xóa');
        }
    });
```

### Duyệt
```javascript
$.post('/Controller/ApproveAjax', { id: id })
    .done(function(res) {
        if (res.success) {
            Notification.success('Đã duyệt thành công');
            setTimeout(function() { location.reload(); }, 1500);
        } else {
            Notification.error(res.message);
        }
    });
```

### Huỷ duyệt
```javascript
$.post('/Controller/RejectAjax', { id: id })
    .done(function(res) {
        if (res.success) {
            Notification.warning('Đã huỷ duyệt');
            setTimeout(function() { location.reload(); }, 1500);
        } else {
            Notification.error(res.message);
        }
    });
```

## Tùy chỉnh Duration

Mặc định:
- success: 3000ms (3 giây)
- error: 4000ms (4 giây)
- warning: 3500ms (3.5 giây)
- info: 3000ms (3 giây)

Tùy chỉnh:
```javascript
Notification.success('Thông báo', 5000); // Hiển thị trong 5 giây
Notification.error('Lỗi nghiêm trọng', 10000); // 10 giây
```

## Modal xác nhận (Confirm)

```javascript
Notification.confirm({
    title: 'Xác nhận xóa',
    message: 'Bạn có chắc chắn muốn xóa?',
    type: 'warning',
    confirmText: 'Xóa',
    cancelText: 'Hủy',
    onConfirm: function() {
        // Code xử lý khi xác nhận
        $.post('/Controller/Delete', { id: id })
            .done(function(res) {
                if (res.success) {
                    Notification.success('Đã xóa thành công');
                    location.reload();
                }
            });
    },
    onCancel: function() {
        // Code xử lý khi hủy (optional)
        Notification.info('Đã hủy thao tác');
    }
});
```

## Lưu ý

1. **Không cần alert()**: Thay thế tất cả `alert()` bằng `Notification.error()` hoặc loại phù hợp
2. **Delay reload**: Sử dụng `setTimeout()` trước khi reload để người dùng thấy thông báo
3. **Consistent**: Sử dụng nhất quán trong toàn bộ ứng dụng:
   - Success: Khi thao tác thành công
   - Error: Khi có lỗi xảy ra
   - Warning: Khi huỷ duyệt hoặc cảnh báo
   - Info: Thông tin chung

##Ví dụ hoàn chỉnh

```javascript
// CRUD Operations với Notification

// Create/Edit
$('#saveBtn').on('click', function() {
    var id = $('#itemId').val();
    var url = id ? '/Controller/EditAjax' : '/Controller/CreateAjax';
    var action = id ? 'cập nhật' : 'thêm mới';
    
    $.post(url, $('#form').serialize())
        .done(function(res) {
            if (res.success) {
                Notification.success('Đã ' + action + ' thành công');
                setTimeout(function() { location.reload(); }, 1500);
            } else {
                Notification.error(res.message || 'Có lỗi xảy ra');
            }
        })
        .fail(function() {
            Notification.error('Không thể kết nối server');
        });
});

// Delete with confirmation modal
$(document).on('click', '[data-action="delete"]', function() {
    var id = $(this).data('id');
    
    Notification.confirm({
        title: 'Xác nhận xóa',
        message: 'Bạn có chắc chắn muốn xóa?',
        type: 'warning',
        onConfirm: function() {
            $.post('/Controller/DeleteAjax', { id: id })
                .done(function(res) {
                    if (res.success) {
                        Notification.success('Đã xóa thành công');
                        setTimeout(function() { location.reload(); }, 1500);
                    } else {
                        Notification.error(res.message);
                    }
                });
        }
    });
});

// Approve (no confirmation)
$(document).on('click', '[data-action="approve"]', function() {
    var id = $(this).data('id');
    $.post('/Controller/ApproveAjax', { id: id })
        .done(function(res) {
            if (res.success) {
                Notification.success('Đã duyệt thành công');
                setTimeout(function() { location.reload(); }, 1500);
            } else {
                Notification.error(res.message);
            }
        });
});

// Reject (no confirmation)
$(document).on('click', '[data-action="reject"]', function() {
    var id = $(this).data('id');
    $.post('/Controller/RejectAjax', { id: id })
        .done(function(res) {
            if (res.success) {
                Notification.warning('Đã huỷ duyệt');
                setTimeout(function() { location.reload(); }, 1500);
            } else {
                Notification.error(res.message);
            }
        });
});
```

## Áp dụng cho các views hiện tại

Đã áp dụng cho:
- ✅ Views/PhanLoaiNhanSu/Index.cshtml
- ✅ Views/Department/Index.cshtml

Cần áp dụng tiếp:
- Views/ChucVu/Index.cshtml
- Views/VaiTro/Index.cshtml
- Views/QuanTriHeThong/Index.cshtml
- Các views khác...
