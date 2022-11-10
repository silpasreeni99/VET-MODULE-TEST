using AutoMapper;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayerVet
{
    public class AutoMapper
    {
        public static Doctor MapperConfig(DoctorDto doctorDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorDto, Doctor>();
            });
            //Using automapper
            var mapper = new Mapper(config);
            var doctor = mapper.Map<Doctor>(doctorDto);

            return doctor;
        }
    }
}
