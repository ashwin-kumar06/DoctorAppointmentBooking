using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AppointmentApi.Models;


namespace AppointmentApi.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly string _jsonFilePath = "data.json";

        [HttpGet]
        public async Task<List<Model>> Get()
        {
            using (StreamReader file = System.IO.File.OpenText(_jsonFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<Model>)serializer.Deserialize(file, typeof(List<Model>));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Model model)
        {
            var data = await Get() ?? new List<Model>();
            data.Add(model); // Add new data  

            using (StreamWriter file = System.IO.File.CreateText(_jsonFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
            return Ok();
        }
    }
}