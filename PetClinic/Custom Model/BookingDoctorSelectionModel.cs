namespace PetClinic.Custom_Model
{
    public class BookingDoctorSelectionModel
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsSelected { get; set; }
    }
}
