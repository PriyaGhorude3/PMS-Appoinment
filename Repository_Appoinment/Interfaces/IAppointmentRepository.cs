
using System.Collections.Generic;
using Repository_Appoinment.Dtos;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Appoinment.Interfaces
{
   public interface IAppointmentRepository
    {
        Task<IEnumerable<PatientAppoinment>> GetAll();

        Task<PatientAppoinment> GetAppointmentById(int id);
            
        Task<int> AddAppointment(PatientAppoinment appoinment);

        Task<bool> RemoveAppointment(int appointmentId);

        Task<int> EditAppointment(PatientAppoinment appoinment);
    }
}
