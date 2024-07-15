using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicRepository.Interface;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;

namespace PetClinicRepository
{
    public class VaccinationDetailRepository : IVaccinationDetailRepository
    {
        public List<VaccinationDetail> GetVaccinationDetailsList() => VaccinationDetailDAO.Instance.GetVaccinationDetailsList();
        public VaccinationDetail GetVaccinationDetailById(int vaccinationDetailId) => VaccinationDetailDAO.Instance.GetVaccinationDetailsById(vaccinationDetailId);
        public void UpdateVaccinationDetail(VaccinationDetail vaccinationDetail) => VaccinationDetailDAO.Instance.UpdateVaccinationDetails(vaccinationDetail);
    }
}
