// notification.js - Hệ thống thông báo chung

const Notification = {
    // Hiển thị thông báo
    show: function(message, type = 'info', duration = 3000) {
        const toastId = 'toast-' + Date.now();
        const icon = this.getIcon(type);
        const bgClass = this.getBgClass(type);
        
        const toastHtml = `
            <div id="${toastId}" class="toast align-items-center text-white ${bgClass} border-0" role="alert" aria-live="assertive" aria-atomic="true">
                <div class="d-flex">
                    <div class="toast-body">
                        <i class="${icon} me-2"></i>${message}
                    </div>
                    <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                </div>
            </div>
        `;
        
        const container = document.getElementById('toast-container');
        if (container) {
            container.insertAdjacentHTML('beforeend', toastHtml);
            
            const toastElement = document.getElementById(toastId);
            const toast = new bootstrap.Toast(toastElement, {
                delay: duration,
                autohide: true
            });
            
            toast.show();
            
            // Tự động xóa khỏi DOM sau khi ẩn
            toastElement.addEventListener('hidden.bs.toast', function() {
                toastElement.remove();
            });
            
            return toast;
        }
        return null;
    },
    
    // Thông báo thành công
    success: function(message, duration = 3000) {
        return this.show(message, 'success', duration);
    },
    
    // Thông báo lỗi
    error: function(message, duration = 4000) {
        return this.show(message, 'error', duration);
    },
    
    // Thông báo cảnh báo
    warning: function(message, duration = 3500) {
        return this.show(message, 'warning', duration);
    },
    
    // Thông báo thông tin
    info: function(message, duration = 3000) {
        return this.show(message, 'info', duration);
    },
    
    // Lưu thông báo vào sessionStorage để hiển thị sau khi reload
    successAndReload: function(message) {
        sessionStorage.setItem('notification', JSON.stringify({ type: 'success', message: message }));
        location.reload();
    },
    
    errorAndReload: function(message) {
        sessionStorage.setItem('notification', JSON.stringify({ type: 'error', message: message }));
        location.reload();
    },
    
    warningAndReload: function(message) {
        sessionStorage.setItem('notification', JSON.stringify({ type: 'warning', message: message }));
        location.reload();
    },
    
    infoAndReload: function(message) {
        sessionStorage.setItem('notification', JSON.stringify({ type: 'info', message: message }));
        location.reload();
    },
    
    // Kiểm tra và hiển thị thông báo từ sessionStorage (gọi khi page load)
    checkPendingNotification: function() {
        const notification = sessionStorage.getItem('notification');
        if (notification) {
            sessionStorage.removeItem('notification');
            const data = JSON.parse(notification);
            // Delay một chút để đảm bảo DOM đã sẵn sàng
            setTimeout(() => {
                this.show(data.message, data.type, 3000);
            }, 300);
        }
    },
    
    // Lấy icon theo loại
    getIcon: function(type) {
        const icons = {
            'success': 'bi bi-check-circle-fill',
            'error': 'bi bi-x-circle-fill',
            'warning': 'bi bi-exclamation-triangle-fill',
            'info': 'bi bi-info-circle-fill'
        };
        return icons[type] || icons['info'];
    },
    
    // Lấy background class theo loại
    getBgClass: function(type) {
        const classes = {
            'success': 'bg-success',
            'error': 'bg-danger',
            'warning': 'bg-warning',
            'info': 'bg-info'
        };
        return classes[type] || classes['info'];
    },
    
    // Lấy màu icon
    getIconColor: function(type) {
        const colors = {
            'success': 'text-success',
            'error': 'text-danger',
            'warning': 'text-warning',
            'info': 'text-info'
        };
        return colors[type] || colors['info'];
    }
};

// Export để sử dụng global
window.Notification = Notification;

// Tự động kiểm tra thông báo pending khi trang load
document.addEventListener('DOMContentLoaded', function() {
    Notification.checkPendingNotification();
});

