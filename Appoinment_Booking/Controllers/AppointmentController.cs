using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Model_Appoinment;
using System.Threading.Tasks;
using Business_Appoinment;
namespace Appoinment_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentBusiness _appointmentBusiness;
        public AppointmentController(IAppointmentBusiness appointment)
        {
            _appointmentBusiness = appointment;
        }

        [HttpGet]
        [Route("GetAllAppointments")]
        public async Task<ActionResult<IEnumerable<PatientAppointmentModel>>> GetAllAppointments()
        {
            try
            {
                var patients = await _appointmentBusiness.GetAll();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("AddAppointment")]
        public async Task<ActionResult<bool>> AddAppointment(PatientAppointmentModel patientAppointmentModel)
        {
            try
            {
                var result = await _appointmentBusiness.AddAppointment(patientAppointmentModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetAppointmentById")]
        public async Task<ActionResult<PatientAppointmentModel>> GetAppointmentById(int id)
        {
            try
            {
                var result = await _appointmentBusiness.GetAppointmentById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPatch]
        [Route("EditAppointment")]
        public async Task<ActionResult<int>> EditAppointment(PatientAppointmentModel patientAppointmentModel)
        {
            try
            {
                var result = await _appointmentBusiness.EditAppointment(patientAppointmentModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("RemoveAppointment")]
        public async Task<ActionResult<bool>> RemoveAppointment(int appointmentId)
        {
            try
            {
                var result = await _appointmentBusiness.RemoveAppointment(appointmentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



    }
}
