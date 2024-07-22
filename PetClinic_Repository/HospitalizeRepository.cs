using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository
{
    public class HospitalizeRepository : IHospitalizeRepository
    {
        public List<Hospitalize> GetAllHospitalize() => HospitalizeDAO.Instance.GetAllHospitalize();

        public Hospitalize? GetHospitalizeById(int id) => HospitalizeDAO.Instance.GetHospitalizeById(id);

        public HospitalizeLog? GetLogById(int id) => HospitalizeDAO.Instance.GetLogById(id);

        public void AddHospitalize(Hospitalize hospitalize) => HospitalizeDAO.Instance.AddHospitalize(hospitalize);

        public void UpdateHospitalize(Hospitalize hospitalize) => HospitalizeDAO.Instance.UpdateHospitalize(hospitalize);

        public List<Hospitalize> GetListByCageId(int cageId) => HospitalizeDAO.Instance.GetListByCageId(cageId);

        public List<HospitalizeLog> GetLogListByHospitalizeId(int hospitalizeId) => HospitalizeDAO.Instance.GetLogListByHospitalizeId(hospitalizeId);

        public void AddHospitalizeLog(HospitalizeLog log) => HospitalizeDAO.Instance.AddHospitalizeLog(log);

        public void UpdateHospitalizeLog(HospitalizeLog log) => HospitalizeDAO.Instance.UpdateHospitalizeLog(log);

        public List<Hospitalize> GetHospitalizeByPetId(int petId) => HospitalizeDAO.Instance.GetHospitalizeByPetId(petId);
    }
}
