using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;

namespace PetClinicRepository.Interface
{
    public interface IVaccinationDetailRepository
    {
        public List<VaccinationDetail> GetVaccinationDetailsList();
        public VaccinationDetail GetVaccinationDetailById(int vaccinationDetailId);
        public void UpdateVaccinationDetail(VaccinationDetail vaccinationDetail);
    }
}
