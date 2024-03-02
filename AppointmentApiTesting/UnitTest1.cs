using Microsoft.AspNetCore.Mvc;
using AppointmentApi.Models;
using AppointmentApi.Controllers;

namespace AppointmentApi.Tests
{
    [TestFixture]
    public class ApiControllerTests
    {
        private ApiController _controller;
        [SetUp]
        public void Setup()
        {
            _controller = new ApiController();
        }
        [Test]
        public async Task Get_ReturnsListOfModels()
        {
            var result = await _controller.Get();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Model>>(result);
        }
        [Test]
        public async Task Post_ReturnsOkResult()
        {
            var model = new Model { ApponintmentNo = 2114, DoctorName = "Ram", Department = "Dentist", AppointmentDate = "06-04-2024", AppointmentTime = "11.00 AM", PatientName = "Prasath"};
            var result = await _controller.Post(model);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}