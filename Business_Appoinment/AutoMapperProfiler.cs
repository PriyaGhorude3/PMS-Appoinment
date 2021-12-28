using System;
using System.Collections.Generic;
using System.Text;
using Model_Appoinment;
using Repository_Appoinment.Dtos;
using AutoMapper;
namespace Business_Appoinment
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<PatientAppointmentModel, PatientAppoinment>().ReverseMap();
            
        }
    }
}
