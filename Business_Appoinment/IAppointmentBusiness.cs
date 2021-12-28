using System;
using System.Collections.Generic;
using System.Text;
using Model_Appoinment;
using System.Threading.Tasks;

namespace Business_Appoinment
{
    public interface IAppointmentBusiness
    {
        Task<IEnumerable<PatientAppointmentModel>> GetAll();

        Task<PatientAppointmentModel> GetAppointmentById(int id);
            
        Task<int> AddAppointment(PatientAppointmentModel appoinment);

        Task<bool> RemoveAppointment(int appointmentId);

        Task<int> EditAppointment(PatientAppointmentModel appoinment);
    }
}
