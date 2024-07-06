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
    public class HospitalizeService : IHospitalizeService
    {
        private readonly IHospitalizeRepository hospitalizeRepository;

        public HospitalizeService()
        {
            if(hospitalizeRepository == null)
            {
                hospitalizeRepository = new HospitalizeRepository();
            }
        }

        public List<Hospitalize> GetAllHospitalize()
        {
            return hospitalizeRepository.GetAllHospitalize();
        }

        public Hospitalize? GetHospitalizeById(int id)
        {
            return hospitalizeRepository.GetHospitalizeById(id);
        }

        public void AddHospitalize(Hospitalize hospitalize)
        {
            hospitalizeRepository.AddHospitalize(hospitalize);
        }


        public void UpdateHospitalize(Hospitalize hospitalize)
        {
            hospitalizeRepository.UpdateHospitalize(hospitalize);
        }
    }
}
