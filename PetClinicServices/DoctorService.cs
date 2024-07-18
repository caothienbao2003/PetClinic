using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository doctorRepository;
        public DoctorService()
        {
            doctorRepository = new DoctorRepository();
        }

        public List<User> GetAllDoctors() => doctorRepository.GetAllDoctors();

        public User GetDoctorById(int doctorId) => doctorRepository.GetDoctorById(doctorId);
    }
}
