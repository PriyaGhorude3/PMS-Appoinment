using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model_Appoinment;
using Repository_Appoinment.Interfaces;
using AutoMapper;
using Repository_Appoinment.Dtos;

namespace Business_Appoinment
{
    public class AppointmentBusiness : IAppointmentBusiness
    {

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentBusiness(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }


        public async Task<int> AddAppointment(PatientAppointmentModel appoinment)
        {
            var appointmentDto = _mapper.Map<PatientAppoinment>(appoinment);
            return await _appointmentRepository.AddAppointment(appointmentDto);
        }

        public async Task<int> EditAppointment(PatientAppointmentModel appoinment)
        {
            var appointmentDto = _mapper.Map<PatientAppoinment>(appoinment);
            return await _appointmentRepository.EditAppointment(appointmentDto);
        }

        public async Task<IEnumerable<PatientAppointmentModel>> GetAll()
        {
            var details = await _appointmentRepository.GetAll();
            return _mapper.Map<IEnumerable<PatientAppointmentModel>>(details);
        }

        public async Task<PatientAppointmentModel> GetAppointmentById(int id)
        {

            var appointmentDetails = await _appointmentRepository.GetAppointmentById(id);
            return _mapper.Map<PatientAppointmentModel>(appointmentDetails);
        }

        public async Task<bool> RemoveAppointment(int appointmentId)
        {
            var removePatient = await _appointmentRepository.RemoveAppointment(appointmentId);
            return removePatient;
        }
    }
}
