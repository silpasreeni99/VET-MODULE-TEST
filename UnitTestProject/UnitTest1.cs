using ApiLayerVet.Controllers;
using BussinessLayerVet;
using DalLayerVet;
using DTOs;
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
        public void Put_Doctor_With_Empty_Doctor_Object_Returns_BadRequest()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Doctor d = new Doctor();
            IHttpActionResult actionResult = Controller.PutDoctor(d, 4);
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
        [TestMethod]
        public void Put_Doctor_Async_With_Empty_Doctor_Object_Returns_TaskOfIHttpActionResult()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Doctor d = new Doctor();
            Task<IHttpActionResult> actionResult = Controller.PutDoctorAsync(d, 4);
            Assert.IsInstanceOfType(actionResult, typeof(Task<IHttpActionResult>));
        }


        [TestMethod]
        public void Post_Doctor_With_Empty_DoctorDto_Object_Returns_BadRequest()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            DoctorDto d = new DoctorDto();
            IHttpActionResult actionResult = Controller.Post(d);
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
        [TestMethod]
        public void Post_Doctor_Async_With_Empty_DoctorDto_Object_Returns_BadRequest()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            DoctorDto d = new DoctorDto();
            Task<IHttpActionResult> actionResult = Controller.PostAsync(d);
            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void Post_Doctor_With_DoctorDto_Object_Returns_IHttpActionResult()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            DoctorDto dto = new DoctorDto { name = "abc", imgUrl = "http://abc.jpg", clinicAddress = "address", email = "abc@gmail.com", speciality = "heart", mobileNo = "66789", npiNo = 567};
            Doctor d = new Doctor { name = "abc", imgUrl = "http://abc.jpg", clinicAddress = "address", email = "abc@gmail.com", speciality = "heart", mobileNo = "66789", npiNo = 567};
            MockRepo.Setup(p => p.AddDoctor(dto)).Returns(d);
            IHttpActionResult actionResult = Controller.Post(dto);
            Assert.IsInstanceOfType(actionResult, typeof(IHttpActionResult));
        }

        [TestMethod]
        public void Post_Doctor_Async_With_DoctorDto_Object_Returns_TaskOfIHttpActionResult()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            DoctorDto dto = new DoctorDto { name = "abc", imgUrl = "http://abc.jpg", clinicAddress = "address", email = "abc@gmail.com", speciality = "heart", mobileNo = "66789", npiNo = 567 };
            Doctor d = new Doctor { name = "abc", imgUrl = "http://abc.jpg", clinicAddress = "address", email = "abc@gmail.com", speciality = "heart", mobileNo = "66789", npiNo = 567 };
            MockRepo.Setup(p => p.AddDoctorAsync(dto)).ReturnsAsync(d);
            Task<IHttpActionResult> actionResult = Controller.PostAsync(dto);
            Assert.IsInstanceOfType(actionResult, typeof(Task<IHttpActionResult>));
        }

    }
}




