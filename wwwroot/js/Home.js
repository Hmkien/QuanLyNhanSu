document.addEventListener('DOMContentLoaded', function () {
    const sidebar = document.querySelector('.sidebar');
    const content = document.querySelector('.content');
    const toggleBtn = document.querySelector('.bi-list');

    toggleBtn.addEventListener('click', function () {
        sidebar.classList.toggle('collapsed');
        content.classList.toggle('collapsed');
    });
    document.addEventListener('DOMContentLoaded', function () {
    const sidebar = document.querySelector('.sidebar');
    const content = document.querySelector('.content');
    const toggleBtn = document.querySelector('.bi-list');
    const searchInput = document.querySelector('.search-input');
    const searchIcon = document.querySelector('.search-icon');

    toggleBtn.addEventListener('click', function () {
        sidebar.classList.toggle('collapsed');
        content.classList.toggle('collapsed');
    });

    searchIcon.addEventListener('click', function () {
        const query = searchInput.value.trim();
        if (query) {
            alert('Tìm kiếm: ' + query); 
        }
    });

    searchInput.addEventListener('keypress', function (e) {
        if (e.key === 'Enter') {
            const query = searchInput.value.trim();
            if (query) {
                alert('Tìm kiếm: ' + query); 
            }
        }
    });

 
});
    const sidebarLinks = document.querySelectorAll('.sidebar a, .sidebar .accordion-button');
    sidebarLinks.forEach(link => {
        const text = link.querySelector('span') ? link.querySelector('span').textContent : link.textContent.trim();
        link.setAttribute('data-title', text);
    });
});
var ctx1 = document.getElementById('chart1').getContext('2d');
        new Chart(ctx1, {
            type: 'doughnut',
            data: {
                labels: ['Đang làm việc', 'Nghỉ hưu', 'Nghỉ thai sản', 'Học việc'],
                datasets: [{
                    data: [50, 20, 15, 15],
                    backgroundColor: ['#007bff', '#ffc107', '#dc3545', '#28a745']
                }]
            },
            options: {
                plugins: {
                    legend: {
                        position: 'bottom'
                    }
                }
            }
        });

        // Bar Chart: Số Lượng Nhân Viên Theo Tháng
        var ctx2 = document.getElementById('chart2').getContext('2d');
        new Chart(ctx2, {
            type: 'bar',
            data: {
                labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
                datasets: [{
                    label: 'Nhân sự',
                    data: [80, 40, 30, 50, 90, 60],
                    backgroundColor: '#007bff'
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });

        // Doughnut Chart 2: Tỷ Lệ Nhân Viên
        var ctx3 = document.getElementById('chart3').getContext('2d');
        new Chart(ctx3, {
            type: 'doughnut',
            data: {
                labels: ['Nam', 'Nữ'],
                datasets: [{
                    data: [60, 40],
                    backgroundColor: ['#6f42c1', '#007bff']
                }]
            },
            options: {
                plugins: {
                    legend: {
                        position: 'bottom'
                    }
                }
            }
        });
        var ctx4 = document.getElementById('chart4').getContext('2d');
        new Chart(ctx4, {
            type: 'line',
            data: {
                labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                datasets: [{
                    label: 'Tuyển dụng',
                    data: [10, 20, 15, 30, 25, 40, 35, 50, 45, 60, 55, 70],
                    borderColor: '#dc3545',
                    backgroundColor: 'rgba(220, 53, 69, 0.2)',
                    fill: true
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });