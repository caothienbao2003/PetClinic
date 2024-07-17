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
