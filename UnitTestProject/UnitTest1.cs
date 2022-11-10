using ApiLayerVet.Controllers;
using BussinessLayerVet;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Put_Doctor_Valid()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Doctor d = new Doctor();
            IHttpActionResult actionResult = Controller.PutDoctor(d, 4);
            //Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
        [TestMethod]
        public void Put_Doctor_async_Valid()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Doctor d = new Doctor();
            Task<IHttpActionResult> actionResult = Controller.PutDoctorAsync(d, 4);
            Assert.IsNotNull(actionResult);
        }


        [TestMethod]
        public void Post_Appointment_Invalid()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Doctor d = new Doctor();
            DoctorAppointment da = new DoctorAppointment();
            da.appointmentIdByAppointmentModule = 15;
            IHttpActionResult actionResult = Controller.PostAppointment(d.doctorId, da);
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
        [TestMethod]
        public void Post_Appointment_Async_Invalid()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Doctor d = new Doctor();
            DoctorAppointment da = new DoctorAppointment();
            da.appointmentIdByAppointmentModule = 16;
            Task<IHttpActionResult> actionResult = Controller.PostAppointmentAsync(d.doctorId, da);
            Assert.IsNotNull(actionResult);
        }
        //[TestMethod]
        //public void Post_Appointment_Valid()
        //{
        //    var MockRepo = new Mock<IDoctorDataProcessor>();
        //    var Controller = new DoctorsController(MockRepo.Object);
        //    //Doctor d = new Doctor();
        //    DoctorAppointment da = new DoctorAppointment();
        //    da.appointmentIdByAppointmentModule = 15;
        //    IHttpActionResult actionResult = Controller.PostAppointment(1, da);
        //    Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        //}
        //[TestMethod]
        //public void Post_Appointment_Async_Valid()
        //{
        //    var MockRepo = new Mock<IDoctorDataProcessor>();
        //    var Controller = new DoctorsController(MockRepo.Object);
        //    //Doctor d = new Doctor();
        //    DoctorAppointment da = new DoctorAppointment();
        //    da.appointmentIdByAppointmentModule = 16;
        //    Task<IHttpActionResult> actionResult = Controller.PostAppointmentAsync(2, da);
        //    Assert.IsNotNull(actionResult);
        //}
    }
}
