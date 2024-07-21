document.addEventListener('DOMContentLoaded', function () {
    var createMedicineBtn = document.getElementById('createMedicineBtn');
    var createMedicineModal = document.getElementById('createMedicineModal');
    var closeButtons = document.querySelectorAll('.close');

    // Open create service modal
    createMedicineBtn.addEventListener('click', function () {
        createMedicineModal.style.display = 'block';
    });

    // Redirect to AdminUpdateService page for updating
    window.openUpdateModal = function (serviceId) {
        var selectedService = services.find(s => s.serviceId == serviceId);
        if (selectedService) {
            window.location.href = `/Admin/AdminManageService/AdminUpdateService/${serviceId}`;
        } else {
            console.error('Service not found for ID:', serviceId);
        }
    };

    // Close modals when clicking on close buttons
    closeButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            var modal = button.closest('.modal');
            if (modal) {
                modal.style.display = 'none';
            }
        });
    });

    // Close modals when clicking outside the modal content
    window.onclick = function (event) {
        if (event.target.classList.contains('modal')) {
            event.target.style.display = 'none';
        }
    };

    // Function to close modal
    window.closeModal = function (modalId) {
        document.getElementById(modalId).style.display = 'none';
    };
});
