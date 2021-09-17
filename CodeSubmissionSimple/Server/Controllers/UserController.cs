using AutoMapper;
using CodeSubmissionSimple.Server.Data;
using CodeSubmissionSimple.Server.IRepositories;
using CodeSubmissionSimple.Server.Models;
using CodeSubmissionSimple.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeSubmissionSimple.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                //Expression<Func<User, bool>> expression = null
                var users = await _unitOfWork.Users.GetAll();
                var results = _mapper.Map<IList<UserDto>>(users);
                return Ok(results);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Route("login/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                //Expression<Func<User, bool>> expression = null
                var user = await _unitOfWork.Users.Get(q => q.Email.Equals(email));
                var results = _mapper.Map<UserDto>(user);
                return Ok(results);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }



        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == id);
                var result = _mapper.Map<UserDto>(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {


                var user = _mapper.Map<User>(userDto);
                await _unitOfWork.Users.Insert(user);
                await _unitOfWork.Save();

                return CreatedAtAction("GetUser", new { id = user.Id }, user);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalUser = await _unitOfWork.Users.Get(q => q.Id == id);

                if (originalUser == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(userDto, originalUser);
                _unitOfWork.Users.Update(originalUser);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == id);

                if (user == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Users.Delete(id);
                await _unitOfWork.Save();

                return NoContent();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
