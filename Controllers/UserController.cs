using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamJacobGroupTaskManagerAppAPI.Services;
using TeamJacobGroupTaskManagerAppAPI.Models;
using TeamJacobGroupTaskManagerAppAPI.Models.DTO;

namespace TeamJacobGroupTaskManagerAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
          private readonly UserService _data;
            public UserController(UserService dataFromService)
            {
                _data = dataFromService;
                
            }


        // Login

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        // Add a user

        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
          return _data.AddUser(UserToAdd);
        }



        // Update user account

        // [HttpPost]
        // [Route("UpdateUser")]
        // public bool UpdateUser(UserModel userToUpdate)
        // {
        //     return _data.UpdateUser(userToUpdate);
        // }

        // Delete user account
    }
}