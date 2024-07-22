using PetClinicBussinessObject;

namespace PetClinic.Custom_Model
{
    public class ScheduleBlockModel
    {
        public int ShiftId {  get; set; }
        public DateTime Date { get; set; }
        public Schedule? Schedule { get; set; }

    }
}
