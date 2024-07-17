console.log(services);

document.addEventListener('DOMContentLoaded', function () {
    var createServiceBtn = document.getElementById('createServiceBtn');
    var createServiceModal = document.getElementById('createServiceModal');
    var updateServiceModal = document.getElementById('updateServiceModal');
    var closeButtons = document.querySelectorAll('.close');

    // Open create service modal
    createServiceBtn.addEventListener('click', function () {
        createServiceModal.style.display = 'block';
    });

    // Open update service modal
    window.openUpdateModal = function (serviceId) {
        var selectedService = services.find(s => s.serviceId == serviceId);

        if (selectedService) {
            document.getElementById('UpdateServiceId').value = selectedService.serviceId;
            document.getElementById('UpdateServiceName').value = selectedService.serviceName;
            document.getElementById('UpdateServicePrice').value = selectedService.price;
            document.getElementById('UpdateServiceDescription').value = selectedService.serviceDescription;
            document.getElementById('UpdateActiveStatus').value = selectedService.activeStatus;

            updateServiceModal.style.display = 'block';
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
