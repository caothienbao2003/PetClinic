using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetClinicBussinessObject;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IVaccinationDetailService
    {
        public List<VaccinationDetail> GetVaccinationDetailsList();

        public VaccinationDetail GetVaccinationDetailById(int vaccinationDetailId);

        public void UpdateVaccinationDetail(VaccinationDetail vaccinationDetail);
    }
}
