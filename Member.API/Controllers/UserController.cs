using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Member.Application_.Services.Interface;
using Member.Domain.DTOs;
using Member.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Member.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserServices userService;
        public UserController(IUserServices UserService)
        {
            this.userService = UserService;
        }
        // GET: api/values
        [HttpGet]
        [HttpGet]
        public ActionResult<List<ProductResponse>> GetUsers()
        {
            return Ok(this.userService.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            try
            {
                var product = this.userService.GetUserById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create(CreateUserRequest request)
        {
            var product = this.userService.CreateUser(request);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateUserRequest request)
        {
            try
            {
                var product = this.userService.UpdateUser(id, request);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.userService.DeleteUserById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}

