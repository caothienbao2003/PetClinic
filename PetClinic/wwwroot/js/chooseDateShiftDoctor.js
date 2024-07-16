function changeMonth(offset) {
    let currentMonthYear = document.getElementById("monthYearDisplay").innerText;
    let date = new Date(currentMonthYear + " 1");
    date.setMonth(date.getMonth() + offset);

    let year = date.getFullYear();
    let month = date.getMonth() + 1;

    $.ajax({
        url: '?handler=ChooseDateShiftDoctor',
        type: 'GET',
        data: {
            year: year,
            month: month,
            selectedPetId: selectedPetId
        },
        success: function (data) {
            $('#calendarBody').html(data);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
}

function selectDate(date) {
    document.getElementById("CurrentDateOnCalendar").value = date;
    document.getElementById("SelectedDate").value = date;
    document.getElementById("dateForm").submit();
}

function selectSlot(element, shiftId) {
    document.querySelectorAll(".slot").forEach(slot => slot.classList.remove("selected"));
    element.classList.add("selected");
    document.getElementById("SelectedShift").value = shiftId;
}

function selectDoctor(element, doctorId) {
    document.querySelectorAll(".doctor").forEach(doctor => doctor.classList.remove("selected"));
    element.classList.add("selected");
    document.getElementById("SelectedDoctor").value = doctorId;
}
