﻿using BussinessLayerVet;
using DTOs;
using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace ApiLayerVet.Controllers
{
    public class DoctorsController : ApiController
    {
        
        IDoctorDataProcessor dataProcessor = null;
        public DoctorsController(IDoctorDataProcessor dataProcessor)
        {
            this.dataProcessor = dataProcessor;
        }


        [HttpGet]
        [Route("api/doctor/{doctorId}/feedback/{appointmentId}")]
        public IHttpActionResult GET_FEEDBACK(int doctorId,int appointmentId)
        {

            try
            {
                Feedback feedback = dataProcessor.getFeedbacks(doctorId, appointmentId);
                return Ok(feedback);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet]
        [Route("api/doctor/{doctorId}/feedback/async/{appointmentId}")]
        public async Task<IHttpActionResult> GET_FEEDBACK_ASYNC(int doctorId,int appointmentId)
        {
            try
            {
                Feedback feedback = await dataProcessor.getFeedbacksAsync(doctorId, appointmentId);
                return Ok(feedback);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPost]
        [Route("api/doctor/feedback/{doctorId}")]
        public IHttpActionResult POST_FEEDBACK([FromUri()] int doctorId, [FromBody()] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool done = dataProcessor.postFeedback(doctorId, feedback);
                    if (done == false)
                    {
                        return BadRequest("doctor ID not present");
                    }
                    else
                    {
                        return Created($"api/Doctor/Feedback/{doctorId}", feedback);
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
            else
            {
                return BadRequest("model state is not valid");
            }
        }
        [HttpPost]
        [Route("api/doctor/feedback/async/{doctorId}")]
        public async Task<IHttpActionResult> POST_FEEDBACK_ASYNC([FromUri()] int doctorId, [FromBody()] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool done = await dataProcessor.postFeedbackAsync(doctorId, feedback);
                    if (done == false)
                    {
                        return BadRequest("doctor ID not present");
                    }
                    else
                    {
                        return Created($"api/Doctor/Feedback/{doctorId}", feedback);
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("model state is not valid");
            }
        }
        [HttpPost]
        [Route("api/Doctors/AssignAppointmentToDoctor/{doctorId}")]
        public IHttpActionResult Post(int doctorId, DoctorAppointment appointmentId)
        {
            bool response = dataProcessor.AddAppointment(doctorId, appointmentId);
            if (response)
                return Ok(); //200
            else
                return BadRequest("Doctor Id not available");
        }

        [HttpPost]
        [Route("api/Doctors/AssignAppointmentToDoctor/async/{doctorId}")]
        public async Task<IHttpActionResult> PostAppointment(int doctorId, DoctorAppointment appointmentId)
        {
            var response = await dataProcessor.AddAppointmentAsync(doctorId, appointmentId);
            if (response == true)
                return Ok(); //200
            else
                return BadRequest("Doctor Id not available");
        }
        [HttpGet]
        [Route("api/doctors")]
        [EnableQuery]
        public IQueryable<Doctor> GetDoctors()
        {
            return dataProcessor.GetDoctors().AsQueryable();
        }

        [HttpGet]
        [Route("api/doctors/async")]
        [EnableQuery]
        public async Task<IQueryable<Doctor>> GetDoctorsAsync()
        {
            var data = await dataProcessor.GetDoctorsAsync();

            return data.AsQueryable();
        }
        [Route("api/doctor")]
        public IHttpActionResult PutDoctor(PutDoctorDto d)
        {
            if (!dataProcessor.editDoctor(d))
                return BadRequest("Doctor ID Invalid");
            return Ok();
        }
        [Route("api/doctor/async/{id}")]
        public async Task<IHttpActionResult> PutDoctorAsync(Doctor d, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            bool x = await dataProcessor.editDoctorAsync(d, id);
            if (!x)
                return BadRequest("Doctor Id Invalid");
            else
                return Ok();
        }
        [Route("api/doctors")]
        [HttpPost]
        public IHttpActionResult Post(DoctorDto doctorDto)
        {
            try
            {
                Doctor doctor = dataProcessor.AddDoctor(doctorDto);
                return Created($"api/doctors/{doctor.doctorId}", doctor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("api/doctors/async")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAsync(DoctorDto doctorDto)
        {
            try
            {
                Doctor doctor = await dataProcessor.AddDoctorAsync(doctorDto);
                return Created($"api/doctors/async/{doctor.doctorId}", doctor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("api/doctorImage")]
        [HttpPut]
        public IHttpActionResult PutDoctorImage(ImageDto d)
        {
            dataProcessor.UpdatePicture(d);
            return Ok();
        }
    }
}
