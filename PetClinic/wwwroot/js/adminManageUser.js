document.addEventListener('DOMContentLoaded', function () {
    const addStaffBtn = document.getElementById('addStaffBtn');
    const createUserModal = document.getElementById('createUserModal');
    const closeModalBtn = document.querySelector('.close');

    addStaffBtn.addEventListener('click', function () {
        createUserModal.style.display = 'block';
    });

    closeModalBtn.addEventListener('click', function () {
        createUserModal.style.display = 'none';
    });

    window.addEventListener('click', function (event) {
        if (event.target == createUserModal) {
            createUserModal.style.display = 'none';
        }
    });
});
