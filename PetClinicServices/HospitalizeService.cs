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

        public List<Hospitalize> GetListByCageId(int cageId)
        {
            return hospitalizeRepository.GetListByCageId(cageId);
        }

        public List<HospitalizeLog> GetLogListByHospitalizeId(int hospitalizeId)
        {
            return hospitalizeRepository.GetLogListByHospitalizeId(hospitalizeId);
        }

        public void AddHospitalizeLog(HospitalizeLog log)
        {
            hospitalizeRepository.AddHospitalizeLog(log);
        }

        public void UpdateHospitalizeLog(HospitalizeLog log)
        {
            hospitalizeRepository.UpdateHospitalizeLog(log);
        }

        public List<Hospitalize> GetHospitalizeByPetId(int petId)
        {
            return hospitalizeRepository.GetHospitalizeByPetId(petId);
        }
    }
}
