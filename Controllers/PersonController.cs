using Microsoft.AspNetCore.Mvc;
using UserData.DAOs;
using UserData.Models;
using UserData.Services;

namespace UserData.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController(IUserDAO _userRepository) : ControllerBase {
        [HttpGet(Name = "GetUsers")]
        public ActionResult<List<Person>> GetUsers() {
            var users = _userRepository.ReadData();
            if(users.Count == 0) {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<Person> GetUserById(int id) {
            var user = _userRepository.ReadData(id);
            if(user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<IActionResult> AddUser([FromForm] Person person, IFormFile image) {
            if(image != null) {
                string filePath = await ImageService.SaveImage(image);
                person.ImageFilePath = filePath;
            }

            _userRepository.AppendData(person);
            return CreatedAtRoute("GetUserById", new { id = person.Id }, person);
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id, [FromForm] Person person, IFormFile image) {
            var user = _userRepository.ReadData(id);
            if(user == null) {
                return NotFound();
            }

            ImageService.DeleteImage(user.ImageFilePath);

            if(image != null) {
                string filePath = await ImageService.SaveImage(image);
                person.ImageFilePath = filePath;
            }

            _userRepository.UpdateData(id, person);
            return CreatedAtRoute("GetUserById", new { id }, person);
        }
    }
}
