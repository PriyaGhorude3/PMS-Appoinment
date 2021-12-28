using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository_Appoinment.Dtos;
using Repository_Appoinment.Interfaces;

namespace Repository_Appoinment.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly UnitOfWork.UnitOfWork _unitOfWork;

        #region Public Constructor

        public AppointmentRepository()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
        }

        #endregion



        public async Task<int> AddAppointment(PatientAppoinment appoinment)
        {
            _unitOfWork.PatientAppointmentRepository.Insert(appoinment);
            return await _unitOfWork.Save();
        }

        public async Task<int> EditAppointment(PatientAppoinment appoinment)
        {
             _unitOfWork.PatientAppointmentRepository.Update(appoinment);
            return await _unitOfWork.Save();
        }

        public async Task<IEnumerable<PatientAppoinment>> GetAll()
        {
            var patientAppointments = await _unitOfWork.PatientAppointmentRepository.GetAll();
            if (patientAppointments != null)
            {
                return patientAppointments;
            }
            return null;
        }

        public async  Task<PatientAppoinment> GetAppointmentById(int id)
        {
            var patient = await _unitOfWork.PatientAppointmentRepository.GetByID(id);
            if (patient != null)
            {
                return patient;
            }
            return null;
        }

        public async Task<bool> RemoveAppointment(int appointmentId)
        {
            bool result = false;
            if (appointmentId > 0)
            {
                
                    var patient = await _unitOfWork.PatientAppointmentRepository.GetByID(appointmentId);
                    if (patient != null)
                    {
                        _unitOfWork.PatientAppointmentRepository.Delete(patient);
                        await _unitOfWork.Save();
                        result = true;

                    }
               
            }
            return result;
        }
    }
}
