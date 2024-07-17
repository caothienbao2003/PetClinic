document.addEventListener('DOMContentLoaded', function () {
    var createServiceBtn = document.getElementById('createServiceBtn');
    var createServiceModal = document.getElementById('createServiceModal');
    var closeButtons = document.querySelectorAll('.close');

    // Open create service modal
    createServiceBtn.addEventListener('click', function () {
        createServiceModal.style.display = 'block';
    });

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
